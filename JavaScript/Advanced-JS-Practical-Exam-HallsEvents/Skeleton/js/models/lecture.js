var app = app || {};

(function (scope) {
    "use strict";
    function Lecture(options) {
        scope.Event.call(this, options);
        this.setTrainer(options.trainer);
        this.setCourse(options.course);
    }

    Lecture.extends(scope.Event);

    Lecture.prototype.setTrainer = function (trainer) {
        if (!(trainer instanceof scope.trainer)) {
            throw new Error('Invalid trainer.');
        }
        this._trainer = trainer;
    };
    Lecture.prototype.getTrainer = function () {
        return this._trainer;
    };
    Lecture.prototype.setCourse = function (course) {
        if (!(course instanceof scope.course)) {
            throw new Error('Invalid course.');
        }
        this._course = course;
    };
    Lecture.prototype.getCourse = function () {
        return this._course;
    };

    scope.lecture = Lecture;
}(app));