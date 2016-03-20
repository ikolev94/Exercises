var app = app || {};

app.calendarView = (function () {

    function calendarView(selector, data) {
        $.get('templates/calendar.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
            if (!data.myLectures) {
                $('#editLecture, #deleteLecture').hide();
            }
            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            Sammy(function () {
                                this.trigger('changeUrl', {url: '#/calendar/add/'});
                            })
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function () {
                            Sammy(function () {
                                this.trigger('changeUrl', {
                                    url: '#/calendar/edit/' + calEvent._id
                                });
                            })
                        });
                        $('#deleteLecture').on('click', function () {
                            Sammy(function () {
                                this.trigger('changeUrl', {
                                    url: '#/calendar/delete/' + calEvent._id
                                });
                            })
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        });
    }

    return calendarView

}());