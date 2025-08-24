package com.transflower.ecommerce.membership.entities;


//POJO class
//means Plain Old Java Object
//Description: This class represents a user in the e-commerce application.

public class User {

    //User claim
    private String contactNumber;
    private String password;


    public User( String contactNumber, String password) {
    
        this.contactNumber = contactNumber;
        this.password = password;
    }

    // Getters and Setters
    public String getContactNumber() {
        return contactNumber;
    }

    public void setContactNumber(String contactNumber) {
        this.contactNumber = contactNumber;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

}
