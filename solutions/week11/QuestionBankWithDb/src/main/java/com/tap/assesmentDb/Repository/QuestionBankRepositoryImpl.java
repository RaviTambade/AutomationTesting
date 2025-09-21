package com.tap.assesmentDb.Repository;

import java.sql.*;
import java.util.*;
import java.util.concurrent.CompletableFuture;

import com.tap.assesmentDb.Entity.Question;

public class QuestionBankRepositoryImpl implements QuestionBankRepository {

    public static Connection connection;
    //static Block
    //means it will be executed only once
    //when the class is loaded
    static {
        try {
            String URL = "jdbc:mysql://localhost:3306/assessmentdb";
            String USERNAME = "root";
            String PASSWORD = "password";
            connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);

        } catch (Exception e) {
            System.out.println(e);
        }
    };

    @Override
    public  CompletableFuture<ArrayList<Question>> getAll() {
        return CompletableFuture.supplyAsync(() -> {
            ArrayList<Question> questions = new ArrayList<Question>();

            try {
                Statement smt = connection.createStatement();
                ResultSet rs = smt.executeQuery("select * from questionbank");

                while (rs.next()) {

                    Question question = new Question(rs.getString(3), rs.getString(4), rs.getString(5), rs.getString(6),
                            rs.getString(7), rs.getString(8), rs.getInt(9), rs.getInt(1), rs.getInt(2));

                    questions.add(question);
                }

            } catch (SQLException e) {
                System.out.println(e);
            }
            return questions;

        });

    }

    @Override
    public  CompletableFuture<Boolean> insert(Question q)  {
        return CompletableFuture.supplyAsync(()->{
            boolean status = false;
            try {
            PreparedStatement pst = connection.prepareStatement("insert into questionbank values(?,?,?,?,?,?,?,?,?)");
            pst.setInt(1, q.getId());
            pst.setInt(2, q.getSubjectId());
            pst.setString(3, q.getTitle());
            pst.setString(4, q.getOptionA());
            pst.setString(5, q.getOptionB());
            pst.setString(6, q.getOptionC());
            pst.setString(7, q.getOptionD());
            pst.setString(8, q.getCorrectAnswer());
            pst.setInt(9, q.getEvaluationCriteria());
            pst.executeUpdate();
            status = true;
            }
            catch(Exception e)
            {
                System.out.println(e);
            }

            return status;
        });
    }
    @Override
    public  CompletableFuture<Boolean> update(int id, Question q)  {
        return CompletableFuture.supplyAsync(()->{
        boolean status = false;
        try{
        PreparedStatement pst = connection.prepareStatement(
                "update questionbank set subjectid=?, title=?, a=?,b=?,c=?,d=?,answerkey=?,evaluationcriteriaid=?,id=? where id=?");
        pst.setInt(10, id);
        pst.setInt(9, q.getId());
        pst.setInt(1, q.getSubjectId());
        pst.setString(2, q.getTitle());
        pst.setString(3, q.getOptionA());
        pst.setString(4, q.getOptionB());
        pst.setString(5, q.getOptionC());
        pst.setString(6, q.getOptionD());
        pst.setString(7, q.getCorrectAnswer());
        pst.setInt(8, q.getEvaluationCriteria());

        pst.executeUpdate();
        status = true;
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
        return status;
        });
    }

    @Override
    public  CompletableFuture<Boolean> delete(int idToBeDelete)  {
        return CompletableFuture.supplyAsync(()->{
        boolean status = false;
        try{
        PreparedStatement pst = connection.prepareStatement(
                "delete from questionbank where id=?");
        pst.setInt(1, idToBeDelete);
        pst.executeUpdate();
        status = true;
        }
        catch(Exception e)
        {
            System.out.println(e);
        }
            return status;

        });
    }

}
