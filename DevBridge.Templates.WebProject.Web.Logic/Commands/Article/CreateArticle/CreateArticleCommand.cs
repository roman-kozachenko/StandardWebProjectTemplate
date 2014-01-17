using System;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Agreement;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.CreateArticle
{
    public class CreateArticleCommand : CommandBase, ICommand<CreateArticleViewModel, bool>
    {
        private readonly IRepository _repository;
        private readonly ArticleAdaptor _adaptor;

        public CreateArticleCommand(IRepository repository)
        {
            _repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public bool Execute(CreateArticleViewModel request)
        {
            var article = _adaptor.CreateArticleViewModel2Article(request);
            _repository.Save(article);
            _repository.Commit();

            return true;
        }
    }
}
