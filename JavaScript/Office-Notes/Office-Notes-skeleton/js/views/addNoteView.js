var app = app || {};

app.addNoteView = (function () {

    function addNoteView(selector) {
        $.get('templates/addNote.html', function (template) {
            $(selector).html(template);

            $('#addNoteButton').click(function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val();

                Sammy(function () {
                    this.trigger('addNote-event', {title: title, text: text, deadline: deadline});
                })
            })
        })
    }

    return addNoteView;
}());