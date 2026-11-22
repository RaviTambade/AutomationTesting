
//contract
//interface

//Role :Printing
//Responsibilty
interface IPrintable{
    //Rule
    print():any;
    display():any;
}

//Role:Saving

interface ISerializable{
    serialize():any;

}

//inheritance

//both roles are implementated by SavingAccount
class SavingAccount implements IPrintable,ISerializable{

    //data member: State
    balance :number;


    //member functions

    //initializer
    constructor(amount:number){
        this.balance=amount;
    }


    deposit(amount :number):boolean{
        let flag:boolean=false;
        this.balance=this.balance+amount;
        flag=true;
        return flag;
    }

    withdraw(amount :number):boolean{
        let flag:boolean=false;
        this.balance=this.balance-amount;
        flag=true;
        return flag;
    }

    print():any{
        console.log("Balance ="+ this.balance);
    }

    display():any{
        console.log("Showing all detais");
    }

    serialize() {
        console.log("Saving data to file");
    }
}


class CurrentAccount implements IPrintable{

    constructor(){

    }

    print() {
        
    }
    display() {
        
    }

}

let acct123:SavingAccount=new SavingAccount(9000);


let acct65:SavingAccount=new SavingAccount(65000);


let iacct:IPrintable=new SavingAccount(89000);
iacct.print();   //Polymorphism
iacct.display();

