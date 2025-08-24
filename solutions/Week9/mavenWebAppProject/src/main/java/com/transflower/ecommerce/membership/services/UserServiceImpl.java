package com.transflower.ecommerce.membership.services;
import com.transflower.ecommerce.membership.entities.User;
import com.transflower.ecommerce.membership.repositories.*;


public class UserServiceImpl implements UserService {

    private UserRepository userRepository   ;
    // Constructor Dependency Injection
    public UserServiceImpl(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @Override
    public void registerUser( String contactNumber, String password) {
        User user = new User(contactNumber, password);
        userRepository.registerUser(user);
    }

    @Override
    public User getUserByContactNumber(String contactNumber) {
        return userRepository.getUserByContactNumber(contactNumber);
    }

    @Override
    public void updateUser(String contactNumber,  String password) {
        User user = new User( contactNumber, password);
        userRepository.updateUser(user);
    }

    @Override
    public void deleteUser(String contactNumber) {
        userRepository.deleteUser(contactNumber);
    }

    @Override
    public boolean login(String contactNumber, String password) {
        return userRepository.login(contactNumber, password);
    }   
}
