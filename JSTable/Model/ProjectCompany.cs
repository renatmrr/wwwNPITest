using Microsoft.EntityFrameworkCore;

namespace JSTable.Model
{
    public class ProjectCompany : Default<DB.Model.ProjectCompany.ProjectCompany, JsProjectCompany>
    {
        public override void Sorting() =>

         Items = Parametrs.IntSortCol_0 switch
         {
             0 => Parametrs.Asc ? Items.OrderBy(c => c.Name) : Items.OrderByDescending(c => c.Name),
             1 => Parametrs.Asc ? Items.OrderBy(c => c.Code) : Items.OrderByDescending(c => c.Code),
             _ => Parametrs.Asc ? Items.OrderBy(c => c.Id) : Items.OrderByDescending(c => c.Id)
         };

        public override void Select() =>
        
            Items = from p in Table
                    
                    select new JsProjectCompany(p.Id, p.Code, p.Name, 
                    p.DesignObjects.Select(l=>new DesignObject(l.Id,l.Code,l.Name,l.Level)));
        
        

    }
}
