
//Test Engineering work

//relative path   ./
//absolute path   C:/Ravi/TAP/TAP/AutomationTesting/solutions/2026/19_9_26/tests/calculator.spec.js

var autCalculator=require('../src/caculator.js');


test("Addition test", () => {
    let actualResult = autCalculator.Addition(1, 1);
    let expectedResult = 2;
    expect(actualResult).toBe(expectedResult);
});

test("Subtraction test", () => {
    let actualResult = autCalculator.Subtraction(5, 3);
    let expectedResult = 2;
    expect(actualResult).toBe(expectedResult);
});

test("Multiplication test", () => {
    let actualResult = autCalculator.Multiplication(4, 3);
    let expectedResult = 12;
    expect(actualResult).toBe(expectedResult);
});

test("Division test", () => {
    let actualResult = autCalculator.Division(10, 2);
    let expectedResult = 5;
    expect(actualResult).toBe(expectedResult);
});