define(['validator', 'event', 'employee', 'extensions'], function (validator, Event, Employee) {
    "use strict";
    return (function () {
        function Party(options) {
            Event.call(this, options);
            this.setIsCatered(options.isCatered);
            this.setIsBirthday(options.isBirthday);
            this.setOrganiser(options.organiser);
        }

        Party.extends(Event);

        Party.prototype.setIsCatered = function (isCatered) {
            validator.validateBoolean(isCatered);
            this._isCatered = isCatered;
        };
        Party.prototype.checkIsCatered = function () {
            return this._isCatered;
        };

        Party.prototype.setIsBirthday = function (isBirthday) {
            validator.validateBoolean(isBirthday);
            this._isBirthday = isBirthday;
        };
        Party.prototype.checkIsBirthday = function () {
            return this._isBirthday;
        };

        Party.prototype.setOrganiser = function (organiser) {
            validator.validateInstance(organiser, Employee);
            this._organiser = organiser;
        };
        Party.prototype.getOrganiser = function () {
            return this._organiser;
        };

        return Party;
    }());
});