var app = app || {};

app.noteModel = (function () {
    function NoteModel(requester) {
        this.requester = requester;
        this.serviceUrl = 'appdata/' + requester.appId + '/notes/';
    }

    NoteModel.prototype.addNote = function (data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    NoteModel.prototype.getNotesByDay = function (deadline, notesPerPage, toSkip) {
        var url = this.serviceUrl + '?query={"deadline":"' + deadline + '"}&limit=' + notesPerPage + '&skip=' + toSkip;
        return this.requester.get(url, true)
    };

    NoteModel.prototype.getNotesByAuthor = function (author, notesPerPage, toSkip) {
        var url = this.serviceUrl + '?query={"author":"' + author + '"}&limit=' + notesPerPage + '&skip=' + toSkip;
        return this.requester.get(url, true)
    };

    NoteModel.prototype.getNoteById = function (id) {
        var url = this.serviceUrl + id;
        return this.requester.get(url, true)
    };

    NoteModel.prototype.editNoteById = function (id, data) {
        var url = this.serviceUrl + id;
        return this.requester.put(url, data, true)
    };

    NoteModel.prototype.deleteNoteById = function (id) {
        var url = this.serviceUrl + id;
        return this.requester.remove(url, true);
    };

    NoteModel.prototype.getNotesCount = function (query) {
        var url = this.serviceUrl + '_count' + query;
        return this.requester.get(url, true);
    };

    return {
        load: function (requester) {
            return new NoteModel(requester);
        }
    }
}());