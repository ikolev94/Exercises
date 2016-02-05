var button = document.getElementsByClassName('button')[0];

button.onclick = function () {
    var firstCol = sumCol(document.getElementsByClassName("firstColumn"));

    var secondCol = sumCol(document.getElementsByClassName("secondColumn"));

    var thirdCol = sumCol(document.getElementsByClassName("thirdColumn"));

    if (!document.getElementById('resultsRow')) {
        appendTr(firstCol, secondCol, thirdCol);
    } else {
        document.getElementById('firstColResult').innerText = firstCol;
        document.getElementById('secondColResult').innerText = secondCol;
        document.getElementById('thirdColResult').innerText = thirdCol;
    }

    var firstRow = document.getElementById('firstRow');
    var firstRowResult = document.getElementById('firstRowResult');
    if (!firstRowResult) {
        appendTd(firstRow, sumRow(firstRow));
    } else {
        firstRowResult.innerText = sumRow(firstRow);
    }

    var secondRow = document.getElementById('secondRow');
    var secondRowResult = document.getElementById('secondRowResult');
    if (!secondRowResult) {
        appendTd(secondRow, sumRow(secondRow));
    } else {
        secondRowResult.innerText = sumRow(secondRow);
    }

    var thirdRow = document.getElementById('thirdRow');
    var thirdRowResult = document.getElementById('thirdRowResult');
    if (!thirdRowResult) {
        appendTd(thirdRow, sumRow(thirdRow));
    } else {
        thirdRowResult.innerText = sumRow(thirdRow);
    }
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

function appendTr(col1, col2, col3) {
    var body = document.getElementsByTagName('tbody')[0];
    var tr = document.createElement('tr');

    var first = document.createElement('td');
    var second = document.createElement('td');
    var third = document.createElement('td');

    first.innerText = col1;
    first.id = 'firstColResult';
    first.className = 'result';
    second.innerText = col2;
    second.id = 'secondColResult';
    second.className = 'result';
    third.innerText = col3;
    third.id = 'thirdColResult';
    third.className = 'result';

    tr.appendChild(first);
    tr.appendChild(second);
    tr.appendChild(third);
    tr.id = 'resultsRow';
    body.insertBefore(tr, body.childNodes[body.childNodes.length - 2]);
}

function appendTd(row, result) {
    var td = document.createElement('td');
    td.id = row.id + 'Result';
    td.className = 'result';
    td.innerText = result;
    row.appendChild(td);
}