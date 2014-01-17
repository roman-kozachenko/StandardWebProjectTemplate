using System;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Models.Agreement;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.CreateArticle
{
    public class CreateArticleCommand : CommandBase, ICommand<CreateArticleViewModel, bool>
    {
        private IRepository repository;

        public CreateArticleCommand(IRepository repository)
        {
            this.repository = repository;
        }

        public bool Execute(CreateArticleViewModel request)
        {
            DataEntities.Entities.Article article = new DataEntities.Entities.Article();

            article.UserId = request.UserId;
            article.Title = request.Title;
            article.Text = request.Text;

            repository.Save(article);
            repository.Commit();

            return true;
        }
    }
}
