using JSTable.Model;

namespace JSTable.Inteface
{
    internal interface IJsTableSelect<T, B> 
    {
        JsTableParametrs Parametrs { get; init; }

        IQueryable<T> Table { get; init; }

        JsTableResult Result { get; }

        IEnumerable<B> Items { get; set; }


    }
}
