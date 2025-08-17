using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo_Database_
{
    public class ETradeContext:DbContext
    {
        //product nesnemi Products adlı tablo gibi kullanma
        public DbSet<Product> Products { get; set; }

    }
}
