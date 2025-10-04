package com.example.catalog.tests;

import io.restassured.RestAssured;
import io.restassured.http.ContentType;

import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class ProductApiTest {

    @Test
    public void testGetAllProducts() {
        RestAssured.baseURI = "http://localhost:9090";

        given()
            .when().get("/api/products")
            .then()
            .statusCode(200)
            .body("size()", greaterThan(0))
            .body("[0].name", notNullValue());
    }

    // ✅ GET one product by ID
     @Test
    public void getProductById_shouldReturnOne() {
        given()
        .when()
            .get("/api/products/1")
        .then()
            .statusCode(200)
            .body("name", notNullValue())
            .body("price", greaterThan(0));
    }

    @Test
    public void createProduct_shouldReturn201() {
        String newProductJson = """
        {
            "id": 66,
            "name": "Wireless Mouse",
            "price": 1500
        }

        """;

        given()
            .contentType(ContentType.JSON)
            .body(newProductJson)
        .when()
            .post("/api/products")
        .then()
            .statusCode(201) // Created
            .body("id", notNullValue())
            .body("name", equalTo("Wireless Mouse"));
    }

    // ✅ UPDATE product (PUT)
    @Test
    public void updateProduct_shouldReturn200() {
        String updatedProductJson = """
        {
            "id": 3,
            "name": "Wireless Mouse",
            "price": 2200
        }
        """;

        given()
            .contentType(ContentType.JSON)
            .body(updatedProductJson)
        .when()
            .put("/api/products/1")
        .then()
            .statusCode(200)
            .body("name", equalTo("Wireless Mouse"))
            .body("price", equalTo(2200));
    }

    @Test
    public void deleteProduct_shouldReturn204() {
        given()
        .when()
            .delete("/api/products/3")
        .then()
            .statusCode(204); // No Content
    }

}