import java.util.Arrays;
import java.util.Scanner;

public class PythagoreanNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++) {
            numbers[i] = scanner.nextInt();
        }
        Arrays.sort(numbers);
        boolean isAny = false;
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i; j < numbers.length; j++) {
                for (int k = j; k < numbers.length; k++) {
                    if (numbers[i] * numbers[i] + numbers[j] * numbers[j] == numbers[k] * numbers[k]) {
                        String output = String.format("%1$d*%1$d + %2$d*%2$d = %3$d*%3$d", numbers[i], numbers[j], numbers[k]);
                        System.out.println(output);
                        isAny = true;
                    }
                }
            }
        }
        if (!isAny){
            System.out.println("No");
        }
    }
}
