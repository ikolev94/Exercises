function solve(input) {
    if (!input.length) return;

    var field = [],
        output = '',
        startRow = 0;
    for (var row = 0; row < input.length; row++) {
        field[row] = input[row].split('');
        if (input[row].indexOf('o') !== -1) {
            startRow = row;
        }
    }
    var currentCol = field[startRow].indexOf('o');
    for (var currentRow = startRow + 1; currentRow < field.length; currentRow++) {
        currentCol += windSpeedCalc(input[currentRow]);
        var currentCell = field[currentRow][currentCol];
        if (currentCell === '_') {
            output += 'Landed on the ground like a boss!';
            break;
        } else if (currentCell === '~') {
            output += 'Drowned in the water like a cat!';
            break;
        } else if (currentCell === '/' || currentCell === '|' || currentCell === '\\') {
            output += 'Got smacked on the rock like a dog!';
            break;
        }
    }

    console.log(output + '\r\n' + currentRow + ' ' + currentCol);

    function windSpeedCalc(line) {
        var left = (line.match(/</g) || []).length;
        var right = (line.match(/>/g) || []).length;
        return right - left;
    }
}

solve([
    '--o----------------------',
    '>------------------------',
    '>------------------------',
    '>-----------------/\\-----',
    '-----------------/--\\----',
    '>---------/\\----/----\\---',
    '---------/--\\--/------\\--',
    '<-------/----\\/--------\\-',
    '\\------/----------------\\',
    '-\\____/------------------']
);