import java.util.Scanner;

public class Timespan {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long start = timeToSeconds(scanner);
        long end = timeToSeconds(scanner);
        long timeLeft = start - end;
        int seconds = (int)(timeLeft % 60);
        int minutues = (int)(timeLeft % 3600 / 60);
        int hours = (int)(timeLeft / 3600);
        System.out.printf("%d:%s:%s",
                hours,
                minutues < 10 ? "0" + minutues : "" + minutues,
                seconds < 10 ? "0" + seconds : "" + seconds);
    }

    private static long timeToSeconds(Scanner scanner) {
        String[] start = scanner.nextLine().split(":");
        long hours = Long.parseLong(start[0]) * 3600;
        long minutes = Long.parseLong(start[1]) * 60;
        long seconds = Long.parseLong(start[2]);
        return hours + minutes + seconds;
    }
}
