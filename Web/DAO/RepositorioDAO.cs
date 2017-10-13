using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Database;
using Web.Models;
using Web.ViewModels;

namespace Web.DAO
{
    public class RepositoryDAO
    {

        public static bool InsertOrUpdate(List<RepositoryViewModel> repositories)
        {
            try
            {
                using (GitHubApplicationDbContext db = new GitHubApplicationDbContext())
                {
                    foreach (RepositoryViewModel repository in repositories)
                    {
                        Repository dbRepository;
                        if ((dbRepository = db.Repositories.FirstOrDefault(x => x.OriginalID == repository.OriginalID)) == null)
                            db.Repositories.Add(new Repository(repository));
                        else
                            dbRepository = new Repository(repository);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("An error happened when importing the repositories");
            }
        }

        internal static List<RepositoryViewModel> GetAll()
        {
            try
            {
                List<RepositoryViewModel> repositories = new List<RepositoryViewModel>();
                using (GitHubApplicationDbContext db = new GitHubApplicationDbContext())
                {
                    foreach(Repository repository in db.Repositories.ToList())
                        repositories.Add(new RepositoryViewModel(repository));
                }
                return repositories;
            }
            catch (Exception e)
            {
                throw new Exception("An error happened when getting all repositories");
            }
        }

        public static RepositoryViewModel Get(int id)
        {
            try
            {
                Repository repository;
                using (GitHubApplicationDbContext db = new GitHubApplicationDbContext())
                {
                    repository = db.Repositories.Find(id);
                }
                return new RepositoryViewModel(repository);
            }
            catch (Exception e)
            {
                //TODO: Log the exceptions
                throw new Exception("An error happened when getting the repository");
            }
        }

    }
}