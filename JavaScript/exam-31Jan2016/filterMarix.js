function solve(input) {

    var num = Number(input[input.length - 1]);
    input.splice(-1, 1);

    var allSymbols = [];
    var matrix = [];

    for (var row = 0; row < input.length; row++) {
        var line = input[row].split(' ');
        matrix.push(line);

        for (var n = 0; n < line.length; n++) {
            allSymbols.push(line[n]);
        }
    }

    var count = 1;
    for (var j = 1; j < allSymbols.length; j++) {
        if (allSymbols[j] === allSymbols[j - 1]) {
            count++;
            if (count === num) {
                for (var i = 0; i < num; i++) {
                    allSymbols[j - i] = 'remove'
                }
                count = 1;
                j++;
            }
        } else {
            count = 1;
        }
    }

    var index = 0;
    for (var r = 0; r < matrix.length; r++) {
        var currentRow = [];
        for (var c = 0; c < matrix[r].length; c++) {
            if (allSymbols[index++] !== 'remove') {
                currentRow.push(matrix[r][c]);
            }
        }

        currentRow.length > 0 ? console.log(currentRow.join(' ')) : console.log('(empty)');
    }

}

solve(
    [
        '3 3 3 2 5 9 9 9 9 1 2',
        '1 1 1 1 1 2 5 8 1 1 7 7',
        '7 1 2 3 5 7 4 4 1 2',
        '2'
    ]);