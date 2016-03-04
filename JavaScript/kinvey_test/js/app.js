var app = app || {};
app.requester.config('kid_W1D-ZR7pCl','71343686690646ee8e8b1d1984be7e9e');
var userRequester = new app.UserRequester();

//userRequester.signUp('jon','12345');
userRequester.login('jon','12345');
//userRequester.logout();
userRequester.getInfo();