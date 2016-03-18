var app = app || {},
    APP_ID = 'kid_W1D-ZR7pCl',
    APP_SECRET = '71343686690646ee8e8b1d1984be7e9e',
    BASE_URL = 'https://baas.kinvey.com/';

(function () {
    var selector = '#container',
        requester = app.requester.load(APP_ID, APP_SECRET, BASE_URL),
        userModel = app.userModel.load(requester),
        noteModel = app.noteModel.load(requester),
        homeController = app.homeController.load(userModel),
        noteController = app.noteController.load(noteModel),
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
                $('#menu').hide();
            } else {
                $('#welcomeMenu').text('Welcome, ' + sessionStorage['fullName']);
                $('#menu').show();
            }
        });

        this.get('#/', function () {
            homeController.loadWelcomePage(selector)
        });

        this.get('#/home/', function () {
            homeController.loadHomePage(selector)
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector)
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/addNote/', function () {
            noteController.loadAddNotePage(selector);
        });

        this.get('#/office/', function () {
            noteController.loadOfficeNotesPage(selector);
        });

        this.get('#/myNotes/', function () {
            noteController.loadMyNotes(selector);
        });

        this.get('#/logout/', function () {
            var _this = this;
            userController.logout()
                .then(function (success) {
                    _this.redirect('#/');
                })
        });

        this.get('#/edit/:id', function (e, data) {
            noteController.getNoteById(this.params['id'])
                .then(function (success) {
                    noteController.loadEditNotePage(selector, success)
                }).done();

        });

        this.get('#/delete/:id', function (e, data) {
            noteController.getNoteById(this.params['id'])
                .then(function (success) {
                    noteController.loadDeleteNotePage(selector, success)
                }).done();

        });

        this.bind('changeUrl', function (e, data) {
            this.redirect(data.url);
        });

    });

    router.run('#/');

}());