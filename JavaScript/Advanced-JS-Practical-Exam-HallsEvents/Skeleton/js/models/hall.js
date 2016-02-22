define(['party', 'lecture', 'validator'], function (Party, Lecture, validator) {
    "use strict";
    return (function () {
        function Hall(name, capacity) {
            this.setName(name);
            this.setCapacity(capacity);
            this.parties = [];
            this.lectures = [];
        }

        Hall.prototype.setName = function (name) {
            validator.validateName(name);
            this._name = name;
        };
        Hall.prototype.getName = function () {
            return this._name;
        };
        Hall.prototype.setCapacity = function (capacity) {
            validator.validateNumber(capacity);
            this._capacity = capacity;
        };
        Hall.prototype.getCapacity = function () {
            return this._capacity;
        };

        Hall.prototype.addEvent = function (event) {
            if (event instanceof Party) {
                this.parties.push(event);
            } else if (event instanceof Lecture) {
                this.lectures.push(event);
            } else {
                throw new Error('Event is not instance of party or lecture');
            }
        };

        return Hall;
    }());
});
