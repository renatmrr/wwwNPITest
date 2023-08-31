using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dynamic
{
    internal class Documentations : Default<DB.Model.ProjectCompany.DesignObject.Documentation.Documentation>
    {
        private static int c = 0;
        public override DB.Model.ProjectCompany.DesignObject.Documentation.Documentation Value =>
           new()
           {
               ModelReferences = Stattic.ModelRefrences.Entity[new Random().Next(0,2)],
               Number = c++
           };

    }
}
