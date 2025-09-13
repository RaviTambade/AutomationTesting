package com.transflower.ecommerce.catalog.repositories;
import java.util.*;
import com.transflower.ecommerce.catalog.entities.Product;

public class ProductRepositoryImpl implements ProductRepository
{
  private List<Product> productDB = new ArrayList<>();
  private int currentId = 1;


   //Constructor overloading
   //Defualt Constructor
   public ProductRepositoryImpl() {
      // Sample data
      productDB.add(new Product(currentId++, "Product 1", "Description 1", 100));
      productDB.add(new Product(currentId++, "Product 2", "Description 2", 200));
   }
  
   //Parameterized constructor
  public ProductRepositoryImpl(List<Product> initialProducts) {
      this.productDB = new ArrayList<>(initialProducts);
      this.currentId = initialProducts.size() + 1;
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



  @Override
  protected void finalize( ) throws Throwable {
      // TODO Auto-generated method stub
      super.finalize(); 
  }


  //difference between overloading and overriding
  // Overloading occurs when two or more methods in the same class have the same name but different parameters.
  // Overriding occurs when a subclass provides a specific implementation of a method that is already defined in its superclass.

}
