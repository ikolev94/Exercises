var app = app || {};

app.userHomeView = (function () {

    function userHomeView(selector,data) {
        $.get('templates/welcome-user.html', function (template) {
            var output = Mustache.render(template,data);
            $(selector).html(output);

        })
    }

    return userHomeView

}());