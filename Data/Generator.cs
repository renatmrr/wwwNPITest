namespace Data
{
    public class Generator
    {
        private DB.Model.Context Context { get; set; }

        public Generator(DB.Model.Context context) => Context = context;

        public int Start(Parametrs parametrs)
        {
            Dynamic.ProjectCompany.Parametrs = parametrs;
            Dynamic.DesignObject.Parametrs = parametrs;
            Dynamic.Documentations.Parametrs = parametrs;

            Context.AddRange(Stattic.ModelRefrences.Entity);

            Context.AddRange(new Dynamic.ProjectCompany().Generation());

            return Context.SaveChanges();
        }
    }
}