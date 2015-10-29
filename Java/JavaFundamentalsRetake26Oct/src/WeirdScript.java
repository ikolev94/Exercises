import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int keyNumber = Integer.parseInt(scanner.nextLine()) - 1;
        char keyChar = (char) ((keyNumber % 26) + 'a');
        if ((keyNumber / 26) % 2 == 1) {
            keyChar = Character.toUpperCase(keyChar);
        }
        String key = "" + keyChar + keyChar;
        StringBuilder text = new StringBuilder();
        String line;
        Pattern pattern = Pattern.compile(key + "(.+?)" + key);
        while (!(line = scanner.nextLine()).equals("End")) {
            text.append(line);
        }

        Matcher matcher = pattern.matcher(text.toString());
        while (matcher.find()) {
            if (matcher.group(1).length() > 0) {
                System.out.println(matcher.group(1));
            }
        }

    }
}
