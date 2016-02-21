var app = app || {};

(function (scope) {
    "use strict";
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
        if (event instanceof scope.party) {
            this.parties.push(event);
        } else if (event instanceof scope.lecture) {
            this.lectures.push(event);
        } else {
            throw new Error('Event is not instance of party or lecture');
        }
    };

    scope.hall = Hall;
}(app));