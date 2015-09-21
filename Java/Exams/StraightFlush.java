import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class StraightFlush {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Character> allFaces = new ArrayList<>();
        allFaces.add('2');
        allFaces.add('3');
        allFaces.add('4');
        allFaces.add('5');
        allFaces.add('6');
        allFaces.add('7');
        allFaces.add('8');
        allFaces.add('9');
        allFaces.add('1');
        allFaces.add('J');
        allFaces.add('Q');
        allFaces.add('K');
        allFaces.add('A');
        String[] cards = scanner.nextLine().split("\\W+");
        boolean isAny = false;
        for (int i = 0; i < cards.length; i++) {
            int firstIndex = allFaces.indexOf(cards[i].charAt(0));
            char firstSuit = cards[i].charAt(cards[i].length() - 1);
            for (int i1 = 0; i1 < cards.length; i1++) {
                int secondIndex = allFaces.indexOf(cards[i1].charAt(0));
                char secondSuit = cards[i1].charAt(cards[i1].length() - 1);
                if (firstSuit != secondSuit || i == i1) continue;
                for (int i2 = 0; i2 < cards.length; i2++) {
                    int thirdIndex = allFaces.indexOf(cards[i2].charAt(0));
                    char thirdSuit = cards[i2].charAt(cards[i2].length() - 1);
                    if (firstSuit != thirdSuit || i1 == i2) continue;
                    for (int i3 = 0; i3 < cards.length; i3++) {
                        int fortIndex = allFaces.indexOf(cards[i3].charAt(0));
                        char fortSuit = cards[i3].charAt(cards[i3].length() - 1);
                        if (firstSuit != fortSuit || i2 == i3) continue;
                        for (int i4 = 0; i4 < cards.length; i4++) {
                            int fifthIndex = allFaces.indexOf(cards[i4].charAt(0));
                            char fifthSuit = cards[i4].charAt(cards[i4].length() - 1);
                            if (firstSuit != fifthSuit || i3 == i4) continue;
                            boolean a = secondIndex - 1 == firstIndex;
                            boolean b = thirdIndex - 1 == secondIndex;
                            boolean c = fortIndex - 1 == thirdIndex;
                            boolean d = fifthIndex - 1 == fortIndex;
                            if (a && b && c && d) {
                                System.out.println("[" + cards[i] + ", " + cards[i1] +
                                        ", " + cards[i2] + ", " + cards[i3] + ", " + cards[i4] + "]");
                                isAny = true;
                            }
                        }
                    }
                }
            }
        }
        if (!isAny) {
            System.out.println("No Straight Flushes");
        }
    }
}

