define(['validator'], function (validator) {
    "use strict";
    return (function () {
        function Event(options) {
            if (this.constructor === Event) {
                throw new Error('Cannot create instance of Event');
            }
            this.setTitle(options.title);
            this.setType(options.type);
            this.setDuration(options.duration);
            this.setDate(options.date);
        }


        Event.prototype.setTitle = function (title) {
            validator.validateTitle(title);
            this._title = title;
        };
        Event.prototype.getTitle = function () {
            return this._title;
        };

        Event.prototype.setType = function (type) {
            validator.validateType(type);
            this._type = type;
        };
        Event.prototype.getType = function () {
            return this._type;
        };

        Event.prototype.setDuration = function (duration) {
            validator.validateDuration(duration);
            this._duration = duration;
        };
        Event.prototype.getDuration = function () {
            return this._duration;
        };

        Event.prototype.setDate = function (date) {
            validator.validateDate(date);
            this._date = date;
        };
        Event.prototype.getDate = function () {
            return this._date;
        };

        return Event;
    }());
});