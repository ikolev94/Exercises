function solve(input) {
    for (var i = 0; i < input.length; i++) {
        var inputArgs = input[i].split(' '),
            car = inputArgs[0],
            fuel = inputArgs[1],
            routeNumber = inputArgs[2],
            luggageWeight = Number(inputArgs[3]),
            totalConsumption,
            extraSnowConsumption,
            consummation = 10;
        switch (fuel) {
            case 'gas':
                consummation = 12;
                break;
            case 'diesel':
                consummation = 8;
                break;
        }
        consummation += luggageWeight * 0.01;
        var extraSnow = 0.3 * consummation;
        var output = car + ' ' + fuel + ' ' + routeNumber + ' ';
        if (routeNumber == 1) {
            totalConsumption = 110 * (consummation / 100);
            extraSnowConsumption = 10 * (extraSnow / 100);
            output += (totalConsumption + extraSnowConsumption).toFixed(0);
        } else {
            totalConsumption = 95 * (consummation / 100);
            extraSnowConsumption = 30 * (extraSnow / 100);
            output += (totalConsumption + extraSnowConsumption).toFixed(0);
        }
        console.log(output);
    }
}

//solve(['BMW petrol 1 320.5',
//    'Golf petrol 2 150.75',
//    'Lada gas 1 202',
//    'Mercedes diesel 2 312.54']);