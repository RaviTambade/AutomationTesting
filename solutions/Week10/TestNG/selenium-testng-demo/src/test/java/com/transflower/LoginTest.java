package com.transflower;


import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.*;
import io.github.bonigarcia.wdm.WebDriverManager;

public class LoginTest {

    WebDriver driver;

    @BeforeClass
    public void setup() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
    }

    @Test
    public void testLoginPageTitle() {
        driver.get("https://example.com/login");
        String title = driver.getTitle();
        System.out.println("Page title: " + title);
        Assert.assertEquals(title, "Login - Example");
    }

    @Test
    public void testLoginButtonExists() {
        driver.get("https://example.com/login");
        WebElement loginButton = driver.findElement(By.id("loginButton"));
        Assert.assertTrue(loginButton.isDisplayed());
    }

    @AfterClass
    public void teardown() {
        if (driver != null) {
            driver.quit();
        }
    }
}
