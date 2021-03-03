using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrdering.Domain.Common
{
    static class Sorting
    {
        private static void SwapDataUnits<data>(ref data lowData, ref data highData)
        {
            data temp = lowData;
            lowData = highData;
            highData = temp;
        }
        public static data[] BubbleSort<data>(data[] sortData) where data : IComparable
        {
            bool escape;
            for (int i = 0;i < sortData.Length;i++)
            {
                escape = true;
                for(int ii = 0;ii < sortData.Length - i - 1;ii++)
                {
                    if (sortData[ii].CompareTo(sortData[ii + 1]) > 0)
                    {
                        SwapDataUnits(ref sortData[ii], ref sortData[ii + 1]);
                        escape = false;
                    }
                }
                if(escape)
                {
                    break;
                }
            }
            return sortData;
        }
    }
}
