using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using Web.Models;

namespace Web.ViewModels
{
    public class RepositoryViewModel
    {
        public RepositoryViewModel()
        {

        }

        public RepositoryViewModel(Repository repository)
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
        [Display(Name = "Owner Login")]
        public string OwnerLogin { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        [Display(Name = "Issues Count")]
        public int IssuesCount { get; set; }
        [Display(Name = "Forks Count")]
        public int ForksCount { get; set; }
        public int OriginalID { get; set; }

    }
}