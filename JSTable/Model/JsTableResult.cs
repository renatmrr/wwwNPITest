namespace JSTable.Model
{
    public record JsTableResult (string? StrEcho, int IntTotalRecords, int IntTotalDisplayRecords, object? Data);
    
}
