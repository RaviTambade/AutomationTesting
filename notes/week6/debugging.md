
#  The Bug That Taught Me More Than the Book

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
 

 

###  🐞 Debugging .NET 9.0 Applications in Visual Studio Code


## ✅ Prerequisites

1. ✅ **Install .NET SDK 9.0**

   * Download from [.NET 9.0 Preview or Latest](https://dotnet.microsoft.com/download)

2. ✅ **Install Visual Studio Code**

3. ✅ **Install C# Extension**

   * Go to Extensions (`Ctrl+Shift+X`) → Install **"C#"** by Microsoft

## 🚀 Create or Open Your Project

Create a .NET 9.0 console app:

```bash
dotnet new console -n MyApp -f net9.0
cd MyApp
code .
```

> 🔁 Replace `console` with `webapi`, `mvc`, or other templates as needed.


## 🏗️ Build & Run from Terminal (Test)

```bash
dotnet build
dotnet run
```

Ensure the app works before debugging.


## 📁 Configure Debugging in VS Code

### Step 1: Add `.vscode/launch.json`

1. Press `Ctrl + Shift + D` (Run & Debug)
2. Click **"create a launch.json file"**
3. Select **“.NET Core”**

Update it for **.NET 9.0**:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET 9.0 Launch (console)",
      "type": "coreclr",
      "request": "launch",
      "preLaunchTask": "build",
      "program": "${workspaceFolder}/bin/Debug/net9.0/MyApp.dll",
      "args": [],
      "cwd": "${workspaceFolder}",
      "stopAtEntry": false,
      "console": "internalConsole"
    }
  ]
}
```

> 🔁 Update `"MyApp.dll"` with your actual project name if different.

### Step 2: Optional `.vscode/tasks.json`

```json
{
  "version": "2.0.0",
  "tasks": [
    {
      "label": "build",
      "command": "dotnet",
      "type": "process",
      "args": [
        "build",
        "${workspaceFolder}/MyApp.csproj"
      ],
      "problemMatcher": "$msCompile"
    }
  ]
}
```

## 🔴 Set Breakpoints

* Open a `.cs` file
* Click on the **left margin** to set a **red dot**
* That’s your breakpoint

## ▶ Start Debugging

* Press `F5` or click **Run → Start Debugging**
* Execution pauses at breakpoints
* Use:

  * `F10` – Step Over
  * `F11` – Step Into
  * `Shift+F11` – Step Out
  * Debug Console and Variables panel for inspection

## 🌐 Debug ASP.NET Core 9.0 App

Use this in `launch.json` for web APIs or MVC:

```json
{
  "name": ".NET 9.0 Web API",
  "type": "coreclr",
  "request": "launch",
  "preLaunchTask": "build",
  "program": "${workspaceFolder}/bin/Debug/net9.0/MyWebApp.dll",
  "args": [],
  "cwd": "${workspaceFolder}",
  "stopAtEntry": false,
  "serverReadyAction": {
    "action": "openExternally",
    "pattern": "\\bNow listening on:\\s+(https?://\\S+)"
  },
  "env": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  },
  "sourceFileMap": {
    "/Views": "${workspaceFolder}/Views"
  }
}
```

## 🧯 Common Troubleshooting

| 🔍 Problem               | ✅ Solution                                      |
| ------------------------ | ----------------------------------------------- |
| Breakpoints not hit      | Ensure `Debug` build is selected                |
| DLL not found            | Confirm correct path to `.dll` in `launch.json` |
| Nothing happens on `F5`  | Ensure `launch.json` is created and valid       |
| C# extension not loading | Reload VS Code, or reinstall the extension      |

## 🧪 Confirm .NET 9.0 Target

Check your `.csproj`:

```xml
<TargetFramework>net9.0</TargetFramework>
```

## 🔧 Architecture Overview

Your .NET Core Solution has:

```
Solution: ProductCatalog
│
├── ConsoleApp (Startup Project)
├── ControllerLayer (Class Library)
├── ServiceLayer (Class Library)
├── RepositoryLayer (Class Library)
└── FileManager (Class Library - handles serialization/deserialization)
```

Each layer has **its own responsibility**:

* **ControllerLayer**: Receives input, calls the service
* **ServiceLayer**: Business logic
* **RepositoryLayer**: Handles data storage/retrieval
* **FileManager**: Reads/writes data (JSON/XML/Text)


### 🎯  The Layered Debugging Detective

> "Imagine you're an intelligence officer in a large fort.
> You send an order (input) to your general (Controller).
> He talks to the minister (Service),
> who asks the accountant (Repository),
> who finally checks the archives (FileManager).
> Now… something goes wrong. Who do you question?"

Answer: **You trace the message — layer by layer.**



### 🐞 How to Debug Such a Solution in VS Code

### ✅ 1. Set up `launch.json` (for ConsoleApp)

Inside `.vscode/launch.json`:

```json
{
  "version": "0.2.0",
  "configurations": [
    {
      "name": ".NET Core ConsoleApp Debug",
      "type": "coreclr",
      "request": "launch",
      "program": "${workspaceFolder}/ConsoleApp/bin/Debug/net9.0/ConsoleApp.dll",
      "args": [],
      "cwd": "${workspaceFolder}/ConsoleApp",
      "stopAtEntry": false,
      "console": "internalConsole"
    }
  ]
}
```

Make sure you **build the solution first**:

```bash
dotnet build
```

### ✅ 2. Add Debug Symbols to All Projects

In each `.csproj` file, make sure the build is in `Debug` mode:

```xml
<PropertyGroup>
  <OutputType>Library</OutputType>
  <TargetFramework>net9.0</TargetFramework>
  <DebugType>portable</DebugType>
  <DebugSymbols>true</DebugSymbols>
