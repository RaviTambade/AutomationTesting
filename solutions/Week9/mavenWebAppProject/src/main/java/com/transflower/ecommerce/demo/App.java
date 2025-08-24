package com.transflower.ecommerce.demo;
import java.util.List;
import com.transflower.ecommerce.demo.entities.Product;
import com.transflower.ecommerce.demo.repositories.*;
import com.transflower.ecommerce.demo.services.*;


public class App 
{
    public static void main( String[] args )
    {
        System.out.println( "Hello World!" );
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