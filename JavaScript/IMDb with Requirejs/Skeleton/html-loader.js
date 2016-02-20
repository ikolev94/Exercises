define([], function () {
    var loadHtml;
    (function () {
        loadHtml = function loadHtml(selector, data) {
            var container = document.querySelector(selector),
                moviesContainer = document.getElementById('movies'),
                detailsContainer = document.getElementById('details'),
                genresUl = loadGenres(data),
                allMovies = [];

            data.forEach(function (genre) {
                allMovies = allMovies.concat(genre.getMovies());
            });

            container.appendChild(genresUl);

            genresUl.addEventListener('click', function (ev) {
                if (ev.target.tagName === 'LI') {
                    var genreId,
                        genre,
                        moviesHtml;

                    genreId = parseInt(ev.target.getAttribute('data-id'));
                    genre = data.filter(function (genre) {
                        return genre._id === genreId;
                    })[0];

                    moviesHtml = loadMovies(genre.getMovies());
                    moviesContainer.innerHTML = moviesHtml.outerHTML;
                    moviesContainer.setAttribute('data-genre-id', genreId);
                }
            });

            moviesContainer.addEventListener('click', function (ev) {
                if (ev.target.tagName === 'LI' || ev.target.parentNode.tagName === 'LI') {
                    var movieId, movie, detailsHtml;
                    movieId = ev.target.getAttribute('data-id') || ev.target.parentNode.getAttribute('data-id');
                    movie = getMovieById(movieId);
                    detailsHtml = loadDetails(movie.getActors(), movie.getReviews(), movieId);
                    detailsContainer.innerHTML = detailsHtml.outerHTML;
                    detailsContainer.setAttribute('movie-id', movieId);
                }
            });

            moviesContainer.addEventListener('click', function (ev) {
                var movieId, genreId, li;
                if (ev.target.tagName === 'BUTTON') {
                    li = ev.target.parentNode;
                    movieId = parseInt(li.getAttribute('data-id'));
                    genreId = parseInt(li.parentNode.parentNode.getAttribute('data-genre-id'));
                    data[genreId - 1].deleteMovieById(movieId);
                    li.parentNode.removeChild(li);
                    while (detailsContainer.firstChild) {
                        detailsContainer.removeChild(detailsContainer.firstChild);
                    }
                }
            });

            detailsContainer.addEventListener('click', function (ev) {
                var movieId, movie, reviewId, li;
                if (ev.target.tagName === 'BUTTON') {
                    li = ev.target.parentNode;
                    movieId = ev.target.className;
                    reviewId = parseInt(li.getAttribute('review-id'));
                    movie = getMovieById(movieId);
                    movie.deleteReviewById(reviewId);
                    li.parentNode.removeChild(li);
                }
            });

            function getMovieById(id) {
                return allMovies.filter(function (m) {
                    return m._id == id;
                })[0];
            }
        };

        function loadGenres(genres) {
            var genresUl = document.createElement('ul');
            genresUl.setAttribute('class', 'nav navbar-nav');
            genres.forEach(function (genre) {
                var liGenre = document.createElement('li');
                liGenre.innerHTML = genre.name;
                liGenre.setAttribute('data-id', genre._id);
                genresUl.appendChild(liGenre);
            });

            return genresUl;
        }

        function loadMovies(movies) {
            var moviesUl = document.createElement('ul');
            movies.forEach(function (movie) {
                var liMovie = document.createElement('li');
                liMovie.setAttribute('data-id', movie._id);

                liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
                liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
                liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
                liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
                liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
                liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
                liMovie.innerHTML += '<button>Delete Movie</button>';
                moviesUl.appendChild(liMovie);
            });

            return moviesUl;
        }

        function loadDetails(actors, reviews, movieId) {
            var actorHead, reviewHead, actorUl, reviewUl, button, div;
            actorHead = document.createElement('h1');
            actorHead.innerHTML = 'Actors';
            reviewHead = document.createElement('h1');
            reviewHead.innerHTML = 'Reviews';
            actorUl = document.createElement('ul');
            reviewUl = document.createElement('ul');
            actors.forEach(function (a) {
                var li, h3, p;
                li = document.createElement('li');
                h3 = document.createElement('h3');
                h3.innerHTML = a.name;
                p = document.createElement('p');
                p.innerHTML = '<strong>Bio: </strong>' + a.bio + '<br><strong>Born: </strong>' + a.born;
                li.appendChild(h3);
                li.appendChild(p);
                actorUl.appendChild(li);
            });
            reviews.forEach(function (r) {
                var li, h3, p;
                li = document.createElement('li');
                h3 = document.createElement('h3');
                h3.innerHTML = r.author;
                p = document.createElement('p');
                p.innerHTML = '<strong>Content: </strong>' + r.content + '<br><strong>Data: </strong>' + r.date;
                button = document.createElement('button');
                button.innerHTML = 'Delete Review';
                button.className = movieId;
                li.appendChild(h3);
                li.appendChild(p);
                li.appendChild(button);
                li.setAttribute('review-id', r._id);
                reviewUl.appendChild(li);
            });
            div = document.createElement('div');
            div.appendChild(actorHead);
            div.appendChild(actorUl);
            div.appendChild(reviewHead);
            div.appendChild(reviewUl);
            return div;
        }
    }());

    return loadHtml;
});

