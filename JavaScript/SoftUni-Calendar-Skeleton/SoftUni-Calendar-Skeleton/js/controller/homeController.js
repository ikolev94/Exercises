var app = app || {};

app.homeController = (function () {
    "use strict";
    var _this;

    function HomeController() {
        _this = this;
    }

    HomeController.prototype.loadWelcomeGuestPage = function (selector) {
        app.welcomeGuestView(selector);
    };

    HomeController.prototype.loadUserHomePage = function (selector) {
        app.userHomeView(selector, {username:sessionStorage['username']});
    };


    return {
        load: function () {
            return new HomeController();
        }
    }
}());