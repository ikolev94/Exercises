var app = app || {};

(function (scope) {
    "use strict";
    function Trainer(name, workHours) {
        scope.employee.call(this, name, workHours);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.extends(scope.employee);

    Trainer.prototype.addFeedback = function (feedback) {
        if (typeof feedback !== 'string') {
            throw new Error('Invalid feedback.');
        }
        this.feedbacks.push(feedback);
    };
    Trainer.prototype.addCourse = function (course) {
        if (!(course instanceof scope.course)) {
            throw new Error('Invalid course.');
        }
        this.courses.push(course);
    };

    scope.trainer = Trainer;
}(app));