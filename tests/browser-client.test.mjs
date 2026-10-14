import test from "node:test";
import assert from "node:assert/strict";
import { readFile } from "node:fs/promises";

const html = await readFile(new URL("../web/index.html", import.meta.url), "utf8");
const js = await readFile(new URL("../web/app.js", import.meta.url), "utf8");
const css = await readFile(new URL("../web/styles.css", import.meta.url), "utf8");

test("browser client includes responsive page structure and accessible status", () => {
  assert.match(html, /<html lang="en">/);
  assert.match(html, /aria-live="polite"/);
  assert.match(html, /id="api-url"/);
  assert.match(html, /id="view-patients"/);
  assert.match(css, /@media\(max-width:700px\)/);
});

test("client connects to health endpoint and calls patient API", () => {
  assert.match(js, /api\("\/health"\)/);
  assert.match(js, /\/api\/v1\/patients/);
  assert.match(js, /AbortController/);
  assert.match(js, /URLSearchParams/);
});

test("client avoids injecting patient response values as HTML", () => {
  assert.match(js, /textContent = \[patient\.givenName, patient\.familyName\]/);
  assert.match(js, /rows\.replaceChildren\(\)/);
  assert.doesNotMatch(js, /innerHTML\s*=/);
});

test("client requires HTTPS for remote APIs", () => {
  assert.match(js, /Use HTTPS for a remote API/);
  assert.match(js, /\["http:", "https:"\]/);
});

test("document view does not claim uploads are implemented", () => {
  assert.match(html, /secure document upload\/download API is not yet implemented/);
});
