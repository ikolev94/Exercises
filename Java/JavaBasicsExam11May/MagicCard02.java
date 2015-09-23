import java.util.Scanner;

public class MagicCard02 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] cards = scanner.nextLine().split("\\s+");
        String oddOrEven = scanner.nextLine();
        String magicCard = scanner.nextLine();
        String magicCardFace = magicCard.substring(0, magicCard.length() - 1);
        String magicCardSuit = magicCard.substring(magicCard.length() - 1);
        int sum = 0;
        for (int i = oddOrEven.equals("odd") ? 1 : 0; i < cards.length; i+=2) {
            String currentCard = cards[i];
            String cardFace = currentCard.substring(0, currentCard.length() - 1);
            String cardSuit = currentCard.substring(currentCard.length() - 1);
            int toAdd = cardValueCalculator(cardFace);
            if (cardFace.equals(magicCardFace)){
                toAdd*=3;
            }
            if (cardSuit.equals(magicCardSuit)){
                toAdd*=2;
            }
            sum+=toAdd;
        }
        System.out.println(sum);
    }

    private static int cardValueCalculator(String cardFace) {
        switch (cardFace){
            case "2":return 20;
            case "3":return 30;
            case "4":return 40;
            case "5":return 50;
            case "6":return 60;
            case "7":return 70;
            case "8":return 80;
            case "9":return 90;
            case "10":return 100;
            case "J":return 120;
            case "Q":return 130;
            case "K":return 140;
            case "A":return 150;
            default:return 0;
        }
    }
}
