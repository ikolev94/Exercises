import java.util.Scanner;

public class DozensofEggs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int allEggs = 0;
        for (int i = 0; i < 7; i++) {
            String[] line = scanner.nextLine().split(" ");
            int eggsToAdd = Integer.parseInt(line[0]);
            if (line[1].equals("dozens")) {
                eggsToAdd *= 12;
            }
            allEggs += eggsToAdd;
        }

        System.out.printf("%d dozens + %d eggs", allEggs / 12, allEggs % 12);


    }
}
