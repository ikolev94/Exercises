var app = app || {};

app.deleteLectureView = (function () {

    function deleteLectureView(selector, data) {
        $.get('templates/delete-lecture.html', function (template) {
            var output = Mustache.render(template, data);
            $('.modal-backdrop').remove();
            $(selector).html(output);

            $('#delete-Lecture').click(function () {
                Sammy(function () {
                    this.trigger('delete-lecture-event', {
                        id: data._id
                    });
                })
            })
        });
    }

    return deleteLectureView

}());