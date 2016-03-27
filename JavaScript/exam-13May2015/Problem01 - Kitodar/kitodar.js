function solve(input) {
    var shards = {Silver: 0, Gold: 0, Diamonds: 0};
    input.forEach(function (line) {
        if (/-/.test(line)) {
            var args = line.split(/-\s+/)[1].split(/\s+:\s+/);
            var type = args[0];
            var amount = Number(args[1]);
            switch (type) {
                case 'gold':
                    shards.Gold += amount;
                    break;
                case 'silver':
                    shards.Silver += amount;
                    break;
                case 'diamonds':
                    shards.Diamonds += amount;
                    break;
            }
        }
    });
    console.log('*Silver: %d\n*Gold: %d\n*Diamonds: %d\n', shards.Silver, shards.Gold, shards.Diamonds);
}

solve(['mine bobovdol - gold : 10',
    'mine - diamonds : 5',
    'mine colas - wood : 10',
    'mine myMine - silver :  14',
    'mine silver:14 - silver : 14']);