package com.tap.assessment.Services;


import java.util.ArrayList;
import java.util.concurrent.CompletableFuture;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.tap.assessment.Entity.Question;
import com.tap.assessment.Repository.QuestionBankRepository;

@Service
public class QuestionBankServiceImpl  implements QuestionBankService {
    
    private QuestionBankRepository questionBankRepository;

    @Autowired
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
