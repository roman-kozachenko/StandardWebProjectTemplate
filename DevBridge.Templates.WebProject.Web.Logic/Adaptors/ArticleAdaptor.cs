using System;
using System.Linq;
using System.Web.Security;
using DevBridge.Templates.WebProject.DataEntities.Entities;
using DevBridge.Templates.WebProject.Web.Logic.Models.Article;
using DevBridge.Templates.WebProject.Web.Logic.Models.Comment;
using DevBridge.Templates.WebProject.Web.Logic.Models.Like;
using DevBridge.Templates.WebProject.Web.Logic.Models.User;

namespace DevBridge.Templates.WebProject.Web.Logic.Adaptors
{
    public class ArticleAdaptor
    {
        public  ArticleViewModel Article2ArticleViewModel(Article article)
        {
            var result = new ArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                Text = article.Text,
                User=GetUserById(article.UserId),
                Comments=article.Comments.Select(Comment2CommentViewModel).ToList()
            };
            return result;
        }

        public UserViewModel GetUserById(Guid userId)
        {
            return  User2UserViewModel(Membership.GetUser(userId));
        }

        private UserViewModel User2UserViewModel(MembershipUser user)
        {
            var result = new UserViewModel {Name = user != null ? user.UserName : "Unknown user"};
            return result;
        }

        public  CommentViewModel Comment2CommentViewModel(Comment comment)
        {
            var result = new CommentViewModel
            {
                Text = comment.Text,
                User = GetUserById(comment.UserId),
                Likes = comment.Likes.Select(Like2LikeViewModel).ToList()
            };
            return result;
        }

        public  LikeViewModel Like2LikeViewModel(Like like)
        {
            return new LikeViewModel {User = GetUserById(like.UserId)};
        }
    }
}
