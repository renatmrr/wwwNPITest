using DO = DB.Model.ProjectCompany.DesignObject.DesignObject;

namespace Data.Dynamic
{
    internal class DesignObject : Default<DO>
    {
        private static int c = 0;

        public override DB.Model.ProjectCompany.DesignObject.DesignObject Value =>
            new()
            {
                Code = new Random().Next(1000).ToString(),

                Name = $"Объект проектирования № {c++}",

                Level = new Random().Next(1,Parametrs.MaxLevel),

                Documentations = new Documentations().Generation(),
            };

    }
}
