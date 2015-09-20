import java.util.LinkedHashMap;
import java.util.Objects;
import java.util.Scanner;
import java.util.TreeMap;

public class UserLogs {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line;
        TreeMap<String, LinkedHashMap<String, Integer>> data = new TreeMap<>();
        while (!Objects.equals(line = scanner.nextLine(), "end")) {
            String[] lineArgs = line.split("[ =]");
            String ip = lineArgs[1];
            String user = lineArgs[5];
            if (!data.containsKey(user)) {
                data.put(user, new LinkedHashMap<>());
            }
            if (!data.get(user).containsKey(ip)) {
                data.get(user).put(ip, 1);
            } else {
                int currentCount = data.get(user).get(ip);
                data.get(user).put(ip, ++currentCount);
            }
        }
        for (String userName : data.keySet()) {
            System.out.println(userName + ": ");
            StringBuilder output = new StringBuilder();
            for (String ip : data.get(userName).keySet()) {
                output.append(ip + " => " + data.get(userName).get(ip) + ", ");
            }
            System.out.println(output.substring(0, output.length() - 2) + ".");
        }
    }
}
