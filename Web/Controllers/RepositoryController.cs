using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.DAO;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class RepositoryController : Controller
    {
        public ActionResult Index()
        {
            List<RepositoryViewModel> repositories = RepositoryDAO.GetAll();
            return View(repositories);
        }

        public ActionResult Details(int? id)
        {
            RepositoryViewModel repository;
            if (!id.HasValue || (repository = RepositoryDAO.Get(id.Value)) == null)
                throw new Exception("Detail request without id");
            return View(repository);
        }

        public ActionResult Import()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Import(string language)
        {
            if (string.IsNullOrEmpty(language))
                throw new Exception("Import request without language");
            List<RepositoryViewModel> repositories = await GitHubService.GetTopRepositories(language);
            RepositoryDAO.InsertOrUpdate(repositories);
            return Redirect("/");
        }
    }
}