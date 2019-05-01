package shoppinglist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import shoppinglist.bindingModel.ProductBindingModel;
import shoppinglist.entity.Product;
import shoppinglist.repository.ProductRepository;

import java.util.List;

@Controller
public class ProductController {

	private final ProductRepository productRepository;

	@Autowired
	public ProductController(ProductRepository productRepository) {
		this.productRepository = productRepository;
	}

	@GetMapping("/")
	public String index(Model model) {

		List<Product> allProducts = productRepository.findAll();

		model.addAttribute("products", allProducts);
		model.addAttribute("view", "product/index");

		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "product/create");  // Add the view page!

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, ProductBindingModel productBindingModel) {

		if (productBindingModel == null) {
			return "redirect:/";
		}

		if (productBindingModel.getName().equals("")
				|| productBindingModel.getStatus().equals("")
				|| productBindingModel.getQuantity() <= 0
				|| productBindingModel.getPriority() < 0) {

			return "redirect:/";
		}

		Product currentProduct = new Product(
				productBindingModel.getPriority(),
				productBindingModel.getName(),
				productBindingModel.getQuantity(),
				productBindingModel.getStatus()
		);

		productRepository.saveAndFlush(currentProduct);

		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {

		Product productToEdit = productRepository.findOne(id);

		if (productToEdit == null) {
			return "redirect:/";
		}

		model.addAttribute("view", "product/edit");
		model.addAttribute("product", productToEdit);

		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, ProductBindingModel productBindingModel) {
		if (productBindingModel == null) {
			return "redirect:/";
		}

		Product productToEdit = productRepository.findOne(id);

		if (productToEdit == null) {
			return "redirect:/";
		}

		productToEdit.setPriority(productBindingModel.getPriority());
		productToEdit.setName(productBindingModel.getName());
		productToEdit.setQuantity(productBindingModel.getQuantity());
		productToEdit.setStatus(productBindingModel.getStatus());

		if (productBindingModel.getName().equals("")
				|| productBindingModel.getStatus().equals("")
				|| productBindingModel.getQuantity() <= 0
				|| productBindingModel.getPriority() <= 0) {

			return "redirect:/";
		}

		productRepository.saveAndFlush(productToEdit);

		return "redirect:/";
	}
}
