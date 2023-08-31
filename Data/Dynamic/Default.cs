using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dynamic
{
    internal class Default<T> where T : class
    {
        public static Parametrs Parametrs { get; set; } = null!;

        public virtual T Value { get; } = null!;

        private int GetCount =>
         (Value) switch
         {
             DB.Model.ProjectCompany.ProjectCompany => Parametrs.CountProject,

             DB.Model.ProjectCompany.DesignObject.DesignObject => Parametrs.CountDesignObject,

             DB.Model.ProjectCompany.DesignObject.Documentation.Documentation => Parametrs.CountDocumentations,

             _ => 0
         };
        public List<T> Generation()
        {
            var values = new T[GetCount];

            for (int i = 0; i < values.Length; i++) values[i] = Value;

            return values.ToList();
        }
    }
}
