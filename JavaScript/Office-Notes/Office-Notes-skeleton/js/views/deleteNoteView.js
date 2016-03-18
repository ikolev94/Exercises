var app = app || {};

app.deleteNoteView = (function () {

    function deleteNoteView(selector, data) {
        $.get('templates/deleteNote.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('#deleteNoteButton').click(function () {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('deleteNote-event', {noteId: id});
                })
            })
        })
    }

    return deleteNoteView;
}());