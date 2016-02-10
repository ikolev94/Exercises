var world = world || {};

world.Mammal = (function () {
    "use strict";
    function Mammal(name, age) {
        this._name = name;
        this._age = age;
    }

    Mammal.prototype.toString = function () {
        return this.constructor.name + ' => Name: ' + this._name + ', Age: ' + this._age;
    };

    return Mammal;
}());