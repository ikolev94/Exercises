var imdb = imdb || {};

(function (scope) {
    var id = 1;

    function Movie(title, length, rating, country) {
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        this._id = id++;
    }


    Movie.prototype.addActor = function (actor) {
        this._actors.push(actor);
    };
    Movie.prototype.getActors = function () {
        return this._actors;
    };
    Movie.prototype.addReview = function (review) {
        this._reviews.push(review);
    };
    Movie.prototype.deleteReview = function (review) {
        var index = this._reviews.indexOf(review);
        if (index !== -1) {
            this._reviews.splice(index, 1);
        }
    };
    Movie.prototype.deleteReviewById = function (id) {
        var reviewToDelete = this._reviews.filter(function (r) {
            return r._id === id;
        });
        this.deleteReview(reviewToDelete)
    };
    Movie.prototype.getReviews = function () {
        return this._reviews;
    };

    scope._Movie = Movie;
    scope.getMovie = function (title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }

}(imdb));