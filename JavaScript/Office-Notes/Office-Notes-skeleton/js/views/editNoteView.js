var app = app || {};

app.editNoteView = (function () {

    function editNoteView(selector, data) {
        $.get('templates/editNote.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('#editNoteButton').click(function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val();

                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('changeNote-event', {
                        noteId: id,
                        note: {title: title, text: text, deadline: deadline, author: sessionStorage['username']}
                    });
                })
            })
        })
    }

    return editNoteView;
}());