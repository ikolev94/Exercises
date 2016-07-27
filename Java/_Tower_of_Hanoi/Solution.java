package _Tower_of_Hanoi;

import java.util.Stack;

public class Solution {
	public static void main(String[] args) {
		Stack<Integer> sourse = new Stack<>();
		Stack<Integer> target = new Stack<>();
		Stack<Integer> spare = new Stack<>();
		for (int i = 6; i > 0; i--)
			sourse.push(i);

		move(6, sourse, target, spare);

		while (!target.isEmpty()) {
			System.out.println(target.pop());
		}
	}

	public static void move(int disk, Stack<Integer> sourse, Stack<Integer> target, Stack<Integer> spare) {
		if (disk > 0) {
			move(disk - 1, sourse, spare, target);
			target.add(sourse.pop());
			move(disk - 1, spare, target, sourse);
		}
	}
}
