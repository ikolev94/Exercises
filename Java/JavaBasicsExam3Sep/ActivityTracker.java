import java.util.Scanner;
import java.util.TreeMap;

public class ActivityTracker {
    public static void main(String[] args) {
        TreeMap<Integer, TreeMap<String, Float>> playersByMount = new TreeMap<>();
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        for (int i = 0; i < n; i++) {
            String[] inputLine = scanner.nextLine().split("[/ ]");
            int mount = Integer.parseInt(inputLine[1]);
            Float distanceToAdd = Float.parseFloat(inputLine[4]);
            String name = inputLine[3];
            if (!playersByMount.containsKey(mount)) {
                playersByMount.put(mount, new TreeMap<>());
            }
            if (!playersByMount.get(mount).containsKey(name)) {
                playersByMount.get(mount).put(name, distanceToAdd);
            } else {
                distanceToAdd += playersByMount.get(mount).get(name);
                playersByMount.get(mount).put(name, distanceToAdd);
            }
        }

        for (Integer mount : playersByMount.keySet()) {
            System.out.printf("%d: ", mount);
            TreeMap<String, Float> player = playersByMount.get(mount);
            boolean isItFirstPlayer = true;
            for (String name : player.keySet()) {
                if (isItFirstPlayer) {
                    System.out.printf("%s(%.0f)", name, player.get(name));
                    isItFirstPlayer = false;
                } else {
                    System.out.printf(", %s(%.0f)", name, player.get(name));
                }
            }
            System.out.println();
        }
    }
}