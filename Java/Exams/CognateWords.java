import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CognateWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        Pattern pattern = Pattern.compile("[A-Za-z]+");
        Matcher matcher = pattern.matcher(text);
        List<String> words = new ArrayList<>();
        while (matcher.find()) {
            words.add(matcher.group());
        }
        Set<String> unique = new HashSet<>();
        for (int i = 0; i < words.size(); i++) {
            for (int j = 0; j < words.size(); j++) {
                if (i == j) continue;
                String combination = words.get(i) + words.get(j);
                for (int k = 0; k < words.size(); k++) {
                    if (k == i || k == j) continue;
                    if (words.get(k).equals(combination)) {
                        unique.add(words.get(i) + "|" + words.get(j) + "=" + words.get(k));
                    }
                }
            }
        }
        if (unique.isEmpty()) {
            System.out.println("No");
        } else {
            unique.forEach(System.out::println);
        }
    }
}
