define(['movie', 'extensions'], function (Movie) {
    return (function () {
        function Theatre(name, length, rating, country, isPuppet) {
            Movie.call(this, name, length, rating, country);
            this.isPuppet = isPuppet;
        }

        Theatre.extends(Movie);
        return Theatre;
    })();
});

