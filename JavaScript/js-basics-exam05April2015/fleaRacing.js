function solve(input) {
    var numberOfJumps,
        trackLength,
        keys,
        i,
        j,
        currentFlea,
        max,
        audience,
        output,
        winner,
        fleas = {};

    numberOfJumps = Number(input.shift());
    trackLength = Number(input.shift());
    input.forEach(function (fleaInfo) {
        fleaInfo = fleaInfo.split(', ');
        fleas[fleaInfo[0]] = {};
        fleas[fleaInfo[0]].position = 1;
        fleas[fleaInfo[0]].jumpDistance = Number(fleaInfo[1]);
        fleas[fleaInfo[0]].name = fleaInfo[0];
    });
    keys = Object.keys(fleas);
    max = 0;
    audience = new Array(trackLength + 1).join('#');
    winner = findWinner(max);
    console.log(audience + '\n' + audience);
    Object.keys(fleas).forEach(function (key) {
        output = '';
        output += new Array(fleas[key].position).join('.');
        output += fleas[key].name.charAt(0).toUpperCase();
        output += new Array(trackLength - fleas[key].position + 1).join('.');
        console.log(output);
    });
    console.log(audience + '\n' + audience);
    console.log('Winner: ' + winner.name);


    function findWinner(max) {
        var winner;
        for (i = 0; i < numberOfJumps; i++) {
            for (j = 0; j < keys.length; j++) {
                currentFlea = fleas[keys[j]];
                currentFlea.position += currentFlea.jumpDistance;
                if (currentFlea.position >= max) {
                    max = currentFlea.position;
                    winner = currentFlea;
                }
                if (currentFlea.position >= trackLength) {
                    currentFlea.position = trackLength;
                    return currentFlea;
                }
            }
        }
        return winner;
    }
}

// solve(
//     ['3', '5', 'cura, 1', 'Pepi, 1', 'UlTraFlee, 1', 'BOIKO, 1']
// );
// solve(
//     [
//         '10',
//         '19',
//         'angel, 9', 'Boris, 10', 'Georgi, 3', 'Dimitar, 7']
// );