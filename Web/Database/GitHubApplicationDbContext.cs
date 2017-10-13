namespace Web.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Web.Models;

    public class GitHubApplicationDbContext : DbContext
    {
        public GitHubApplicationDbContext()
            : base("name=GitHubApplicationDbContext")
        {

        }
        
        public virtual DbSet<Repository> Repositories { get; set; }
        
    }

}