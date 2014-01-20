using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.CreateComment
{
    public class CreateCommentCommand : CommandBase, ICommand<CreateCommentViewModel, CommentViewModel>
    {
        private readonly IRepository repository;
        private ArticleAdaptor adaptor;

        public CreateCommentCommand(IRepository repository)
        {
            this.repository = repository;
            adaptor = new ArticleAdaptor();
        }

        public CommentViewModel Execute(CreateCommentViewModel request)
        {
            if (request.ArticleId == null && request.ParentCommentId == null)
                return null;
            
            DataEntities.Entities.Comment parentComment = (request.ParentCommentId.HasValue)
                ? repository.AsQueryable<DataEntities.Entities.Comment>().FirstOrDefault(f => f.Id == request.ParentCommentId.Value)
                : null;

            if (request.ParentCommentId.HasValue && parentComment == null)
                return null;

            DataEntities.Entities.Article article = (request.ArticleId.HasValue)
                ? repository.AsQueryable<DataEntities.Entities.Article>().FirstOrDefault(f => f.Id == request.ArticleId)
                : parentComment.Article;

            DataEntities.Entities.Comment comment = new DataEntities.Entities.Comment();

            comment.UserId = request.UserId;
            comment.Text = request.Text;

            comment.Article = article;
            comment.ParentComment = parentComment;

            repository.Save(comment);
            repository.Commit();

            repository.Refresh(comment);

            return adaptor.Comment2CommentViewModel(comment);
        }
    }
}
