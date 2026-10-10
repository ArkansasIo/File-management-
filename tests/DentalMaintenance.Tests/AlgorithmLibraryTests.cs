using DentalMaintenance.Core.Services;
using Xunit;
namespace DentalMaintenance.Tests;
public sealed class AlgorithmLibraryTests
{
 [Fact] public void BubbleSort_SortsAscending(){var values=new List<int>{5,1,4,2,8};AlgorithmLibrary.BubbleSort(values);Assert.Equal(new[]{1,2,4,5,8},values);}
 [Fact] public void BinarySearch_FindsValue(){Assert.Equal(2,AlgorithmLibrary.BinarySearch(new[]{1,3,5,7},5));}
 [Fact] public void Gcd_ComputesCorrectly(){Assert.Equal(6,AlgorithmLibrary.GreatestCommonDivisor(54,24));}
}