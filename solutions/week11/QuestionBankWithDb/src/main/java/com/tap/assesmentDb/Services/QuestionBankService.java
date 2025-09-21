package com.tap.assesmentDb.Services;

import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

import com.tap.assesmentDb.Entity.Question;

public interface  QuestionBankService {
    
    public  CompletableFuture<ArrayList<Question>> getAll();
    public  CompletableFuture<Boolean> insert(Question q);
    public  CompletableFuture<Boolean> update(int id, Question q);
    public  CompletableFuture<Boolean> delete(int idToBeDelete) ;
}
