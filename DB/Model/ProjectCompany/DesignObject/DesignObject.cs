namespace DB.Model.ProjectCompany.DesignObject
{
    public class DesignObject : DefualtTable
    {
        public required string Code { get; init; }

        public required string Name { get; init; }

        public required int Level { get; init; }

        public ProjectCompany ProjectCompany { get; set; } = null!;

        public required List<Documentation.Documentation> Documentations { get; init; }
    }
}
