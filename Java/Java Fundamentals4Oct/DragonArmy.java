import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class problem01 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        LinkedHashMap<String, TreeMap<String, ArrayList<Integer>>> dragons = new LinkedHashMap<>();
        for (int i = 0; i < n; i++) {
            String[] lineArgs = scanner.nextLine().split("\\s+");
            String type = lineArgs[0];
            String name = lineArgs[1];
            int damage = lineArgs[2].equals("null") ? 45 : Integer.parseInt(lineArgs[2]);
            int health = lineArgs[3].equals("null") ? 250 : Integer.parseInt(lineArgs[3]);
            int armor = lineArgs[4].equals("null") ? 10 : Integer.parseInt(lineArgs[4]);
            if (!dragons.containsKey(type)) {
                dragons.put(type, new TreeMap<>());
            }
            if (!dragons.get(type).containsKey(name)) {
                dragons.get(type).put(name, new ArrayList<>());
            }
            dragons.get(type).get(name).add(0, damage);
            dragons.get(type).get(name).add(1, health);
            dragons.get(type).get(name).add(2, armor);
        }
        for (String dragonType : dragons.keySet()) {
            double totalDamage = 0;
            double totalHealth = 0;
            double totalArmor = 0;
            double count = dragons.get(dragonType).values().size();
            for (ArrayList<Integer> stats : dragons.get(dragonType).values()) {
                totalDamage += stats.get(0);
                totalHealth += stats.get(1);
                totalArmor += stats.get(2);
            }
            String format = String.format("%s::(%.2f/%.2f/%.2f)", dragonType, totalDamage / count, totalHealth / count, totalArmor / count);
            System.out.println(format);
            for (String dragonName : dragons.get(dragonType).keySet()) {
                String output = String.format("-%s -> damage: %d, health: %d, armor: %d",dragonName,dragons.get(dragonType).get(dragonName).get(0)
                        ,dragons.get(dragonType).get(dragonName).get(1),dragons.get(dragonType).get(dragonName).get(2));
                System.out.println(output);
            }
        }
    }
}
