using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DataOrdering.Domain.DataAggregates;

namespace DataOrdering.App.Tests
{
    [TestClass()]
    public class OrderingDataServiceTests
    {
        [TestMethod()]
        public void Save_And_Load_Data()
        {
            string path = "SavedData.txt";
            string[] data = new string[] { "A", "D", "B" };
            OrderingDataService.Save_Data_To_Text(data, path);
            string loaded = OrderingDataService.Load_Last_Ordered_Data(path);
            Assert.IsTrue(loaded == string.Join(" ", data));
        }
        [TestMethod()]
        public void Get_Sorted_Data()
        {
            string path = "SortedSaveTest.txt";
            List<string> stringArray = new List<string>() { "A", "F", "C" };
            List<int> intArray = new List<int>() { 2, -1, 0 };
            List<double> doubleArray = new List<double>() { 44.1, 44.01, 1.1111 };

            string[] sortedString = OrderingDataService.Sort_Data(string.Join(' ', stringArray), DataTypes.String.ToString(), path);
            stringArray.Sort();

            string[] sortedInt = OrderingDataService.Sort_Data(string.Join(' ', intArray), DataTypes.Int.ToString(), path);
            intArray.Sort();

            string[] sortedDouble = OrderingDataService.Sort_Data(string.Join(' ', doubleArray), DataTypes.Double.ToString(), path);
            doubleArray.Sort();

            Assert.IsTrue(string.Join(' ', stringArray) == string.Join(' ', sortedString)
                            && string.Join(' ', intArray) == string.Join(' ', sortedInt)
                            && string.Join(' ', doubleArray) == string.Join(' ', sortedDouble));

        }
    }
}