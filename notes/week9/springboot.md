# 🌿 Garden Analogy for Layered Architecture → Spring Boot

## **Phase 1 – Manual Gardening (No Spring)**

👉 Students feel the effort of wiring.

**Garden Analogy**: You are watering plants yourself with buckets.

### Example Code: Plain Java (no Spring)

```java
// Entity
class Plant {
    String name;
    Plant(String name) { this.name = name; }
}

// Repository
class PlantRepository {
    public Plant findPlant(String name) {
        return new Plant(name);
    }
}

// Service
class PlantService {
    private PlantRepository repo;

    // Manual wiring through constructor
    public PlantService(PlantRepository repo) {
        this.repo = repo;
    }

    public void waterPlant(String name) {
        Plant p = repo.findPlant(name);
        System.out.println("Watering " + p.name + " manually with a bucket...");
    }
}

// Controller (entry point)
public class GardenApp {
    public static void main(String[] args) {
        // MANUAL wiring
        PlantRepository repo = new PlantRepository();
        PlantService service = new PlantService(repo);

        service.waterPlant("Rose");
    }
}
```

**Lesson Takeaway**: Students see how they manually connect repo → service → controller.
💡 They understand the “bucket carrying effort.”

## **Phase 2 – Introducing Spring Boot (Automatic Watering)**

👉 Show how Spring Boot **takes over wiring** with Dependency Injection.

**Garden Analogy**: You install an **automatic sprinkler system** (Spring Container). Now you don’t carry buckets, you just plant and declare needs.

### Example Code: Spring Boot Version

```java
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.*;

class Plant {
    String name;
    Plant(String name) { this.name = name; }
}

@Repository
class PlantRepository {
    public Plant findPlant(String name) {
        return new Plant(name);
    }
}

@Service
class PlantService {
    private PlantRepository repo;

    // DI happens automatically (no manual wiring)
    @Autowired
    public PlantService(PlantRepository repo) {
        this.repo = repo;
    }

    public String waterPlant(String name) {
        Plant p = repo.findPlant(name);
        return "Watering " + p.name + " with automated sprinkler system!";
    }
}

@RestController
class GardenController {
    @Autowired
    private PlantService service;

    @GetMapping("/water/{name}")
    public String water(@PathVariable String name) {
        return service.waterPlant(name);
    }
}
```

### Bootstrapping App

```java
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class GardenApp {
    public static void main(String[] args) {
        SpringApplication.run(GardenApp.class, args);
    }
}
```

**Lesson Takeaway**:

* Students see the **same project** evolve from manual → auto-wired.
* Spring Boot is not “magic” — it’s just automating what they did manually.
* They appreciate **why frameworks exist**.

## **Phase 3 – Classroom Activity**

1. Ask students to **manually wire** Entity → Repo → Service → Controller in plain Java.
2. Let them run it, feel the “bucket effort.”
3. Then introduce **Spring Boot auto-wiring**, using the same example.
4. Use the **garden story** to make it memorable.

🌱 This flow ensures students **first struggle**, then **appreciate the automation**.


# 🌱 2-Hour Hands-On Lab Plan: Garden Analogy → Spring Boot App

## **Hour 1: Manual Garden Setup (Pure Java Layered Architecture)**

*Objective: Understand the need for layering & DI before Spring Boot takes over.*

### **0–15 mins** → Warmup & Analogy Refresh

* Storytelling: “We already planted seeds, added water (DI), and grew plants (objects). But now our garden is bigger, so we need a structured way to manage it.”
* Quick recall of layers:

  * **Entity = Seed**
  * **Repository = Storehouse** (where seeds are stored)
  * **Service = Gardener** (knows when/how to water)
  * **Controller = Visitor** (asks gardener for a plant).


### **15–45 mins** → Hands-on Coding in Plain Java

* **Step 1:** Create `Plant` entity (fields: `id`, `name`, `type`).
* **Step 2:** Create `PlantRepository` (interface + simple in-memory list implementation).
* **Step 3:** Create `PlantService` (business logic: add plant, get plants).
* **Step 4:** Create `PlantController` (console-based interaction).

👉 Run a small console app:

* Visitor asks → Controller → Service → Repository → Entity.
* Demonstrate **manual object creation** (new PlantService(new PlantRepositoryImpl())).



### **45–60 mins** → Reflection & Discussion

* Ask students: *“What happens if I change repo from InMemory to Database?”*
* Highlight the pain of **manual wiring** → segue into why Spring Boot is needed.



## **Hour 2: Spring Boot Magic (Garden with Automatic Watering)**

*Objective: Experience how Spring Boot reduces boilerplate via DI and annotations.*

### **60–75 mins** → Project Setup

* Create **Spring Boot project** (via Spring Initializr or CLI).
* Add dependencies: **Spring Web, Spring Data JPA, H2 Database**.
* Run and verify blank project.


### **75–100 mins** → Hands-on Coding in Spring Boot

* **Step 1:** `Plant` → `@Entity`.
* **Step 2:** `PlantRepository` → `extends JpaRepository`.
* **Step 3:** `PlantService` → `@Service` with business logic.
* **Step 4:** `PlantController` → `@RestController` with GET/POST mappings.

