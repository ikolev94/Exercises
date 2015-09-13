import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SimpleExpression {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("[\\d.]+|[+\\-]");
        Matcher matcher = pattern.matcher(scanner.nextLine());
        List<String> words = new ArrayList<>();
        while (matcher.find()) {
            words.add(matcher.group());
        }
        BigDecimal sum = new BigDecimal(words.get(0));

        for (int i = 1; i < words.size(); i += 2) {
            BigDecimal number = new BigDecimal(words.get(i+1));
            if (words.get(i).equals("-")) {
               sum = sum.subtract(number);
            } else {
                sum = sum.add(number);
            }
        }
        System.out.println(sum);

    }
}
