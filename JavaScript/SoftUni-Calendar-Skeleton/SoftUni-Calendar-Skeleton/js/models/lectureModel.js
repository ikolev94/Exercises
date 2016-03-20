var app = app || {};

app.lectureModel = (function () {
    function LectureModel(requester) {
        this.requester = requester;
        this.serviceUrl = 'appdata/' + requester.appId + '/lectures/';
    }

    LectureModel.prototype.addLecture = function (data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    LectureModel.prototype.getLectures = function () {
        var url = this.serviceUrl;
        return this.requester.get(url, true)
    };

    LectureModel.prototype.getLectureById = function (id) {
        var url = this.serviceUrl + id;
        return this.requester.get(url, true)
    };

    LectureModel.prototype.getLectureByAuthor = function (author) {
        var url = this.serviceUrl + '?query={"lecturer":"' + author + '"}';
        return this.requester.get(url, true)
    };

    LectureModel.prototype.editLectureById = function (id, data) {
        var url = this.serviceUrl + id;
        return this.requester.put(url, data, true)
    };

    LectureModel.prototype.deleteLectureById = function (id) {
        var url = this.serviceUrl + id;
        return this.requester.remove(url, true);
    };

    return {
        load: function (requester) {
            return new LectureModel(requester);
        }
    }
}());