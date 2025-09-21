package com.tap.assesmentDb.Repository;

import java.sql.*;
import java.util.*;
import java.util.concurrent.CompletableFuture;

import com.tap.assesmentDb.Entity.Question;

public interface QuestionBankRepository {
    public  CompletableFuture<ArrayList<Question>> getAll();
    public  CompletableFuture<Boolean> insert(Question q);
    public  CompletableFuture<Boolean> update(int id, Question q) ;
    public  CompletableFuture<Boolean> delete(int idToBeDelete);

}
