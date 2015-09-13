import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SumCards {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("[AJQK]|\\d+");
        Matcher matcher = pattern.matcher(scanner.nextLine());
        List<String> cardsFaces = new ArrayList<>();
        while (matcher.find()){
            cardsFaces.add(matcher.group());
        }
        int sum = 0;
        boolean isLAst = false;
        for (int i = 0; i < cardsFaces.size(); i++) {
            int toAdd = 0;
            String card = cardsFaces.get(i);
            if (Character.isDigit(card.charAt(0))) {
                toAdd = Integer.parseInt(card);
            } else {
                switch (card){
                    case "A":toAdd=15;break;
                    case "K":toAdd=14;break;
                    case "Q":toAdd=13;break;
                    case "J":toAdd=12;break;
                }
            }
            if (i+1<cardsFaces.size()&&cardsFaces.get(i+1).equals(card)||(i!=0&&cardsFaces.get(i-1).equals(card))){
                toAdd*=2;
            }
            sum+=toAdd;
        }
        System.out.println(sum);

    }
}
