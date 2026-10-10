namespace DentalMaintenance.Core.Services;
public sealed record AlgorithmInfo(string Code,string Name,string Category,string Complexity,string Status);
public static class AlgorithmLibrary
{
 public static IReadOnlyList<AlgorithmInfo> Catalog { get; } = new[]
 {
  new AlgorithmInfo("SORT-BUBBLE","Bubble sort","Sorting","O(n²)","Implemented"),
  new AlgorithmInfo("SORT-QUICK","Quicksort","Sorting","Average O(n log n)","Catalog"),
  new AlgorithmInfo("SORT-MERGE","Merge sort","Sorting","O(n log n)","Catalog"),
  new AlgorithmInfo("SEARCH-LINEAR","Linear search","Searching","O(n)","Catalog"),
  new AlgorithmInfo("SEARCH-BINARY","Binary search","Searching","O(log n)","Implemented"),
  new AlgorithmInfo("GRAPH-BFS","Breadth-first search","Graph","O(V+E)","Catalog"),
  new AlgorithmInfo("GRAPH-DFS","Depth-first search","Graph","O(V+E)","Catalog"),
  new AlgorithmInfo("MATH-GCD","Euclidean GCD","Math","O(log min(a,b))","Implemented")
 };
 public static void BubbleSort<T>(IList<T> values,IComparer<T>? comparer=null)
 {
  comparer??=Comparer<T>.Default;
  for(var end=values.Count-1;end>0;end--){var changed=false;for(var i=0;i<end;i++)if(comparer.Compare(values[i],values[i+1])>0){(values[i],values[i+1])=(values[i+1],values[i]);changed=true;}if(!changed)break;}
 }
 public static int BinarySearch<T>(IReadOnlyList<T> values,T target,IComparer<T>? comparer=null)
 {
  comparer??=Comparer<T>.Default;var low=0;var high=values.Count-1;
  while(low<=high){var mid=low+((high-low)/2);var cmp=comparer.Compare(values[mid],target);if(cmp==0)return mid;if(cmp<0)low=mid+1;else high=mid-1;}return -1;
 }
 public static long GreatestCommonDivisor(long a,long b){a=Math.Abs(a);b=Math.Abs(b);while(b!=0)(a,b)=(b,a%b);return a;}
}