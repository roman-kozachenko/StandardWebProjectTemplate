using System;
using System.Web.Security;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Like
{
    public class CreateLikeCommand:CommandBase,ICommand<int,bool>
    {
        private readonly IRepository _repository;

        public CreateLikeCommand(IRepository repository)
        {
            _repository = repository;
        }

        public bool Execute(int commentId)
        {
            var comment = _repository.FirstOrDefault<DataEntities.Entities.Comment>(commentId);
            if (comment == null)
                return false;
            
            var like = new DataEntities.Entities.Like
            {
                Comment = comment,
            };

            var user = Membership.GetUser();
            if (user != null && user.ProviderUserKey is Guid)
                like.UserId = (Guid) user.ProviderUserKey;
            _repository.Save(like);
            _repository.Commit();
            return true;
        }
    }
}
