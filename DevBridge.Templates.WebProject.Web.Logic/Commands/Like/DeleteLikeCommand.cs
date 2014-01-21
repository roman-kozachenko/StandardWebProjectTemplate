using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Like
{
    public class DeleteLikeCommand:CommandBase,ICommand<int>
    {
       private readonly IRepository _repository;

       public DeleteLikeCommand(IRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int likeId)
        {
            _repository.Delete<DataEntities.Entities.Like>(likeId);
            _repository.Commit();
        }
    }
}
