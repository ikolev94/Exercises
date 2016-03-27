function solve(input) {
    var banned = input[input.length - 1].split(' ');
    input.splice(-1);
    var inputLine = input.join('--|--');
    var codes = inputLine.match(/<code>(.+?)<\/code>/g);
    var regex = /#([a-zA-Z][\w]+[a-zA-Z0-9])\b/g;
    var match = regex.exec(inputLine);
    while (match) {
        if (banned.indexOf(match[1]) !== -1) {
            var str = new Array(match[1].length).join('*') + '*';
            inputLine = inputLine.replace(match[0], str);
        } else {
            var link = '<a href="/users/profile/show/' + match[1] + '\">' + match[1] + '</a>';
            inputLine = inputLine.replace(match[0], link);
        }

        match = regex.exec(inputLine)
    }
    var codes2 = inputLine.match(/<code>(.+?)<\/code>/g);
    for (var i = 0; i < codes.length; i++) {
        inputLine = inputLine.replace(codes2[i], codes[i]);
    }
    console.log(inputLine.replace(/--\|--/g, '\n'));
}

solve([
    '#RoYaL: I\'m not sure what you mean,',
    'but I am confident that I\'ve written',
    'everything correctly. Ask #iordan_93',
    'and #pesho if you don\'t believe me',
    '<code>',
    '#trying to print stuff',
    'print("yoo")',
    '</code>',
    '<code>',
    'sssssssss',
    '</code>',
    'pesho gosho']);