import java.util.Scanner;

public class TinySporebat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int health = 5800;
        int glowcaps = 0;
        String line;
        while (!(line = scanner.nextLine()).equals("Sporeggar")) {
            char[] letters = line.toCharArray();
            for (int i = 0; i < letters.length - 1; i++) {
                if (letters[i] != 'L') {
                    health -= letters[i];
                } else {
                    health += 200;
                }
            }
            if (health <= 0) {
                System.out.printf("Died. Glowcaps: %d%n", glowcaps);
                return;
            } else {
                int glowcapsToAdd = Integer.parseInt(line.substring(line.length() - 1));
                glowcaps += glowcapsToAdd;
            }
        }
        System.out.printf("Health left: %d%n", health);
        if (glowcaps < 30) {
            System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.%n", 30 - glowcaps);
        } else {
            System.out.printf("Bought the sporebat. Glowcaps left: %d%n", glowcaps - 30);
        }
    }
}
