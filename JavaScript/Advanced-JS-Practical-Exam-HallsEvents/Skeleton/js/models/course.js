var app = app || {};

(function (scope) {
    "use strict";
    function Course(name, numberOfLectures) {
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);
    }


    Course.prototype.setName = function (name) {
        validator.validateName(name);
        this._name = name;
    };
    Course.prototype.getName = function () {
        return this._name;
    };
    Course.prototype.setNumberOfLectures = function (numberOfLectures) {
        validator.validateNumber(numberOfLectures);
        this._numberOfLectures = numberOfLectures;
    };
    Course.prototype.getNumberOfLectures = function () {
        return this._numberOfLectures;
    };

    scope.course = Course;
}(app));