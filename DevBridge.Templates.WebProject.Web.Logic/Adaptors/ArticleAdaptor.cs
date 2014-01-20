using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using DevBridge.Templates.WebProject.DataContracts;
using DevBridge.Templates.WebProject.DataEntities;
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
                //Comments=article.Comments.Select(Comment2CommentViewModel).ToList(),
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
            if (user != null)
                result.UserId = user.ProviderUserKey is Guid ? (Guid) user.ProviderUserKey : new Guid();
            return result;
        }

        public CommentViewModel Comment2CommentViewModel(Comment comment)
        {
            var result = new CommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                User = GetUserById(comment.UserId),
                Likes = comment.Likes.Select(Like2LikeViewModel).ToList(),
                Comments = comment.Comments.Select(Comment2CommentViewModel).ToList()
            };
            return result;
        }

        public  LikeViewModel Like2LikeViewModel(Like like)
        {
            return new LikeViewModel {User = GetUserById(like.UserId)};
        }

        public Article ArticleViewModel2Article(ArticleViewModel articleViewModel)
        {
            var article = new Article();
            article.Id = articleViewModel.Id;
            article.Text = articleViewModel.Text;
            article.Title = articleViewModel.Title;
            article.UserId = articleViewModel.User.UserId;
            return article;
        }

        public Article CreateArticleViewModel2Article(CreateArticleViewModel request)
        {
            var article = new Article {UserId = request.UserId, Title = request.Title, Text = request.Text};
            return article;
        }
    }
}

