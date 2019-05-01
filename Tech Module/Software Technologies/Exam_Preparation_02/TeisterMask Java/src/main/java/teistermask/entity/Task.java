package teistermask.entity;

import org.springframework.data.annotation.*;

import javax.persistence.*;
import javax.persistence.Id;

@Entity
@Table(name = "tasks")
public class Task {
	// TODO: Implement me...

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    private String title;

    private  String status;

    public Task() {
        // Empty constructor!!!
    }

    public Task(String title, String status) {
        this.title = title;
        this.status = status;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
