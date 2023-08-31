using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSTable.Model
{
    public class ObjectDesign : Default<DB.Model.ProjectCompany.DesignObject.DesignObject, JsProjectCompanyGeneral>
    {

        public override void Select() =>

           Items =
              
               from o in Table
               from d in o.Documentations
               select new JsProjectCompanyGeneral(

                  d.Id,
                  o.ProjectCompany.Code,
                  $"{o.ProjectCompany.Code}.{o.Code}",
                  d.ModelReferences.LongName,
                  d.ModelReferences.ShortName + d.Number,
                  $"{o.ProjectCompany.Code}-{o.Code}-{d.ModelReferences.ShortName + d.Number}"
              );

        public override void Sorting() =>

       Items = Parametrs.IntSortCol_0 switch
       {
          // 0 => Parametrs.Asc ? Items.OrderBy(c => c.Id) : Items.OrderByDescending(c => c.Id),
           0 => Parametrs.Asc ? Items.OrderBy(c => c.Code) : Items.OrderByDescending(c => c.Code),
           1 => Parametrs.Asc ? Items.OrderBy(c => c.CodeObject) : Items.OrderByDescending(c => c.CodeObject),
           2 => Parametrs.Asc ? Items.OrderBy(c => c.Model) : Items.OrderByDescending(c => c.Model),
           3 => Parametrs.Asc ? Items.OrderBy(c => c.Number) : Items.OrderByDescending(c => c.Number),
           4 => Parametrs.Asc ? Items.OrderBy(c => c.FullCode) : Items.OrderByDescending(c => c.FullCode),
           _ => Items
       };
    }
}
