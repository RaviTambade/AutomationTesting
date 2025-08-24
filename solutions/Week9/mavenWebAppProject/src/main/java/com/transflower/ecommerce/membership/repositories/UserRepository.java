package com.transflower.ecommerce.membership.repositories;
import com.transflower.ecommerce.membership.entities.User;

//Interface defines the contract for user-related operations

public  interface  UserRepository {
  
    public void registerUser(User user);
    public User getUserByContactNumber(String contactNumber);
    public void updateUser(User user);
    public void deleteUser(String contactNumber);
    public boolean login(String contactNumber, String password);

}
