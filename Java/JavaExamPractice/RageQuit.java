import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class RageQuit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine().toUpperCase();
        String textWhiteoutDigits = text.replaceAll("[\\d]+", "");
        Set<Character> uniqueSymbols = new HashSet<>();
        for (int i = 0; i < textWhiteoutDigits.length(); i++) {
            uniqueSymbols.add(textWhiteoutDigits.charAt(i));
        }
        System.out.println("Unique symbols used: " + uniqueSymbols.size());
        Pattern pattern = Pattern.compile("(\\D+)(\\d+)");
        Matcher matcher = pattern.matcher(text);
        while (matcher.find()) {
            int timesToMultiply = Integer.parseInt(matcher.group(2));
            String word = matcher.group(1);
            for (int i = 0; i < timesToMultiply; i++) {
                System.out.print(word);
            }
        }
    }
}
