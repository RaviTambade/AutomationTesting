package com.tap.assesmentDb.Main;

import java.sql.*;
import java.util.ArrayList;

import com.tap.assesmentDb.Entity.Question;
import com.tap.assesmentDb.Repository.QuestionBankRepository;
import com.tap.assesmentDb.Repository.QuestionBankRepositoryImpl;
import com.tap.assesmentDb.Services.QuestionBankService;
import com.tap.assesmentDb.Services.QuestionBankServiceImpl;
import com.tap.assesmentDb.UI.UiManager;

public class App {
    public static void main(String[] args) throws Exception {

        QuestionBankRepository questionBankRepository = new QuestionBankRepositoryImpl();
        QuestionBankService questionBankService = new QuestionBankServiceImpl(questionBankRepository);


        int choice = 0;
        do {
            UiManager.displayMenu();
            choice = UiManager.getUserChoice();
            switch (choice) {
                case 1: {
                    ArrayList<Question> q1 = new ArrayList<Question>();
                    q1 = questionBankService.getAll().get();
                    for (Question q : q1) {
                        System.out.println(q);
                    }
                }
                    break;
                case 2: {
                    Question question = UiManager.getInputQuestion();
                    boolean status = questionBankService.insert(question).get();
                    if (status) {
                        UiManager.successful();
                    } else {
                        UiManager.failed();
                    }
                }
                    break;
                case 3: {
                    int id = UiManager.getInputId();
                    Question question = UiManager.getInputQuestion();
                    boolean status = questionBankService.update(id, question).get();
                    if (status) {
                        UiManager.successful();
                    } else {
                        UiManager.failed();
                    }
                }
                    break;

                case 4: {
                    int id = UiManager.getInputId();
                    boolean status = questionBankService.delete(id).get();
                    if (status) {
                        UiManager.successful();
                    } else {
                        UiManager.failed();
                    }
                }
                    break;
                case 5:
                    UiManager.thankyoumsg();
                    System.exit(0);
                    break;

                default:
                    UiManager.wrongChoice();
                   
                    break;
            }
        } while (choice != 5);

    }
}
