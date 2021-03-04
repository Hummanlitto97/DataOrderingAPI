using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataOrdering.Domain.DataAggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrdering.Domain.DataAggregates.Tests
{
    [TestClass()]
    public class DataLineTests
    {
        [TestMethod()]
        public void Empty_Constructor()
        {
            DataLine<int> dataLine = new DataLine<int>();
            Assert.IsTrue(dataLine.DataUnits.Length == 0);
        }
        [TestMethod()]
        public void Empty_String()
        {
            DataLine<int> dataLine = new DataLine<int>("");
            Assert.IsTrue(dataLine.DataUnits.Length == 0);
        }
        [TestMethod()]
        public void Constructor_Strings()
        {
            bool test = true;
            List<string> testArray = new List<string>{ "Test", "Tiring", "A" };
            DataLine<string> dataLine = new DataLine<string>(string.Join(" ", testArray));
            for(int i = 0;i < dataLine.DataUnits.Length;i++)
            {
                if (testArray.Contains(dataLine.DataUnits[i])) continue;
                test = false;
            }
            Assert.IsTrue(dataLine.DataUnits.Length == testArray.Count && test);
        }
        [TestMethod()]
        public void Constructor_Integers()
        {
            bool test = true;
            List<int> testArray = new List<int> { 77, 49888, 1};
            DataLine<int> dataLine = new DataLine<int>(string.Join(" ", testArray));
            for (int i = 0; i < dataLine.DataUnits.Length; i++)
            {
                if (testArray.Contains(dataLine.DataUnits[i])) continue;
                test = false;
            }
            Assert.IsTrue(dataLine.DataUnits.Length == testArray.Count && test);
        }
        [TestMethod()]
        public void Constructor_Doubles()
        {
            bool test = true;
            List<double> testArray = new List<double> { 77, 77.002, 77.00003, 49888, 1.222 };
            DataLine<double> dataLine = new DataLine<double>(string.Join(" ", testArray));
            for (int i = 0; i < dataLine.DataUnits.Length; i++)
            {
                if (testArray.Contains(dataLine.DataUnits[i])) continue;
                test = false;
            }
            Assert.IsTrue(dataLine.DataUnits.Length == testArray.Count && test);
        }
        [TestMethod()]
        public void Sort_Strings()
        {
            bool test = true;
            List<string> testArray = new List<string> { "Test", "Tiring", "A" };
            DataLine<string> dataLine = new DataLine<string>(string.Join(" ", testArray));
            testArray.Sort();
            string[] sortedArray = dataLine.Get_Sorted_Data();
            for(int i = 0; i < sortedArray.Length;i++)
            {
                if (testArray[i] == sortedArray[i]) continue;
                test = false;
            }
            Assert.IsTrue(test);
        }
        [TestMethod()]
        public void Sort_Integers()
        {
            bool test = true;
            List<int> testArray = new List<int> { 77, 11, -1 };
            DataLine<int> dataLine = new DataLine<int>(string.Join(" ", testArray));
            testArray.Sort();
            string[] sortedArray = dataLine.Get_Sorted_Data();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (testArray[i].ToString() == sortedArray[i]) continue;
                test = false;
            }
            Assert.IsTrue(test);
        }
        [TestMethod()]
        public void Sort_Doubles()
        {
            bool test = true;
            List<double> testArray = new List<double> { 11.1, 11.001, 4.7, 4 };
            DataLine<double> dataLine = new DataLine<double>(string.Join(" ", testArray));
            testArray.Sort();
            string[] sortedArray = dataLine.Get_Sorted_Data();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (testArray[i].ToString() == sortedArray[i]) continue;
                test = false;
            }
            Assert.IsTrue(test);
        }
        [TestMethod()]
        public void Sort_Empty()
        {
            bool test = true;
            List<double> testArray = new List<double> { };
            DataLine<double> dataLine = new DataLine<double>(string.Join(" ", testArray));
            testArray.Sort();
            string[] sortedArray = dataLine.Get_Sorted_Data();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (testArray[i].ToString() == sortedArray[i]) continue;
                test = false;
            }
            Assert.IsTrue(test);
        }

    }
}