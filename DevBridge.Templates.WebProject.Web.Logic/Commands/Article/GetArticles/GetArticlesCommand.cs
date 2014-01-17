using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Commands.Agreement.GetAgreements;
using DevBridge.Templates.WebProject.Web.Logic.Models.Agreement;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticles
{
    public class GetArticlesCommand : CommandBase, ICommand<GetArticlesFilterViewModel,ArticleListViewModel>
    {
        public ArticleListViewModel Execute(GetArticlesFilterViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}
