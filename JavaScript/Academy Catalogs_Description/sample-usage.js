function solve() {

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    Array.prototype.flatten = function () {
        'use strict';

        var resultArray = [];

        function getValues(array) {
            var i,
                value;

            for (i = 0; i < array.length; i += 1) {
                value = array[i];

                if (Array.isArray(value)) {
                    getValues(value);
                } else {
                    resultArray.push(value);
                }
            }
        }

        getValues(this);

        return resultArray;
    };

    var Item = (function () {
        var id = 1;

        function Item(name, description) {
            setName.call(this, name);
            setDescription.call(this, description);
            this.id = id++;
        }

        function setName(name) {
            if (!isValidName(name, 2, 40)) {
                throw new Error('Invalid name.');
            }
            this.name = name;
        }

        function setDescription(description) {
            if (!description) {
                throw  new Error('Description cannot be empty.');
            }
            this.description = description;
        }

        return Item;
    }());

    var Book = (function () {
        function Book(name, isbn, genre, description) {
            Item.call(this, name, description);
            setIsbn.call(this, isbn);
            setGenre.call(this, genre);
        }

        Book.extends(Item);

        function setIsbn(isbn) {
            var pattern = /\b\d{10}(\d{3})?\b/g;
            if (pattern.test(isbn)) {
                this.isbn = isbn;
            } else {
                throw new Error('Invalid Isbn.');
            }
        }

        function setGenre(genre) {
            if (typeof(genre) !== 'string' || genre.length < 2 || genre.length > 20) {
                throw new Error('Invalid genre.');
            }
            this.genre = genre;
        }

        return Book;
    }());

    var Media = (function () {
        function Media(name, rating, duration, description) {
            Item.call(this, name, description);
            setDuration.call(this, duration);
            setRating.call(this, rating);
        }

        Media.extends(Item);
        function setDuration(duration) {
            if (typeof (duration) !== 'number' || duration <= 0) {
                throw new Error('Invalid duration.');
            }
            this.duration = duration;
        }

        function setRating(rating) {
            if (typeof (rating) !== 'number' || rating < 1 || rating > 5) {
                throw new Error('Invalid rating.')
            }
            this.rating = rating;
        }

        return Media;
    }());

    var Catalog = (function () {
        var id = 1;

        function Catalog(name, item) {
            setName.call(this, name);
            this.items = [];
            this.id = id++;
            this.item = item;
        }

        function setName(name) {
            if (!isValidName(name, 2, 40)) {
                throw new Error('Invalid catalog name.')
            }
            this.name = name;
        }

        Catalog.prototype.add = function () {
            if (typeof (arguments) === 'undefined') {
                throw new Error('undefined cannot be added to a catalog');
            }
            var a = [], i, itemsToAdd;
            for (i = 0; i < arguments.length; i++) {
                a.push(arguments[i]);
            }
            itemsToAdd = a.flatten();
            if (!itemsToAdd.length) {
                throw new Error('No items to add.')
            }
            for (var j = 0; j < itemsToAdd.length; j++) {
                if (!(itemsToAdd[j] instanceof this.item)) {
                    throw new Error('Invalid item.');
                }

            }
            for (i = 0; i < itemsToAdd.length; i++) {
                var obj = itemsToAdd[i];
                this.items.push(obj);
            }

        };

        Catalog.prototype.find = function (options) {
            var result;
            if (typeof options === 'undefined') {
                throw new Error('Invalid id.');
            }
            if (typeof options === 'number') {
                result = this.items.filter(function (e) {
                    return e.id === options;
                })[0];
                result = result ? result : null;
            } else {
                result = this.items.filter(function (item) {
                    return Object.keys(options).every(function (key) {
                        return options[key] === item[key];
                    });
                });
            }
            return result;

        };

        Catalog.prototype.search = function (pattern) {
            var result = [], regex;
            regex = new RegExp(pattern, 'i');
            this.items.forEach(function (item) {
                if (regex.test(item.name) || regex.test(item.description)) {
                    result.push(item);
                }
            });
            return result;
        };

        return Catalog;
    }());

    var BookCatalog = (function () {
        function BookCatalog(name) {
            Catalog.call(this, name, Book);
        }

        BookCatalog.extends(Catalog);

        BookCatalog.prototype.getGenres = function () {
            var allGenres = [];
            this.items.forEach(function (book) {
                allGenres.push(book.genre.toLowerCase());
            });
            return allGenres.filter(function (value, index, self) {
                return self.indexOf(value) === index;
            });
        };

        return BookCatalog;
    }());

    var MediaCatalog = (function () {
        function MediaCatalog(name) {
            Catalog.call(this, name, Media)
        }

        MediaCatalog.extends(Catalog);

        MediaCatalog.prototype.getTop = function (count) {
            if (isNaN(count) || count < 1) {
                throw new Error('Invalid count.');
            }
            var items = this.items.slice();
            items.sort(function (a, b) {
                return b.rating - a.rating;
            });
            return items.slice(0, count).map(function (e) {
                return {
                    id: e.id,
                    name: e.name
                }
            })
        };

        MediaCatalog.prototype.getSortedByDuration = function () {
            var items = this.items.slice();
            return items.sort(function (a, b) {
                if (b.duration !== a.duration) {
                    return b.duration - a.duration;
                }
                return a.id - b.id;
            })
        };


        return MediaCatalog;
    }());

    function isValidName(str, min, max) {
        return !(typeof (str) !== 'string' ||
        str.length < min ||
        str.length > max);


    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    };
}

/*
var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');
var catalogMedia = module.getMediaCatalog('Media Catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
var book3 = module.getBook('JavaScript2: DOM', '3323456789', 'programing', 'book about JavaScript');
var media1 = module.getMedia('BBTV', 3, 32, 'tv Stuff');
var media2 = module.getMedia('Radio1', 4, 32, 'radio Stuff');
var media3 = module.getMedia('news', 1, 22, 'news Stuff');
catalog.add(book1, book2, book3);
catalogMedia.add([media1, media2, media3]);

console.log(catalogMedia.getSortedByDuration());

catalog.add(book2);
console.log(catalog.getGenres());
console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2
//
console.log(catalog.search('js'));
//returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'));
//returns []
*/