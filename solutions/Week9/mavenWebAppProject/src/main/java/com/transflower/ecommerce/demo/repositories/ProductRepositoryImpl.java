package com.transflower.ecommerce.demo.repositories;
import java.util.*;
import com.transflower.ecommerce.demo.entities.Product;

public class ProductRepositoryImpl implements ProductRepository
{
  private List<Product> productDB = new ArrayList<>();
  private int currentId = 1;

   public ProductRepositoryImpl() {
      // Sample data
      productDB.add(new Product(currentId++, "Product 1", "Description 1", 100));
      productDB.add(new Product(currentId++, "Product 2", "Description 2", 200));
  }
  

  @Override
  public Product createProduct(Product product) {
      product.setId(currentId++);
      productDB.add(product);
      return product;
  }

  @Override
  public Product getProductById(int id) {
      return productDB.stream()
              .filter(product -> product.getId() == id)
              .findFirst()
              .orElse(null);
  }

  @Override
  public List<Product> getAllProducts() {
      return new ArrayList<>(productDB);
  }

  @Override
  public Product updateProduct(int id, Product product) {
      deleteProduct(id);
      product.setId(id);
      productDB.add(product);
      return product;
  }

  @Override
  public void deleteProduct(int id) {
      productDB.removeIf(product -> product.getId() == id);
  }
}
