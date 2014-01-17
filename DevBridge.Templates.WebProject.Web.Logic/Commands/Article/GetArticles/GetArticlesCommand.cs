using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Agreement.GetAgreements;
using DevBridge.Templates.WebProject.Web.Logic.Models.Agreement;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticles
{
    public class GetArticlesCommand : CommandBase, ICommand<GetArticlesFilterViewModel, ArticleListViewModel>
    {
        private IRepository repository;

        public GetArticlesCommand(IRepository repository)
        {
            this.repository = repository;
        }

        public ArticleListViewModel Execute(GetArticlesFilterViewModel request)
        {
            var query = repository.AsQueryable<DataEntities.Entities.Article>().ToList();
            
            return new ArticleListViewModel()
            {
                Articles = query.Select(a => new ArticleViewModel()).ToList()
            };
        }
    }
}
