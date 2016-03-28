function solve(input) {
    var data = [];
    input.forEach(function (line) {
        var args = line.trim().split(/\s*:\s*/);
        var names = args[0].split(/\s*vs.\s*/).map(function (name) {
            return name.replace(/\s+/, ' ');
        });
        var results = args[1].trim().split(/\s+/);

        var player1 = data.filter(function (p) {
            return p.name === names[0];
        })[0];

        var player2 = data.filter(function (p) {
            return p.name === names[1];
        })[0];

        if (!player1) {
            data.push({
                name: names[0],
                matchesWon: 0,
                matchesLost: 0,
                setsWon: 0,
                setsLost: 0,
                gamesWon: 0,
                gamesLost: 0
            });
            player1 = data.filter(function (p) {
                return p.name === names[0];
            })[0];
        }
        if (!player2) {
            data.push({
                name: names[1],
                matchesWon: 0,
                matchesLost: 0,
                setsWon: 0,
                setsLost: 0,
                gamesWon: 0,
                gamesLost: 0
            });
            player2 = data.filter(function (p) {
                return p.name === names[1];
            })[0];
        }

        var p1gamesWon = 0;
        var p1gamesLost = 0;
        var p1setsWon = 0;
        var p1setsLost = 0;
        var p2gamesWon = 0;
        var p2gamesLost = 0;
        var p2setsWon = 0;
        var p2setsLost = 0;

        results.forEach(function (r) {
            var results = r.split('-');
            var player1Result = Number(results[0]);
            var player2Result = Number(results[1]);
            if (player1Result > player2Result) {
                p1setsWon++;
                p2setsLost++;
            } else {
                p1setsLost++;
                p2setsWon++;
            }
            p1gamesWon += player1Result;
            p1gamesLost += player2Result;

            p2gamesWon += player2Result;
            p2gamesLost += player1Result;
        });

        if (p1setsWon > p2setsWon) {
            player1.matchesWon++;
            player2.matchesLost++;
        } else {
            player1.matchesLost++;
            player2.matchesWon++;
        }
        player1.setsWon += p1setsWon;
        player2.setsWon += p2setsWon;
        player1.setsLost += p1setsLost;
        player2.setsLost += p2setsLost;

        player1.gamesWon += p1gamesWon;
        player2.gamesWon += p2gamesWon;
        player1.gamesLost += p1gamesLost;
        player2.gamesLost += p2gamesLost;
    });

    data.sort(function (a, b) {
        if (a.matchesWon !== b.matchesWon) {
            return b.matchesWon - a.matchesWon;
        }
        if (a.setsWon !== b.setsWon) {
            return b.setsWon - a.setsWon;
        }
        if (a.gamesWon !== b.gamesWon) {
            return b.gamesWon - a.gamesWon;
        }
        return a.name.localeCompare(b.name);
    });
    console.log(JSON.stringify(data));
    // })
}

// solve([
//     'Novak Djokovic vs. Roger Federer : 6-3 6-3',
//     'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3',
//     'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7',
//     'Andy Murray vs. David Ferrer : 6-4 7-6',
//     'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7',
//     'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2',
//     'Pete Sampras vs. Andre Agassi : 2-1',
//     'Boris Beckervs.Andre        \t\t\tAgassi:2-1']);