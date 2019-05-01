package todolist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import todolist.bindingModel.TaskBindingModel;
import todolist.entity.Task;
import todolist.repository.TaskRepository;

import java.util.List;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        //TODO:Implement me...

        List<Task> tasks = taskRepository.findAll();

        model.addAttribute("tasks", tasks);
        model.addAttribute("view", "task/index");

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        //TODO:Implement me...

        model.addAttribute("view", "task/create");  // Add the view page!

        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, TaskBindingModel taskBindingModel) {
        //TODO:Implement me...

        if (taskBindingModel == null) {
            return "redirect:/";
        }

        if (taskBindingModel.getTitle().equals("")
                || taskBindingModel.getComments().equals("")) {

            return "redirect:/";
        }

        Task currentTask = new Task(
                taskBindingModel.getTitle(),
                taskBindingModel.getComments()
        );

        taskRepository.saveAndFlush(currentTask);

        return "redirect:/";
    }

    @GetMapping("/delete/{id}")
    public String delete(Model model, @PathVariable int id) {
        //TODO:Implement me...

        Task taskToDelete = taskRepository.findOne(id);

        if (taskToDelete == null) {
            return "redirect:/";
        }

        model.addAttribute("view", "task/delete");
        model.addAttribute("task", taskToDelete);

        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    public String deleteProcess(Model model, @PathVariable int id) {
        //TODO:Implement me...

        Task taskToDelete = taskRepository.findOne(id);

        if (taskToDelete == null) {
            return "redirect:/";
        }

        taskRepository.delete(taskToDelete);
        taskRepository.flush();

        return "redirect:/";
    }
}