👉 Run app → use **Postman / curl** to test APIs:

* `POST /plants` → add a plant
* `GET /plants` → list plants


### **100–115 mins** → Lab Extensions

* Show how **Spring Boot auto-wires beans**.
* Compare manual wiring vs `@Autowired`.
* Highlight: “Garden is now self-watering!”


### **115–120 mins** → Wrap-up & Q\&A

* Key Takeaways:

  * Manual DI → Spring Boot DI.
  * Layers: Entity → Repo → Service → Controller.
  * Analogy: From **hand-watering garden** → **automatic irrigation system**.


✅ Deliverables for Students:

1. Plain Java layered garden app.
2. Spring Boot garden REST API.


Perfect 👌 Let’s design a **step-by-step coding worksheet** for a **2-hour Spring Boot lab** (beginner-friendly, project-based).

We’ll use the **garden analogy** you liked earlier, so students can connect the dots naturally.
The project: **Garden Management API** 🌱 – manage plants with CRUD operations.


# 🌱 Spring Boot Hands-on Lab Worksheet (2 Hours)


## **0. Setup (10 min)**

✅ Prerequisites:

* JDK 17+ installed (`java -version`)
* Maven installed (`mvn -v`)
* IDE: IntelliJ / Eclipse / VS Code with Java extension

👉 Verify setup by running:

```bash
java -version
mvn -v
```

## **1. Create Spring Boot Project (10 min)**

👉 Use [Spring Initializr](https://start.spring.io) OR CLI:

```bash
spring init --dependencies=web,data-jpa,h2 garden-api
cd garden-api
```

Dependencies:

* Spring Web
* Spring Data JPA
* H2 Database (in-memory, for practice)

Open project in IDE.

## **2. Create Entity: Plant (15 min)**

📂 `src/main/java/com/example/garden/entity/Plant.java`

```java
package com.example.garden.entity;

import jakarta.persistence.*;

@Entity
public class Plant {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private String name;
    private String type;   // e.g., Flower, Vegetable
    private int age;       // in weeks

    // Constructors
    public Plant() {}
    public Plant(String name, String type, int age) {
        this.name = name;
        this.type = type;
        this.age = age;
    }

    // Getters & Setters
    public Long getId() { return id; }
    public String getName() { return name; }
    public void setName(String name) { this.name = name; }
    public String getType() { return type; }
    public void setType(String type) { this.type = type; }
    public int getAge() { return age; }
    public void setAge(int age) { this.age = age; }
}
```

## **3. Create Repository (5 min)**

📂 `src/main/java/com/example/garden/repository/PlantRepository.java`

```java
package com.example.garden.repository;

import com.example.garden.entity.Plant;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PlantRepository extends JpaRepository<Plant, Long> {
}
```

## **4. Create Service Layer (15 min)**

📂 `src/main/java/com/example/garden/service/PlantService.java`

```java
package com.example.garden.service;

import com.example.garden.entity.Plant;
import com.example.garden.repository.PlantRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PlantService {
    private final PlantRepository repo;

    public PlantService(PlantRepository repo) {
        this.repo = repo;
    }

    public List<Plant> getAllPlants() {
        return repo.findAll();
    }

    public Plant addPlant(Plant plant) {
        return repo.save(plant);
    }

    public void removePlant(Long id) {
        repo.deleteById(id);
    }
}
```

## **5. Create Controller (20 min)**

📂 `src/main/java/com/example/garden/controller/PlantController.java`

```java
package com.example.garden.controller;

import com.example.garden.entity.Plant;
import com.example.garden.service.PlantService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/plants")
public class PlantController {

    private final PlantService service;

    public PlantController(PlantService service) {
        this.service = service;
    }

    @GetMapping
    public List<Plant> getAllPlants() {
        return service.getAllPlants();
    }

    @PostMapping
    public Plant addPlant(@RequestBody Plant plant) {
        return service.addPlant(plant);
    }

    @DeleteMapping("/{id}")
    public void removePlant(@PathVariable Long id) {
        service.removePlant(id);
    }
}
```

 

## **6. Test the API (20 min)**

Run the app:

```bash
mvn spring-boot:run
```

Test with **Postman / curl**:

1. ✅ Add a plant

```bash
POST http://localhost:8080/plants
Body: { "name":"Rose", "type":"Flower", "age":4 }
```

2. ✅ View all plants

```bash
GET http://localhost:8080/plants
```

3. ✅ Delete a plant

```bash
DELETE http://localhost:8080/plants/1
```

 

## **7. Lab Reflection (10 min)**

🪴 **Garden Analogy Recap**:

* `Entity (Plant)` → A seed 🌱
* `Repository` → Garden tools ⚒️
* `Service` → Gardener 👩‍🌾 (decides how to use tools)
* `Controller` → Garden gate 🚪 (API entry for visitors)
* **Spring Boot DI** = automatic watering system 💧

 

## ⏱️ Timeline (2 Hours)

* Setup & Project Creation → 20 min
* Entity + Repo → 20 min
* Service + Controller → 35 min
* Testing API → 20 min
* Recap & Q/A → 15 min

 