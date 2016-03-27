function solve(input) {
    var message='',
        magicNumber,
        key,
        matrix = [],
        result = '';

    message += input.splice(0, 1);
    magicNumber = Number(input.splice(0, 1));
    input.forEach(function (line) {
        matrix.push(line.split(' ').map(Number))
    });
    key = findKey(matrix);

    for (var letterIndex = 0; letterIndex < message.length; letterIndex++) {
        if (letterIndex % 2 == 0) {
            result += String.fromCharCode(message[letterIndex].charCodeAt(0) + key);
        } else {
            result += String.fromCharCode(message[letterIndex].charCodeAt(0) - key);
        }
    }
    console.log(result);


    function findKey(matrix) {
        for (var row = 0; row < matrix.length; row++) {
            for (var col = 0; col < matrix[row].length; col++) {
                for (var row2 = 0; row2 < matrix.length; row2++) {
                    for (var col2 = 0; col2 < matrix[row2].length; col2++) {
                        if (row !== row2 || col !== col2) {
                            if (matrix[row][col] + matrix[row2][col2] === magicNumber) {
                                return row + col + row2 + col2;
                            }
                        }
                    }
                }
            }
        }
    }
}

solve([
    'QqdvSpg',
    '400',
    '100 200 120',
    '120 300 310',
    '150 290 370']);
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