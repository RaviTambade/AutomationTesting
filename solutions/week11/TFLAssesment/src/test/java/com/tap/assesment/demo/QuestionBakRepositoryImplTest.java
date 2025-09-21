package com.tap.assesment.demo;
import com.tap.assesment.Entity.Question;
import com.tap.assesment.Managers.FileIOManager;
import com.tap.assesment.Repository.QuestionBankRepositoryImpl;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.*;
import java.util.*;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

public class QuestionBakRepositoryImplTest {
   
    @Mock
    private FileIOManager fileIOManager;

    @InjectMocks
    private QuestionBankRepositoryImpl repository;

    private Question question1;
   

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);

        question1 = new Question(
                "What is .NET?", "A", "B", "C", "D",
                'C', 5, 200, 200
        );

    }

    @Test
    void testSave() {
        List<Question> mockList = new ArrayList<>();
        when(fileIOManager.loadFromFile()).thenReturn(mockList);

       boolean status = repository.addQuestion(question1);
        assertTrue(status);

        //assertTrue(mockList.contains(question1));
       // verify(fileIOManager, times(1)).saveToFile(mockList);
    }


}
