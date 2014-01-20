using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.EditArticleCommand
{
    public class EditArticleCommand:CommandBase, ICommand<ArticleViewModel>
    {
        private readonly IRepository _repository;
        private readonly ArticleAdaptor _adaptor;

        public EditArticleCommand(IRepository repository)
        {
            _repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public void Execute(ArticleViewModel viewModel)
        {
            var entity =
                _repository.AsQueryable<DataEntities.Entities.Article>()
                    .FirstOrDefault(article => article.Id == viewModel.Id);

            if (entity != null)
            {
                entity.Text = viewModel.Text;
                entity.Title = viewModel.Title;
            }
            _repository.Save(entity);
            _repository.Commit();
        }
    }
}
