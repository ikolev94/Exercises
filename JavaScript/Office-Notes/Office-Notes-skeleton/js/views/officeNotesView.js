var app = app || {};

app.officeNotesView = (function () {

    function officeNotesView(selector, data) {
        $.get('templates/officeNoteTemplate.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('#pagination').pagination({
                items: data.pagination.numberOfItems,
                itemsOnPage: data.pagination.itemsPerPage,
                ccsStyle: 'light-theme',
                hrefTextPrefix: data.pagination.hrefPrefix
            }).pagination('selectPage', data.pagination.selectedPage);
        }).done();
    }

    return officeNotesView

}());