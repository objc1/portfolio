package hse.java.leypunskiyMaksim208hw5.model;

import hse.java.leypunskiyMaksim208hw5.geometry.Figures;
import hse.java.leypunskiyMaksim208hw5.geometry.Rotations;
import hse.java.leypunskiyMaksim208hw5.geometry.Utils;

import java.util.Random;

public class Figure {
    private final Figures type;
    private final Rotations rotation;

    private static final Random random = new Random();

    public Figure(Figures type, Rotations rotation) {
        this.type = type;
        this.rotation = rotation;
    }

    /**
     * Generation of random figure.
     * @return Random figure.
     */
    public static Figure generateRandom() {
        // Int code represents type of figure.
        // Can be found in ./geometry/Figures.java enum file.
        final int codeOfFigure = random.nextInt(0, Figures.count);
        // Int code represents degrees of rotation.
        // 0 - 0 degrees.
        // 1 - 90 degrees.
        // 2 - 180 degrees.
        // 3 - 270 degrees.
        final int codeOfRotation = random.nextInt(0, Rotations.count);
        Figures type = Figures.values()[codeOfFigure];
        Rotations rotation = Rotations.values()[codeOfRotation];
        return new Figure(type, rotation);
    }

    public Figures getType() {
        return type;
    }

    public Rotations getRotation() {
        return rotation;
    }

    public int[][] getField() {
        return Utils.rotate(type.getField(), rotation);
    }

    public int getScore() {
        int score = 0;
        for (int i = 0; i < type.getField().length; ++i) {
            for (int j = 0; j < type.getField()[i].length; ++j) {
                if (type.getField()[i][j] == 1) {
                    ++score;
                }
            }
        }
        return score;
    }

    @Override
    public String toString() {
        return "Figure{" +
                "type=" + type +
                ", rotation=" + rotation +
                '}';
    }
}
