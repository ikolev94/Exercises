import java.util.Scanner;

public class TerroristsWin {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[] text = scanner.nextLine().toCharArray();

        for (int i = 0; i < text.length; i++) {
            char currentLetter = text[i];
            int bombFirstSymbolIndex;
            int bombLastSymbolIndex;
            if (currentLetter == '|' ) {
                bombFirstSymbolIndex = i;
                i++;
                if (i >= text.length) break;
                String bomb = "";
                while (text[i] != '|' ) {
                    bomb += text[i++];
                    if (i >= text.length) break;
                }
                int bombPower = bombPowerCalculator(bomb);
                bombLastSymbolIndex = i + bombPower;
                bombFirstSymbolIndex = bombFirstSymbolIndex - bombPower;
                for (int j = Math.max(bombFirstSymbolIndex, 0); j <= bombLastSymbolIndex && j < text.length; j++) {
                    text[j] = '.';
                }
            }

        }
        System.out.println(text);

    }

    private static int bombPowerCalculator(String bomb) {
        int sum = 0;
        for (int i = 0; i < bomb.length(); i++) {
            sum += bomb.charAt(i);
        }
        return sum % 10;
    }
}
