using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.GetCommentsCommand
{
    public class GetCommentsCommand:CommandBase,ICommand<int,CommentListViewModel>
    {
        private readonly IRepository _repository;
        private readonly ArticleAdaptor _adaptor;

        public GetCommentsCommand(IRepository repository)
        {
            _repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public CommentListViewModel Execute(int articleId)
        {
            var query =
                _repository.AsQueryable<DataEntities.Entities.Comment>()
                    .Where(comment => comment.Article.Id == articleId && comment.ParentComment == null);

            return new CommentListViewModel
            {
                Comments = query.Select(comment => _adaptor.Comment2CommentViewModel(comment)).ToList()
            };
        }
    }
}
