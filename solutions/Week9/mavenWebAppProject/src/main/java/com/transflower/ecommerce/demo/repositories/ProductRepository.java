package com.transflower.ecommerce.demo.repositories;
import java.util.*;
import com.transflower.ecommerce.demo.entities.Product;

public interface ProductRepository {

    //CRUD Operations for Product
    Product createProduct(Product product);
    Product getProductById(int id);
    List<Product> getAllProducts();
    Product updateProduct(int id, Product product);
    void deleteProduct(int id);

}
