import java.util.Collections;
import java.util.Scanner;
import java.util.TreeSet;

public class Biggest3PrimeNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] numbers = scanner.nextLine().split("[( )]+");
        TreeSet<Integer> primeNumbers = new TreeSet<>(Collections.reverseOrder());
        for (int i = 0; i < numbers.length; i++) {
            if (!numbers[i].isEmpty()) {
                int number = Integer.parseInt(numbers[i]);
                if (isPrime(number)) {
                    primeNumbers.add(number);
                }
            }
        }
        boolean haveEnoughPrimes = false;
        int count = 0;
        int sumOfBiggestPrimes = 0;
        for (Integer primeNumber : primeNumbers) {
            count++;
            sumOfBiggestPrimes+=primeNumber;
            if (count==3){
                haveEnoughPrimes = true;
                break;
            }
        }
        if (haveEnoughPrimes){
            System.out.println(sumOfBiggestPrimes);
        } else {
            System.out.println("No");
        }


    }

    private static boolean isPrime(int number) {
        int boundary = (int)Math.floor(Math.sqrt(number));
        if (number <= 1) {
            return false;
        }
        if (number == 2){
            return true;
        }
        for (int i = 2; i <= boundary; ++i)  {
            if (number % i == 0)  {
                return false;
            }
        }
        return true;
    }
}
