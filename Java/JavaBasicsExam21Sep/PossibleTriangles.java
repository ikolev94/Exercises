import java.util.Arrays;
import java.util.Scanner;

public class PossibleTriangles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String inputLine;
        boolean isAny = false;
        while (!"End".equals(inputLine = scanner.nextLine())) {
            Double[] numbers = Arrays.asList(inputLine.split("\\s+")).stream().map(Double::parseDouble).sorted().toArray(Double[]::new);
            if (numbers[0] + numbers[1] > numbers[2]) {
                System.out.printf("%.2f+%.2f>%.2f%n", numbers[0], numbers[1], numbers[2]);
                isAny =true;
            }
        }
        if (!isAny){
            System.out.println("No");
        }
    }
}
