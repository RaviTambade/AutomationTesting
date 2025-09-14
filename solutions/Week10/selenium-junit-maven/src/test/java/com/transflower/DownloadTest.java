package com.transflower;


import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;


import static org.assertj.core.api.Assertions.assertThat;


public class DownloadTest extends BaseTest {


@Test
public void verify_download_link_exists() {
driver.get("http://localhost:5500/download.html");
String href = driver.findElement(By.cssSelector("[data-test='link-download']")).getAttribute("href");
assertThat(href).startsWith("data:text/plain");
}
}