package hse.java.faketetris.model;

import hse.java.faketetris.geometry.Figures;
import hse.java.faketetris.geometry.Point;
import hse.java.faketetris.geometry.Rotations;
import hse.java.faketetris.geometry.Utils;

public class GameField {
    private static final int heightSize = 9;
    private static final int widthSize = 9;

    private int[][] field;

    public GameField() {
        this.field = new int[heightSize][widthSize];
    }

    /**
     * Places figure with all params.
     * @param figure Figure with params.
     * @param topLeft Point where to place figure.
     * @return True if figure was successfully added, False if figure is out of bounds or there is a collision.
     */
    public boolean placeFigure(Figure figure, Point topLeft) {
        return placeFigureWithRotation(figure.getType(), figure.getRotation(), topLeft);
    }

    /**
     * Places and rotates figure.
     * @param figure Figure to place.
     * @param rotation Wanted rotation of figure.
     * @param topLeft Point where to place.
     * @return True if figure was successfully added, False if figure is out of bounds or there is a collision.
     */
    public boolean placeFigureWithRotation(Figures figure, Rotations rotation, Point topLeft) {
        // Rotation of figure.
        int[][] figureField = Utils.rotate(figure.getField(), rotation);
        // Placing figure.
        return placeFigureField(figureField, topLeft);
    }

    public boolean canPlaceNext(Figure figure) {
        if (figure.getField().length < 1) {
            return false;
        }

        int figureHeight = figure.getField().length;
        int figureWidth = figure.getField()[0].length;
        for (int i = 0; i < field.length - figureHeight + 1; ++i) {
            for (int j = 0; j < field[i].length - figureWidth + 1; ++j) {
                // Check whether we can place this figure on this position or not.
                if (i + figureHeight > heightSize || j + figureWidth > widthSize) {
                    continue;
                }

                // Making mask with wanted position for our figure.
                final int[][] mask = new int[heightSize][widthSize];
                for (int k = 0; k < figureHeight; ++k) {
                    System.arraycopy(figure.getField()[k], 0, mask[k + i], j, figure.getField()[0].length);
                }

                // Check if we have collisions.
                int[][] newField = Utils.matrixAddition(field, mask);
                if (Utils.isAdditionCorrect(newField)) {
                    return true;
                }
            }
        }
        return false;
    }

    /**
     * Method tries to place new figure on the game field.
     * @param figure Figure to place.
     * @param topLeft Point where to place.
     * @return True if figure was successfully added, False if figure is out of bounds or there is a collision.
     */
    public boolean placeFigureField(int[][] figure, Point topLeft) {
        final int xShift = topLeft.getX();
        final int yShift = topLeft.getY();

        // Check whether we can place this figure on this position or not.
        if (yShift + figure.length > heightSize || xShift + figure[0].length > widthSize) {
            return false;
        }

        // Making mask with wanted position for our figure.
        final int[][] mask = new int[heightSize][widthSize];
        for (int i = 0; i < figure.length; ++i) {
            System.arraycopy(figure[i], 0, mask[i + yShift], xShift, figure[0].length);
        }

        // Check if we have collisions.
        int[][] newField = Utils.matrixAddition(field, mask);
        if (!Utils.isAdditionCorrect(newField)) {
            return false;
        }

        // Add new figure on map.
        for (int i = 0; i < heightSize; ++i) {
            System.arraycopy(newField[i], 0, field[i], 0, widthSize);
        }

        field = Utils.clearFullRows(field);

        return true;
    }

    public void printField() {
        for (int i = 0; i < heightSize; ++i) {
            for (int j = 0; j < widthSize; ++j) {
                System.out.print(field[i][j] + "  ");
            }
            System.out.println();
        }
    }

    public int[][] getField() {
        return field;
    }

    public static int getHeight() {
        return heightSize;
    }

    public static int getWidth() {
        return widthSize;
    }
}
