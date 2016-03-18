var app = app || {};

app.officeNotesView = (function () {

    function officeNotesView(selector, data) {
        $.get('templates/officeNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        })
    }

    return officeNotesView

}());