var app = app || {};
(function (scope) {
    "use strict";
    function Employee(name, workHours) {
        this.setName(name);
        this.setWorkHours(workHours);
    }

    Employee.prototype.setName = function (name) {
        validator.validateName(name);
        this._name = name;
    };
    Employee.prototype.getName = function () {
        return this._name;
    };
    Employee.prototype.setWorkHours = function (workHours) {
        validator.validateNumber(workHours);
        this._workHours = workHours;
    };
    Employee.prototype.getWorkhours = function () {
        return this._workHours;
    };

    scope.employee = Employee;
}(app));