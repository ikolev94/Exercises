import java.math.BigDecimal;
import java.util.*;

public class ThreeLargestNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        BigDecimal[] numbers = new BigDecimal[n];
        for (int i = 0; i < n; i++) {
            String numberAsString = scanner.nextLine();
            numbers[i] = new BigDecimal(numberAsString);
        }
        Arrays.sort(numbers);
        int count = 3;
        for (int i = numbers.length-1; i >= 0 && count > 0; i--, count--) {
            System.out.println(numbers[i].toPlainString());
        }
    }
}
