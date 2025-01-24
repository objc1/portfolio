package hse.java.faketetris.view;

import javafx.animation.KeyFrame;
import javafx.animation.KeyValue;
import javafx.animation.Timeline;
import javafx.beans.binding.Bindings;
import javafx.beans.binding.StringBinding;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.geometry.Insets;
import javafx.geometry.Orientation;
import javafx.geometry.Pos;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.layout.*;
import javafx.scene.paint.Color;
import javafx.scene.text.TextAlignment;
import javafx.util.Duration;

public class InfoView extends VBox {
    private final Button newGameButton;
    private final Button endGameButton;
    private final Timeline timeline;
    private final IntegerProperty timeCount;
    private final ListView<String> listView;
    private final Label scoreLabel;

    public InfoView() {
        this.newGameButton = new Button("New game");
        newGameButton.setBackground(new Background(new BackgroundFill(Color.GREEN, CornerRadii.EMPTY, Insets.EMPTY)));
        newGameButton.setTextAlignment(TextAlignment.CENTER);

        this.endGameButton = new Button("End game");
        endGameButton.setTextAlignment(TextAlignment.CENTER);
        endGameButton.setBackground(new Background(new BackgroundFill(Color.RED, CornerRadii.EMPTY, Insets.EMPTY)));

        this.listView = new ListView<>();
        int cellSize = 30;
        listView.setFixedCellSize(cellSize);
        listView.setMaxHeight(cellSize * 5);
        listView.setEditable(false);

        Label leaderboardLabel = new Label("Leaderboard");

        VBox vBox = new VBox();
        vBox.setAlignment(Pos.CENTER);
        vBox.getChildren().addAll(leaderboardLabel, listView);

        Label timerLabel = new Label("Time: 0");
        timerLabel.setAlignment(Pos.CENTER);
        timerLabel.setTextAlignment(TextAlignment.CENTER);

        scoreLabel = new Label("Score: 0");
        scoreLabel.setAlignment(Pos.CENTER);
        scoreLabel.setTextAlignment(TextAlignment.CENTER);

        BorderPane borderPane = new BorderPane();

        FlowPane left = new FlowPane();
        left.setVgap(10);
        left.setOrientation(Orientation.VERTICAL);
        left.setAlignment(Pos.CENTER);
        left.getChildren().addAll(
                scoreLabel,
                timerLabel,
                newGameButton,
                endGameButton
        );
        left.setPadding(new Insets(0, 50, 0, 0));

        borderPane.setPadding(new Insets(0, 0, 0, 50));
        borderPane.setLeft(left);
        borderPane.setRight(vBox);
        getChildren().add(borderPane);

        // Setting up timer.
        timeCount = new SimpleIntegerProperty(0);
        timeline = new Timeline(new KeyFrame(Duration.seconds(1000), new KeyValue(timeCount, 1000)));
        StringBinding binging = Bindings.createStringBinding(() -> "Time:  " + timeCount.get(), timeCount);
        timerLabel.textProperty().bind(binging);
    }

    public Button getNewGameButton() {
        return newGameButton;
    }

    public Button getEndGameButton() {
        return endGameButton;
    }

    public ListView<String> getListView() {
        return listView;
    }

    public Label getScoreLabel() {
        return scoreLabel;
    }

    public Timeline getTimeline() {
        return timeline;
    }

    public int getTimeCount() {
        return timeCount.get();
    }

    public IntegerProperty timeCountProperty() {
        return timeCount;
    }
}
