function solve(input) {
    var matrix = [],
        outputMatrix = [];
    for (var i = 0; i < input.length; i++) {
        matrix[i] = input[i].toLowerCase().split('');
        outputMatrix[i] = input[i].split('');
    }
    for (var row = 0; row < matrix.length; row++) {
        for (var col = 0; col < matrix[row].length; col++) {
            if (matrix[row + 1] !== undefined &&matrix[row-1]&& matrix[row][col - 1] !== undefined
                && matrix[row][col + 1] !== undefined) {
                if (matrix[row][col] === matrix[row][col + 1] && matrix[row][col] === matrix[row][col - 1]
                    && matrix[row][col] === matrix[row + 1][col] && matrix[row][col] === matrix[row - 1][col]) {
                    outputMatrix[row][col] = '';
                    outputMatrix[row][col + 1] = '';
                    outputMatrix[row][col - 1] = '';
                    outputMatrix[row + 1][col] = '';
                    outputMatrix[row - 1][col] = '';
                }
            }
        }
    }
    for (var j = 0; j < outputMatrix.length; j++) {
        console.log(outputMatrix[j].join(''));
    }
}

//solve([
//    '888**t*',
//    '8888ttt',
//    '888ttt<<',
//    '*8*0t>>hi'
//]);
//solve(
//    [
//        'ab**l5',
//        'bBb*555',
//        'absh*5',
//        'ttHHH',
//        'ttth'
//    ]);

//solve([ '@s@a@p@una',
//    'p@@@@@@@@dna',
//    '@6@t@*@*ego',
//    'vdig*****ne6',
//    'li??^*^*' ]);