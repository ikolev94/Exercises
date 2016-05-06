package tryReflection;

import java.lang.reflect.Field;

public class Main {

	public static void main(String[] args) throws IllegalArgumentException, IllegalAccessException {
		Student[] students = new Student[]{
				new Student("Ivan", 21),
				new Student("gogo", 17)		
		};
		
		for (Student student : students) {
			System.out.println("Before -> " + student);
			
			changeFields(student);
			
			System.out.printf("After  -> " + student +"%n%n");
		}
	}

	private static void changeFields(Student student) throws IllegalAccessException {
		Field[] fields = student.getClass().getDeclaredFields();
		for (Field field : fields) {
			field.setAccessible(true);
			if (field.getType() == int.class) {
				int currentInt = (int) field.get(student);
				field.set(student, currentInt + 10);
			}
			if (field.getType() == String.class) {
				String currentString = field.get(student).toString();
				field.set(student, currentString.toUpperCase());
			}
		}
	}

}
