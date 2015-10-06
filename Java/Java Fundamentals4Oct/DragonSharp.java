import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class problem04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        Pattern pattern = Pattern.compile("\"([\\S\\s]*)\"(?=;)");
        ArrayList<String> text = new ArrayList<>();
        ArrayList<String> words = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            text.add(scanner.nextLine());
            Matcher matcher2 = pattern.matcher(text.get(i));
            if (!matcher2.find() || !text.get(i).contains("out")) {
                System.out.printf("Compile time error @ line %d", i + 1);
                return;
            }
            words.add(matcher2.group(1));
        }
        boolean hasElse = false;
        for (int i = 0; i < n; i++) {
            String input = text.get(i);
            String[] inputArgs = input.split("\\s+");
            String first = inputArgs[0];
            if (first.equals("if")) {
                hasElse = false;
                String condition = inputArgs[1];
                if (testCondition(condition)) {
                    if (inputArgs[2].equals("loop")) {
                        int times = Integer.parseInt(inputArgs[3]);
                        for (int j = 0; j < times; j++) {
                            System.out.println(words.get(i));
                        }
                    } else {
                        System.out.println(words.get(i));
                    }
                } else {
                    hasElse = true;
                }
            } else {
                if (first.equals("else") && hasElse) {
                    if (inputArgs[1].equals("loop")) {
                        int times = Integer.parseInt(inputArgs[2]);
                        for (int j = 0; j < times; j++) {
                            System.out.println(words.get(i));
                        }
                    } else {
                        System.out.println(words.get(i));
                    }
                }
            }
        }
    }

    private static boolean testCondition(String condition) {
        String[] numbers = condition.replaceAll("[()]", "").replaceAll("[^\\d-]+", " ").split(" ");
        long a = Long.parseLong(numbers[0]);
        long b = Long.parseLong(numbers[1]);
        if (condition.contains("==")) return a == b;

        if (condition.contains("<")) return a < b;

        return condition.contains(">") && a > b;
    }
}
