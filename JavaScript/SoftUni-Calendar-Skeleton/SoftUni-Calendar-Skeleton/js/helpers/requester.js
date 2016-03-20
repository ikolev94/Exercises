var app = app || {};

app.requester = (function () {
    "use strict";
    var that;

    function Requester(appId, appSecret, baseUrl) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = baseUrl;
        that = this;
    }

    Requester.prototype.get = function (url, useSession) {
        return makeRequest('GET', url, null, useSession);
    };

    Requester.prototype.post = function (url, data, useSession) {
        return makeRequest('POST', url, data, useSession);
    };

    Requester.prototype.put = function (url, data, useSession) {
        return makeRequest('PUT', url, data, useSession);
    };

    Requester.prototype.remove = function (url, useSession) {
        return makeRequest('DELETE', url, {}, useSession);
    };

    function makeRequest(method, url, dataObj, useSession) {
        var token,
            options = {
                method: method,
                url: that.baseUrl + url,
                headers: {
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(dataObj) || undefined
            };

        if (!useSession) {
            token = that.appId + ':' + that.appSecret;
            options.beforeSend = function (xhr) {
                xhr.setRequestHeader('Authorization', 'Basic ' + btoa(token));
            };
        } else {
            token = sessionStorage['sessionAuth'];
            options.beforeSend = function (xhr) {
                xhr.setRequestHeader('Authorization', 'Kinvey ' + token);
            };
        }

        return $.ajax(options);
    }

    return {
        load: function (appId, appSecret, baseUrl) {
            return new Requester(appId, appSecret, baseUrl);
        }
    }
}());