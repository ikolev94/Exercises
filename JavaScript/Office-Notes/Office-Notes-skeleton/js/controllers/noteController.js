var app = app || {};

app.noteController = (function () {
    "use strict";
    var _this;

    function NoteController(model) {
        this.model = model;
        _this = this;
    }

    function validateNote(data) {
        if (!data.title) {
            Noty.error('Invalid title!');
            return false;
        }
        if (!data.text) {
            Noty.error('Invalid text!!');
            return false;
        }
        if (!data.deadline) {
            Noty.error('Invalid deadline!');
            return false;
        }
        return true;
    }

    NoteController.prototype.loadAddNotePage = function (selector) {
        app.addNoteView(selector);
    };

    NoteController.prototype.loadOfficeNotesPage = function (selector) {
        this.getAllTodayNotes()
            .then(function (success) {
                app.officeNotesView(selector, {notes: success});
            }).done();
    };

    NoteController.prototype.loadMyNotes = function (selector) {
        this.getMyNotes()
            .then(function (success) {
                app.myNotesView(selector, {notes: success});
            }).done();
    };

    NoteController.prototype.loadEditNotePage = function (selector, data) {
        app.editNoteView(selector, data);
    };

    NoteController.prototype.loadDeleteNotePage = function (selector, data) {
        app.deleteNoteView(selector, data);
    };

    NoteController.prototype.addNote = function (data) {
        data.author = sessionStorage['username'];
        return this.model.addNote(data);
    };

    NoteController.prototype.getAllTodayNotes = function () {
        var deadline = new Date().toISOString().slice(0, 10);
        return this.model.getNotesByDay(deadline);
    };

    NoteController.prototype.getNoteById = function (id) {
        return this.model.getNoteById(id);
    };

    NoteController.prototype.getMyNotes = function () {
        return this.model.getNotesByAuthor(sessionStorage['username']);
    };


    Sammy(function () {
        var sammyObj;
        this.bind('addNote-event', function (e, data) {
            if (validateNote(data)) {
                sammyObj = this;
                _this.addNote(data)
                    .then(function (success) {
                        Noty.success('You have successfully add a note!');
                        sammyObj.redirect('#/home/');
                    }).done();
            }
        });

        this.bind('changeNote-event', function (e, data) {
            sammyObj = this;
            _this.model.editNoteById(data.noteId, data.note)
                .then(function (success) {
                    Noty.success('You have successfully edit a note!');
                    //sammyObj.redirect('#/myNotes')
                }, function (error) {
                    Noty.error('Invalid note edit!');
                    //sammyObj.redirect('')
                });
            this.redirect('#/myNotes/');
        });

        this.bind('deleteNote-event', function (e, data) {
            sammyObj = this;
            _this.model.deleteNoteById(data.noteId)
                .then(function (success) {
                    Noty.success('You have successfully delete a note!');
                    //sammyObj.redirect('#/myNotes')
                }, function (error) {
                    Noty.error('Invalid note remove!');
                    //sammyObj.redirect('')
                });
            this.redirect('#/myNotes/');
        })

    });


    return {
        load: function (model) {
            return new NoteController(model);
        }
    }
}());