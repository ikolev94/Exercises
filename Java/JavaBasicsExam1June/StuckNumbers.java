import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class StuckNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        List<String> numbers = Arrays.asList(scanner.nextLine().split(" "));
        boolean isAny = false;
        for (String number : numbers) {
            for (String s : numbers) {
                for (String number1 : numbers) {
                    for (String number2 : numbers) {
                        if (number.equals(s)
                                ||number.equals(number1)
                                ||number.equals(number2)
                                ||s.equals(number1)
                                ||s.equals(number2)
                                ||number1.equals(number2)) continue;
                        if ((number + s).equals(number1 + number2)) {
                            System.out.println(number + "|" + s + "==" + number1 + "|" + number2);
                            isAny= true;
                        }
                    }
                }
            }
        }
        if (!isAny){
            System.out.println("No");
        }
    }
}
