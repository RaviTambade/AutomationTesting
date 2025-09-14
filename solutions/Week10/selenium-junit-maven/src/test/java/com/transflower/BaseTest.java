package com.transflower;


import io.github.bonigarcia.wdm.WebDriverManager;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;


public class BaseTest {
protected WebDriver driver;


@BeforeEach
public void setUp(){
WebDriverManager.chromedriver().setup();
ChromeOptions opts = new ChromeOptions();
// uncomment headless for CI
// opts.addArguments("--headless=new");
driver = new ChromeDriver(opts);
driver.manage().window().maximize();
}


@AfterEach
public void tearDown(){
if(driver != null) driver.quit();
}
}