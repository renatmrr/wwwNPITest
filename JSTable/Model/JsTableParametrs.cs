using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTable.Model
{
    public class JsTableParametrs
    {
        public string? StrEcho { get; set; }
        public string? StrSearch { get; set; }
        public int IntDisplayLength { get; set; }
        public int IntDisplayStart { get; set; }
        public int IntColumns { get; set; }
        public int IntSortCol_0 { get; set; }
        public string? StrSortDir_0 { get; set; }
        public int IntSortingCols { get; set; }
        public string? StrColumns { get; set; }
        public bool Asc => StrSortDir_0 == "asc";
    }
}
