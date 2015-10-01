import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;

public class SchoolSystem {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        TreeMap<String, TreeMap<String, ArrayList<Double>>> students = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] inputArgs = scanner.nextLine().split("\\s+");
            String name = inputArgs[0] + " " + inputArgs[1];
            String subject = inputArgs[2];
            Double score = Double.parseDouble(inputArgs[3]);
            if (!students.containsKey(name)) {
                students.put(name, new TreeMap<>());
            }
            if (!students.get(name).containsKey(subject)) {
                students.get(name).put(subject, new ArrayList<>());
            }
            students.get(name).get(subject).add(score);
        }
        for (String studentName : students.keySet()) {
            System.out.print(studentName + ": [");
            ArrayList<String> output = new ArrayList<>();
            for (String subject : students.get(studentName).keySet()) {
                String format = String.format("%s - %.2f",subject,students.get(studentName).get(subject)
                        .stream()
                        .mapToDouble(a -> a).average().orElse(0));
                output.add(format);
            }
            System.out.print(String .join(", ",output));
            System.out.println("]");
        }
    }
}
