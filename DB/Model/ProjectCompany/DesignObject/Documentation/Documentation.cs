namespace DB.Model.ProjectCompany.DesignObject.Documentation
{
    public class Documentation:DefualtTable
    {
        public required ModelReference.ModelReference ModelReferences { get; init; }

        public int Number { get; set; }
    }
}
