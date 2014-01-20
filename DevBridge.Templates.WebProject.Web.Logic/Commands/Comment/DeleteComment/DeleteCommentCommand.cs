using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommand:CommandBase,ICommand<int>
    {
        private readonly IRepository _repository;

        public DeleteCommentCommand(IRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int request)
        {
            _repository.Delete<DataEntities.Entities.Comment>(request);
            _repository.Commit();
        }
    }
}
