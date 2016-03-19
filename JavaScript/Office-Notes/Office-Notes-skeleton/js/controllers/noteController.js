var app = app || {};

app.noteController = (function () {
    "use strict";
    var _this;

    function NoteController(model, notesPerPage) {
        this.model = model;
        this.notesPerPage = notesPerPage;
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

    NoteController.prototype.loadOfficeNotesPage = function (selector, page) {
        var deadline = new Date().toISOString().slice(0, 10);
        this.getAllTodayNotes(deadline, page)
            .then(function (success) {
                _this.model.getNotesCount('?query={"deadline":"' + deadline + '"}')
                    .then(function (data) {
                        app.officeNotesView(selector,
                            {
                                notes: success,
                                pagination: {
                                    numberOfItems: data.count,
                                    itemsPerPage: _this.notesPerPage,
                                    selectedPage: page,
                                    hrefPrefix: '#/office/'
                                }
                            });
                    })
            }).done();
    };

    NoteController.prototype.loadMyNotes = function (selector, page) {
        this.getMyNotes(page)
            .then(function (success) {
                _this.model.getNotesCount('?query={"author":"' + sessionStorage['username'] + '"}')
                    .then(function (data) {
                        app.myNotesView(selector,
                            {
                                notes: success,
                                pagination: {
                                    numberOfItems: data.count,
                                    itemsPerPage: _this.notesPerPage,
                                    selectedPage: page,
                                    hrefPrefix: '#/myNotes/'
                                }
                            });
                    })

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

    NoteController.prototype.getAllTodayNotes = function (deadline, page) {
        var toSkip = (page - 1) * this.notesPerPage;
        return this.model.getNotesByDay(deadline, this.notesPerPage, toSkip);
    };

    NoteController.prototype.getNoteById = function (id) {
        return this.model.getNoteById(id);
    };

    NoteController.prototype.getMyNotes = function (page) {
        var toSkip = (page - 1) * this.notesPerPage;
        return this.model.getNotesByAuthor(sessionStorage['username'], this.notesPerPage, toSkip);
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
                }, function (error) {
                    Noty.error('Invalid note edit!');
                });
            this.redirect('#/myNotes/');
        });

        this.bind('deleteNote-event', function (e, data) {
            sammyObj = this;
            _this.model.deleteNoteById(data.noteId)
                .then(function (success) {
                    Noty.success('You have successfully delete a note!');
                }, function (error) {
                    Noty.error('Invalid note remove!');
                });
            this.redirect('#/myNotes/');
        })

    });


    return {
        load: function (model, notesPerPage) {
            return new NoteController(model, notesPerPage);
        }
    }
}());