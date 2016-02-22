define(['validator', 'employee', 'course', 'extensions'], function (validator, Employee, Course) {
    "use strict";
    return (function () {
        function Trainer(name, workHours) {
            Employee.call(this, name, workHours);
            this.courses = [];
            this.feedbacks = [];
        }

        Trainer.extends(Employee);

        Trainer.prototype.addFeedback = function (feedback) {
            if (typeof feedback !== 'string') {
                throw new Error('Invalid feedback.');
            }
            this.feedbacks.push(feedback);
        };
        Trainer.prototype.addCourse = function (course) {
            validator.validateInstance(course, Course);
            this.courses.push(course);
        };

        return Trainer;
    }());
});