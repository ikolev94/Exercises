function solve(input) {
    var courseToLookFor = [input[input.length - 1].trim(), 0, 0],
        inputArgs, studentName, course, examPoints, bonus, grade, av;

    for (var i = 0; i < input.length - 1; i++) {
        inputArgs = input[i].trim().split(/\s+/g).map(function (e) {
            return e.trim();
        });
        studentName = inputArgs[0];
        course = inputArgs[1];
        examPoints = Number(inputArgs[2]);
        bonus = Number(inputArgs[3]);
        if (course === courseToLookFor[0]) {
            courseToLookFor[1] += examPoints;
            courseToLookFor[2]++;
        }
        if (examPoints < 100) {
            console.log('%s failed at "%s"', studentName, course);
            continue;
        }
        examPoints *= 0.2;
        examPoints += bonus;
        grade = Math.min(((examPoints / 80) * 4) + 2, 6);
        examPoints = Number(examPoints.toFixed(2));
        grade = (grade.toFixed(2));
        console.log('%s: Exam - "%s"; Points - %d; Grade - %s', studentName, course, examPoints, grade);
    }
    av = courseToLookFor[1] / courseToLookFor[2];
    console.log('"%s" average points -> %d', courseToLookFor[0], av.toFixed(2));
}

solve([
    'Pesho C#-Advanced 100 3',
    'Gosho Java-Basics 157 3',
    'Tosho HTML&CSS 317 12',
    'Minka C#-Advanced 57 15',
    'Stanka C#-Advanced 157 15',
    'Kircho C#-Advanced 300 0',
    'Niki C#-Advanced 400 10',
    'C#-Advanced']
);