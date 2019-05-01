package softuniBlog.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import softuniBlog.entity.Article;
import softuniBlog.repository.ArticleRepository;

import java.util.List;

@Controller
public class HomeController {

    @GetMapping("/")
    public String index(Model model) {

        List<Article> allArticles = this.articleRepository.findAll();

        model.addAttribute("view", "home/index");
        model.addAttribute("articles", allArticles);
        return "base-layout";
    }

    @Autowired
    private ArticleRepository articleRepository;
}
