package com.transflower.ecommerce.membership.services;
import com.transflower.ecommerce.membership.entities.User;
public interface UserService {

    void registerUser( String contactNumber, String password);
    User getUserByContactNumber(String contactNumber);
    void updateUser(String contactNumber, String password);
    void deleteUser(String contactNumber);
    boolean login(String contactNumber, String password);

}
