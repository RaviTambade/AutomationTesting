package com.transflower.ecommerce.membership.repositories;
import com.transflower.ecommerce.membership.entities.User;
import java.util.*;


public class UserRepositoryImpl implements UserRepository {

 List<User> users = new ArrayList<>();

    @Override
    public void registerUser(User user) {
        users.add(user);
        System.out.println("User registered: " + user.getContactNumber());
    }

    @Override
    public User getUserByContactNumber(String contactNumber) {
        for (User user : users) {
            if (user.getContactNumber().equals(contactNumber)) {
                return user;
            }
        }
        return null;
    }

    @Override
    public void updateUser(User user) {
        for (int i = 0; i < users.size(); i++) {
            if (users.get(i).getContactNumber().equals(user.getContactNumber())) {
                users.set(i, user);
                System.out.println("User updated: " + user.getContactNumber());
                return;
            }
        }
    }

    @Override
    public void deleteUser(String contactNumber) {
        users.removeIf(user -> user.getContactNumber().equals(contactNumber));
        System.out.println("User deleted: " + contactNumber);
    }

    @Override
    public boolean login(String contactNumber, String password) {
        boolean userFound = false;
        for (User user : users) {
            if (user.getContactNumber().equals(contactNumber) && user.getPassword().equals(password)) {
                System.out.println("Login successful for user: " + user.getContactNumber());
                userFound = true;
                break;
            }
        }
        System.out.println("Login failed for user with contact number: " + contactNumber);
        return userFound;
    }

}
