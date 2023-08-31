using JSTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTable.Inteface
{
    internal interface IJsTableSelect<T, B> 
    {
        JsTableParametrs Parametrs { get; init; }

        IQueryable<T> Table { get; init; }

        JsTableResult Result { get; }

        IEnumerable<B> Items { get; set; }


    }
}
