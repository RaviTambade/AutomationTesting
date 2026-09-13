//TestBed
//means a place where you can test your code and see the output

//variables
//programming statements
//functions
//data 
var products=require('./products.json');
var lib=require('./src/autlib.js');

//global variable
var companyName="Transflower";
console.log(companyName);

//scope of variable
let count=89;
console.log(count);
//JSON object
//JavaScript Object Notation
let product={
    name: "Laptop",
    price: 50000,
    title: "HP",
    stockAvailable: true,
    stock: 100,
    reviews: [
        {
            name: "Ravi",
            rating: 5,
            comment: "Great product!"
        },
        {
            name: "Akashay",
            rating: 4,
            comment: "Good value for money."
        }
    ]
};
console.log(product);
for(let i=0; i<products.length; i++){
    console.log(products[i].name);
    console.log(products[i].price);
    console.log(products[i].title);
}

//forEach loop
products.forEach(lib.showProductDetails);


//SOC:
//Separation of Concerns
