(() => {
  "use strict";
  const $ = (id) => document.getElementById(id);
  const state = { apiBase: "", connected: false, patients: [] };
  const knownViews = ["dashboard", "patients", "documents", "tools"];

  function notify(message, error = false) {
    const node = $("notice");
    node.textContent = message;
    node.classList.toggle("error", error);
    node.hidden = false;
  }
  function clearNotice() { $("notice").hidden = true; }
  function setConnection(connected, message) {
    state.connected = connected;
    $("connection-label").textContent = connected ? "API connected" : "API unavailable";
    document.querySelector(".status-dot").classList.toggle("online", connected);
    $("api-status").textContent = connected ? "Connected" : "Not connected";
    if (message) notify(message, !connected);
  }
  function baseUrl() {
    const raw = $("api-url").value.trim();
    if (!raw) throw new Error("Enter the deployed API base URL first.");
    const url = new URL(raw);
    if (!["http:", "https:"].includes(url.protocol)) throw new Error("API URL must use HTTP or HTTPS.");
    if (url.protocol !== "https:" && url.hostname !== "localhost" && url.hostname !== "127.0.0.1") {
      throw new Error("Use HTTPS for a remote API.");
    }
    return url.href.replace(/\/+$/, "");
  }
  async function api(path, options = {}) {
    const controller = new AbortController();
    const timeout = setTimeout(() => controller.abort(), 10000);
    try {
      const response = await fetch(state.apiBase + path, {
        ...options, signal: controller.signal,
        headers: { Accept: "application/json", ...(options.headers || {}) }
      });
      if (!response.ok) {
        const body = await response.text();
        throw new Error(`API returned ${response.status}${body ? ": " + body.slice(0, 180) : ""}`);
      }
      return response.status === 204 ? null : response.json();
    } catch (error) {
      if (error.name === "AbortError") throw new Error("API request timed out after 10 seconds.");
      if (error instanceof TypeError) throw new Error("Could not reach the API. Check its URL, HTTPS certificate, availability and CORS allowlist.");
      throw error;
    } finally { clearTimeout(timeout); }
  }
  async function connect() {
    clearNotice();
    try {
      state.apiBase = baseUrl();
      localStorage.setItem("caredesk-api-url", state.apiBase);
      await api("/health");
      setConnection(true, "Connected to the API health endpoint.");
      await loadPatients("");
    } catch (error) {
      setConnection(false, error.message || "Connection failed.");
    }
  }
  function showView(name) {
    if (!knownViews.includes(name)) return;
    knownViews.forEach(view => { $("view-" + view).hidden = view !== name; });
    document.querySelectorAll("[data-view]").forEach(button => button.classList.toggle("active", button.dataset.view === name));
    const titles = { dashboard: "Overview", patients: "Patient directory", documents: "Documents", tools: "Clinical tools" };
    $("page-title").textContent = titles[name];
    $("breadcrumb").textContent = titles[name].toUpperCase();
    if (location.hash !== "#" + name) history.replaceState(null, "", "#" + name);
  }
  function safeText(value) { return value == null ? "" : String(value); }
  function renderPatients(patients) {
    const rows = $("patient-rows");
    rows.replaceChildren();
    if (!patients.length) {
      const tr = document.createElement("tr"), td = document.createElement("td");
      td.colSpan = 3; td.className = "empty-cell"; td.textContent = "No active records found.";
      tr.append(td); rows.append(tr);
    } else {
      patients.forEach(patient => {
        const tr = document.createElement("tr");
        const name = document.createElement("td");
        name.textContent = [patient.givenName, patient.familyName].filter(Boolean).join(" ") || "Unnamed record";
        const mrn = document.createElement("td"); mrn.textContent = safeText(patient.medicalRecordNumber) || "—";
        const status = document.createElement("td"); status.textContent = patient.isActive === false ? "Inactive" : "Active";
        tr.append(name, mrn, status); rows.append(tr);
      });
    }
    $("patient-count").textContent = String(patients.length);
    $("patient-summary").textContent = `Showing ${patients.length} record(s), maximum 100 per request.`;
  }
  async function loadPatients(query) {
    if (!state.apiBase) { notify("Connect to an API before searching patient records.", true); return; }
    const rows = $("patient-rows");
    rows.replaceChildren();
    const tr = document.createElement("tr"), td = document.createElement("td");
    td.colSpan = 3; td.className = "empty-cell"; td.textContent = "Loading records…"; tr.append(td); rows.append(tr);
    try {
      const params = new URLSearchParams();
      if (query.trim()) params.set("q", query.trim().slice(0, 100));
      const data = await api("/api/v1/patients" + (params.size ? "?" + params.toString() : ""));
      state.patients = Array.isArray(data) ? data : [];
      renderPatients(state.patients);
      clearNotice();
    } catch (error) {
      state.patients = [];
      renderPatients([]);
      $("patient-summary").textContent = "Request failed.";
      notify(error.message, true);
    }
  }
  async function loadTools() {
    if (!state.apiBase) { notify("Connect to an API before loading tools.", true); return; }
    const output = $("tools-output");
    output.textContent = "Loading…";
    try {
      const data = await api("/api/v1/algorithms");
      output.replaceChildren();
      const items = Array.isArray(data) ? data : (data.items || []);
      if (!items.length) output.textContent = "No tool entries were returned by the API.";
      items.forEach(item => {
        const row = document.createElement("div"); row.className = "tool-item";
        const title = document.createElement("strong"); title.textContent = safeText(item.name || item.id || "Unnamed tool");
        const description = document.createElement("small"); description.textContent = safeText(item.description || item.status || "No description provided.");
        row.append(title, description); output.append(row);
      });
      clearNotice();
    } catch (error) { output.textContent = "Could not load tools."; notify(error.message, true); }
  }
  document.querySelectorAll("[data-view]").forEach(button => button.addEventListener("click", () => showView(button.dataset.view)));
  $("save-api").addEventListener("click", connect);
  $("check-api").addEventListener("click", connect);
  $("patient-search").addEventListener("submit", event => { event.preventDefault(); loadPatients($("patient-query").value); });
  $("clear-search").addEventListener("click", () => { $("patient-query").value = ""; loadPatients(""); });
  $("load-tools").addEventListener("click", loadTools);
  try {
    const saved = localStorage.getItem("caredesk-api-url");
    if (saved) $("api-url").value = saved;
  } catch { /* Storage can be unavailable in private browsing; manual URL entry still works. */ }
  showView(knownViews.includes(location.hash.slice(1)) ? location.hash.slice(1) : "dashboard");
})();