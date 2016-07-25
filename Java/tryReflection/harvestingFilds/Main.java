package harvestingFilds;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.math.BigInteger;
import java.util.Calendar;
import java.util.stream.Stream;

public class Main {

	class RichSoilLand {
		private int testInt;
		public double testDouble;
		protected String testString;
		private long testLong;
		protected double aDouble;
		public String aString;
		private Calendar aCalendar;
		public StringBuilder aBuilder;
		private char testChar;
		public short testShort;
		protected byte testByte;
		public byte aByte;
		protected StringBuilder aBuffer;
		private BigInteger testBigInt;
		protected BigInteger testBigNumber;
		protected float testFloat;
		public float aFloat;
		private Thread aThread;
		public Thread testThread;
		private Object aPredicate;
		protected Object testPredicate;
		public Object anObject;
		private Object hiddenObject;
		protected Object fatherMotherObject;
		private String anotherString;
		protected String moarString;
		public int anotherIntBitesTheDust;
		private Exception internalException;
		protected Exception inheritableException;
		public Exception justException;
		public Stream aStream;
		protected Stream moarStreamz;
		private Stream secretStream;
	}

	/*
	 * You are given a RichSoilLand class with lots of fields. Like the good
	 * farmer you are, you must harvest them. Harvesting means that you must
	 * print each field in a certain format. Input You will receive a maximum of
	 * 100 lines with one of the following commands: • private - print all
	 * private fields • protected - print all protected fields • public - print
	 * all public fields • all - print ALL declared fields • HARVEST - end the
	 * input Output For each command you must print the fields that have the
	 * given access modifier as described in the input section. The format in
	 * which the fields should be printed is:
	 * "<access modifier> <field type> <field name>"
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
				if (inputAccessModifier.equalsIgnoreCase(modString)) {
					String p = field.getType().toString();
					String[] params = p.split("\\.");
					System.out.printf("%s %s %s%n", modString, params[params.length - 1], field.getName());
				}
			}
		}

	}

}
