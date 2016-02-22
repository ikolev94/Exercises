define(['hall', 'employee', 'trainer', 'course', 'lecture', 'party'],
    function (Hall, Employee, Trainer, Course, Lecture, Party) {
        "use strict";
        return (function () {
            var halls = [],
                openSource,
                inspiration,
                mariya,
                pesho,
                gosho,
                feedback,
                feedback2,
                feedback3,
                advancedJs,
                jsFrameworks,
                examPractice,
                advancedJSExam,
                courseIntro,
                saintValParty,
                trifonParty;

            openSource = new Hall('Open Source', 110);
            inspiration = new Hall('Inspiration', 220);

            mariya = new Employee('Mariya', 40);
            pesho = new Trainer('Pesho', 20);
            gosho = new Trainer('Gosho', 40);

            feedback = 'I love gosho';
            feedback2 = 'Best lecturer but still has to work on his diction';
            feedback3 = 'Holy moly';
            gosho.addFeedback(feedback);
            gosho.addFeedback(feedback2);
            pesho.addFeedback(feedback3);

            advancedJs = new Course('Advanced JS', 12);
            jsFrameworks = new Course('JS Frameworks', 13);
            pesho.addCourse(advancedJs);
            pesho.addCourse(jsFrameworks);
            gosho.addCourse(jsFrameworks);

            examPractice = new Lecture({
                title: 'Advanced JS Exam Practice',
                type: 'lecture',
                duration: 4,
                date: new Date(2016, 1, 17, 18, 0),
                course: advancedJs,
                trainer: pesho
            });
            advancedJSExam = new Lecture({
                title: 'Advanced JS Exam',
                type: 'lecture',
                duration: 6,
                date: new Date(2016, 1, 21, 9, 0),
                course: advancedJs,
                trainer: pesho
            });
            courseIntro = new Lecture({
                title: 'Course Introduction',
                type: 'lecture',
                duration: 2,
                date: new Date(2016, 1, 22, 18, 0),
                course: jsFrameworks,
                trainer: gosho
            });
            saintValParty = new Party({
                title: 'Saint Valentines',
                type: 'party',
                duration: 6,
                date: new Date(2016, 1, 14, 19, 0),
                isBirthday: false,
                isCatered: false,
                organiser: mariya
            });
            trifonParty = new Party({
                title: 'Trifon Zarezan',
                type: 'party',
                duration: 4,
                date: new Date(2016, 1, 14, 19, 0),
                isBirthday: false,
                isCatered: true,
                organiser: mariya
            });

            openSource.addEvent(examPractice);
            openSource.addEvent(courseIntro);
            inspiration.addEvent(advancedJSExam);
            inspiration.addEvent(saintValParty);
            inspiration.addEvent(trifonParty);
            halls.push(openSource);
            halls.push(inspiration);

            return halls;
        }());
    });