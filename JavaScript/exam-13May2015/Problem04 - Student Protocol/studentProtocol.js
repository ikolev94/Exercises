function solve(input) {

    var studentsArgs, name, exam, score, student, keys, j, data = {};
    input.forEach(function (line) {
        studentsArgs = line.trim().split(/\s*-\s*|\s*:\s*/);
        name = studentsArgs[0];
        exam = studentsArgs[1];
        score = Number(studentsArgs[2]);
        if (score >= 0 && score <= 400) {
            if (!data[exam]) {
                data[exam] = [];
            }
            student = data[exam].filter(function (e) {
                return e.name === name;
            })[0];
            if (!student) {
                data[exam].push({name: name, result: score, makeUpExams: 0});
            } else {
                student.makeUpExams++;
                student.result = Math.max(student.result, score);
            }
        }
    });

    keys = Object.keys(data);
    for (j = 0; j < keys.length; j++) {
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

solve([
    'Peter Jackson - Java : 350',
    'Jane - JavaScript : 200',
    'Jane     -    JavaScript :     400',
    'Simon Cowell - PHP : 100',
    'Simon Cowell-PHP: 500',
    'Simon Cowell - PHP : 200']);
