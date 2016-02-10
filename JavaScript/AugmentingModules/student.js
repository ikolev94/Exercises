var world = world || {};

world.Student = (function (w) {
    "use strict";
    function Student(name, age, email, course) {
        w.Person.call(this, name, age, email);
        this._course = course;
    }

    Student.extend(w.Person);

    Student.prototype.toString = function () {
        return w.Person.prototype.toString.call(this) + ', Course: ' + this._course;
    };

    return Student;
}(world));