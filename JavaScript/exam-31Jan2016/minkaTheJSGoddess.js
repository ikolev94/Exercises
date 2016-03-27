function solve(input) {
    var args,
        name,
        type,
        taskNumber,
        score,
        linesOfCode,
        av,
        sortedKeys,
        i,
        result = {},
        data = {};
    
    for (i = 0; i < input.length; i++) {
        args = input[i].trim().split(/\s+&\s+/);
        name = args[0];
        type = args[1];
        taskNumber = 'Task ' + args[2];
        score = Number(args[3]);
        linesOfCode = Number(args[4]);

        if (!data[taskNumber]) {
            data[taskNumber] = {};
            data[taskNumber].tasks = [];
            data[taskNumber].average = 0;
            data[taskNumber].lines = 0;
        }
        data[taskNumber].tasks.push({name: name, type: type});
        data[taskNumber].average += score;
        data[taskNumber].lines += linesOfCode;
    }
    Object.keys(data).forEach(function (key) {
        av = (data[key].average / data[key].tasks.length);
        data[key].average = Number(av.toFixed(2));
        data[key].tasks.sort(function (a, b) {
            return a.name.localeCompare(b.name);
        });
    });
    sortedKeys = Object.keys(data).sort(function (a, b) {
        if (data[a].average !== data[b].average) {
            return data[b].average - data[a].average;
        }
        return data[a].lines - data[b].lines;
    });
    sortedKeys.forEach(function (key) {
        result[key] = data[key];
    });
    console.log(JSON.stringify(result));
}

// solve(['Array Matcher & strings & 4 & 100 & 38',
//     'Magic Wand & draw & 3 & 100 & 15',
//     'Dream Item & loops & 2 & 88 & 80',
//     'Knight Path & bits & 5 & 100 & 65',
//     'Basket Battle & conditionals & 2 & 100 & 120',
//     'Torrent Pirate & calculations & 1 & 100 & 20',
//     'Encrypted Matrix & nested loops & 4 & 90 & 52',
//     'Game of bits & bits & 5 & 100 & 18',
//     'Fit box in box & conditionals & 1 & 100 & 95',
//     'Disk & draw & 3 & 90 & 15',
//     'Poker Straight & nested loops & 4 & 40 & 57',
//     'Friend Bits & bits & 5 & 100 & 81']
// );