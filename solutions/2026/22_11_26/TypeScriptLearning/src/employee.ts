

//Object:
// state, behaviour, identity

class Developer{

    constructor(){

    }

    build(){

    }

    code(){

    }
}


class Tester{
    constructor(){

    }

    report(){

    }
    test(){

    }
}


class Mentor{
    constructor(){

    }

    teach(){

    }

    evaluate(){

    }
}


class  Employee{

    //data members (state)
    empId:number;
    name:string;
    department:string;
    salary:number;

    //member functions (behaviour)
    constructor(i:number, nm:string,dept:string, sal:number){
        this.empId=98;
        this.department="sales";
        this.salary=56000;
        this.name="Ravi";
    }

    display(){
        console.log(this.empId +" "+ " "+ this.department+ " "+ this.salary);

    }
}


//Create objects

let emp1=new Employee(45,"Akshay","accounts",96000);
let emp2=new Employee(56,"Rajiv","training",78000);

emp1.display();

let ev1:Developer=new Developer();

//basics of  OOP's
//How to write simple typescript variable
//How to write simple typescript type
//How to create number of objects from user defined types
//How to write a class 
//How to declare data members for a class
//How to declare constructor for a class
//How to initialize data members  inside a constructor
//How to write member function display to a classs
//How to create object from class
//How to call member function using object variable
