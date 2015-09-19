import java.util.Scanner;
import java.util.TreeMap;

public class ExamScore {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        scanner.nextLine();
        scanner.nextLine();
        scanner.nextLine();
        String line = scanner.nextLine();
        String[] lineArgs = line.split("[\\s|]+");
        TreeMap<Integer,TreeMap<String,Double>> data = new TreeMap<>();
        while (lineArgs.length>1){
            String name = lineArgs[1]+ " " + lineArgs[2];
            int score = Integer.parseInt(lineArgs[3]);
            double grade = Double.parseDouble(lineArgs[4]);
            if (!data.containsKey(score)){
                data.put(score,new TreeMap<>());
            }
            if (!data.get(score).containsKey(name)){
                data.get(score).put(name,grade);
            }
            lineArgs = scanner.nextLine().split("[\\s|]+");
        }
        for (Integer integer : data.keySet()) {
            System.out.print(integer + " -> " + data.get(integer).keySet());
            int count =  data.get(integer).keySet().size();
            double sum = 0;
            for (String s : data.get(integer).keySet()) {
                sum+=data.get(integer).get(s);
            }
            System.out.printf("; avg=%.2f",sum/count);
            System.out.println();
        }
    }
}
