using JSTable.Inteface;

namespace JSTable.Model
{
    public abstract class Default<T, B> : IJsTableSelect<T, B>
    {
        public required JsTableParametrs Parametrs { get; init; }
        public required IQueryable<T> Table { get; init; }

        public IEnumerable<B> Items { get; set; } = null!;

        public abstract void Select();

        public abstract void Sorting();

        public JsTableResult Res => new(
            Parametrs.StrEcho,
            Items.Count(),
            Items.Count(),
            Items.Skip(Parametrs.IntDisplayStart).Take(Parametrs.IntDisplayLength).ToArray()
        );

        public JsTableResult Result { get
            {
                Select();
                Sorting();
                return Res;
            }
        }
    }
}
