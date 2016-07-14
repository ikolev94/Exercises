package first;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ReverseOddWordsRecursively {
	public static void main(String[] args) throws IOException {
		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		String sentence = reader.readLine();

		System.out.println(reverseOddWord(sentence));

	}

	private static String reverseOddWord(String sentence) {
		String[] words = sentence.split("\\s+");
		StringBuilder result = new StringBuilder(sentence);
		int start, end;
		String reversedWord;
		for (int i = 0; i < words.length; i += 2) {
			start = sentence.indexOf(words[i]);
			end = words[i].length() + start;
			reversedWord = reverseWordRecursively(words[i]);
			result.replace(start, end, reversedWord);
		}

		return result.toString();
	}

	private static String reverseWordRecursively(String word) {
		int len = word.length();
		if (len == 1) {
			return word;
		} else {
			return word.charAt(len - 1) + reverseWordRecursively(word.substring(0, len - 1));
		}
	}
}
