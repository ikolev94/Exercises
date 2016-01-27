function solve(input) {
    var data = {};
    for (var i = 0; i < input.length; i++) {
        var inputArgs = input[i].replace(/\s+/g, ' ').split(/-|:/g).map(function (e) {
            return e.trim();
        });

        var name = inputArgs[0];
        var course = inputArgs[1];
        var result = Number(inputArgs[2]);

        if (result < 0 || result > 400) continue;

        if (!data[course]) data[course] = [];

        var currentStudent = data[course].filter(function (e) {
            return e.name === name;
        })[0];

        if (!currentStudent) {
            data[course].push(
                {
                    'name': name,
                    'result': result,
                    'makeUpExams': 0
                }
            );
        } else {
            if (currentStudent.result < result) currentStudent.result = result;
            currentStudent.makeUpExams++;
        }
    }

    var keys = Object.keys(data);
    for (var j = 0; j < keys.length; j++) {
        data[keys[j]].sort(function (a, b) {
            if (a.result !== b.result) {
                return b.result - a.result;
            } else if (a.makeUpExams !== b.makeUpExams) {
                return a.makeUpExams - b.makeUpExams
            } else {
                return a.name.localeCompare(b.name);
            }
        })
    }
    console.log(JSON.stringify(data));
}

//solve(['Peter Jackson - Java : 350',
//    'Jane - JavaScript : 200',
//    'Jane     -    JavaScript :     400',
//    'Simon Cowell - PHP : 100',
//    'Simon Cowell-PHP: 500',
//    'Simon Cowell - PHP : 200']);
