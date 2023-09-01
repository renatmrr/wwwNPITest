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
        public IEnumerable<T> Generation()
        {
            var values = new T[GetCount];

            Parallel.For(0, values.Length,(i) =>
            {
                values[i] = Value;

            });

            return values;
        }
    }
}
