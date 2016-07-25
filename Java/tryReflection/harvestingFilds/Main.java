package harvestingFilds;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;

public class Main {

	/*
	 * You are given a RichSoilLand class with lots of fields. Like the good
	 * farmer you are, you must harvest them. Harvesting means that you must
	 * print each field in a certain format. Input You will receive a maximum of
	 * 100 lines with one of the following commands: 
	 * • private - print all * private fields 
	 * • protected - print all protected fields 
	 * • public - print * all public fields 
	 * • HARVEST - end the * input Output For each command
	 * you must print the fields that have the given access modifier as
	 * described in the input section. The format in which the fields should be
	 * printed is: "<access modifier> <field type> <field name>"
	 */

	public static void main(String[] args) throws ReflectiveOperationException, IOException {
		Class rClass = RichSoilLand.class;
		Field[] fields = rClass.getDeclaredFields();
		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		String inputAccessModifier;

		while (!(inputAccessModifier = reader.readLine()).equals("HARVEST")) {
			for (Field field : fields) {
				int mod = field.getModifiers();
				String modString = Modifier.toString(mod);
				if (modString.matches("protected|public|private"))
					if (inputAccessModifier.equalsIgnoreCase(modString)) {
						String p = field.getType().toString();
						String[] params = p.split("\\.");
						System.out.printf("%s %s %s%n", modString, params[params.length - 1], field.getName());
					}
			}
		}

	}

}
