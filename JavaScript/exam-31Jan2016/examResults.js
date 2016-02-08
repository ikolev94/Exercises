function solve(input) {
    var courseToLookFor = input[input.length - 1].trim();
    var grades = [];
    for (var i = 0; i < input.length - 1; i++) {
        var obj = input[i].trim().split(/\s+/g);
        var studentName = obj[0].trim();
        var course = obj[1].trim();
        var points = Number(obj[2]);
        var bonus = Number(obj[3]);
        if (course === courseToLookFor) {
            grades.push(points);
        }
        if (points < 100) {
            console.log(studentName + ' failed at ' + '\"' + course + '\"');
            continue;
        }
        var po = points * 0.2;
        po += bonus;
        var finalPoints = ((po / 80) * 4) + 2;
        if (finalPoints >= 6) {
            finalPoints = 6;
        }
        finalPoints = finalPoints.toFixed(2);
        po = Number(po.toFixed(2));

        console.log(studentName + ': Exam - ' + '\"' + course + '\"' + ';' +
            ' Points - ' + po + '; Grade - ' + finalPoints);

    }
    var sum = 0;
    for (var j = 0; j < grades.length; j++) {
        sum += grades[j];
    }
    var avg = sum / grades.length;
    avg = Number(avg.toFixed(2));
    console.log('\"' + courseToLookFor + '\" average points -> ' + avg);
}

//solve(['afds']);
//solve([' Pesho C#-Advanced      100 -4440.5000      ',
//    'Kircho C#-Advanced 390 0',
//    'Niki C#-Advanced 44 10',
//    '    C#-Advanced  ']);
//solve(['   Pesho C#-Advanced      100 3      ',
//    'Gosho Java-Basics 101 0',
//    'Tosho HTML&CSS 317 12',
//    'Minka C#-Advanced 57 15',
//    'Stanka C#-Advanced 157 15',
//    'Kircho C#-Advanced 300 0',
//    'Niki C#-Advanced 400 10',
//    '    C#-Advanced  ']);