package hse.java.faketetris.geometry;

public enum Figures {
    R_MID_SHAPE(new int[][]{
            {1, 1},
            {1, 0},
            {1, 0}
    }),
    R_SMALL_SHAPE(new int[][]{
            {1, 1},
            {1, 0}
    }),
    R_BIG_SHAPE(new int[][]{
            {1, 1, 1},
            {1, 0, 0},
            {1, 0, 0}
    }),
    L_MID_SHAPE(new int[][]{
            {1, 0},
            {1, 0},
            {1, 1}
    }),
    L_SMALL_SHAPE(new int[][]{
            {1, 0},
            {1, 1}
    }),
    L_BIG_SHAPE(new int[][]{
            {1, 0, 0},
            {1, 0, 0},
            {1, 1, 1}
    }),
    T_BIG_SHAPE(new int[][]{
            {1, 1, 1},
            {0, 1, 0},
            {0, 1, 0}
    }),
    T_SMALL_SHAPE(new int[][]{
            {1, 1, 1},
            {0, 1, 0}
    }),
    Z_NORMAL_SHAPE(new int[][]{
            {1, 0},
            {1, 1},
            {0, 1}
    }),
    Z_REVERSED_SHAPE(new int[][]{
            {0, 1},
            {1, 1},
            {1, 0}
    }),
    SQUARE_SHAPE(new int[][]{
            {1, 1},
            {1, 1}
    }),
    LARGE_SQUARE_SHAPE(new int[][]{
            {1, 1, 1},
            {1, 1, 1},
            {1, 1, 1}
    }),
    LINE_SHAPE(new int[][]{
            {1, 1, 1}
    }),
    SHORT_LINE_SHAPE(new int[][]{
            {1, 1}
    }),
    DIAGONAL_SHAPE(new int[][]{
            {1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}
    }),
    SHORT_DIAGONAL_SHAPE(new int[][]{
            {1, 0},
            {0, 1}
    }),
    DOT_SHAPE(new int[][]{
            {1}
    });

    private final int[][] field;

    Figures(int[][] field) {
        this.field = field;
    }

    public int[][] getField() {
        return field;
    }

    // Number of all figures.
    public static final int count = Figures.values().length;
}
