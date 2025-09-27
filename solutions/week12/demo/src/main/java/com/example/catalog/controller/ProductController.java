package com.example.catalog.controller;

import com.example.catalog.model.Product;
import org.springframework.web.bind.annotation.*;

import java.util.*;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    private final List<Product> products = new ArrayList<>(Arrays.asList(
            new Product(1, "Laptop", 75000),
            new Product(2, "Phone", 35000),
            new Product(3, "Headphones", 2000)
    ));

    @GetMapping
    public List<Product> getAllProducts() {
        return products;
    }

    @GetMapping("/{id}")
    public Product getProductById(@PathVariable int id) {
        return products.stream()
                .filter(p -> p.getId() == id)
                .findFirst()
                .orElse(null);
    }

 
    @PostMapping
    public Product createProduct(@RequestBody Product product) {
        // Generate new ID (max+1)

        System.out.println("Creating product: " + product.getName());
        int newId = products.stream().mapToInt(Product::getId).max().orElse(0) + 1;
        product.setId(newId);
        products.add(product);
        return product;
    }


    @PutMapping("/{id}")
    public Product updateProduct(@PathVariable int id, @RequestBody Product updatedProduct) {

        System.out.println("Updating product: " + updatedProduct.getName());
        for (int i = 0; i < products.size(); i++) {
            Product p = products.get(i);
            if (p.getId() == id) {
                p.setName(updatedProduct.getName());
                p.setPrice(updatedProduct.getPrice());
                return p;
            }
        }
        return null; // or throw exception
    }

    @DeleteMapping("/{id}")
    public String deleteProduct(@PathVariable int id) {

        System.out.println("Deleting product with ID: " + id);
        boolean removed = products.removeIf(p -> p.getId() == id);
        return removed ? "Product deleted successfully" : "Product not found";
    }
}