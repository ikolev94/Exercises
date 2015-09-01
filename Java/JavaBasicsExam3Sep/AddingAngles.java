import java.util.Scanner;

public class AddingAngles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int countOfNumbers = scanner.nextInt();
        int[] degrees = new int[countOfNumbers];
        for (int i = 0; i < countOfNumbers; i++) {
            degrees[i] = scanner.nextInt();
        }
        boolean isAny = false;
        for (int i = 0; i < countOfNumbers; i++) {
            for (int j = i + 1; j < countOfNumbers; j++) {
                for (int k = j + 1; k < countOfNumbers; k++) {
                    int sum = degrees[i] + degrees[j] + degrees[k];
                    if (sum % 360 == 0) {
                        System.out.printf("%d + %d + %d = %d degrees\n"
                                , degrees[i]
                                , degrees[j]
                                , degrees[k]
                                , sum);
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