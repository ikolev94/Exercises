import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class PlayingWhitLambda {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = Arrays.asList(scanner.next().split("\\s+"))
                .stream()
                .map(Integer::parseInt)
                .filter(number -> number > 0)
                .distinct()
                .sorted(Comparator.<Integer>reverseOrder())
                .collect(Collectors.toList());

        System.out.println(String.join(", ", numbers.stream()
                .map(Object::toString)
                .collect(Collectors.toList())));
    }
}
