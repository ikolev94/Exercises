var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
            moviesContainer = document.getElementById('movies'),
            detailsContainer = document.getElementById('details'),
            genresUl = loadGenres(data);

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

        // Task 2 - Add event listener for movies boxes
        moviesContainer.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI' || ev.target.parentNode.tagName === 'LI') {
                var movieId,
                    allMovies = [],
                    detailsHtml;

                movieIdStr = ev.target.getAttribute('data-id') || ev.target.parentElement.getAttribute('data-id');
                movieId = parseInt(movieIdStr);

                data.forEach(function (genre) {
                    genre.getMovies().forEach(function (m) {
                        allMovies.push(m);
                    })
                });
                var movie = allMovies.filter(function (m) {
                    return m._id === movieId;
                })[0];

                detailsContainer.setAttribute('data-movie-id', movieId);
                detailsHtml = loadDetails(movie.getActors(), movie.getReviews());
                detailsContainer.innerHTML = detailsHtml.outerHTML;
            }
        });
        // Task 3 - Add event listener for delete button (delete movie button or delete review button)
        moviesContainer.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'BUTTON') {

                var movieId = parseInt(ev.target.parentNode.getAttribute('data-id')),
                    genreId = parseInt(moviesContainer.getAttribute('data-genre-id')),
                genre = data.filter(function (g) {
                    return g._id === genreId;
                })[0];
                genre.deleteMovie(movieId);

                var movieLi = ev.target.parentNode;
                movieLi.parentNode.removeChild(movieLi);
                ev.stopPropagation();
            }
        })
    }

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
            liMovie.innerHTML += '<button>Delete movie</button>';
            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    function loadDetails(actors, reviews) {
        var div = document.createElement('div'),
            actorsHeader = document.createElement('h2'),
            actorUl = document.createElement('ul'),
            reviewsUl = document.createElement('ul'),
            reviewsHeader = document.createElement('h2');
        actorsHeader.innerText = 'Actors';
        reviewsHeader.innerText = 'Reviews';
        div.appendChild(actorsHeader);
        actors.forEach(function (a) {
            var li = document.createElement('li');

            li.innerHTML = '<h4>' + a.name + '</h4>';
            li.innerHTML += '<p><strong>Bio:</strong>' + a.bio + '</p>';
            li.innerHTML += '<p><strong>Born:</strong>' + a.born + '</p>';

            actorUl.appendChild(li);
        });
        div.appendChild(actorUl);
        div.appendChild(reviewsHeader);
        reviews.forEach(function (r) {
            var li = document.createElement('li');

            li.innerHTML = '<h4>' + r.author + '</h4>';
            li.innerHTML += '<p>Bio: ' + r.content + '</p>';
            li.innerHTML += '<p>Born: ' + r.date + '</p>';

            reviewsUl.appendChild(li);
        });
        div.appendChild(reviewsUl);

        return div;
    }

    scope.loadHtml = loadHtml;
}(imdb));