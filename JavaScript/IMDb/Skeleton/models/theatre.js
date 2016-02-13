var imdb = imdb || {};

(function (scope) {

    function Theatre(name, length, rating, country, isPappet) {
        scope._Movie.call(this, name, length, rating, country);
        this.isPappet = isPappet;
    }

    Theatre.extends(scope._Movie);

    scope.getTheatre = function (name, length, rating, country, isPappet) {
        return new Theatre(name, length, rating, country, isPappet);
    }
}(imdb));