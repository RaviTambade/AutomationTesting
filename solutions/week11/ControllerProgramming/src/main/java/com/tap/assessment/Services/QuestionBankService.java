package com.tap.assessment.Services;

import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

import com.tap.assessment.Entity.Question;

public interface  QuestionBankService {
    
    public  ArrayList<Question> getAll();
    public  Boolean insert(Question q);
    public  Boolean update(int id, Question q);
    public  Boolean delete(int idToBeDelete) ;
}
