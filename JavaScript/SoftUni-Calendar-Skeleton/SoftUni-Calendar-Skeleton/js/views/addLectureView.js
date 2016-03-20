var app = app || {};

app.addLectureView = (function () {

    function addLectureView(selector) {
        $.get('templates/add-lecture.html', function (template) {
            $(selector).html(template);

            $('#addLecture').click(function () {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('add-new-lecture-event', {title: title, start: start, end: end});
                })
            })
        })
    }

    return addLectureView

}());