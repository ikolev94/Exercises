var app = app || {};

app.welcomeGuestView = (function () {

    function welcomeGuestView(selector, data) {
        $.get('templates/welcome-guest.html', function (template) {
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

    return welcomeGuestView

}());