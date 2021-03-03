using System;
using System.Linq;
using DataOrdering.Domain.Common;
using System.Collections.Generic;
using System.Text;

namespace DataOrdering.Domain.DataAggregates
{
    class DataLine<data> where data: IComparable, IConvertible
    {
        data[] DataUnits;
        public DataLine()
        {
            DataUnits = new data[0];
        }
        public DataLine(string data)
        {
            string[] splittedData = data.Split(' ');
            DataUnits = Array.ConvertAll(splittedData, unit => (data)Convert.ChangeType(unit,typeof(data)));
        }
        public string Get_Sorted_Data()
        { 
            return string.Join(" ", Array.ConvertAll(Sorting.BubbleSort(DataUnits),unit => unit.ToString()));
        }
    }
}
