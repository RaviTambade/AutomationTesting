package com.example.catalog.tests;

import io.restassured.RestAssured;
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
}