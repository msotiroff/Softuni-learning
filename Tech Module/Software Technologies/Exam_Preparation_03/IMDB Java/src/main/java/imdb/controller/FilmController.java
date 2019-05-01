package imdb.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import imdb.bindingModel.FilmBindingModel;
import imdb.entity.Film;
import imdb.repository.FilmRepository;

import java.util.List;

@Controller
public class FilmController {

	private final FilmRepository filmRepository;

	@Autowired
	public FilmController(FilmRepository filmRepository) {

		this.filmRepository = filmRepository;
	}

	@GetMapping("/")
	public String index(Model model) {

		List<Film> allFilms = filmRepository.findAll();

		model.addAttribute("films", allFilms);
		model.addAttribute("view", "film/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {

		model.addAttribute("view", "film/create");  // Add the view page!

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, FilmBindingModel filmBindingModel) {
		if (filmBindingModel == null) {
			return "redirect:/";
		}

		if (filmBindingModel.getName().equals("")
				|| filmBindingModel.getGenre().equals("")
				|| filmBindingModel.getDirector().equals("")) {

			return "redirect:/";
		}

		Film currentFilm = new Film(
				filmBindingModel.getName(),
				filmBindingModel.getGenre(),
				filmBindingModel.getDirector(),
				filmBindingModel.getYear()
		);

		filmRepository.saveAndFlush(currentFilm);

		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		Film filmToEdit = filmRepository.findOne(id);

		if (filmToEdit == null) {
			return "redirect:/";
		}

		model.addAttribute("view", "film/edit");
		model.addAttribute("film", filmToEdit);

		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, FilmBindingModel filmBindingModel) {
		if (filmBindingModel == null) {
			return "redirect:/";
		}

		Film filmToEdit = filmRepository.findOne(id);

		if (filmToEdit == null) {
			return "redirect:/";
		}

		filmToEdit.setName(filmBindingModel.getName());
		filmToEdit.setGenre(filmBindingModel.getGenre());
		filmToEdit.setDirector(filmBindingModel.getDirector());
		filmToEdit.setYear(filmBindingModel.getYear());

		filmRepository.saveAndFlush(filmToEdit);

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		Film filmToDelete = filmRepository.findOne(id);

		if (filmToDelete == null) {
			return "redirect:/";
		}

		model.addAttribute("view", "film/delete");
		model.addAttribute("film", filmToDelete);

		return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id) {
		Film filmToDelete = filmRepository.findOne(id);

		if (filmToDelete == null) {
			return "redirect:/";
		}

		filmRepository.delete(filmToDelete);
		filmRepository.flush();

		return "redirect:/";
	}
}
