var app = app || {},
    APP_ID = 'kid_WkbJzrE6kZ',
    APP_SECRET = 'ebae5132d8c048429c7d7be7c4040710',
    BASE_URL = 'https://baas.kinvey.com/';

(function () {
    var selector = '#container',
        requester = app.requester.load(APP_ID, APP_SECRET, BASE_URL),
        userModel = app.userModel.load(requester),
        lectureModel = app.lectureModel.load(requester),
        homeController = app.homeController.load(),
        lectureController = app.lectureController.load(lectureModel),
        userController = app.userController.load(userModel);

    var router = Sammy(function () {

        this.before({except: {path: '#\/(login/|register/)?'}}, function () {
            if (!sessionStorage['sessionAuth']) {
                this.redirect('#/');
                return false;
            }
        });

        this.before(function () {
            if (!sessionStorage['sessionAuth']) {
                $('#menu').load('templates/menu-login.html');
            } else {
                $('#menu').load('templates/menu-home.html');
            }
        });

        this.get('#/', function () {
            if (sessionStorage['sessionAuth']) {
                homeController.loadUserHomePage(selector)
            } else {
                homeController.loadWelcomeGuestPage(selector)
            }
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector)
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector)
        });

        this.get('#/logout/', function () {
            var _this = this;
            userController.logout()
                .then(function (success) {
                    _this.redirect('#/');
                })
        });

        this.get('#/calendar/list/', function () {
            lectureController.loadCalendarPage(selector);
        });

        this.get('#/calendar/my/', function () {
            lectureController.loadMyCalendarPage(selector);
        });


        this.get('#/calendar/edit/:id', function () {
            lectureController.getLectureById(this.params['id'])
                .then(function (data) {
                    lectureController.loadEditLecturePage(selector, data);
                });
            lectureController.loadAddLecturePage(selector);
        });

        this.get('#/calendar/delete/:id', function () {
            lectureController.getLectureById(this.params['id'])
                .then(function (data) {
                    lectureController.loadDeleteLecturePage(selector, data);
                });
            lectureController.loadAddLecturePage(selector);
        });

        this.get('#/calendar/add/', function (e, data) {
            lectureController.loadAddLecturePage(selector);
        });

        //this.bind('add-new-lecture-event', function (e, data) {
        //    lectureController.addLecture(data);
        //});

        this.bind('changeUrl', function (e, data) {
            this.redirect(data.url);
        });
    });

    router.run('#/');
}());