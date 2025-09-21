package com.tap.assesment.demo;
import com.tap.assesment.Entity.Question;
 
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class QuestionTest {

    @Test
    void testDefaultConstructor() {
        Question question = new Question();
        assertEquals("", question.getTitle(), "Default title should be empty string");
        assertEquals(0, question.getId(), "Default id should be 0");
    }

    @Test
    void testParameterizedConstructor() {
        Question question = new Question("What is dotnet ?","option1", "option2", "option3", "option4", 'A', 10, 1, 100);

        assertEquals("What is dotnet ?", question.getTitle());
        assertEquals("option1", question.getOptionA());
        assertEquals("option2", question.getOptionB());
        assertEquals("option3", question.getOptionC());
        assertEquals("option4", question.getOptionD());
        assertEquals('A', question.getCorrectAnswer());
        assertEquals(10, question.getEvaluationCriteria());
        assertEquals(1, question.getId());
         
    }

    @Test
    void testSettersAndGetters() {
        Question question = new Question();

        question.setTitle("New Title");
        question.setId(5);
        question.setSubjectId(101);
        question.setOptionA("Option A");
        question.setOptionB("Option B");
        question.setOptionC("Option C");
        question.setOptionD("Option D");
        question.setCorrectAnswer('B');
        question.setEvaluationCriteria(25);

    }

    @Test
    void testToString() {
        Question question = new Question(
                "Title", "A", "B", "C", "D",
                'C', 5, 200, 200
        );

        String expected = "Title";
        assertEquals(expected, question.toString());
    }
}
