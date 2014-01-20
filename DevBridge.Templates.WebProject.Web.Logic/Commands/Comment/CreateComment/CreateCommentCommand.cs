using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Comment.CreateComment
{
    public class CreateCommentCommand:CommandBase,ICommand<CreateCommentViewModel,bool>
    {
        private readonly IRepository _repository;
        private readonly ArticleAdaptor _adaptor;

        public CreateCommentCommand(IRepository repository)
        {
            _repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public bool Execute(CreateCommentViewModel request)
        {
            var comment = _adaptor.CreateCommentViewModel2Comment(request);
            _repository.Save(comment);
            _repository.Commit();
            return true;
        }
    }
}
