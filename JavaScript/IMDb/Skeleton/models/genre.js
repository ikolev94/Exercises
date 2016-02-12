var imdb = imdb || {};

(function (scope) {
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
        if (index!==-1) {
            this._movies.splice(index,1);
        }
    };

    Genre.prototype.deleteMovieById = function (id) {
        var movieToDelete = this._movies.filter(function (m) {
            return m._id ===id;
        });
        this.deleteMovie(movieToDelete);
    };

    Genre.prototype.getMovies = function () {
        return this._movies;
    };

    scope.getGenre = function (name) {
        return new Genre(name);
    }

}(imdb));