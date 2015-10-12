import java.util.Scanner;

public class PrimeGenerator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        for (int i = 0; i < n; i++) {
            int first = scanner.nextInt();
            int last = scanner.nextInt();
            for (int j = first; j <= last; j++) {
                if (isPrime(j)) System.out.println(j);
            }
            System.out.println();
        }
    }

    private static boolean isPrime(int number) {
        int boundary = (int) Math.floor(Math.sqrt(number));
        if (number <= 1) {
            return false;
        }
        if (number == 2) {
            return true;
        }
        for (int i = 2; i <= boundary; ++i) {
            if (number % i == 0) {
                return false;
            }
        }
        return true;
    }
}
