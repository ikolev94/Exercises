var app = app || {};

app.loginView = (function () {

    function loginView(selector) {
        $.get('templates/login.html', function (template) {
            $(selector).html(template);

            $('#loginButton').click(function () {
                var $usernameInput = $('#username'),
                    $passwordInput = $('#password'),
                    username = $usernameInput.val(),
                    password = $passwordInput.val();
                $usernameInput.val('');
                $passwordInput.val('');

                Sammy(function () {
                    this.trigger('login-event', {username: username, password: password});
                })
            })
        })
    }

    return loginView

}());