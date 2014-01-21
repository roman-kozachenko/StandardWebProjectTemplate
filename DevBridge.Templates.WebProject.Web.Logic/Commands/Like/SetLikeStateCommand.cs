using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Models.Like;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Like
{
    public class SetLikeStateCommand : CommandBase, ICommand<SetLikeStateViewModel, bool>
    {
        private IRepository repository;

        public SetLikeStateCommand(IRepository repository)
        {
            this.repository = repository;
        }

        public bool Execute(SetLikeStateViewModel request)
        {
            var comment =
                repository.AsQueryable<DataEntities.Entities.Comment>()
                    .FirstOrDefault(f => f.Id == request.CommentId);

            if (comment == null)
                return false;

            if (request.LikeState)
            {
                if (comment.Likes.Any(f => f.UserId == request.UserId))
                    return true;

                var like = new DataEntities.Entities.Like()
                {
                    Comment = comment,
                    UserId = request.UserId
                };

                repository.Save(like);
                repository.Commit();
            }
            else
            {
                var like = comment.Likes.FirstOrDefault(f => f.UserId == request.UserId);

                if (like == null)
                    return true;

                repository.Delete(like);
                repository.Commit();
            }

            return true;
        }
    }
}
