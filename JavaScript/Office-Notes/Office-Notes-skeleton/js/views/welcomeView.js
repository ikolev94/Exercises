var app = app || {};

app.welcomeView = (function () {

    function welcomeView(selector) {
        $.get('templates/welcome.html', function (template) {
            $(selector).html(template);
        })
    }

    return welcomeView

}());