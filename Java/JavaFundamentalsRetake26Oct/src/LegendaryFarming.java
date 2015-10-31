import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LegendaryFarming {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        TreeMap<String, Integer> junk = new TreeMap<>();
        Map<String, Integer> legendItems = new TreeMap<>();
        legendItems.put("motes", 0);
        legendItems.put("fragments", 0);
        legendItems.put("shards", 0);
        String line;
        Pattern pattern = Pattern.compile("(\\d+) ([a-z]+)");
        boolean isObtained = false;
        while (!isObtained) {
            line = scanner.nextLine().toLowerCase();
            Matcher matcher = pattern.matcher(line);
            while (matcher.find()) {
                int quantity = Integer.parseInt(matcher.group(1));
                String material = matcher.group(2);
                if (material.equals("fragments") || material.equals("shards") || material.equals("motes")) {
                    int currentQuantity = legendItems.get(material);
                    legendItems.put(material, currentQuantity + quantity);
                    if (legendItems.get("fragments") > 250) {
                        System.out.println("Valanyr obtained!");
                        int oldValue = legendItems.get("fragments");
                        legendItems.put("fragments", oldValue - 250);
                        isObtained = true;
                    } else if (legendItems.get("shards") > 250) {
                        System.out.println("Shadowmourne obtained!");
                        int oldValue = legendItems.get("shards");
                        legendItems.put("shards", oldValue - 250);
                        isObtained = true;
                    } else if (legendItems.get("motes") > 250) {
                        System.out.println("Dragonwrath obtained!");
                        int oldValue = legendItems.get("motes");
                        legendItems.put("motes", oldValue - 250);
                        isObtained = true;
                    }
                    if (isObtained) break;
                } else {
                    if (!junk.containsKey(material)) {
                        junk.put(material, 0);
                    }
                    int currentJunkQuantity = junk.get(material);
                    junk.put(material, currentJunkQuantity + quantity);
                }
            }
        }
        legendItems.entrySet().stream()
                .sorted((k1, k2) -> -k1.getValue().compareTo(k2.getValue()))
                .forEach(k -> System.out.println(k.getKey() + ": " + k.getValue()));
        junk.entrySet().forEach(j -> System.out.println(j.getKey() + ": " + j.getValue()));
    }
}
