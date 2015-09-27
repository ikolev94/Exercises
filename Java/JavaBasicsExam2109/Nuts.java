import java.util.*;

public class Nuts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        TreeMap<String, LinkedHashMap<String, Integer>> companies = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] inputArgs = scanner.nextLine().split("\\s+");
            String company = inputArgs[0];
            String nuts = inputArgs[1];
            int amount = Integer.parseInt(inputArgs[2].replace("kg",""));
            if (!companies.containsKey(company)) {
                companies.put(company, new LinkedHashMap<>());
            }
            if (!companies.get(company).containsKey(nuts)) {
                companies.get(company).put(nuts, amount);
            } else {
                int amountToAdd = companies.get(company).get(nuts);
                companies.get(company).put(nuts, amount + amountToAdd);
            }
        }
        for (String company : companies.keySet()) {
            System.out.print(company + ": ");
            List<String> output = new ArrayList<>();
            for (String nuts : companies.get(company).keySet()) {
                output.add(nuts + "-" + companies.get(company).get(nuts) + "kg");
            }
            System.out.println(String.join(", ", output));
        }
    }
}
