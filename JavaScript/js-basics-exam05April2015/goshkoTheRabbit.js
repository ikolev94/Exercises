function solve(input) {
    var directions,
        matrix = [],
        hitWallsCount = 0,
        col = 0,
        row = 0,
        visitedCells = [],
        newCell,
        match,
        data = {"&": 0, "*": 0, "#": 0, "!": 0, "wall hits": 0};

    directions = input.shift().split(', ');
    input.forEach(function (line) {
        matrix.push(line.split(', '));
    });
    for (var i = 0; i < directions.length; i++) {
        newCell = true;
        switch (directions[i]) {
            case 'up':
                row--;
                if (row < 0) {
                    row = 0;
                    data['wall hits']++;
                    newCell = false;
                }
                break;
            case 'down':
                row++;
                if (row >= matrix.length) {
                    row--;
                    data['wall hits']++;
                    newCell = false;
                }
                break;
            case 'right':
                col++;
                if (!matrix[row][col]) {
                    col--;
                    data['wall hits']++;
                    newCell = false;
                }
                break;
            case'left':
                col--;
                if (!matrix[row][col]) {
                    col++;
                    data['wall hits']++;
                    newCell = false;
                }
                break;
        }
        if (newCell) {
            match = matrix[row][col].match(/#|\*|&|!/g) || [];
            match.forEach(function (veg) {
                data[veg]++;
            });
            matrix[row][col] = matrix[row][col].replace(/{#}|{\*}|{&}|{!}/g, '@');
            visitedCells.push(matrix[row][col]);
        }
    }
    console.log(JSON.stringify(data));
    if (visitedCells.length) {
        console.log(visitedCells.join('|'));
    } else {
        console.log('no');
    }

}

// solve(['right, up, up, down',
//     'asdf, as{#}aj{g}{}dasd, kjldk{}fdffd, jdflk{#}jdfj',
//     'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
//     'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']);

// solve(['up, right, left, down', 'as{!}xnk']);