import java.util.HashSet;
import java.util.Hashtable;
import java.util.Scanner;

public class CouplesFrequency {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] numbersAsString = scanner.nextLine().split(" ");
        Hashtable<String, Integer> couples = new Hashtable<>();
        for (int i = 0; i < numbersAsString.length - 1; i++) {
            String couple = String.format("%s %s", numbersAsString[i], numbersAsString[i + 1]);
            if (couples.containsKey(couple)) {
                couples.put(couple, couples.get(couple) + 1);
            } else {
                couples.put(couple, 1);
            }
        }

        HashSet<String> distinct = new HashSet<>();
        for (int i = 0; i < numbersAsString.length - 1; i++) {
            String couple = String.format("%s %s", numbersAsString[i], numbersAsString[i + 1]);
            if (!distinct.contains(couple)) {
                float frequency = (float) couples.get(couple) / (numbersAsString.length - 1);
                System.out.printf("%s -> %.2f%%", couple, frequency * 100);
                System.out.println();
                distinct.add(couple);
            }
        }
    }
}
