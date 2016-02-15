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

function solve() {

    var Item = (function () {
        var id = 1;

        function Item(name, description) {
            setName(name);
            setDescription(description);
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
            setIsbn(isbn);
            setGenre(genre);
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
            if (genre.length < 2 || genre.length > 40) {
                throw new Error('Invalid genre.');
            }
            this.genre = genre;
        }

        return Book;
    }());

    var Media = (function () {
        function Media(name, rating, duration, description) {
            Item.call(this, name, description);
            setDuration(duration);
            setRating(rating);
        }

        Media.extends(Item);
        function setDuration(duration) {
            if (isNaN(duration) || duration <= 0) {
                throw new Error('Invalid duration.');
            }
            this.duration = duration;
        }

        function setRating(rating) {
            if (isNaN(rating) || rating < 1 || rating > 5) {
                throw new Error('Invalid rating.')
            }
            this.rating = rating;
        }

        return Media;
    }());

    var Catalog = (function () {
        var id = 1;

        function Catalog(name) {
            setName(name);
            this.items = [];
            this.id = id++;
        }

        function setName(name) {
            if (!isValidName(name, 2, 40)) {
                throw new Error('Invalid catalog name.')
            }
            this.name = name;
        }

        Catalog.prototype.add = function () {
            var a = [], i, itemsToAdd;
            for (i = 0; i < arguments.length; i++) {
                a.push(arguments[i]);
            }
            itemsToAdd = a.flatten();
            if (!itemsToAdd.length) {
                throw new Error('No items to add.')
            }
            itemsToAdd.forEach(function (e) {
                if (!e instanceof Item) {
                    throw new Error('Invalid item.');
                }
            });
            for (i = 0; i < itemsToAdd.length; i++) {
                var obj = itemsToAdd[i];
                this.items.push(obj);
            }

        };

        Catalog.prototype.find = function (id) {
            if (id === undefined || isNaN(id)) {
                throw new Error('Invalid id.');
            }

            return this.items.filter(function (e) {
                return e.id === id;
            })[0];
        };

        return Catalog;
    }());

    function isValidName(str, min, max) {
        var len = str.length;
        return !(len < min || len > max);

    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new Catalog(name);
        },
        getMediaCatalog: function (name) {
            return new Catalog(name);
            //return a media catalog instance
        }
    };
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add([book1, book2]);
//catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

console.log(catalog.search('js'));
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'))
//returns []
