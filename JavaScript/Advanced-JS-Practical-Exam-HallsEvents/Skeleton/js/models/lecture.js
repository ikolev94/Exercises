define(['validator', 'event', 'trainer', 'course', 'extensions'], function (validator, Event, Trainer, Course) {
    "use strict";
    return (function () {
        function Lecture(options) {
            Event.call(this, options);
            this.setTrainer(options.trainer);
            this.setCourse(options.course);
        }

        Lecture.extends(Event);

        Lecture.prototype.setTrainer = function (trainer) {
            validator.validateInstance(trainer, Trainer);
            this._trainer = trainer;
        };
        Lecture.prototype.getTrainer = function () {
            return this._trainer;
        };
        Lecture.prototype.setCourse = function (course) {
            validator.validateInstance(course, Course);
            this._course = course;
        };
        Lecture.prototype.getCourse = function () {
            return this._course;
        };

        return Lecture;
    }());
});