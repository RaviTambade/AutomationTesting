


//inbuilt types

let count:number=45;
let flag:boolean=false;
let title:string="Transflower";


//User Defined type
type Product={
    price:number;
    id:number;
    title:string;
   
    isAvailable:boolean;
}


let flower11:Product={
id:45,
title:"Gerbera",
isAvailable:true,
price:56,
}


let flower12:Product={
id:47,
title:"Rose",
price:56,
isAvailable:false
}


//type , blueprint, class,  template, metadata

type Customer={
    custid:number;
    firstname:string;
    lastname:string;
    age:number;
    registered:boolean;
}


let c1:Customer={
    custid:56,
    firstname:"Sameer",
    lastname:"Patil",
    age:23,
    registered:true
};

let c2:Customer={
    custid:45,
    firstname:"Aay",
    lastname:"Patil",
    age:23,
    registered:true
};

let c3:Customer={
    custid:67,
    firstname:"Sameer",
    lastname:"Mane",
    age:23,
    registered:true
};

console.log(c3);
console.log(flower12);