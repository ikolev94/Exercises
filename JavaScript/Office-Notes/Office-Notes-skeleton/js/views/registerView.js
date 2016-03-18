var app = app || {};

app.registerView = (function () {

    function registerView(selector) {
        $.get('templates/register.html', function (template) {
            $(selector).html(template);

            $('#registerButton').click(function () {
                var $usernameInput = $('#username'),
                    $passwordInput = $('#password'),
                    $fullName = $('#fullName'),
                    username = $usernameInput.val(),
                    password = $passwordInput.val(),
                    fullName = $fullName.val();

                $usernameInput.val('');
                $passwordInput.val('');
                $fullName.val('');

                Sammy(function () {
                    this.trigger('register-event', {username: username, password: password, fullName: fullName});
                })
            })
        })
    }

    return registerView;

}());