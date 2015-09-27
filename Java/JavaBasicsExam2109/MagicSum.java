import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class MagicSum {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = Integer.parseInt(scanner.nextLine());
        String line = scanner.nextLine();
        List<Integer> numbers = new ArrayList<>();
        while (!line.equals("End")){
            numbers.add(Integer.parseInt(line));
            line = scanner.nextLine();
        }
        int max = Integer.MIN_VALUE;
        String output = "No";
        for (int i1 = 0; i1 < numbers.size(); i1++) {
            for (int i2 = i1+1; i2 < numbers.size(); i2++) {
                for (int i3 = i2+1; i3 < numbers.size(); i3++) {
                    int first = numbers.get(i1);
                    int second = numbers.get(i2);
                    int third = numbers.get(i3);
                    if ((first + second + third) % n == 0){
                        if (first+second+third>max){
                            max = first+second+third;
                            output = String.format("(%d + %d + %d) %% %d = 0%n",first,second,third,n);
                        }
                    }
                }
            }
        }
        System.out.println(output);
    }
}
