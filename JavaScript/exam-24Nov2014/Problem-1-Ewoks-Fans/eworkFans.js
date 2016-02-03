function solve(input) {
    var limitUp = new Date('2015-01-01'),
        limitDown = new Date('1900-01-01T11:59:59'),
        ewokDay = new Date('1973-05-25'),
        haters = [],
        fans = [];
    for (var i = 0; i < input.length; i++) {
        var pattern = /(\d{2})\.(\d{2})\.(\d{4})/;
        var dt = new Date(input[i].replace(pattern, '$3-$2-$1'));
        if (dt.getTime() >= limitDown.getTime() && dt.getTime() <= limitUp.getTime()) {
            if (dt.getTime() >= ewokDay.getTime()) {
                fans.push(dt)
            } else {
                haters.push(dt);
            }
        }
    }
    haters.sort(function (a, b) {
        return a.getTime() - b.getTime();
    });
    fans.sort(function (a, b) {
        return a.getTime() - b.getTime();
    });
    if (!fans.length && !haters.length) {
        console.log('No result');
        return;
    }
    if (fans.length) {
        console.log('The biggest fan of ewoks was born on ' + fans[fans.length - 1].toDateString());
    }
    if (haters.length) {
        console.log('The biggest hater of ewoks was born on ' + haters[0].toDateString());
    }

}
//solve([]);
//solve(['22.03.2014', '17.05.1933', '10.10.1954']);
//solve(['22.03.2014']);
//solve(['22.03.2000']);