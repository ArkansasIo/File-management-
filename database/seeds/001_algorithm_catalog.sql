USE dental_maintenance;
INSERT INTO algorithm_catalog (code,name,category,complexity,implementation_status,description) VALUES
('SORT-BUBBLE','Bubble sort','Sorting','O(n^2)','Implemented','Educational in-memory sort.'),
('SORT-QUICK','Quicksort','Sorting','Average O(n log n)','Catalog','Reference entry; implementation not included.'),
('SORT-MERGE','Merge sort','Sorting','O(n log n)','Catalog','Reference entry; implementation not included.'),
('SEARCH-BINARY','Binary search','Searching','O(log n)','Implemented','Requires sorted input.'),
('GRAPH-BFS','Breadth-first search','Graph','O(V+E)','Catalog','Reference entry.'),
('MATH-GCD','Euclidean GCD','Math','O(log min(a,b))','Implemented','Greatest common divisor.')
ON DUPLICATE KEY UPDATE name=VALUES(name),category=VALUES(category),complexity=VALUES(complexity),implementation_status=VALUES(implementation_status),description=VALUES(description);