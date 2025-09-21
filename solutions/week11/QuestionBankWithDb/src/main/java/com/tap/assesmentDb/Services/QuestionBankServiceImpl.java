package com.tap.assesmentDb.Services;


import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

import com.tap.assesmentDb.Entity.Question;
import com.tap.assesmentDb.Repository.QuestionBankRepository;
import com.tap.assesmentDb.Repository.QuestionBankRepositoryImpl;


public class QuestionBankServiceImpl  implements QuestionBankService {
    
    private QuestionBankRepository questionBankRepository;


    public QuestionBankServiceImpl(QuestionBankRepository questionBankRepository) {
        this.questionBankRepository = questionBankRepository;
    }

    @Override
    public CompletableFuture<ArrayList<Question>> getAll() {
        return questionBankRepository.getAll();
    }
    
    @Override
    public CompletableFuture<Boolean> insert(Question q) {
        return questionBankRepository.insert(q);
    }

    @Override
    public CompletableFuture<Boolean> update(int id, Question q)
    {
        return questionBankRepository.update(id, q);
    }

    @Override
    public CompletableFuture<Boolean> delete(int idToBeDelete)
    {
        return questionBankRepository.delete(idToBeDelete);
    }
}
