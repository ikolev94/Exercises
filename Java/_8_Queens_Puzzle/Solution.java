package _8_Queens_Puzzle;

import java.util.HashSet;
import java.util.Set;

public class Solution {

	static int solutionsFound = 0;
	static final String boardSeparator = new String(new char[24]).replace("\0", "-") + System.lineSeparator();

	static Set<Integer> attackedColumns = new HashSet<>();
	// Left diagonal = column - row
	static Set<Integer> attackedLeftDiagonals = new HashSet<>();
	// Right diagonal = column + row
	static Set<Integer> attackedRightDiagonals = new HashSet<>();

	private static void putQueens(int row) {
		if (row == Chessboard.SIZE) {
			print();
			solutionsFound++;
		} else {
			for (int col = 0; col < Chessboard.SIZE; col++) {
				if (canPlaceQueen(row, col)) {
					markAttackedPositions(row, col);
					putQueens(row + 1);
					unmarkAttackedPossitions(row, col);
				}
			}
		}
	}

	private static void unmarkAttackedPossitions(int row, int col) {
		attackedColumns.remove(col);
		attackedLeftDiagonals.remove(col - row);
		attackedRightDiagonals.remove(col + row);
		Chessboard.chessboard[row][col] = false;
	}

	private static void markAttackedPositions(int row, int col) {
		attackedColumns.add(col);
		attackedLeftDiagonals.add(col - row);
		attackedRightDiagonals.add(col + row);
		Chessboard.chessboard[row][col] = true;
	}

	private static boolean canPlaceQueen(int row, int col) {
		boolean result = attackedColumns.contains(col) || attackedRightDiagonals.contains(row + col)
				|| attackedLeftDiagonals.contains(col - row);

		return !result;
	}

	static void print() {
		StringBuilder output = new StringBuilder(100);
		output.append(boardSeparator);
		for (int row = 0; row < Chessboard.SIZE; row++) {
			for (int col = 0; col < Chessboard.SIZE; col++) {
				output.append(Chessboard.chessboard[row][col] ? " Q " : "|_|");
			}
			output.append(System.lineSeparator());
		}
		output.append(boardSeparator);
		System.out.println(output);
	}

	public static void main(String[] args) {
		putQueens(0);
		System.out.println("Solutions found = " + solutionsFound);
	}
}
