import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Pyramid {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        int first = scanner.nextInt();
        scanner.nextLine();
        List<Integer> result = new ArrayList<>();
        result.add(first);
        for (int i = 1; i < n; i++) {
            String line = scanner.nextLine();
            line = line.replaceAll("\\s+", " ").trim();
            List<Integer> nums = Arrays.asList(line.split(" ")).stream().map(Integer::parseInt).sorted().collect(Collectors.toList());
            boolean isAny = false;
            for (Integer num : nums) {
                if (num > first) {
                    result.add(num);
                    first = num;
                    isAny = true;
                    break;
                }
            }
            if (!isAny) {
                first++;
            }
        }
        System.out.println(String.join(", ", result.stream().map(Object::toString).collect(Collectors.toList())));

    }
}
