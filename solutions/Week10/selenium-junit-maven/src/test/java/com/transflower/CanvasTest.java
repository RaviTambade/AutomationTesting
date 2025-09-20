package com.transflower;
import org.junit.jupiter.api.Test;
import org.openqa.selenium.By;

import static org.assertj.core.api.Assertions.assertThat;

public class CanvasTest extends BaseTest {

@Test
public void canvas_element_exists() {
driver.get("http://localhost:5500/canvas.html");
assertThat(driver.findElement(By.id("myCanvas")).isDisplayed()).isTrue();
assertThat(driver.findElement(By.id("myCanvas")).getAttribute("width")).isEqualTo("300");
assertThat(driver.findElement(By.id("myCanvas")).getAttribute("height")).isEqualTo("150");
}
}