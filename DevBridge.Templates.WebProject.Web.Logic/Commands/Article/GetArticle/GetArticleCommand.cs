using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.GetArticle
{
    class GetArticleCommand:CommandBase,ICommand<int,ArticleViewModel>
    {
        public ArticleViewModel Execute(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}
