function solve(input) {
    var count = 1, sequenceLength, matrix = [], line = [], output = [];
    sequenceLength = Number(input[input.length - 1]);
    for (var i = 0; i < input.length - 1; i++) {
        var obj = input[i].split(/\s+/g);
        matrix[i] = obj;
        line = line.concat(obj)
    }
    for (var j = 1; j < line.length; j++) {
        if (line[j] === line[j - 1]) {
            count++;
            if (count === sequenceLength) {
                for (k = j - sequenceLength + 1; k <= j; k++) {
                    line[k] = 'remove';
                }
                count = 1;
            }
        } else {
            count = 1
        }
    }
    count = 0;
    for (var row = 0; row < matrix.length; row++) {
        for (var col = 0; col < matrix[row].length; col++) {
            if (line[count++] !== 'remove') {
                output.push(matrix[row][col])
            }
        }
        if (output.length) {
            console.log(output.join(' '));
            output = [];
        } else {
            console.log('(empty)');
        }

    }
}

solve(
    [
        '3 3 3 2 5 9 9 9 9 1 2',
        '1 1 1 1 1 2 5 8 1 1 7 7',
        '7 1 2 3 5 7 4 4 1 2',
        '2'
    ]);