import java.util.HashSet;
import java.util.Scanner;

public class FireTheArrows {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        char[][] matrix = new char[n][];
        for (int i = 0; i < n; i++) {
            matrix[i] = scanner.nextLine().toCharArray();
        }
        boolean isOver = false;
        HashSet<Character> symbols = new HashSet<>();
        symbols.add('>');
        symbols.add('<');
        symbols.add('v');
        symbols.add('^');
        while (!isOver) {
            isOver = true;
            for (int row = 0; row < n; row++) {
                for (int col = 0; col < matrix[row].length; col++) {
                    if (matrix[row][col] == '<' && col - 1 >= 0 && !symbols.contains(matrix[row][col - 1])) {
                        matrix[row][col] = 'o';
                        matrix[row][col - 1] = '<';
                        isOver = false;
                    } else if (matrix[row][col] == '>' && col + 1 < matrix[row].length && !symbols.contains(matrix[row][col + 1])) {
                        matrix[row][col] = 'o';
                        matrix[row][col + 1] = '>';
                        isOver = false;
                    } else if (matrix[row][col] == 'v' && row + 1 < n && !symbols.contains(matrix[row + 1][col])) {
                        matrix[row][col] = 'o';
                        matrix[row + 1][col] = 'v';
                        isOver = false;
                    } else if (matrix[row][col] == '^' && row - 1 >= 0 && !symbols.contains(matrix[row - 1][col])) {
                        matrix[row][col] = 'o';
                        matrix[row - 1][col] = '^';
                        isOver = false;
                    }
                }
            }
        }
        for (char[] chars : matrix) {
            System.out.println(chars);
        }
    }
}
