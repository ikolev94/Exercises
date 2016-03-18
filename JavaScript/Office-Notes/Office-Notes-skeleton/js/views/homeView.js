var app = app || {};

app.homeView = (function () {

    function homeView(selector, data) {
        $.get('templates/home.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);

            $('#loginButton').click(function () {
                var username = $('#username').val(),
                    password = $('#password').val();

                Sammy(function () {
                    this.trigger('login-event', {username: username, password: password});
                })
            })
        })
    }

    return homeView

}());