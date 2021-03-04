using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataOrdering.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataOrdering.Infrastructure.Tests
{
    [TestClass()]
    public class TextFileTests
    {
        [TestMethod()]
        public void Constructor_Empty()
        {
            TextFile tempFile = new TextFile();
            Assert.IsTrue(tempFile.Path == string.Empty);
        }

        [TestMethod()]
        public void Constructor_With_Path()
        {
            string path = "Path\\";
            TextFile tempFile = new TextFile(path);
            Assert.IsTrue(tempFile.Path == path);
        }
        [TestMethod()]
        public void Create_File()
        {
            string path = "TestData.txt";
            TextFile tempFile = new TextFile(path);
            tempFile.Save_Data("");
            Assert.IsTrue(File.Exists(path));
        }
        [TestMethod()]
        public void Write_File()
        {
            string path = "TestDataWrite.txt";
            string data = "Test";
            TextFile tempFile = new TextFile(path);
            tempFile.Save_Data(data);
            Assert.IsTrue(File.Exists(path) && File.ReadAllText(path) == data);
        }
        [TestMethod()]
        public void Load_File()
        {
            string path = "TestDataLoad.txt";
            string data = "Test";
            TextFile tempFile = new TextFile(path);
            tempFile.Save_Data(data);
            Assert.IsTrue(File.Exists(path) && tempFile.Load_Data() == data);
        }
    }
}