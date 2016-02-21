var app = app || {};

(function (scope) {
    "use strict";
    function Party(options) {
        scope.Event.call(this, options);
        this.setIsCatered(options.isCatered);
        this.setIsBirthday(options.isBirthday);
        this.setOrganiser(options.organiser);
    }

    Party.extends(scope.Event);

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
        if (!(organiser instanceof scope.employee)) {
            throw new Error('Invalid organiser.');
        }
        this._organiser = organiser;
    };
    Party.prototype.getOrganiser = function () {
        return this._organiser;
    };

    scope.party = Party;
}(app));