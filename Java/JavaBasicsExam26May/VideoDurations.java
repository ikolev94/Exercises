import java.util.Scanner;

public class VideoDurations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        int totalMinutes = 0;
        while (!line.equals("End")) {
            String[] lineArgs = line.split(":");
            totalMinutes += (Integer.parseInt(lineArgs[0]) * 60) + Integer.parseInt(lineArgs[1]);
            line = scanner.nextLine();
        }
        System.out.printf("%d:%02d", totalMinutes / 60, totalMinutes % 60);
    }
}
