using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Model
{
    public class Context : DbContext
    {
      
        public DbSet<ProjectCompany.ProjectCompany> ProjectCompanies { get; set; } = null!;

        public DbSet<ProjectCompany.DesignObject.DesignObject> DesignObjects { get; set; } = null!;

        public DbSet<ProjectCompany.DesignObject.Documentation.Documentation> DocumentationObjects { get; set; } = null!;    

        public DbSet<ProjectCompany.DesignObject.Documentation.ModelReference.ModelReference> ModelReferences { get; set; } = null!;    

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
