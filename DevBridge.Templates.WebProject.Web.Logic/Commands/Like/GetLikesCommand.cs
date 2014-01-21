using System.Linq;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.Tools.Commands;
using DevBridge.Templates.WebProject.Web.Logic.Adaptors;
using DevBridge.Templates.WebProject.Web.Logic.Models.Like;

namespace DevBridge.Templates.WebProject.Web.Logic.Commands.Like
{
    public class GetLikesCommand : CommandBase, ICommand<int, LikesListViewModel>
    {
        private readonly IRepository _repository;
        private readonly ArticleAdaptor _adaptor;
        public GetLikesCommand(IRepository repository)
        {
            _repository = repository;
            _adaptor = new ArticleAdaptor();
        }

        public LikesListViewModel Execute(int commentId)
        {
            var query = _repository.AsQueryable<DataEntities.Entities.Like>()
                .Where(like => like.Comment.Id == commentId);
            return new LikesListViewModel
            {
                Likes = query.Select(like => _adaptor.Like2LikeViewModel(like)).ToList()
            };
        }
    }
}
