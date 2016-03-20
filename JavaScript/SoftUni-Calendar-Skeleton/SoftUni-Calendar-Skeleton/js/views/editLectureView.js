var app = app || {};

app.editLectureView = (function () {

    function editLectureView(selector, data) {
        $.get('templates/edit-lecture.html', function (template) {
            var output = Mustache.render(template, data);
            $('.modal-backdrop').remove();
            $(selector).html(output);

            $('#edit-Lecture').click(function () {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('edit-lecture-event', {
                        id: data._id,
                        lecture: {title: title, start: start, end: end, lecturer: sessionStorage['username']}
                    });
                })
            })
        })
    }

    return editLectureView

}());