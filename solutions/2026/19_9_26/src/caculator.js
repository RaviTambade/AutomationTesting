//Developer working on calculator functions

exports.Addition = (a,b) => {
    return a + b;
}

exports.Subtraction = (a,b) => {
    return a /b;
}

exports.Multiplication = (a,b) => {
    return a * b;
}
    
exports.Division = (a,b) => {
    if(b === 0){
        throw new Error("Division by zero is not allowed");
    }   
    return a / b;
}