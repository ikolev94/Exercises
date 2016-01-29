function solve(input) {
    var people = {};
    for (var i = 0; i < input.length - 1; i++) {
        var inputArgs = input[i].split(/\.*\*\.*/g);
        var name = inputArgs[0];
        var luggageName = inputArgs[1];
        var isFood = (inputArgs[2] === 'true');
        var isDrink = (inputArgs[3] === 'true');
        var isFragile = (inputArgs[4] === 'true');
        var wight = Number(inputArgs[5]);
        var transferredWith = inputArgs[6];
        var type = isDrink ? 'drink' : isFood ? 'food' : 'other';

        if (!people[name]) {
            people[name] = {};
        }
        people[name][luggageName] = {
            'kg': wight,
            'fragile': isFragile,
            'type': type,
            'transferredWith': transferredWith
        };
    }
    if (input[input.length - 1] === 'luggage name') {
        var newPeople = {};
        Object.keys(people).forEach(function (key) {
            newPeople[key] = {};
            var innerKeys = Object.keys(people[key]).sort();

            innerKeys.forEach(function (innerKey) {
                newPeople[key][innerKey] = people[key][innerKey];
            })
        });
        console.log(JSON.stringify(newPeople));
    } else if (input[input.length - 1] === 'weight') {
        var newSort = {};
        Object.keys(people).forEach(function (key) {
            newSort[key] = {};
            var a = Object.keys(people[key]).sort(function (a, b) {
                return people[key][a].kg - people[key][b].kg;
            });
            a.forEach(function (sss) {
                newSort[key][sss] = people[key][sss];
            })
        });
        console.log(JSON.stringify(newSort));
    } else if (input[input.length - 1] === 'strict') {
        console.log(JSON.stringify(people));
    }

    function trim(str, chr) {
        if (chr === '.')chr = '\\' + chr;
        var rgxtrim = (!chr) ? new RegExp('^\\s+|\\s+$', 'g') : new RegExp('^' + chr + '+|' + chr + '+$', 'g');
        return str.replace(rgxtrim, '');
    }
}

//solve(['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
//    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
//    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
//    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
//    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
//    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
//    'strict']);