var app = app || {};

app.myNotesView = (function () {

    function myNotesView(selector, data) {
        $.get('templates/myNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('.edit').click(function () {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('edit-event', {noteId: id});
                })
            });

            $('.delete').click(function () {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('delete-event', {noteId: id});
                })
            })
        })
    }

    return myNotesView

}());