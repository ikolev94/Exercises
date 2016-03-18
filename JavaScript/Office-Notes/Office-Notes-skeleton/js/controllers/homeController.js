var app = app || {};

app.homeController = (function () {
    "use strict";
    var _this;

    function HomeController(model) {
        this.model = model;
        _this = this;
    }

    HomeController.prototype.loadWelcomePage = function (selector) {
        app.welcomeView(selector);
    };

    HomeController.prototype.loadHomePage = function (selector) {
        var data = {fullName: sessionStorage['fullName'], username: sessionStorage['username']};
        app.homeView(selector, data);
    };


    return {
        load: function (model) {
            return new HomeController(model);
        }
    }
}());