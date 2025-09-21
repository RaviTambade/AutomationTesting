package com.tap.assessment.Repository;

import java.sql.*;
import java.util.*;
import java.util.concurrent.CompletableFuture;

import org.springframework.stereotype.Repository;

import com.tap.assessment.Entity.Question;


public interface QuestionBankRepository {


    public  ArrayList<Question> getAll();
    public  Boolean insert(Question q);
    public  Boolean update(int id, Question q);
    public  Boolean delete(int idToBeDelete) ;
}
