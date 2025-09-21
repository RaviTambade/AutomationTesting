package com.transflower.tflassessment.controllers;

import org.springframework.web.bind.annotation.*;
import com.transflower.tflassessment.entities.*;

import java.util.*;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    private final Map<Integer, Product> productStore = new HashMap<>();
    private int nextId = 1;

    // CREATE
    @PostMapping
    public Product createProduct(@RequestBody Product product) {
        product.setId(nextId++);
        productStore.put(product.getId(), product);
        return product;
    }

    // READ ALL
    @GetMapping
    public List<Product> getAllProducts() {
        return new ArrayList<>(productStore.values());
    }

    // READ BY ID
    @GetMapping("/{id}")
    public Product getProductById(@PathVariable int id) {
        return productStore.get(id);
    }

    // UPDATE
    @PutMapping("/{id}")
    public Product updateProduct(@PathVariable int id, @RequestBody Product updated) {
        Product existing = productStore.get(id);
        if (existing != null) {
            existing.setName(updated.getName());
            existing.setPrice(updated.getPrice());
        }
        return existing;
    }

    // DELETE
    @DeleteMapping("/{id}")
    public String deleteProduct(@PathVariable int id) {
        return productStore.remove(id) != null ? "Deleted" : "Not Found";
    }
}