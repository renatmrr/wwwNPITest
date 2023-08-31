using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTable.Model
{
    public class JsTableResult
    {
        public string? StrEcho { get; set; }

        public int IntTotalRecords { get; set; }

        public int IntTotalDisplayRecords { get; set; }

        public object? Data { get; set; }
    }
}
