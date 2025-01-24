package hse.java.faketetris;

import hse.java.faketetris.geometry.Point;
import hse.java.faketetris.model.Figure;
import hse.java.faketetris.model.GameField;
import hse.java.faketetris.model.User;
import hse.java.faketetris.view.FigureView;
import hse.java.faketetris.view.InteractiveView;
import javafx.application.Application;
import javafx.application.Platform;
import javafx.geometry.Bounds;
import javafx.geometry.Insets;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.ButtonType;
import javafx.scene.control.TextInputDialog;
import javafx.scene.layout.*;
import javafx.scene.paint.Color;
import javafx.stage.Stage;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;

public class MainApplication extends Application {
    private final static String SAVE_FILE_NAME = ".save.txt";
    private GridPane gridPane;
    private GameField gameField;
    private Pane[][] panes;
    private InteractiveView interactiveView;
    private double mouseAnchorX;
    private double mouseAnchorY;
    private double startX;
    private double startY;
    private boolean isStartCorrect = false;
    private static final Random random = new Random();
    private static final ArrayList<User> users = new ArrayList<>();
    private int count;
    private Optional<User> currentUser = Optional.empty();

    @Override
    public void start(Stage stage) {
        configureGridPane();
        configureScene(stage);
        configureGame();
        generateNewFigure();
        getLeaderboard();
        askForName();
        startTimer();
        count = 0;
    }

    private void setup() {
        count = 0;
        configureGridPane();
        configureGame();
        generateNewFigure();
        startTimer();
        interactiveView.getLeft().getScoreLabel().setText("Score: 0");
        interactiveView.getFigureView().setTranslateX(startX);
        interactiveView.getFigureView().setTranslateY(startY);
    }

    private void getLeaderboard() {
        try (Scanner scanner = new Scanner(new File(SAVE_FILE_NAME))) {
            while (scanner.hasNextLine()) {
                String nextLine = scanner.nextLine();
                String[] user = nextLine.split(";");
                if (user.length != 2) {
                    throw new IllegalArgumentException("Error while parsing: " + nextLine);
                }

                int score = Integer.parseInt(user[1]);
                if (score < 0) {
                    throw new IllegalArgumentException("Wrong score for: " + user[0]);
                }

                users.add(new User(user[0], score));
            }
        } catch (IOException | IllegalArgumentException exception) {
            System.out.println("error: " + exception.getMessage());
        }

        updateUsers();
    }

    private void updateUsers() {
        interactiveView.getLeft().getListView().getItems().clear();
        Collections.sort(users);
        Collections.reverse(users);
        List<String> userStrings = users.stream().map(User::toString).toList();
        interactiveView.getLeft().getListView().getItems().addAll(userStrings);
    }

    private void startTimer() {
        interactiveView.getLeft().getTimeline().stop();
        interactiveView.getLeft().timeCountProperty().set(0);
        interactiveView.getLeft().getTimeline().play();
    }

    private void generateNewFigure() {
        interactiveView.getFigureView().getChildren().clear();
        Figure figure = Figure.generateRandom();
        FigureView figureView = new FigureView(figure);
        interactiveView.updateFigure(figureView);
        makeDraggable(interactiveView.getFigureView(), panes);

        if (!gameField.canPlaceNext(figure)) {
            showResults();
            setup();
        }
    }

    private void makeDraggable(FigureView node, Pane[][] panes) {
        if (!isStartCorrect) {
            startX = node.getTranslateX();
            startY = node.getTranslateY();
            isStartCorrect = true;
        }
        node.setOnMousePressed(mouseEvent -> {
            mouseAnchorX = mouseEvent.getSceneX() - node.getTranslateX();
            mouseAnchorY = mouseEvent.getSceneY() - node.getTranslateY();
        });

        node.setOnMouseDragged(mouseEvent -> {
            node.setTranslateX(mouseEvent.getSceneX() - mouseAnchorX);
            node.setTranslateY(mouseEvent.getSceneY() - mouseAnchorY);
        });

        node.setOnMouseReleased(mouseEvent -> {
            findLeftTopCell(node, panes);
            Optional<Point> point = findLeftTopCell(node, panes);
            if (point.isPresent()) {
                if (gameField.placeFigure(node.getFigure(), point.get())) {
                    System.out.println("successfully added");
                    updateField();
                    node.setTranslateX(startX);
                    node.setTranslateY(startY);
                    count += node.getFigure().getScore();
                    interactiveView.getLeft().getScoreLabel().setText(String.format("Score: %d", count));
                    generateNewFigure();
                }
            }
        });
    }

    private Optional<Point> findLeftTopCell(FigureView node, Pane[][] panes) {
        Node topLeft = node.getPanes()[0][0];
        Bounds bounds = topLeft.localToScene(topLeft.getBoundsInLocal());
        double x = bounds.getCenterX();
        double y = bounds.getCenterY();

        Bounds gridBound;
        double gridX;
        double gridY;
        for (int i = 0; i < panes.length; ++i) {
            for (int j = 0; j < panes[0].length; ++j) {
                gridBound = panes[i][j].localToScene(panes[i][j].getBoundsInLocal());
                gridX = gridBound.getCenterX();
                gridY = gridBound.getCenterY();
                if (Math.abs(gridX - x) < 25 && Math.abs(gridY - y) < 25) {
                    //System.out.printf("found left top corner: [%d][%d]\n", i, j);
                    return Optional.of(new Point(j, i));
                }
            }
        }
        return Optional.empty();
    }

