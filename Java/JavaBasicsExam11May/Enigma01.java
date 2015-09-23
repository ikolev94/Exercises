import java.util.Scanner;

public class Enigma01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String line = scanner.nextLine();
            String lineWithoutNumbersAndWhiteSpaces = line.replaceAll("[\\d\\s]+", "");
            int length = lineWithoutNumbersAndWhiteSpaces.length();
            for (int j = 0; j < line.length(); j++) {
                char letter = line.charAt(j);
                if (!Character.isDigit(letter) && letter != ' ') {
                    letter = (char) (letter + length / 2);
                }
                System.out.print(letter);
            }
            System.out.println();
        }
    }
}
