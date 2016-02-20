define([], function () {
    return (function () {
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
            return this._actors.slice();
        };
        Movie.prototype.getReviews = function () {
            return this._reviews.slice();
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
            var review = this._reviews.filter(function (e) {
                return e._id === id;
            })[0];
            this.deleteReview(review);
        };
        return Movie;
    })();
});
