
## 🌱 Consuming REST API in .NET

> "Last time we built a REST API and tested it using Postman. But let’s think like professionals now — what if I want my .NET application itself to consume this API? This is how we move from being just API creators to real-world API consumers."

### 🌍 Provider and Consumer

* Imagine your **Web API** is like a shop. It has products on its shelves (data).
* But to buy something from this shop, you need a **customer** — that’s your **console application**, the consumer.
* So we now have two roles:

  1. **Provider** → Web API (running on Kestrel server)
  2. **Consumer** → Console app that calls the Web API


### 🛠 Step 1: Create the Console Consumer

Inside the same solution, let’s **add a new Console Application** called `RestApiClient`.

* This app doesn’t have its own database.
* It will rely on the Web API.
* Think of it like a remote control — it doesn’t generate the data, it just asks the TV (Web API) to show data.

### 📡 Step 2: Using `HttpClient`

To make this consumer talk to the Web API, we need a postman inside the code. That postman is:

```csharp
HttpClient client = new HttpClient();
```
* This comes from the namespace:

  ```csharp
  using System.Net.Http;
  ```
* But since APIs are asynchronous, we also bring in:

  ```csharp
  using System.Threading.Tasks;
  ```
* And because the API returns **JSON**, we’ll use:

  ```csharp
  using System.Text.Json;
  ```
 

### 📝 Step 3: Writing the Call

1. Set the **base URL** of the API (like telling your driver the shop’s address).

   ```csharp
   client.BaseAddress = new Uri("https://localhost:5001/api/");
   ```

2. Call the **GET** endpoint:

   ```csharp
   HttpResponseMessage response = await client.GetAsync("products");
   ```

3. Check the **status code**:

   * ✅ 200 OK → Data received
   * ❌ 404 → Not found
   * ❌ 500 → Server error

   ```csharp
   response.EnsureSuccessStatusCode();
   ```

4. Read the **response body** as string:

   ```csharp
   string data = await response.Content.ReadAsStringAsync();
   Console.WriteLine(data);
   ```
### 🔑 Step 4: Resource Management

At the end:

```csharp
client.Dispose();
```

* Why? Because like closing a water tap, you should release resources when you’re done.
* This comes from `IDisposable` pattern in C#.

### 🖥 Step 5: Running Both Projects

* If you only run the client, it fails — because the shop (API) is closed!
* So we configure **multiple startup projects** in Visual Studio:

  1. First → Start the Web API (Provider)
  2. Then → Start the Console Client (Consumer)

Now, when you debug:

* First window: Web API starts on Kestrel
* Second window: Console app makes the request

You can even set breakpoints in **both projects** to watch the full round trip.

### 🎯 3-Tier Architecture

With this setup, we now see **three layers** clearly:

1. **Database** → MySQL (foundation, never changes often)
2. **Web API** → Service layer (business logic, reusable)
3. **Console App** → Frontend (UI/consumer, can change frequently)

This is classic **3-Tier Architecture**.

* Frontend may change (Angular, React, .NET console, mobile app).
* Web API may evolve a little.
* But database logic (stored procedures, triggers) is the most stable.

### 🚀 Mentor Advice

* If you only stay at frontend, you’re just scratching the surface.
* To grow as a developer, you must **go deeper** → learn API building, and then database design.
* In banking, healthcare, insurance — the **real business logic lives in the database**.
* Full-stack means: UI → API → Database → Data Analytics → AI.

So, next time you consume an API, don’t stop at “it works.” Think about **who provides the data, how it flows, and where the real business rules lie.**

👉 This way, you didn’t just learn how to write an `HttpClient`. You’ve understood **how distributed applications talk** — and how each layer plays its role like soldiers in a strategy.
