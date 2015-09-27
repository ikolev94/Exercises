import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine().replaceAll("[\\s()|/\\\\]+", "");
        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher matcher = pattern.matcher(text);
        List<String> words = new ArrayList<>();
        List<Integer> wordsWeights = new ArrayList<>();
        while (matcher.find()) {
            words.add(matcher.group());
            wordsWeights.add(getWordWeight(matcher.group()));
        }
        int maxWeight = 0;
        int indexOfFirstWord = 0;
        for (int i = 1; i < wordsWeights.size(); i++) {
            int currentWeight = wordsWeights.get(i - 1) + wordsWeights.get(i);
            if (currentWeight > maxWeight) {
                maxWeight = currentWeight;
                indexOfFirstWord = i - 1;
            }
        }
        System.out.println(words.get(indexOfFirstWord));
        System.out.println(words.get(indexOfFirstWord + 1));
    }

    private static int getWordWeight(String word) {
        int wordWeight = 0;
        for (int i = 0; i < word.length(); i++) {
            char currentLetter = word.toLowerCase().charAt(i);
            wordWeight += currentLetter - 'a' + 1;
        }
        return wordWeight;
    }
}
