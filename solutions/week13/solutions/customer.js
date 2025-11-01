

class Customer {
    constructor(name, email,age) {
        this.name = name;
        this.email = email;
        this.age=age
    }

    showDetails() {
        console.log("Customer Name: " + this.name);
        console.log("Customer Email: " + this.email);
        console.log("Customer Age: " + this.age);
    }
}



let customer1 = new Customer("Alice Smith", "alice@example.com", 30);
let customer2 = new Customer("Bob Johnson", "bob@example.com", 25);
let customer3 = new Customer("Charlie Brown", "charlie@example.com", 35);
customer1.showDetails();
customer2.showDetails();
customer3.showDetails();