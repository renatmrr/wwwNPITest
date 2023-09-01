namespace DB.Model.ProjectCompany
{
    public class ProjectCompany: DefualtTable
    {
        public required string Code { get; init; }

        public required string Name { get; init; }

        public IEnumerable<DesignObject.DesignObject> DesignObjects { get; set; } = null!;
    }
}
