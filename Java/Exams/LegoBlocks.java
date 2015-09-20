import java.util.*;
import java.util.stream.Collectors;

public class LegoBlocks {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();
        List<List<Integer>> first = new ArrayList<>();
        List<List<Integer>> second = new ArrayList<>();
        readInput(scanner, n, first);
        readInput(scanner, n, second);
        for (int i = 0; i < first.size(); i++) {
            Collections.reverse(second.get(i));
            first.get(i).addAll(second.get(i));
        }
        boolean isFit = true;
        int size = first.get(0).size();
        for (List<Integer> integers : first) {
            if (integers.size()!=size){
                isFit = false;
                break;
            }
        }
        if (isFit){
            first.forEach(System.out::println);
        }else {
            int count = 0;
            for (List<Integer> integers : first) {
                count+=integers.size();
            }
            System.out.printf("The total number of cells is: %d", count);
        }

    }

    private static void readInput(Scanner scanner, int n, List<List<Integer>> matrix) {
        for (int i = 0; i < n; i++) {
            matrix.add(new ArrayList<>());
            matrix.get(i).addAll(Arrays.asList(scanner.nextLine().trim().split("\\s+")).stream().map(Integer::parseInt).collect(Collectors.toList()));
        }
    }
}
