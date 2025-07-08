

# Understanding Containment in C# OOP through Real Coding

Once upon a time, every software engineer stood where you are today — curious, sometimes puzzled, but always hungry to build something real.

I still remember the day I first understood what a *class* was. We had just learned how to write a class, how to declare private variables, and write getter-setter methods. It felt like we were learning to define our own small universe — one object at a time.

But today, I want to take you deeper.

We are entering a new dimension of Object-Oriented Programming: **Containment**.


🛠️ **Imagine you're building a graphics application.**

A basic one. Nothing fancy.

It needs to represent simple graphical objects — `Point`, `Line`, `Circle`. You see, each shape has a relationship with another object.

> 🔁 *"A Circle **has-a** Point (center). A Line **has-a** Point (start and end)."*

That’s **containment** — when one class includes another class as its member.

---

📦 So we roll up our sleeves and create a fresh project:

```bash
mkdir GraphicsSolution
cd GraphicsSolution
dotnet new console -o GraphicsTest
```

We even organize it well with a solution and add the project:

```bash
dotnet new sln -n GraphicsSolution
dotnet sln add ./GraphicsTest/GraphicsTest.csproj
```

---

### ✏️ Let’s start small. A **Point** class.

```csharp
namespace Drawing
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }
    }
}
```

This is no longer just variables and constructors. This is **your first reusable building block.**

### ⭕ Now the **Circle** class

> “Every Circle has a center – which is a Point – and a radius.”

So, in your class:

```csharp
public class Circle
{
    public Point Center { get; set; }
    public int Radius { get; set; }

    public Circle()
    {
        Center = new Point();
        Radius = 0;
    }

    public Circle(Point center, int radius)
    {
        Center = center;
        Radius = radius;
    }

    public void Display()
    {
        Console.WriteLine($"Circle => Center: ({Center.X}, {Center.Y}), Radius: {Radius}");
    }
}
```

This is **containment** in action — one object wrapping another object within itself.

---

### ➖ Let's not forget the **Line** class:

```csharp
public class Line
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Line(Point start, Point end)
    {
        StartPoint = start;
        EndPoint = end;
    }

    public void Display()
    {
        Console.WriteLine($"Line => Start: ({StartPoint.X}, {StartPoint.Y}), End: ({EndPoint.X}, {EndPoint.Y})");
    }
}
```

Everything is coming together now — multiple classes, working together like parts of a living system.

---

🧠 **Lesson Hidden in the Code**

When you create a class that *has-a* relationship with another class, you are practicing one of the strongest ideas in object-oriented design: **reusability and modularity**. It’s how real-world software is written.

Think of this like building a house: You don’t reinvent the concept of a "brick" every time. You build with bricks (Point), assemble them into walls (Line), and then construct rooms (Circle).

---

📘 **Another Story: The HR System**

Let’s flip the page to a more real-world use case: an **HR Management System**.

We designed a `Date` class:

```csharp
namespace HR
{
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public void Display()
        {
            Console.WriteLine($"{Day}/{Month}/{Year}");
        }
    }
}
```

And an `Employee` class that *contains* this:

```csharp
public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Date JoinDate { get; set; }

    public void Display()
    {
        Console.WriteLine($"{FirstName} {LastName} joined on {JoinDate.Day}/{JoinDate.Month}/{JoinDate.Year}");
    }
}
```

Just like our graphics application, this system builds on containment. Whether it's shapes or people, **containment creates connected systems.**

---

💡 **The Bigger Picture**

These examples aren’t just about points, circles, or dates. They’re about **how software thinks** — how large, complex systems are just a collection of smaller, focused, reusable objects.

* ✅ Properties (`get; set;`)
* ✅ Constructors (default + parameterized)
* ✅ Object creation using `new`
* ✅ Containment (`has-a` relationship)
* ✅ Reusability and structure

---

🎯 **Takeaway from Your Mentor**

> “This is not just code. This is the story of software. Of how systems come alive. Of how each class becomes a character. And your mind? The author.”

When I started my journey, these small examples built my confidence. They became stepping stones to writing real-world systems, to leading teams, to architecting cloud platforms.

Keep this curiosity alive.

You’ve just built your first meaningful system — a graphics application and an HR module — powered by **containment**. Imagine what you'll build next.

---

🔚 **Next Steps**

* Build more shapes: Triangle, Polygon, Ellipse.
* Extend HR: Add Department, Salary, Address as separate classes.
* Practice identifying *has-a* vs *is-a* relationships.

🧱 Brick by brick, class by class — **you're becoming a software architect**.

Let’s keep building. 🚀

