
## 👩‍🏫 **Part 9: Advanced Microservices Testing with Mocking, WebSockets, and Message Queues**

The morning was calm, but the lab was buzzing with excitement.
Rutuja and Sanika had mastered full-stack BDD with CI/CD pipelines.
Now, they were stepping into **the real enterprise playground — microservices and asynchronous communication**.

> **Rutuja:** “Sir, what happens when our service depends on another service?”
> **Sanika:** “Yeah, like inventory or payment service?”

I nodded.

> “Exactly. In microservices, services talk to each other. We need to **mock these dependencies** and test them in isolation.
> Let’s also add **WebSockets** and **RabbitMQ** to simulate real-time and asynchronous communication.”

### ⚙️ Scene 1: Mocking External APIs

We created a **mock service** for an external inventory API using **Mockito**:

```java
@Service
public class InventoryService {
    public boolean isAvailable(int productId) {
        // External API call simulation
        return true; // Default mock behavior
    }
}
```

In the step definitions:

```java
@MockBean
InventoryService inventoryService;

@Given("the product ID {int} is available in inventory")
public void productAvailable(int id) {
    when(inventoryService.isAvailable(id)).thenReturn(true);
}
```

> **Sanika:** “So we’re not hitting the real API?”
> **I:** “Correct. This is faster, safer, and predictable — essential for automated pipelines.”


### ⚡ Scene 2: Testing WebSockets

Rutuja was curious.

> “Sir, how do we test real-time updates?”

We added a simple WebSocket endpoint:

```java
@Configuration
@EnableWebSocket
public class WebSocketConfig implements WebSocketConfigurer {
    @Override
    public void registerWebSocketHandlers(WebSocketHandlerRegistry registry) {
        registry.addHandler(new ProductSocketHandler(), "/ws/products");
    }
}

public class ProductSocketHandler extends TextWebSocketHandler {
    @Override
    protected void handleTextMessage(WebSocketSession session, TextMessage message) throws Exception {
        session.sendMessage(new TextMessage("Product Updated: " + message.getPayload()));
    }
}
```

We wrote a test:

```java
@Autowired
private WebSocketTestClient client;

@Test
void testWebSocketMessage() {
    String response = client.sendAndReceive("/ws/products", "Laptop");
    assertEquals("Product Updated: Laptop", response);
}
```

> **Sanika:** “It’s like talking to the server in real-time!”
> **I:** “Exactly — you can simulate live events and verify responses in your pipeline.”

### 🧩 Scene 3: Using RabbitMQ for Async Testing

We introduced **RabbitMQ** to simulate message queues:

```java
@Component
public class OrderPublisher {
    @Autowired
    private RabbitTemplate template;

    public void publishOrder(String orderId) {
        template.convertAndSend("order-exchange", "order.routing", orderId);
    }
}
```

Consumer:

```java
@Component
@RabbitListener(queues = "order-queue")
public class OrderListener {
    @RabbitHandler
    public void handle(String orderId) {
        System.out.println("Order Received: " + orderId);
    }
}
```

> **Rutuja:** “So messages are sent and processed asynchronously?”
> **Sanika:** “Exactly. CI/CD can now verify if async flows work without manual checks.”

---

### 💻 Scene 4: Integrating All in CI/CD Pipeline

We updated the GitHub Actions workflow:

```yaml
- name: Run full-stack tests
  run: mvn clean verify
```

**`mvn verify`** executes:

* Unit tests ✅
* BDD tests ✅
* WebSocket tests ✅
* RabbitMQ integration tests ✅

> **Sanika:** “Sir, every push now validates the entire microservices ecosystem!”
> **I:** “Yes. This is how large teams catch issues early and confidently deploy microservices.”

### 🧠 Scene 5: Mentor Reflection

By now, Rutuja and Sanika had learned the **complete enterprise-grade automation workflow**:

1. Unit testing with mocks
2. BDD with Cucumber for human-readable scenarios
3. Database integration (H2 / real DB)
4. Parameterized feature files for scalable tests
5. CI/CD pipelines with Maven and GitHub Actions
6. Mocking external APIs for isolated service testing
7. WebSockets for real-time testing
8. RabbitMQ for asynchronous messaging

> **Rutuja:** “Now I understand how microservices projects run in production safely.”
> **Sanika:** “We didn’t just code; we built **confidence in software delivery**.”

I nodded.

> “Exactly. Automation is not about replacing humans — it’s about enabling **safe, scalable, and fast delivery** in complex systems.”

### 🪜 Next Step (Part 10 Preview)

> **“End-to-End Project Simulation and Career Roadmap”**

Next, Rutuja and Sanika will:

* Combine **frontend + backend + CI/CD** into one project
* Simulate **real enterprise workflows**
* Learn **career-ready skills for software engineering**

They are ready to see **the full picture — from coding to deployment to real-world teamwork**.
