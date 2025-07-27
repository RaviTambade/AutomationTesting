
###  “The Bug That Taught Me More Than the Book”

> *"Sir, why do we spend so much time debugging instead of writing new code?”*
> a student once asked me with frustration in his voice.

I smiled.
"Let me tell you a story..."
 

## 🕷️ **The Invisible Bug**

Many years ago, I was working on a simple console application.
It calculated employee salaries after tax deduction.
I had written what I thought was *perfect code*. I even tested it — inputs went in, outputs came out.

All good... until my manager called and said,

> “Why are we paying Rs. 35,000 to someone who earns Rs. 15,000?”

My heart skipped a beat.

 

## 🔍 The First Real Lesson

I checked the code.

```csharp
double salary = 15000;
double taxRate = 0.1;
double netPay = salary + (salary * taxRate);  // Wait... what?!
```

I was **adding tax instead of deducting it**.
A silly mistake. One line.
But it could have cost the company a lot if it went to production.

I fixed it:

```csharp
double netPay = salary - (salary * taxRate);
```

And that’s when it hit me:

> **Code that works is not always code that works correctly.**

 

## 🧠 Debugging Teaches You to Think Like a Detective

Debugging isn't just about fixing code. It’s about **understanding how your logic thinks**, how your **data flows**, and how **small assumptions** break big systems.

* It sharpens your thinking
* It builds patience
* It improves your design instincts

Every bug you solve **teaches you something the textbook never will**.

 

## 🧰 Tools Are Your Sidekicks

Like Sherlock Holmes has Watson,
You — the developer — have:

* 🔴 **Breakpoints** (to pause the scene)
* 🔎 **Watch window** (to track suspects — variables)
* 🔁 **Step into/over** (to follow the trail)
* 💬 **Debug console** (to interrogate the code)

And guess what? Every great developer you admire?
They didn’t avoid bugs —
**They got really good at hunting them.**
 

## 🏁 Final Words to My Students

I tell my students this every time:

> "Writing code shows what you know.
> Debugging code shows how deeply you understand."

So next time you hit a bug, don’t panic.
Smile.
Because you’re about to **level up as a developer**.
 