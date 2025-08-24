package com.transflower.ecommerce.catalog.services;
import java.util.*;
import com.transflower.ecommerce.catalog.entities.Product;

public interface ProductService {
    // Define service methods here
    Product createProduct(Product product);
    Product getProductById(int id);
    List<Product> getAllProducts();
    Product updateProduct(int id, Product product);
    void deleteProduct(int id);
}
