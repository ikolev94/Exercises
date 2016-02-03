function solve(input) {
    var encryptedMessage = input[0],
        magicNumber = Number(input[1]),
        matrix = [];
    for (var i = 2; i < input.length; i++) {
        matrix.push(input[i].split(' ').map(function (e) {
            return Number(e);
        }));
    }
    var key = traverseMatrix(),
        output = '';

    for (var letterIndex = 0; letterIndex < encryptedMessage.length; letterIndex++) {
        if (letterIndex % 2 == 0) {
            output += String.fromCharCode(encryptedMessage[letterIndex].charCodeAt(0) + key);
        } else {
            output += String.fromCharCode(encryptedMessage[letterIndex].charCodeAt(0) - key);
        }
    }
    console.log(output);

    function traverseMatrix() {
        for (var row1 = 0; row1 < matrix.length; row1++) {
            for (var col1 = 0; col1 < matrix[row1].length; col1++) {
                for (var row2 = 0; row2 < matrix.length; row2++) {
                    for (var col2 = 0; col2 < matrix[row2].length; col2++) {
                        if (row1 === row2 && col1 === col2) continue;
                        if (matrix[row1][col1] + matrix[row2][col2] === magicNumber) {
                            return row1 + row2 + col1 + col2;
                        }
                    }
                }
            }
        }
    }
}

//solve(['QqdvSpg', '400', '100 200 120', '120 300 310', '150 290 370']);
//
//solve(['Vi`ujr!sihtudts',
//    '0',
//    '0 0 120 300',
//    '100 9 300 100',
//    '1 290 370 100',
//    '10 11 100 550']);
//
//solve(['*<&*)@&*=kdtW',
//    '999',
//    '100 100 120 300 100',
//    '100 900 300 100 100',
//    '100 290 370 333 100',
//    '100 110 666 550 100',
//    '100 110 100 550 100']);