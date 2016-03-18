var app = app || {};

app.myNotesView = (function () {

    function myNotesView(selector, data) {
        $.get('templates/myNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('.edit').click(function () {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('changeUrl', {url: '#/edit/' + id});
                })
            });

            $('.delete').click(function () {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('changeUrl', {url: '#/delete/' + id});
                })
            })
        })
    }

    return myNotesView

}());