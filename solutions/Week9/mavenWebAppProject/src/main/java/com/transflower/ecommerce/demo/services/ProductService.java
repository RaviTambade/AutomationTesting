package com.transflower.ecommerce.demo.services;
import java.util.*;
import com.transflower.ecommerce.demo.entities.Product;

public interface ProductService {
    // Define service methods here
    Product createProduct(Product product);
    Product getProductById(int id);
    List<Product> getAllProducts();
    Product updateProduct(int id, Product product);
    void deleteProduct(int id);
}
