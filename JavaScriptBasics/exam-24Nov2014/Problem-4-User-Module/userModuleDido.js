function solve(input) {
    var criteria = input[0].split('^'),
        students = [],
        trainers = [];
    for (var i = 1; i < input.length; i++) {
        var obj = JSON.parse(input[i]);
        if (obj.role === 'student') {
            students.push(obj)
        } else {
            trainers.push(obj)
        }
    }
    if (criteria[0] === 'name') {
        students.sort(function (a, b) {
            if (a.firstname !== b.firstname) {
                return a.firstname.localeCompare(b.firstname);
            }
            return a.lastname.localeCompare(b.lastname);
        })
    } else if (criteria[0] === 'level') {
        students.sort(function (a, b) {
            if (a.level !== b.level) {
                return a.level - b.level;
            }
            return a.id - b.id;
        });
    }

    trainers.sort(function (a, b) {
        if (a.courses.length !== b.courses.length) {
            return a.courses.length - b.courses.length;
        }
        return a.lecturesPerDay - b.lecturesPerDay;
    });

    students.forEach(function (student) {
        delete student.town;
        delete student.role;
        delete student.level;
        student['averageGrade'] = student.grades.map(function (e) {
            return Number(e);
        }).map(function (x, i, arr) {
            return x / arr.length
        }).reduce(function (a, b) {
            return a + b
        }).toFixed(2);

        var certificate = student.certificate;
        delete student.grades;
        delete student.certificate;
        student['certificate'] = certificate;
    });

    trainers.forEach(function (trainer) {
        delete trainer.town;
        delete trainer.role;
    });

    var allPeople = {'students': students, 'trainers': trainers};
    console.log(JSON.stringify(allPeople));
}

//solve(['level^courses',
//    '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//    '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//    '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//    '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//    '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}']
//);