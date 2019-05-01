package todolist.entity;

import org.springframework.boot.autoconfigure.web.ResourceProperties;

import javax.persistence.*;

@Entity
@Table(name = "tasks")
public class Task {
	// TODO:Implement me...
    // Create properties
    // Create Getters and Setters
    // Create Constructors

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private String title;

    private String comments;

    public Task() {
        // Empty constructor!
    }

    public Task(String title, String comments) {
        this.title = title;
        this.comments = comments;
    }

    @Column(nullable = false)   // Insert annotation for getter
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Column(nullable = false)   // Insert annotation for getter
    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    @Column(nullable = false)   // Insert annotation for getter
    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }
}
