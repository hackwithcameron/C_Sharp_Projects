using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCodeFirst.Models;

namespace EFCodeFirst.DAL
{
    public class dbInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<WebsiteDB>
    {
        protected override void Seed(WebsiteDB context)
        {
            new NewAccount { FirstName = "Test", LastName = "Account", EmailAddress = "Test@Email.com" };
            context.SaveChanges();
        }
    }
}
