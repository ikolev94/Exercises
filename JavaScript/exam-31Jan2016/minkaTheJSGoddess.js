function solve(input) {
    var tasks = {};
    for (var i = 0; i < input.length; i++) {
        var inputArgs = input[i].split(/\s+&\s+/g);
        var name = inputArgs[0];
        var type = inputArgs[1];
        var taskNum = 'Task ' + inputArgs[2];
        var score = Number(inputArgs[3]);
        var lines = Number(inputArgs[4]);
        if (!tasks[taskNum]) {
            tasks[taskNum] = {
                'tasks': [],
                'average': 0,
                'lines': 0
            };
        }
        tasks[taskNum].tasks.push({
            'name': name,
            'type': type
        });
        tasks[taskNum].average += score;
        tasks[taskNum].lines += lines;
    }
    Object.keys(tasks).forEach(function (task) {
        tasks[task].tasks.sort(function (r, t) {
            return r.name.localeCompare(t.name);
        });
        var av = tasks[task].average / tasks[task].tasks.length;
        tasks[task].average = Number(av.toFixed(2));
    });

    var keys = Object.keys(tasks).sort(function (a, b) {
        var e = a;
        var rr = b;
        if (tasks[a].average !== tasks[b].average) {
            return tasks[b].average - tasks[a].average;
        }
        return tasks[a].lines - tasks[b].lines;
    });
    var oo = {};
    for (var r = 0; r < keys.length; r++) {
        oo[keys[r]] = tasks[keys[r]];
    }

    console.log(JSON.stringify(oo));

}

//solve(['Array Matcher & strings & 4 & 100 & 38',
//    'Magic Wand & draw & 3 & 100 & 15',
//    'Dream Item & loops & 2 & 88 & 80',
//    'Knight Path & bits & 5 & 100 & 65',
//    'Basket Battle & conditionals & 2 & 100 & 120',
//    'Torrent Pirate & calculations & 1 & 100 & 20',
//    'Encrypted Matrix & nested loops & 4 & 90 & 52',
//    'Game of bits & bits & 5 & 100 & 18',
//    'Fit box in box & conditionals & 1 & 100 & 95',
//    'Disk & draw & 3 & 90 & 15',
//    'Poker Straight & nested loops & 4 & 40 & 57',
//    'Friend Bits & bits & 5 & 100 & 81']
//);