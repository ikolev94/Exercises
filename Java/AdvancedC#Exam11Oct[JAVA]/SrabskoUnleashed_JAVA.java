import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SrabskoUnleashed_JAVA {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        Pattern pattern = Pattern.compile("^(([a-zA-Z]+\\s*){1,3}) @(([a-zA-Z]+\\s*){1,3}) (\\d+) (\\d+)");
        String line = scanner.nextLine();
        LinkedHashMap<String, LinkedHashMap<String, Integer>> singersByVenue = new LinkedHashMap<>();
        while (!line.equals("End")) {
            Matcher matcher = pattern.matcher(line);
            if (matcher.find()) {
                String singerName = matcher.group(1);
                String venue = matcher.group(3);
                int ticketsPrice = Integer.parseInt(matcher.group(5));
                int ticketsCount = Integer.parseInt(matcher.group(6));
                int money = ticketsCount * ticketsPrice;
                if (!singersByVenue.containsKey(venue)) {
                    singersByVenue.put(venue, new LinkedHashMap<>());
                }
                if (!singersByVenue.get(venue).containsKey(singerName)) {
                    singersByVenue.get(venue).put(singerName, money);
                } else {
                    int moneyToAdd = singersByVenue.get(venue).get(singerName);
                    singersByVenue.get(venue).put(singerName, moneyToAdd + money);
                }
            }
            line = scanner.nextLine();
        }

        for (String venue : singersByVenue.keySet()) {
            System.out.println(venue);
            Map<String, Integer> singers = sortMapByValue(singersByVenue.get(venue));
            for (String singerName : singers.keySet()) {
                System.out.println("#  " + singerName + " -> " + singers.get(singerName));
            }
        }

    }

    private static Map sortMapByValue(Map unsortedMap) {
        List list = new LinkedList(unsortedMap.entrySet());
        Collections.sort(list, (o1, o2) -> -((Comparable) ((Map.Entry) (o1)).getValue())
                .compareTo(((Map.Entry) (o2)).getValue()));

        Map sortedHashMap = new LinkedHashMap();
        for (Iterator it = list.iterator(); it.hasNext();) {
            Map.Entry entry = (Map.Entry) it.next();
            sortedHashMap.put(entry.getKey(), entry.getValue());
        }
        return sortedHashMap;
    }
}
