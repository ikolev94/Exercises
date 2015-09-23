import java.util.Scanner;

public class LabyrinthDash03 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        char[][] matrix = new char[n][];
        for (int i = 0; i < n; i++) {
            matrix[i] = scanner.nextLine().toCharArray();
        }
        char[] commands = scanner.nextLine().toCharArray();
        int x = 0;
        int y = 0;
        int lives = 3;
        int moves = 0;
        for (char command : commands) {
            int currentX = x;
            int currentY = y;

            switch (command) {
                case '>':
                    currentY++;
                    break;
                case '<':
                    currentY--;
                    break;
                case 'v':
                    currentX++;
                    break;
                case '^':
                    currentX--;
                    break;
            }
            try {
                if (matrix[currentX][currentY] == '$') {
                    lives++;
                    System.out.printf("Awesome! Lives left: %d%n", lives);
                    x = currentX;
                    y = currentY;
                    matrix[currentX][currentY] = '.';
                    moves++;
                } else if (matrix[currentX][currentY] == '_' || matrix[currentX][currentY] == '|') {
                    System.out.println("Bumped a wall.");
                } else if (matrix[currentX][currentY] == '@'
                        || matrix[currentX][currentY] == '*'
                        || matrix[currentX][currentY] == '#') {
                    System.out.printf("Ouch! That hurt! Lives left: %d%n", --lives);
                    y = currentY;
                    x = currentX;
                    moves++;
                    if (lives <= 0) {
                        System.out.println("No lives left! Game Over!");
                        break;
                    }
                } else if (matrix[currentX][currentY] == '.') {
                    x = currentX;
                    y = currentY;
                    moves++;
                    System.out.println("Made a move!");
                } else if (matrix[currentX][currentY] == ' ') {
                    throw new Exception();
                }

            } catch (Exception e) {
                System.out.println("Fell off a cliff! Game Over!");
                moves++;
                break;
            }
        }
        System.out.printf("Total moves made: %d",moves);
    }
}
