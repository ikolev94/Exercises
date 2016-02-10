var world = world || {};

world.Person = (function (w) {
    "use strict";
    function Person(name, age, email) {
        w.Mammal.call(this, name, age);
        this._email = email;
    }

    Person.extend(w.Mammal);

    Person.prototype.toString = function () {
        return w.Mammal.prototype.toString.call(this) + ', Email: ' + this._email;
    };

    return Person;
}(world));