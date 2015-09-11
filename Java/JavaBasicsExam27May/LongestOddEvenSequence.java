import java.util.Scanner;

public class LongestOddEvenSequence {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] numbersAsString = scanner.nextLine().replace(" ", "").replace("(", "").split("\\)");
        int[] numbers = new int[numbersAsString.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(numbersAsString[i]);
        }
        int count = 0;
        int max = 0;
        boolean shouldItBe = numbers[0] % 2 != 0;
        for (int i = 0; i < numbers.length; i++) {
            if (isOdd(numbers[i]) == shouldItBe || numbers[i] == 0) {
                count++;
            } else {
                shouldItBe = isOdd(numbers[i]);
                count = 1;
            }
            shouldItBe = !shouldItBe;
            if (count > max) {
                max = count;
            }

        }
        System.out.println(max);
    }

    private static boolean isOdd(int number) {
        if (number % 2 == 0)
            return true;
        return false;
    }
}
