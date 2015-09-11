import java.util.Scanner;

public class CountBeers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        int allBeers = 0;
        while (!line.equals("End")) {
            String[] lineArgs = line.split(" ");
            int numberOfBeers = Integer.parseInt(lineArgs[0]);
            if (lineArgs[1].equals("stacks")) {
                numberOfBeers *= 20;
            }
            allBeers += numberOfBeers;
            line = scanner.nextLine();
        }
        System.out.printf("%d stacks + %d beers", allBeers / 20, allBeers % 20);
    }
}
