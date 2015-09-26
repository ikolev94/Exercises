import java.util.*;
import java.util.stream.Collectors;

public class OfficeStuff {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        TreeMap<String, LinkedHashMap<String, Integer>> companies = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" - ");
            String company = input[0].replace("|", "");
            Integer amount = Integer.parseInt(input[1]);
            String product = input[2].replace("|", "");
            if (!companies.containsKey(company)) {
                companies.put(company, new LinkedHashMap<>());
            }
            if (!companies.get(company).containsKey(product)) {
                companies.get(company).put(product, amount);
            } else {
                int currentAmount = companies.get(company).get(product);
                companies.get(company).put(product, amount + currentAmount);
            }
        }
        for (String company : companies.keySet()) {
            System.out.print(company + ": ");
            List<String> output = companies.get(company).keySet()
                    .stream()
                    .map(product -> product + "-" + companies.get(company).get(product))
                    .collect(Collectors.toList());
            System.out.println(String.join(", ", output));
        }
    }
}
