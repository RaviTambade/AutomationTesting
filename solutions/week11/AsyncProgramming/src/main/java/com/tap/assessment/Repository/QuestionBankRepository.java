package com.tap.assessment.Repository;

import java.sql.*;
import java.util.*;
import java.util.concurrent.CompletableFuture;

import org.springframework.stereotype.Repository;

import com.tap.assessment.Entity.Question;


public interface QuestionBankRepository {


    public  CompletableFuture<ArrayList<Question>> getAll();
    public  CompletableFuture<Boolean> insert(Question q);
    public  CompletableFuture<Boolean> update(int id, Question q);
    public  CompletableFuture<Boolean> delete(int idToBeDelete) ;
}
