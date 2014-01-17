using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticle
{
    public class GetArticleCommand:CommandBase,ICommand<int,ArticleViewModel>
    {
        private readonly IRepository repository;
        private ArticleAdaptor _adaptor;

        public GetArticleCommand(IRepository repository)
        {
            this.repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public ArticleViewModel Execute(int articleId)
        {
            var result =
                repository.AsQueryable<DataEntities.Entities.Article>()
                    .FirstOrDefault(article => article.Id == articleId);

            return _adaptor.Article2ArticleViewModel(result);
        }
    }
}
