package hse.java.faketetris.geometry;

public final class Utils {
    private Utils() { }

    /**
     * Standard matrix addition.
     * @param origin A matrix.
     * @param toAdd B matrix.
     * @return A + B result.
     */
    public static int[][] matrixAddition(int[][] origin, int[][] toAdd) {
        final int[][] newOrigin = new int[origin.length][origin[0].length];
        for (int i = 0; i < origin.length; ++i) {
            for (int j = 0; j < origin[0].length; ++j) {
                newOrigin[i][j] = origin[i][j] + toAdd[i][j];
            }
        }
        return newOrigin;
    }

    /**
     * If there is a value > 1 in our field it means that there is a collision and this matrix cannot exist.
     * @param matrix Matrix which we are checking.
     * @return True if it is correct, false otherwise.
     */
    public static boolean isAdditionCorrect(int[][] matrix) {
        for (int[] ints : matrix) {
            for (int j = 0; j < ints.length; ++j) {
                if (ints[j] > 1) {
                    return false;
                }
            }
        }
        return true;
    }

    public static int[][] clearFullRows(int[][] matrix) {
        int rows = matrix.length;
        int cols = matrix[0].length;

        // Step 1: Find columns with all 1s
        boolean[] fullCols = new boolean[cols];
        for (int j = 0; j < cols; j++) {
            boolean allOnes = true;
            for (int[] ints : matrix) {
                if (ints[j] != 1) {
                    allOnes = false;
                    break;
                }
            }
            fullCols[j] = allOnes;
        }

        // Step 2: Find rows with all 1s
        boolean[] fullRows = new boolean[rows];
        for (int i = 0; i < rows; i++) {
            boolean allOnes = true;
            for (int j = 0; j < cols; j++) {
                if (matrix[i][j] != 1) {
                    allOnes = false;
                    break;
                }
            }
            fullRows[i] = allOnes;
        }

        // Step 3: Replace all 1s in full columns with 0
        for (int j = 0; j < cols; j++) {
            if (fullCols[j]) {
                for (int i = 0; i < rows; i++) {
                    matrix[i][j] = 0;
                }
            }
        }

        // Step 4: Replace all 1s in full rows with 0
        for (int i = 0; i < rows; i++) {
            if (fullRows[i]) {
                for (int j = 0; j < cols; j++) {
                    matrix[i][j] = 0;
                }
            }
        }

        // Step 5: Return resulting matrix
        return matrix;
    }

    /**
     * Matrix rotation clockwise.
     * @param matrix Matrix to rotate.
     * @param rotation Angle on which we will rotate matrix.
     * @return Rotated matrix.
     */
    public static int[][] rotate(int[][] matrix, Rotations rotation) {
        switch (rotation) {
            case DEG0 -> {
                return matrix;
            }
            case DEG90 -> {
                return rotate90(matrix);
            }
            // Rotating 90 + rotating 90 == rotating 180.
            case DEG180 -> {
                return rotate90(rotate90(matrix));
            }
            // Rotating 90 + rotating 90 + rotating 90 == rotating 270.
            case DEG270 -> {
                return rotate90(rotate90(rotate90(matrix)));
            }
            default -> throw new IllegalArgumentException("Wrong rotation!");
        }
    }

    /**
     * Standard matrix rotation.
     * @param matrix Matrix which we want to rotate on 90 degrees.
     * @return Rotated on 90 degrees matrix.
     */
    private static int[][] rotate90(int[][] matrix) {
        final int height = matrix.length;
        final int width = matrix[0].length;
        int[][] rotatedMatrix = new int[width][height];
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                rotatedMatrix[j][height - 1 - i] = matrix[i][j];
            }
        }
        return rotatedMatrix;
    }
}
