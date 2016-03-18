var app = app || {};

app.userController = (function () {
    "use strict";
    var _this;

    function UserController(model) {
        this.model = model;
        _this = this;
    }

    function validateUserInput(data, hasFullName) {
        if (!data.username) {
            Noty.error('Invalid Username!');
            return false;
        }
        if (!data.password) {
            Noty.error('Invalid Password!!');
            return false;
        }
        if (hasFullName && !data.fullName) {
            Noty.error('Invalid Full name!');
            return false;
        }
        return true;
    }

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data._id;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['sessionAuth'] = data._kmd.authtoken;
    }

    UserController.prototype.loadLoginPage = function (selector) {
        app.loginView(selector);
    };

    UserController.prototype.loadRegisterPage = function (selector) {
        app.registerView(selector);
    };

    UserController.prototype.login = function (data) {
        return this.model.login(data);
    };

    UserController.prototype.register = function (data) {
        return this.model.register(data);
    };

    UserController.prototype.logout = function () {
        var defer = Q.defer();
        this.model.logout()
            .then(function (success) {
                defer.resolve(success);
                sessionStorage.clear();
            }, function (error) {
                defer.reject(error);
            });
        return defer.promise;
    };

    Sammy(function () {
        var sammyObj;
        this.bind('login-event', function (e, data) {
            if (validateUserInput(data)) {
                sammyObj = this;
                _this.login(data)
                    .then(function (success) {
                        setUserToStorage(success);
                        Noty.success('You have successfully logged in!');
                        sammyObj.redirect('#/home/');
                    }, function (error) {
                        Noty.error('Invalid Username or password!');
                    })
            }
        });

        this.bind('register-event', function (e, data) {
            if (validateUserInput(data, true)) {
                sammyObj = this;
                _this.register(data)
                    .then(function (success) {
                        setUserToStorage(success);
                        Noty.success('You have successfully register!');
                        sammyObj.redirect('#/home/');
                    }, function (error) {
                        Noty.error('Invalid Username or password!');
                    })
            }
        });
    });


    return {
        load: function (model) {
            return new UserController(model);
        }
    }
}());