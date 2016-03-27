function solve(input) {
    var coins = 0;
    input.forEach(function (line) {
        var coinArgs = line.split(' ');
        var type = coinArgs[0].toLowerCase();
        var amount = Number(coinArgs[1]);
        if (amount % 1 === 0 && amount > 0 && type === 'coin') {
            coins += amount;
        }
    });
    console.log('gold : %d\nsilver : %d\nbronze : %d'
        , Math.floor(coins / 100)
        , Math.floor((coins % 100) / 10)
        , Math.floor((coins % 10)));
}

solve(['Coin 1',
    'coin 2',
    'coin 5',
    'coin 10',
    'coin 20',
    'coin 50',
    'coin 100',
    'coin 200',
    'coin 500',
    'cigars 1']
);