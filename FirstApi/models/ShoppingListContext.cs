using Microsoft.EntityFrameworkCore;

namespace FirstApi.models
{
    public class ShoppingListContext: DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
            : base(options)
        {

        }

       public DbSet<Grocery> groceries { get; set; }
    }
}
