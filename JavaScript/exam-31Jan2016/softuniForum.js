function solve(input) {
var regex = /#([a-zA-Z][\w-]+[a-zA-Z0-9])(?:[! ,:?.-;]|\b)/g;
var banned = input[input.length - 1].split(' ');
var isCode = false;
for (var i = 0; i < input.length - 1; i++) {

    if (input[i].indexOf('<code>') !== -1) {
        isCode = true;
    }
    if (isCode && input[i].indexOf('</code>') !== -1) {
        isCode = false;
    }
    if (isCode) {
        console.log(input[i]);
        continue;
    }
    var math = regex.exec(input[i]);
    while (math) {
        if (banned.indexOf(math[1]) !== -1) {
            var str = new Array(math[1].length).join('*') + '*';
            input[i] = input[i].replace('#' + math[1], str);
            math = regex.exec(input[i]);
            continue;
        }
        var link = '<a href="/users/profile/show/' + math[1] + '\">' + math[1] + '</a>';
        input[i] = input[i].replace('#' + math[1], link);
        math = regex.exec(input[i]);
    }
    console.log(input[i]);
}
}

//solve(['pesho gosho']);
//solve(['#RoYaL: I<code>m not#pesho: sure</code> what you mean,',
//    'but I am confident that I\'ve written',
//    'everything correctly. Ask #iordan_93',
//    'and #pesho if you don\'t believe me',
//    '<code>',
//    '#trying to print stuff',
//    'print("yoo")',
//    '</code>',
//    'pesho gosho']);