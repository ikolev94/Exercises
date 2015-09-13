import java.util.*;

public class LogsAggregator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        TreeMap<String, Person> data = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] line = scanner.nextLine().split(" ");
            String id = line[0];
            String currentName = line[1];
            int duration = Integer.parseInt(line[2]);
            if (!data.containsKey(currentName)) {
                data.put(currentName, new Person());
            }
            data.get(currentName).setDuration(duration);
            data.get(currentName).setId(id);
        }
        for (String s : data.keySet()) {
            System.out.println(s + ": " + data.get(s).getDuration() + " " + data.get(s).getId());
        }
    }
}

class Person {

    private int duration = 0;
    private TreeSet<String> id = new TreeSet<>();

    public int getDuration() {
        return duration;
    }

    public void setDuration(int duration) {
        this.duration += duration;
    }

    public TreeSet<String> getId() {
        return id;
    }

    public void setId(String id) {
        this.id.add(id);
    }
}
