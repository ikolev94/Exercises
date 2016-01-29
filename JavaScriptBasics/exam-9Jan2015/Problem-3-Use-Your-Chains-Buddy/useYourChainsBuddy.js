function solve(input) {
    var myRegexp = /<p>(.+?[\n]*)<\/p>/g,
        output = '',
        textA = myRegexp.exec(input[0]);
    while (textA != null) {
        var text = textA[1].replace(/[A-Z\W]+/g, ' ').split('');
        for (var symbolIndex = 0; symbolIndex < text.length; symbolIndex++) {
            var symbol = text[symbolIndex];
            if (!isNaN(symbol) || symbol === ' ') {
                output += symbol;
                continue;
            }
            var asciiValue = symbol.charCodeAt();
            asciiValue < 'n'.charCodeAt() ? asciiValue += 13 : asciiValue -= 13;
            output += String.fromCharCode(asciiValue);
        }
        textA = myRegexp.exec(input[0]);
    }
    console.log(output);
}

//solve(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);

//solve(['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj punvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf </p><div>It is frustrating that you have not put car chains yet... Embarrassing...</div><p>orsber lbh ernpu fabjl ebnqf lbh jvyy znxr lbhe yvsr jnl rnfvre</p></body>']);