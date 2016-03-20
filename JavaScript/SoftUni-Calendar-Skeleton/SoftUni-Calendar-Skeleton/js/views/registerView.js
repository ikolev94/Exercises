var app = app || {};

app.registerView = (function () {

    function registerView(selector) {
        $.get('templates/register.html', function (template) {
            $(selector).html(template);

            $('#register-button').click(function () {
                var $usernameInput = $('#username'),
                    $passwordInput = $('#password'),
                    $confirmPassword = $('#confirm-password'),
                    username = $usernameInput.val(),
                    password = $passwordInput.val(),
                    confirmPassword = $confirmPassword.val();

                $usernameInput.val('');
                $passwordInput.val('');
                $confirmPassword.val('');

                Sammy(function () {
                    this.trigger('register-event', {username: username, password: password, confirmPassword: confirmPassword});
                })
            })
        })
    }

    return registerView;

}());