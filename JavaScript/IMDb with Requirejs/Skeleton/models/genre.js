define([], function () {
    return (function () {
        var id = 1;

        function Genre(name) {
            this.name = name;
            this._movies = [];
            this._id = id++;
        }

        Genre.prototype.addMovie = function (movie) {
            this._movies.push(movie);
        };

        Genre.prototype.deleteMovie = function (movie) {
            var index = this._movies.indexOf(movie);
            if (index !== -1) {
                this._movies.splice(index, 1);
            }
        };

        Genre.prototype.deleteMovieById = function (id) {
            var movie = this._movies.filter(function (e) {
                return e._id === id;
            })[0];
            this.deleteMovie(movie);
        };

        Genre.prototype.getMovies = function () {
            return this._movies.slice();
        };

        return Genre;
    })();
});
