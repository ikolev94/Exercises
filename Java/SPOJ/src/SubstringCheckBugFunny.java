import java.util.Scanner;

public class SubstringCheckBugFunny {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        for (int i = 0; i < 24; i++) {
            String[] inputArgs = scanner.nextLine().split("\\s+");
            int output =0;
            for (int j = 0; j < 5; j++) {
                String result = inputArgs[0].substring(j,j+5);
                if (result.equals(inputArgs[1])){
                    output++;
                    break;
                }
            }
            System.out.println(output);
        }
    }
}
