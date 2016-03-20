var app = app || {};

app.lectureController = (function () {
    "use strict";
    var _this;

    function LectureController(model) {
        this.model = model;
        _this = this;
    }

    function validateLecture(data) {
        if (isNaN(Date.parse(data.start)) || isNaN(Date.parse(data.end))) {
            Noty.error('Invalid date format!');
            return false;
        }
        if (new Date(data.start).getTime() > new Date(data.end).getTime()) {
            Noty.error('Invalid start or end!');
            return false;
        }
        if (!data.title) {
            Noty.error('Invalid title!');
            return false;
        }
        if (!data.start) {
            Noty.error('Invalid start!!');
            return false;
        }
        if (!data.end) {
            Noty.error('Invalid end!');
            return false;
        }
        return true;
    }

    LectureController.prototype.loadAddLecturePage = function (selector) {
        app.addLectureView(selector);
    };

    LectureController.prototype.loadEditLecturePage = function (selector, data) {
        app.editLectureView(selector, data);
    };

    LectureController.prototype.loadDeleteLecturePage = function (selector, data) {
        app.deleteLectureView(selector, data);
    };

    LectureController.prototype.loadCalendarPage = function (selector) {
        this.model.getLectures()
            .then(function (data) {
                app.calendarView(selector, data)
            });
    };

    LectureController.prototype.loadMyCalendarPage = function (selector) {
        this.model.getLectureByAuthor(sessionStorage['username'])
            .then(function (data) {
                data.myLectures = true;
                app.calendarView(selector, data)
            })

    };

    LectureController.prototype.addLecture = function (data) {
        if (validateLecture(data)) {
            data.lecturer = sessionStorage['username'];
            this.model.addLecture(data)
                .then(function (success) {
                    Noty.success('You have successfully add a lecture!');
                    Sammy(function () {
                        this.trigger('changeUrl', {url: '#/calendar/my/'})
                    })
                }, function (error) {
                    Node.error('Invalid lecture!');
                })
        }
    };

    LectureController.prototype.getLectureById = function (id) {
        return this.model.getLectureById(id);
    };

    LectureController.prototype.editLecture = function (data) {
        if (validateLecture(data.lecture)) {
            this.model.editLectureById(data.id, data.lecture)
                .then(function (success) {
                    Noty.success('You have successfully edit a lecture!');
                }, function (error) {
                    Noty.error('Invalid lecture edit!');
                });
        }
    };

    LectureController.prototype.deleteLecture = function (data) {
        this.model.deleteLectureById(data.id)
            .then(function (success) {
                Noty.success('You have successfully delete a lecture!');
            }, function (error) {
                Noty.error('Invalid lecture remove!');
            });
    };

    Sammy(function () {

        this.bind('add-new-lecture-event', function (e, data) {
            _this.addLecture(data);
        });

        this.bind('edit-lecture-event', function (e, data) {
            _this.editLecture(data);
            this.redirect('#/calendar/my/');
        });

        this.bind('delete-lecture-event', function (e, data) {
            _this.deleteLecture(data);
            this.redirect('#/calendar/my/');
        })

    });


    return {
        load: function (model, notesPerPage) {
            return new LectureController(model, notesPerPage);
        }
    }
}());