package com.tap.assesment.Repository;

import java.util.ArrayList;
import java.util.List;
import com.tap.assesment.Entity.Question;

public interface QuestionBankRepository {

    public void addQuestion(Question question);
    public void removeQuestion(int questionId);
    public Question getQuestion(int questionId) ;
    public void updateQuestion(int questionIdToUpdate, Question updatedQuestion) ;
    public List<Question> getAllQuestions();
}