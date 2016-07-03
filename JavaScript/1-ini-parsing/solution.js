var fs = require('fs'),
	request = require('request'),
	fileToOpen = process.argv[2],
	isRemote = /http/.test(fileToOpen),
	extension = fileToOpen.split('.').pop();

function iniToJSON(iniText) {
	var result = {},
		args = [],
		currentKey,
		allLines = iniText.split(/\r|\n/g);
	allLines.forEach(function(line) {
		line = line.trim();
		if (line && line.charAt(0) !== ';') {
			args = line.split(/\[|\]/);
			if (args.length === 3) {
				currentKey = args[1];
				result[currentKey] = {};
			} else if (args.length === 1) {
				var params = line.split(/\s*=\s*/);
				result[currentKey][params[0]] = params[1];
			}
		};
	})

	return JSON.stringify(result);
}

function JSONtoIni(jsonText) {
	var obj = JSON.parse(jsonText),
		result = '';

	Object.keys(obj).forEach(function(key) {
		result += '[' + key + ']';
		Object.keys(obj[key]).forEach(function(innerKey) {
			result += '\n\r' + innerKey + '=' + obj[key][innerKey];
		})
		result += '\n\r';
	})

	return result;
}

function choseFormat(data) {
	if (extension === 'ini') {
		writeFile(iniToJSON(data), 'ini', 'json');
	} else if (extension === 'json') {
		writeFile(JSONtoIni(data), 'json', 'ini');
	};
}

function writeFile(data, replaceFrom, replaceTo) {
	var fileName = isRemote ? fileToOpen.substring(fileToOpen.lastIndexOf('/') + 1) : fileToOpen
	fs.writeFileSync(fileName.replace(replaceFrom, replaceTo), data);
}

if (isRemote) {
	request.get(fileToOpen, function(error, response, body) {
		choseFormat(body);
	});
} else {
	fs.readFile(fileToOpen, 'utf8', function(err, data) {
		if (err) throw err;
		choseFormat(data);
	})
}