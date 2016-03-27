function solve(input) {
    var banned,
        inputLine,
        regex,
        match,
        str,
        link,
        codes2,
        i;

    banned = input[input.length - 1].split(/\s+/);
    input.splice(-1);
    inputLine = input.join('--|--');
    codes = inputLine.match(/<code>(.+?)<\/code>/g) || [];
    regex = /#(\b[a-zA-Z][\w\-]+[a-zA-Z0-9])\b/g;
    match = regex.exec(inputLine);
    while (match) {
        if (banned.indexOf(match[1]) !== -1) {
            str = new Array(match[1].length).join('*') + '*';
            inputLine = inputLine.replace(match[0], str);
        } else {
            link = '<a href="/users/profile/show/' + match[1] + '\">' + match[1] + '</a>';
            inputLine = inputLine.replace(match[0], link);
        }

        match = regex.exec(inputLine)
    }
    codes2 = inputLine.match(/<code>(.+?)<\/code>/g);
    for (i = 0; i < codes.length; i++) {
        inputLine = inputLine.replace(codes2[i], codes[i]);
    }
    console.log(inputLine.replace(/--\|--/g, '\n'));
}

// solve([
//     'The quick, brown fox jumps over a lazy dog.',
//     'DJs flock by when MTV ax quiz prog. Junk MTV',
//     'quiz graced by fox whelps. Bawds jog, flick quartz,',
//     'vex nymphs. #Waltz, bad nymph, for quick jigs vex!',
//     'Fox nymphs grab #1quick-jived waltz. Brick quiz whangs',
//     'jumpy veldt fox. #Bright_ vixens jump; dozy fowl quack. Quick',
//     'wafting zephyrs vex #bold Jim. Quick zephyrs blow, vexing daft Jim.',
//     'Sex-charged fop',
//     'blew my junk TV quiz.',
//     'How quickly daft',
//     'jumping zebras vex. Two driven jocks',
//     'help fax my big quiz. Quick, Baz,',
//     'get my woven flax jodhpurs!',
//     '"Now fax quiz Jack!" my #brave ghost pled.',
//     'brave bold']);

// solve([
//     '#RoYaL: I\'m not sure what you mean,',
//     'but I am confident that I\'ve written',
//     'everything correctly. Ask #iordan_93',
//     'and #pesho if you don\'t believe me',
//     '<code>',
//     '#trying to print stuff',
//     'print("yoo")',
//     '</code>',
//     '<code>',
//     'sssssssss',
//     '</code>',
//     'pesho gosho']);