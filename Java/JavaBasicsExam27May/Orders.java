import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Orders {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        LinkedHashMap<String, TreeMap<String, Integer>> data = new LinkedHashMap<>();
        for (int i = 0; i < n; i++) {
            String[] line = scanner.nextLine().split(" ");
            String product = line[2];
            String name = line[0];
            int amount = Integer.parseInt(line[1]);
            if (!data.containsKey(product)) {
                data.put(product, new TreeMap<>());
            }
            if (!data.get(product).containsKey(name)) {
                data.get(product).put(name, amount);
            } else {
                int amountToAdd = data.get(product).get(name);
                data.get(product).put(name, amountToAdd + amount);
            }
        }

        for (String product : data.keySet()) {
            System.out.print(product+": ");
            int count = data.get(product).size();
            int countElements = 0;
            for (Map.Entry<String, Integer> namesAndAmount : data.get(product).entrySet()) {
                String name = namesAndAmount.getKey();
                int amount = namesAndAmount.getValue();
                countElements++;
                if (count<=countElements){
                    System.out.print(name +" "+amount);
                } else {
                    System.out.print(name + " " + amount + ", ");
                }
            }
            System.out.println();
        }
    }
}
