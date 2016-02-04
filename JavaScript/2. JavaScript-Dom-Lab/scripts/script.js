var button = document.getElementsByClassName('button')[0];

button.onclick = function () {
    var firstCol = document.getElementsByClassName("firstColumn");
    document.getElementById('firstColResult').innerText = sumCol(firstCol);

    var secondCol = document.getElementsByClassName("secondColumn");
    document.getElementById('secondColResult').innerText = sumCol(secondCol);

    var thirdCol = document.getElementsByClassName("thirdColumn");
    document.getElementById('thirdColResult').innerText = sumCol(thirdCol);

    var firstRow = document.getElementById('firstRow');
    document.getElementById('firstRowResult').innerText = sumRow(firstRow);

    var secondRow = document.getElementById('secondRow');
    document.getElementById('secondRowResult').innerText = sumRow(secondRow);

    var thirdRow = document.getElementById('thirdRow');
    document.getElementById('thirdRowResult').innerText = sumRow(thirdRow);
};

function sumRow(row) {
    var td = row.children;
    var a = Number(td[0].children[0].value);
    var b = Number(td[1].children[0].value);
    var c = Number(td[2].children[0].value);
    var rowSum = a + b + c;
    var isEmpty = (a === 0 && b === 0 && c === 0);
    if (isNaN(rowSum) || isEmpty) {
        return 'Wrong Input';
    } else {
        return rowSum;
    }
}

function sumCol(col) {

    var a = Number(col[0].value);
    var b = Number(col[1].value);
    var c = Number(col[2].value);
    var colSum = a + b + c;
    var isEmpty = (a === 0 && b === 0 && c === 0);
    if (isNaN(colSum) || isEmpty) {
        return 'Wrong input';
    } else {
        return colSum;
    }
}