    private void updateField() {
        for (int i = 0; i < gameField.getField().length; ++i) {
            for (int j = 0; j < gameField.getField()[0].length; ++j) {
                if (gameField.getField()[i][j] == 1) {
                    panes[i][j].setBackground(FigureView.getOkColor());
                } else {
                    panes[i][j].setBackground(new Background(new BackgroundFill(Color.LIGHTGREY, CornerRadii.EMPTY, Insets.EMPTY)));
                }
            }
        }
        gridPane.getChildren().clear();
        for (int i = 0; i < gameField.getField().length; ++i) {
            for (int j = 0; j < gameField.getField()[0].length; ++j) {
                gridPane.add(panes[i][j], j, i);
            }
        }
    }

    private void configureGame() {
        this.gameField = new GameField();
    }

    private void addUser(User user) {
        users.add(user);
        interactiveView.getLeft().getListView().getItems().add(user.toString());
        currentUser = Optional.of(user);
    }

    private void showResults() {
        interactiveView.getLeft().getTimeline().pause();
        Alert alert = new Alert(Alert.AlertType.INFORMATION,
                "Results: "
                        + interactiveView.getLeft().getTimeCount() +
                        " seconds\ntotal score: "
                        + count,
                ButtonType.OK);
        alert.setHeaderText("Game finished!");
        alert.showAndWait();

        if (!currentUser.isPresent()) {
            return;
        }

        currentUser.get().setHighScore(Math.max(currentUser.get().getHighScore(), count));
        updateUsers();
        saveData();
    }

    private void saveData() {
        try(FileWriter fileWriter = new FileWriter(SAVE_FILE_NAME)) {
            for (User user : users) {
                fileWriter.write(String.format("%s;%d\n", user.getName(), user.getHighScore()));
            }
        } catch (IOException exception) {
            System.out.println(exception.getMessage());
        }
    }

    private void configureScene(Stage stage) {
        stage.setMinWidth(800);
        stage.setMaxWidth(800);
        stage.setMinHeight(850);
        stage.setMaxHeight(850);
        stage.setTitle("Not a Tetris");
        BorderPane root = new BorderPane();
        BorderPane bottomCenter = new BorderPane();
        BorderPane top = new BorderPane();
        this.interactiveView = new InteractiveView();
        this.interactiveView.getLeft().getNewGameButton().setOnAction(actionEvent -> {
            showResults();
            setup();
        });
        this.interactiveView.getLeft().getEndGameButton().setOnAction(actionEvent -> {
            showResults();
            Platform.exit();
            System.exit(0);
        });
        top.setCenter(interactiveView);

        bottomCenter.setCenter(gridPane);
        var bottomPadding = new Pane();
        bottomPadding.setPrefHeight(50);
        bottomCenter.setBottom(bottomPadding);
        root.setBottom(bottomCenter);
        root.setTop(top);
        Scene scene = new Scene(root);
        stage.setScene(scene);
        stage.show();
    }

    private void askForName() {
        TextInputDialog dialog = new TextInputDialog("user" + random.nextInt(1000, 100000));
        dialog.setTitle("Give me your name!");
        dialog.setHeaderText("What's your name?");
        dialog.setContentText("Please enter your name:");
        dialog.getDialogPane().lookupButton(ButtonType.CANCEL).setVisible(false);
        dialog.getDialogPane().lookupButton(ButtonType.CANCEL).setDisable(true);

        Optional<String> result = dialog.showAndWait();

        handleName(result);
    }

    private void handleName(Optional<String> name) {
        if (name.isEmpty()) {
            Alert alert = new Alert(Alert.AlertType.ERROR, "Name is incorrect", ButtonType.OK);
            alert.showAndWait();
            askForName();
            return;
        }

        boolean userExist = false;
        for (User user: users) {
            if (name.get().equals(user.getName())) {
                userExist = true;
                currentUser = Optional.of(user);
                break;
            }
        }

        if (!userExist) {
            User newUser = new User(name.get(), 0);
            addUser(newUser);
        }
    }

    private void configureGridPane() {
        if (!Objects.isNull(this.gridPane)) {
            gridPane.getChildren().clear();
        } else {
            gridPane = new GridPane();
        }
        gridPane.setPadding(new Insets(4));
        gridPane.setMaxSize(466, 466);
        gridPane.setBackground(new Background(new BackgroundFill(Color.BLACK, CornerRadii.EMPTY, Insets.EMPTY)));
        gridPane.setHgap(2);
        gridPane.setVgap(2);

        panes = new Pane[GameField.getHeight()][GameField.getWidth()];
        for (int i = 0; i < GameField.getHeight(); ++i) {
            for (int j = 0; j < GameField.getWidth(); ++j) {
                Pane pane = new Pane();
                pane.setPrefSize(50, 50);
                pane.setBackground(new Background(new BackgroundFill(Color.LIGHTGREY, CornerRadii.EMPTY, Insets.EMPTY)));
                gridPane.add(pane, j, i);
                panes[i][j] = pane;
            }
        }
    }

    public static void main(String[] args) {
        launch();
    }
}