
import type { Person } from './person';
import type { Product } from './product';


//JavaScript code
let result=56;
let fullname="John Doe";
let status=true;
let price=1000.50;

//JSON object
let user1={
    name:"John",
    age:30,
    isActive:true
};

//TypeScript code

class Customer {
    //Properties
    id: number;
    name: string;
    email: string;

    //behaviors ( Member functions)
    constructor(id: number, name: string, email: string) {
        this.id = id;
        this.name = name;
        this.email = email;
    }

    display():void {
        console.log(`Customer: ${this.name}, Email: ${this.email}`);
    }
}

//inbuilt types

let message:string="Welcome to Transflower";
let count:number=56;
let isactive:boolean=true;



//User defined types

//Defineing a type for a person object
let user3: Person={
    name:"John",
    age:30,
    isActive:true
};

//Define shema for a product object
//sekeleton of a product object
//strcuture

let product1: Product={
    id:1,
    name:"Laptop",
    price:1000,
    isAvailable:true
};

let product2: Product={
    id:2,
    name:"Smartphone",
    price:500,
    isAvailable:false
};  

let product3: Product={
    id:3,
    name:"Tablet",
    price:300,
    isAvailable:true
};


let products: Product[]=[
    product1,
    product2,
    product3
];

console.log("Result:",result);
console.log("Full Name:",fullname);
console.log("Status:",status);
console.log("Price:",price);

console.log("User1:",user1);
console.log("User3:",user3);
console.log("Product1:",product1);
console.log("Product2:",product2);
console.log("Product3:",product3);
console.log("Products:",products);



//Command to run the TypeScript code

//npx tsc src/app.ts --outDir dist --ignoreConfig


//new keyword is used to create an instance of a class

//class is a blueprint for creating objects
//constructor is a special method that is called 
//when an object is created from a class


//properties are variables that are associated with a class

let customer1=new Customer(1,"John Doe","john.doe@example.com");
customer1.display();


let customer2=new Customer(2,"Jane Smith","jane.smith@example.com");
customer2.display();


let customer3=new Customer(3,"Alice Johnson","alice.johnson@example.com");
customer3.display();
