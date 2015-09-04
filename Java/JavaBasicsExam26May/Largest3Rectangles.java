import java.util.Scanner;

public class Largest3Rectangles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String rectangles = scanner.nextLine();
        rectangles = rectangles.replace("[", "");
        rectangles = rectangles.replace(" ", "");

        String[] rectanglesArgs = rectangles.split("]");
        int[] areas = new int[rectanglesArgs.length];
        for (int i = 0; i < rectanglesArgs.length; i++) {
            String[] rect = rectanglesArgs[i].split("x");
            int currentSum = Integer.parseInt(rect[0]) * Integer.parseInt(rect[1]);
            areas[i] = currentSum;
        }
        int maxSum = Integer.MIN_VALUE;
        for (int i = 0; i < areas.length - 2; i++) {
            int sum = areas[i] + areas[i + 1] + areas[i + 2];
            if (sum > maxSum){
                maxSum = sum;
            }
        }
        System.out.println(maxSum);
    }
}
