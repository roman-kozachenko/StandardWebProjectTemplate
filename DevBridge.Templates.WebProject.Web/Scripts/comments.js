ArticleViewModel = function(id) {
    var self = this;

    self.mapping = {
        "Comments": {
            create: function(options) {
                return new CommentViewModel(options.data, self);
            }
        }
    };

    self.ArticleId = id;

    self.Comments = ko.observableArray();
    self.CommentBox = ko.observable(new CommentBoxViewModel(self));

    self.reloadCommentTree = function() {
        $.ajax({
            url: "/Comment/GetComments",
            type: "GET",
            data: {
                articleId: self.ArticleId
            },
            dataType: "json",
            success: function (json) {
                ko.mapping.fromJS(json, self.mapping, self);
            }
        });
    };

    self.resetCommentBox = function() {
        self.CommentBox = ko.observable(new CommentBoxViewModel(self));
    };
};

CommentViewModel = function(data, parent) {
    var self = this;

    self.parent = parent;

    self.mapping = {
        "Comments": {
            create: function(options) {
                return new CommentViewModel(options.data, self);
            }
        }
    };

    self.Id = ko.observable();
    self.UserId = ko.observable();

    self.UserName = ko.observable();

    self.CreatedOn = ko.observable();
    self.ModifiedOn = ko.observable();

    self.Text = ko.observable();

    self.IsLiked = ko.observable();
    self.LikesCount = ko.observable();

    self.LikeText = ko.computed(function() {
        if (self.LikesCount() == 0)
            return "";

        if (self.LikesCount() == 1)
            return "1 user liked";

        return self.LikesCount() + " users liked";
    }, self);

    self.Comments = ko.observableArray();
    self.CommentBox = ko.observable();

    self.showCommentBox = function() {
        self.CommentBox(new CommentBoxViewModel(self));
    };

    self.resetCommentBox = function() {
        self.CommentBox(null);
    };

    self.like = function() {
        $.ajax({
            url: "/Comment/Like",
            type: "POST",
            data: {
                CommentId: self.Id()
            },
            dataType: "json",
            success: function (json) {
                if (json) {
                    self.IsLiked(true);
                    self.LikesCount(self.LikesCount() + 1);
                }
            }
        });
    };

    self.unlike = function() {
        $.ajax({
            url: "/Comment/Unlike",
            type: "POST",
            data: {
                CommentId: self.Id()
            },
            dataType: "json",
            success: function (json) {
                if (json) {
                    self.IsLiked(false);
                    self.LikesCount(self.LikesCount() - 1);
                }
            }
        });
    };

    ko.mapping.fromJS(data, self.mapping, self);
};

CommentBoxViewModel = function(parent) {
    var self = this;

    self.parent = parent;

    self.Text = ko.observable();

    self.submit = function() {
        var articleId = null;
        var commentId = null;

        if (self.parent.ArticleId) {
            articleId = self.parent.ArticleId;
        } else {
            commentId = self.parent.Id();
        }

        $.ajax({
            url: "/Comment/Create",
            type: "POST",
            data: {
                ArticleId: articleId,
                ParentCommentId: commentId,
                Text: self.Text()
            },
            dataType: "json",
            success: function (json) {
                self.parent.Comments.push(new CommentViewModel(json, parent));
                self.parent.resetCommentBox();
            }
        });
    };

    self.cancel = function() {
        self.parent.resetCommentBox();
    };
};
