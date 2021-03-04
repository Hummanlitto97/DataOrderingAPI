using System;
using DataOrdering.Domain.Common;

namespace DataOrdering.Domain.DataAggregates
{
    public class DataLine<data> where data: IComparable, IConvertible
    {
        public data[] DataUnits { get; private set; }
        public DataLine()
        {
            DataUnits = Array.Empty<data>();
        }
        public DataLine(string data)
        {
            string[] splittedData = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splittedData.Length != 0)
            {
                DataUnits = Array.ConvertAll(splittedData, unit => (data)Convert.ChangeType(unit, typeof(data)));
            }
            else
            {
                DataUnits = Array.Empty<data>();
            }
        }
        public string[] Get_Sorted_Data()
        {
            return Array.ConvertAll(Sorting.BubbleSort(DataUnits), unit => unit.ToString());
        }
    }
}
