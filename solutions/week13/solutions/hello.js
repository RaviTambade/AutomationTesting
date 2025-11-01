//interpreted programming language: JavaScript
//Means:line by line execution
//dynamically typed language


var count = 0;
console.log("Hello, World!");
count++;
console.log("This program has been run " + count + " times.");
var fullname = "John Doe";
let status = false;
var character = 'A';
//json object
var product={
    id: 1,
    name: "Sample Product",
    price: 9.99
};

var strProduct = JSON.stringify(product);

function getCount() {
    return count;
}
function addition(a, b) {
    return a + b;
}

console.log("Full Name: " + fullname);
console.log("Status: " + status);
console.log("Character: " + character);
console.log("Product: " +strProduct );
console.log("Addition of 5 and 10: " + addition(5, 10));

var oldProduct=JSON.parse(strProduct);
console.log("Old Product Name: " + oldProduct.name);
