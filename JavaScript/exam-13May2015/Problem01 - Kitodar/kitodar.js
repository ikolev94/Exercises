function solve(input) {
    var text = input.join('\r\n'),
        pattern = /mine\s+(.+)?\s*-\s+(gold|silver|diamonds)\s*:\s*(\d+)/g,
        info,
        ores = {'gold': 0, 'silver': 0, 'diamonds': 0};
    while (info = pattern.exec(text)) {
        var amount = Number(info[3]);
        switch (info[2]) {
            case'gold':
                ores['gold'] += amount;
                break;
            case'diamonds':
                ores['diamonds'] += amount;
                break;
            case'silver':
                ores['silver'] += amount;
                break;
            default:
                console.log('Error');
        }
    }
    console.log('*Silver: ' + ores['silver']);
    console.log('*Gold: ' + ores['gold']);
    console.log('*Diamonds: ' + ores['diamonds']);
}

solve([ 'mine bobovdol - gold : 10',
    'mine - diamonds : 5',
    'mine colas - wood : 10',
    'mine myMine - silver :  14',
    'mine silver:14 - silver : 14' ]);