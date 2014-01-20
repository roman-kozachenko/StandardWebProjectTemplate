using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DevBridge.Templates.WebProject.Web.Helpers;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.CreateArticle;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.DeleteArticle;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.EditArticleCommand;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticle;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticles;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Controllers
{
    public partial class ArticleController : Tools.Mvc.ExtendedControllerBase
    {
        //
        // GET: /Article/

        public virtual ActionResult Index()
        {
            var model = GetCommand<GetArticlesCommand>().ExecuteCommand(GetFilter());

            return View(model);
        }

        private GetArticlesFilterViewModel GetFilter()
        {
            var result = new GetArticlesFilterViewModel();
            return result;
        }

        //
        // GET: /Article/Details/5

        public virtual ActionResult Details(int id)
        {
            var model = GetCommand<GetArticleCommand>().ExecuteCommand(id);

            return View(model);
        }

        //
        // GET: /Article/Create

        public virtual ActionResult Create()
        {
            
            
            return View();
        } 

        //
        // POST: /Article/Create

        [HttpPost]
        public virtual ActionResult Create(CreateArticleViewModel articleViewModel)
        {
            try
            {
                var membershipUser = Membership.GetUser(User.Identity.Name);
                if (membershipUser != null)
                    if (membershipUser.ProviderUserKey != null)
                        articleViewModel.UserId = Guid.Parse(membershipUser.ProviderUserKey.ToString());

                GetCommand<CreateArticleCommand>().ExecuteCommand(articleViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Article/Edit/5

        public virtual ActionResult Edit(int id)
        {
            var model = GetCommand<GetArticleCommand>().ExecuteCommand(id);

            return View(model);
        }

        //
        // POST: /Article/Edit/5

        [HttpPost]
        public virtual ActionResult Edit(int id,ArticleViewModel article)
        {
            try
            {
                GetCommand<EditArticleCommand>().ExecuteCommand(article);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Delete/5

        public virtual ActionResult Delete(int id)
        {
            GetCommand<DeleteArticleCommand>().ExecuteCommand(id);
            return RedirectToAction("Index");
        }
    }
}
