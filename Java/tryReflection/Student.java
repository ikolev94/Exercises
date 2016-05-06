package tryReflection;

public class Student {
	private String name;
	private int age;
	private int favoriteNumber;

	public Student(String name, int age) {
		this.name = name;
		this.age = age;
		this.favoriteNumber = this.age + (int) this.name.charAt(0);
	}

	@Override
	public String toString() {
		return "Student name = " + name + ", age = " + age + ", favorite number = "+favoriteNumber;
	}
}

