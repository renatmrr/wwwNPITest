namespace Data.Dynamic
{
    internal class ProjectCompany : Default<DB.Model.ProjectCompany.ProjectCompany>
    {
        private static int c = 0;
        public override DB.Model.ProjectCompany.ProjectCompany Value => new()
        {
            Code = new Random().Next(1000).ToString(),

            Name = $"Проект № {c++}",

            DesignObjects = new DesignObject().Generation()
        };

    }
}
