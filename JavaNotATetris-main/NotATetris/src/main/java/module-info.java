module hse.java.faketetris {
    requires javafx.controls;
    requires javafx.fxml;


    opens hse.java.faketetris to javafx.fxml;
    exports hse.java.faketetris;
}