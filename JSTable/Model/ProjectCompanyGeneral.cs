namespace JSTable.Model
{
    public class ProjectCompanyGeneral : Default<DB.Model.ProjectCompany.ProjectCompany, JsProjectCompanyGeneral>
    {
        public override void Sorting() =>

        Items = Parametrs.IntSortCol_0 switch
        {
         //   0 => Parametrs.Asc ? Items.OrderBy(c => c.Id) : Items.OrderByDescending(c => c.Id),
            0 => Parametrs.Asc ? Items.OrderBy(c => c.Code) : Items.OrderByDescending(c => c.Code),
            1 => Parametrs.Asc ? Items.OrderBy(c => c.CodeObject) : Items.OrderByDescending(c => c.CodeObject),
            2 => Parametrs.Asc ? Items.OrderBy(c => c.Model) : Items.OrderByDescending(c => c.Model),
            3 => Parametrs.Asc ? Items.OrderBy(c => c.Number) : Items.OrderByDescending(c => c.Number),
            4 => Parametrs.Asc ? Items.OrderBy(c => c.FullCode) : Items.OrderByDescending(c => c.FullCode),
            _ => Items
        };

        public override void Select() =>

            Items =
                from p in Table
                from o in p.DesignObjects
                from d in o.Documentations
                select new JsProjectCompanyGeneral(

                  d.Id,
                  p.Code,
                  $"{p.Code}.{o.Code}",
                  d.ModelReferences.LongName,
                  d.ModelReferences.ShortName + d.Number,
                  $"{p.Code}-{o.Code}-{d.ModelReferences.ShortName + d.Number}"
              );



    }
}
