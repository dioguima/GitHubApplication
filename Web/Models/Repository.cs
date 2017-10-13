using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.Models
{
    public class Repository
    {
        public Repository()
        {

        }

        public Repository(RepositoryViewModel repository)
        {
            this.ID = repository.ID;
            this.OriginalID = repository.OriginalID;
            this.Name = repository.Name;
            this.URL = repository.URL;
            this.Description = repository.Description;
            this.Language = repository.Language;
            this.Stars = repository.Stars;
            this.Private = repository.Private;
            this.OwnerLogin = repository.OwnerLogin;
            this.Created = repository.Created;
            this.IssuesCount = repository.IssuesCount;
            this.ForksCount = repository.ForksCount;
            this.OriginalID = repository.OriginalID;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public int Stars { get; set; }
        public bool Private { get; set; }
        public string OwnerLogin { get; set; }
        public DateTime Created { get; set; }
        public int IssuesCount { get; set; }
        public int ForksCount { get; set; }
        public int OriginalID { get; set; }
    }
}