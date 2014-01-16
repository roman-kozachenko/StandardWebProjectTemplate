using System;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Models.Agreement;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.CreateArticle
{
    class CreateArticleCommand : CommandBase, ICommand<CreateArticleViewModel, bool>
    {
        public bool Execute(CreateArticleViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
