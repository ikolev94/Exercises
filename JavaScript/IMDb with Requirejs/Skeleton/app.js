(function () {
    require.config({
        paths: {
            'extensions': 'helpers/extensions',
            'generator': 'helpers/generator',
            'actor': 'models/actor',
            'genre': 'models/genre',
            'movie': 'models/movie',
            'review': 'models/review',
            'theatre': 'models/theatre',
            'loader': 'html-loader'
        }
    })
}());

require(['generator', 'loader'], function (imdb, loadHtml) {
    var genres;

    imdb.generateData();
    genres = imdb.getGenres();

    loadHtml('#genres', genres);
});