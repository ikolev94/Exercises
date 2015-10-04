import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ValidUsernames {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("\\b[A-Za-z]\\w{2,24}\\b");
        List<String> names = new ArrayList<>();
        Matcher matcher = pattern.matcher(scanner.nextLine());
        while (matcher.find()) {
            names.add(matcher.group());
        }

        int indexOfFirstName = 0;
        int maxLength = 0;
        for (int i = 1; i < names.size(); i++) {
            int currentLength = names.get(i - 1).length() + names.get(i).length();
            if (currentLength > maxLength) {
                maxLength = currentLength;
                indexOfFirstName = i - 1;
            }
        }
        System.out.println(names.get(indexOfFirstName));
        System.out.println(names.get(indexOfFirstName + 1));
    }
}
