### 📖 Mentor Storytelling Flow

👨‍🏫 *“Alright team, let’s roll back to something very basic — the **command window**. The good old `CMD`. That black screen is like the backstage where the real magic of programming happens.”*

### Step 1: Writing Our First Java Program

* We wrote a simple file `Hello.java`.
* Inside it, we created a class with the **entry point** method:

  ```java
  public static void main(String[] args) {
      System.out.println("Hello World");
  }
  ```
* Then we went to the command prompt:

  ```bash
  javac Hello.java   // compile → creates Hello.class (bytecode)
  java Hello         // run → JVM executes bytecode
  ```

👨‍🏫 *“Notice — Java compiles into `.class` files (bytecode). In .NET, it’s `.dll` assemblies. Both are not raw machine code, but intermediate code waiting for the runtime to execute.”*

### Step 2: Environment Setup

* Installed **JDK 24**.
* Set `JAVA_HOME` environment variable.
* Added `bin` folder to `PATH`.
* Opened VS Code.
* Installed **Java Extension Pack** for smooth coding.

👨‍🏫 *“Think of it like setting your kitchen. JDK is your gas cylinder, VS Code is the stove, and the extension pack is your set of utensils. Without them, you can’t cook!”*

### Step 3: Employee Class – Encapsulation

We created `Employee.java`:

```java
public class Employee {
    private String firstName;
    private String lastName;
    private String email;
    private String contactNumber;

    public Employee() {}  // default constructor

    public Employee(String f, String l, String e, String c) {
        this.firstName = f;
        this.lastName = l;
        this.email = e;
        this.contactNumber = c;
    }

    // Getters & Setters
    // toString() override
}
```

👨‍🏫 *“Notice: In Java, everything starts with encapsulation. Private variables, getters, setters. In C#, it’s similar but we often use auto-properties (`{ get; set; }`). Small difference, same spirit.”*

### Step 4: Readonly / Final Keyword

* In **C#**, we use `readonly`.
* In **Java**, we use `final`.

```java
public final String location;
```

* Once initialized in constructor → cannot be changed later.

👨‍🏫 *“If Pune is your employee’s location, it will remain Pune forever. Even if HR tries to transfer him — Java will say ❌ *‘Final field cannot be reassigned’.* That’s immutability.”*



### Step 5: Inheritance – SalesEmployee

We extended `Employee`:

```java
public class SalesEmployee extends Employee {
    private double salesAmount;
    private double commissionRate;

    public SalesEmployee(String f, String l, String e, String c,
                         double amount, double rate) {
        super(f, l, e, c);  // parent constructor
        this.salesAmount = amount;
        this.commissionRate = rate;
    }

    public double computePay() {
        return salesAmount * commissionRate;
    }

    @Override
    public String toString() {
        return super.toString() + 
               " Sales Amount=" + salesAmount +
               " Commission=" + commissionRate;
    }
}
```

👨‍🏫 *“In C# we say `: base(...)`. In Java we say `super(...)`. Both mean → respect your parents first, then define yourself.”*

---

### Step 6: Testing – Main Program

```java
public class Test {
    public static void main(String[] args) {
        SalesEmployee s1 = new SalesEmployee(
            "Ravi", "Tambade", "ravi@email.com", "1234567890",
            50000, 0.10
        );
        System.out.println(s1);
        System.out.println("Salary: " + s1.computePay());
    }
}
```

* Compile & run:

  ```bash
  javac *.java
  java Test
  ```

👨‍🏫 *“Here JVM will create objects on the heap, references on the stack, and when you print `System.out.println(s1)`, it automatically calls `toString()`. That’s polymorphism in action!”*

---

### Step 7: Packages

* We created a folder `HR/`.
* Put `Employee.java` and `SalesEmployee.java` inside.
* Declared `package HR;` on top of each file.
* In `Test.java`:

  ```java
  import HR.*;
  ```

👨‍🏫 *“In C#, we use `using HR;`. In Java, we use `import HR.*;`. Same kitchen, different utensils.”*

---

### Step 8: Automation with Maven

👨‍🏫 *“Till now, we used `javac` and `java` manually. But what if you have **50 files** and **10 dependencies**? Will you compile each one by hand?”*

That’s where **Maven** comes in:

* Build automation tool for Java.
* Uses **POM (Project Object Model)** file.
* Handles compilation, packaging (`.jar`), testing, and documentation automatically.

👨‍🏫 *“So instead of washing dishes after every meal, Maven is your dishwasher. You just focus on cooking the recipe (business logic).”*

---

### Step 9: Bigger Picture

* **Java** = simplicity.
* **C#** = power (took best things from Java, C++, VB).
* **Visual Basic** = elegance.
* **C#** combined all → Simplicity + Power + Elegance.

👨‍🏫 *“If you’re a Java developer, moving to C# is easy. If you’re a C# developer, moving to Java is also easy. That’s why companies love full-stack engineers who can adapt.”*

---

✅ **Final Mentor Punchline**
*“Remember — tools like VS Code, Eclipse, or IntelliJ are just kitchens. Languages like Java, C#, Python are just recipes. What matters is — can you cook a tasty dish that solves a business problem? That’s what industry pays you for.”*

 