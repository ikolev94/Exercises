import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class GandalfsStash {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int mood = scanner.nextInt();
        scanner.nextLine();
        List<String> foods = Arrays.asList(scanner.nextLine().toLowerCase().split("[^a-z]"))
                .stream()
                .filter(s->!s.isEmpty())
                .collect(Collectors.toList());

        for (String food : foods) {
            switch (food) {
                case "melon":
                    mood += 1;
                    break;
                case "cram":
                    mood += 2;
                    break;
                case "lembas":
                    mood += 3;
                    break;
                case "apple":
                    mood += 1;
                    break;
                case "honeycake":
                    mood += 5;
                    break;
                case "mushrooms":
                    mood -= 10;
                    break;
                default:
                    mood -= 1;
                    break;
            }
        }
        System.out.println(mood);
        if (mood<-5){
            System.out.println("Angry");
        } else if (mood<0){
            System.out.println("Sad");
        } else if (mood<15){
            System.out.println("Happy");
        } else {
            System.out.println("Special JavaScript mood");
        }
    }
}
