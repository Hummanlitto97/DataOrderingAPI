using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrdering.Infrastructure.Common.Interfaces
{
    interface IDatabase
    {
        string Save_Data(string data);
        string Load_Data();
    }
}
