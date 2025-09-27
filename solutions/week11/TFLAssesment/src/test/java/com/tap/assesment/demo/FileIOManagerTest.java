package com.tap.assesment.demo;
import com.tap.assesment.Entity.Question;
import com.tap.assesment.Managers.FileIOManager;
import com.tap.assesment.*;
import org.junit.jupiter.api.*;

import java.io.File;
import java.util.*;
import static org.junit.jupiter.api.Assertions.*;

class FileIOManagerTest {

    private FileIOManager fileIOManager;
    private String testFileName = "test_questions.dat";

    @BeforeEach
    void setUp() {
        fileIOManager = new FileIOManager() {
            { this.fileName = testFileName; } // override default file name
        };
    }



    @Test
    void testSaveAndLoadQuestions() {
        // Arrange
        List<Question> questions = new ArrayList<>();
        questions.add(new Question(
                "What is .NET?", "A", "B", "C", "D",
                'C', 5, 200, 200
        ));

        questions.add(new Question(
                "What is Java?", "A", "B", "C", "D",
                'C', 5, 200, 200
        ));
        

        // Act - Save to file
        fileIOManager.saveToFile(questions);

        // Assert file exists
        File file = new File(testFileName);
        assertTrue(file.exists(), "File should be created after saving");

        // Act - Load from file
        List<Question> loadedQuestions = fileIOManager.loadFromFile();

        // Assert loaded data
        assertNotNull(loadedQuestions, "Loaded questions should not be null");
        assertEquals(2, loadedQuestions.size(), "Should load 2 questions");

        assertEquals("What is .NET?", loadedQuestions.get(0).getTitle());
        assertEquals("What is Java?", loadedQuestions.get(1).getTitle());

    }

    @Test
    void testLoadFromFileWhenFileDoesNotExist() {
        // File is deleted in tearDown
        List<Question> loadedQuestions = fileIOManager.loadFromFile();
        assertNotNull(loadedQuestions, "Should return empty list if file not found");
        assertTrue(loadedQuestions.isEmpty(), "List should be empty if file not found");
    }


        @AfterEach
    void tearDown() {
        File file = new File(testFileName);
        if (file.exists()) {
            file.delete();
        }
    }
}