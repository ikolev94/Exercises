import java.util.Arrays;

public enum MyType {
	SSH, SSO, API("zak", "pak", "ap");

	private String[] value;

	private MyType(String... value) {
		this.value = value;
	}

	public String[] getValue() {
		return this.value;
	}

	public static MyType getEnum(String value) {
		for (MyType v : values())
			if (Arrays.asList(v.getValue()).contains(value)) {
				return v;
			}
		throw new IllegalArgumentException("Invalid MyType type! :D");
	}
}
