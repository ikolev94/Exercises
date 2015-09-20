import java.util.Scanner;

public class Durts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int centreX = scanner.nextInt();
        int centreY = scanner.nextInt();
        int radius = scanner.nextInt();
        int n = scanner.nextInt();
        scanner.nextLine();
        for (int i = 0; i < n; i ++) {
            int shotX = scanner.nextInt();
            int shotY = scanner.nextInt();
            if (isInHorizontal(centreX, centreY, radius, shotX, shotY) || isInVertical(centreX, centreY, radius, shotX, shotY)) {
                System.out.println("yes");
            } else {
                System.out.println("no");
            }
        }
    }

    private static boolean isInHorizontal(int centreX, int centreY, int radius, int shotX, int shotY) {
        return shotX >= centreX - radius && shotX <= centreX + radius
                && shotY <= centreY + radius / 2 && shotY >= centreY - radius / 2;
    }

    private static boolean isInVertical(int centreX, int centreY, int radius, int shotX, int shotY) {
        return shotX >= centreX - radius / 2 && shotX <= centreX + radius / 2
                && shotY <= centreY + radius && shotY >= centreY - radius;
    }
}
