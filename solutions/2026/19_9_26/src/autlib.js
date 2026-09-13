//Library is a collection of functions that can be used in other files. 
//It is a way to organize code and make it reusable.

//CRUD operations for products
//C:Create
//R:Read
//U:Update
//D:Delete

//you are setting up a function to show product details
exports.showProductDetails = (theProduct) => {
    console.log(theProduct.name);
    console.log(theProduct.price);
    console.log(theProduct.title);
}

exports.addProduct = (theProduct) => {
    console.log("Product added successfully");
    console.log(theProduct);
}

exports.updateProduct = (theProduct) => {
    console.log("Product updated successfully");
    console.log(theProduct);
}

exports.deleteProduct = (theProduct) => {
    console.log("Product deleted successfully");
    console.log(theProduct);
}