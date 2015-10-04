import java.util.*;

public class PopulationCounter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String line;
        Map<String, Country> countries = new HashMap<>();
        while (!(line = scanner.nextLine()).equals("report")) {
            String[] lineArgs = line.split("\\|");
            String inputCityName = lineArgs[0];
            String inputCountryName = lineArgs[1];
            int inputCityPopulation = Integer.parseInt(lineArgs[2]);
            if (!countries.containsKey(inputCountryName)) {
                countries.put(inputCountryName, new Country());
            }
            if (!countries.get(inputCountryName).getCities().containsKey(inputCityName)) {
                countries.get(inputCountryName).setCities(inputCityName, inputCityPopulation);
            } else {
                int toAdd = countries.get(inputCountryName).getCities().get(inputCityName);
                countries.get(inputCountryName).setCities(inputCityName, inputCityPopulation + toAdd);
            }
        }
        for (String country : countries.keySet()) {
            System.out.println(country + " " + countries.get(country).getTotalPopulation());
            for (String o : countries.get(country).getCities().keySet()) {
                System.out.println(o + " -> " + countries.get(country).getCities().get(o));
            }
        }
    }


}

class Country {
    public int getTotalPopulation() {
        return this.cities.values().stream().mapToInt(r -> r).sum();
    }
    private String name;
    private int totalPopulation;

    public Map<String, Integer> getCities() {
        return sortByComparator(this.cities);
    }

    public void setCities(String cityName, Integer cityPopulation) {
        this.cities.put(cityName, cityPopulation);
    }

    private Map<String, Integer> cities = new HashMap<>();

    private Map<String, Integer> sortByComparator(Map<String, Integer> unsortMap) {

        // Convert Map to List
        List<Map.Entry<String, Integer>> list =
                new LinkedList<>(unsortMap.entrySet());

        // Sort list with comparator, to compare the Map values
        Collections.sort(list, (o1, o2) -> -(o1.getValue()).compareTo(o2.getValue()));

        // Convert sorted map back to a Map
        Map<String, Integer> sortedMap = new LinkedHashMap<>();
        for (Iterator<Map.Entry<String, Integer>> it = list.iterator(); it.hasNext(); ) {
            Map.Entry<String, Integer> entry = it.next();
            sortedMap.put(entry.getKey(), entry.getValue());
        }
        return sortedMap;
    }
}