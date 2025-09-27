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
}