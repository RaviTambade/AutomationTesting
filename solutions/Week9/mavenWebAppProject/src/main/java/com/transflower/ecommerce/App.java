package com.transflower.ecommerce;
import java.util.List;
import com.transflower.ecommerce.catalog.entities.Product;
import com.transflower.ecommerce.catalog.repositories.*;
import com.transflower.ecommerce.catalog.services.*;


public class App 
{
    public static void main( String[] args )
    {
        //java lang 
        Product p1=new Product(1, "Gerbera","Wedding Flower", 109);
        ProductRepository productRepository = new ProductRepositoryImpl();
        ProductService productService = new ProductServiceImpl(productRepository);
        Product product = new Product(1, "Rose","Valentine Flower", 109);
        productService.createProduct(product);

        Product product2 = new Product(2, "Tulip","Spring Flower", 89);
        productService.createProduct(product2);
        List<Product> products = productService.getAllProducts();
        products.forEach(p -> System.out.println(p.getTitle()));

    }
}


//mvn package 
//mvn clean compile exec:java