</PropertyGroup>
```


### ✅ 3. Set Breakpoints Layer by Layer

Here’s a real-world flow and where to set breakpoints:

#### ✅ ConsoleApp → Program.cs

```csharp
var controller = new ProductController();
controller.AddProduct(); // Set breakpoint here
```


#### ✅ ControllerLayer → ProductController.cs

```csharp
public void AddProduct()
{
    var product = new Product { Id = 1, Name = "Laptop" };
    productService.SaveProduct(product); // Breakpoint here
}
```



#### ✅ ServiceLayer → ProductService.cs

```csharp
public void SaveProduct(Product p)
{
    productRepo.Save(p); // Breakpoint here
}
```

---

#### ✅ RepositoryLayer → ProductRepository.cs

```csharp
public void Save(Product p)
{
    fileManager.Serialize(p); // Breakpoint here
}
```



#### ✅ FileManager → FileManager.cs

```csharp
public void Serialize(Product p)
{
    var json = JsonSerializer.Serialize(p);
    File.WriteAllText("products.json", json); // Breakpoint here
}
```



## 🛠 Debugging Tips

| 🔍 What You're Checking | ✅ How to Debug                      |
| ----------------------- | ----------------------------------- |
| Input from user         | Set breakpoint in **ConsoleApp**    |
| Business rules          | Set in **ServiceLayer**             |
| File write success      | Step into **FileManager**           |
| File path errors        | Inspect path in debugger            |
| Incorrect data          | Watch variable values at each layer |



## 🧪 Bonus: Debug Deserialization Path

If you are loading data from a file:

```csharp
// FileManager.cs
public Product Deserialize()
{
    string json = File.ReadAllText("products.json");
    return JsonSerializer.Deserialize<Product>(json); // Breakpoint here
}
```

Then follow the path in reverse:

* FileManager → Repository → Service → Controller → ConsoleApp



## 🔁 Summary: Debugging Layer by Layer

🔁 Always **start from the console entry point** and trace flow down:

1. **ConsoleApp** – Main entry point
2. **ControllerLayer** – Input & orchestration
3. **ServiceLayer** – Business rules
4. **RepositoryLayer** – Data access logic
5. **FileManager** – Actual I/O (bug-prone!)


## 🧙 Mentor's Final Words

> “Each layer is like a stage in a relay race. If the baton drops, don’t blame the last runner.
> Trace back — who fumbled? Where did it fall?
> Debugging teaches you how to **listen to your own system**."

 
