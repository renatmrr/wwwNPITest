using DB.Model.ProjectCompany.DesignObject.Documentation.ModelReference;

namespace Data.Stattic
{
    internal  class ModelRefrences 
    {
        public static List<ModelReference> Entity  =>
            new()
        {
         new ModelReference
         {
             LongName = "Технология производства",
             ShortName = "ТХ"
         },
         new ModelReference
         {
             LongName = "Архитектурно-строительные решения",
             ShortName = "АС"
         },
         new ModelReference
         {
             LongName = "Сметная документация",
             ShortName = "СМ"
         }
        };
    }
}
