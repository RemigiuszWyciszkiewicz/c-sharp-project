using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Utils
{
    interface RowExtracotr<T>
    {
        T extractBookFromDbRow(IDataRecord record);
    }
}
