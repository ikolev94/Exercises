import java.util.*;

public class MirrorNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String[] numbers = scanner.nextLine().split("\\s+");
        boolean isAny = false;
        HashSet<String> uniqueNumbers = new HashSet<>();
        for (int i = 0; i < n; i++) {
            String currentNumber = numbers[i];
            String reversedCurrentNumber = new StringBuffer(currentNumber).reverse().toString();

            for (String number : numbers) {
                if (number.equals(reversedCurrentNumber)
                        && !number.equals(currentNumber)
                        && !uniqueNumbers.contains(number)
                        && !uniqueNumbers.contains(currentNumber)) {
                    System.out.println(currentNumber + "<!>" + number);
                    uniqueNumbers.add(number);
                    uniqueNumbers.add(currentNumber);
                    isAny = true;
                }
            }
        }
        if (!isAny) {
            System.out.println("No");
        }
    }
}
