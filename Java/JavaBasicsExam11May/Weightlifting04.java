import java.util.List;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.stream.Collectors;

public class Weightlifting04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        TreeMap<String, TreeMap<String, Long>> players = new TreeMap<>();
        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String[] inputArgs = scanner.nextLine().split("\\s+");
            String name = inputArgs[0];
            String exercise = inputArgs[1];
            long weight = Long.parseLong(inputArgs[2]);
            if (!players.containsKey(name)) {
                players.put(name, new TreeMap<>());
            }
            if (!players.get(name).containsKey(exercise)) {
                players.get(name).put(exercise, weight);
            } else {
                long currentWeight = players.get(name).get(exercise);
                players.get(name).put(exercise, currentWeight + weight);
            }
        }
        for (String name : players.keySet()) {
            System.out.print(name + " : ");
            List<String> exercises = players.get(name).keySet()
                    .stream()
                    .map(exercise -> exercise + " - " + players.get(name)
                    .get(exercise) + " kg")
                    .collect(Collectors.toList());
            System.out.println(String.join(", ", exercises));
        }
    }
}
