var Noty = (function () {
    function display(type, text, time) {
        noty({
            text: text,
            type: type,
            theme: 'relax',
            dismissQueue: true,
            layout: 'top',
            maxVisible: 10,
            timeout: time,
            closeWith: ['button']
        });
    }

    function success(text) {
        display('success', text, 2000);
    }

    function error(text) {
        display('error', text, 4000);
    }

    return {
        success: success,
        error: error
    }
}());