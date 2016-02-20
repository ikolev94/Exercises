define([], function () {
    return (function () {
        var id = 1;

        function Review(author, content, date) {
            this.author = author;
            this.content = content;
            this.date = date;
            this._id = id++;
        }

        return Review;
    })();
});

