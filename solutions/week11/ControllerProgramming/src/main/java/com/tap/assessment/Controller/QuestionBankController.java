package com.tap.assessment.Controller;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.CompletableFuture;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import com.tap.assessment.Entity.Question;
import com.tap.assessment.Services.QuestionBankService;



@RestController
public class QuestionBankController {

    @Autowired
    private final QuestionBankService questionBankService;

    //@Autowired
    public QuestionBankController(QuestionBankService service) {
        this.questionBankService = service;
    }
    
    // http://localhost:9090/questionbank/questions
     @GetMapping("/questionbank/questions")
    public ArrayList<Question> getAll(){
        return questionBankService.getAll();
    }

     
    @PostMapping("/questionbank/addQuestion")  
    public Boolean addQuestion(@RequestBody Question question)   
    {  
        return questionBankService.insert(question);  
    }
   
    @DeleteMapping("/questionbank/deleteQuestion/{id}")  
    public Boolean deleteProduct(@PathVariable("id") int id)   
    {  
         return questionBankService.delete(id);  
    }  

    @PutMapping("/questionbank/updateQuestion/{id}")  
    private Boolean updateProduct(@PathVariable("id") int id, @RequestBody Question question)   
    {  
        return questionBankService.update(id,question);
    }  

}