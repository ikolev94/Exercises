function solve(input) {
    var sentencesWithWords = input[0],
        words = input[0].replace(/\.|!|\?/g, '').split(' '),
        sentences = input[1].split(/\.|!|\?/g),
        obviousWord = [],
        symbols = input[1].match(/(\.|\?|!)/g),
        wordsCounter = {};

    for (var i = 0; i < words.length; i++) {
        var currentWord = words[i].trim().toLowerCase();
        if (!wordsCounter[currentWord]) {
            wordsCounter[currentWord] = 0;
        }
        wordsCounter[currentWord]++;
    }

    var keys = Object.keys(wordsCounter);
    for (var j = 0; j < keys.length; j++) {
        if (wordsCounter[keys[j]] >= 3) {
            obviousWord.push(keys[j]);
        }
    }

    if (!obviousWord.length) {
        console.log('No words');
        return;
    }
    for (var k = 0; k < sentences.length; k++) {
        for (var r = 0; r < obviousWord.length; r++) {
            var word = obviousWord[r];
            if (sentences[k].toLocaleLowerCase().indexOf(word) !== -1) {
                console.log(sentences[k].trim() + symbols[k]);
                break;
            }
        }
    }
}


//solve(['Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!',
//    'The captain  walwasking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know.']);