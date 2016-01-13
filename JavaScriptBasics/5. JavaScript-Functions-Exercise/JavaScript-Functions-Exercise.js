function solve(input) {
    var n = Number(input[0]),
        stars = n,
        dots = 0,
        i, j, k,
        output = "";
    for (i = 0; i < n / 2; i++) {
        output += newString('.', dots) + newString('*', stars) + newString('.', dots);
        output += "\n";
        stars -= 2;
        dots++;
    }
    dots--;
    stars += 2;
    for (i = 0; i < n / 2 - 1; i++) {
        dots--;
        stars += 2;
        output += newString('.', dots) + newString('*', stars) + newString('.', dots);
        output += "\n"
    }
    return output;
}

function newString(symbol, count) {
    return new Array(Number(count) + 1).join(symbol);
}
console.log(solve(['7']));