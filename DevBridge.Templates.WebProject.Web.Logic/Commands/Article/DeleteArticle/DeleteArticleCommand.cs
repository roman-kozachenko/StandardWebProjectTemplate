using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Article.DeleteArticle
{
    public class DeleteArticleCommand:CommandBase,ICommand<int>
    {
        private readonly IRepository _repository;

        public DeleteArticleCommand(IRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int articleId)
        {
            _repository.Delete<DataEntities.Entities.Article>(articleId);
            _repository.Commit();
        }
    }
}
