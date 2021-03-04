using System;

using DataOrdering.Infrastructure;
using DataOrdering.Domain.DataAggregates;

namespace DataOrdering.App
{
    public static class OrderingDataService
    {
        public static string[] Sort_Data(string sortData, string type, string path)
        {
                DataTypes parsedType;
                if (Enum.IsDefined(typeof(DataTypes), type) && Enum.TryParse(type, out parsedType))
                {
                    switch (parsedType)
                    {
                        case DataTypes.Int:
                            return Save_Data_To_Text(new DataLine<int>(sortData).Get_Sorted_Data(), path);
                        case DataTypes.Double:
                            return Save_Data_To_Text(new DataLine<double>(sortData).Get_Sorted_Data(), path);
                        case DataTypes.String:
                            return Save_Data_To_Text(new DataLine<string>(sortData).Get_Sorted_Data(), path);
                        default:
                            throw new NotImplementedException("Empty type case for data");
                    }
                }
                throw new NotImplementedException("Unforseen type for data");
        }
        public static string[] Save_Data_To_Text(string[] data, string path)
        {
            new TextFile(path).Save_Data(string.Join(" ", data));
            return data;
        }
        public static string Load_Last_Ordered_Data(string path)
        {
            return new TextFile(path).Load_Data();
        }
    }
}