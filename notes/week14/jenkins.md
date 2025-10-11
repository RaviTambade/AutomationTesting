
## 🏭 **The Story of CI/CD: The Invisible Factory**

> *“Every time you click ‘push’ in Git, somewhere in the cloud, your code walks into a giant invisible factory.”*
> – The Mentor


### Scene 1: The Factory Awakens

“Imagine,” said the Mentor, “you and your team are working on a car design — but instead of cars, you build software.”

Each developer is like an **engineer** adding a new feature — some design the dashboard (UI), some tune the engine (backend), and some write the rules (business logic).

But there’s a problem —
when everyone keeps changing parts, how do you **assemble the whole car** again and again without breaking it?

That’s where the **Invisible Factory** comes alive —
this is your **CI/CD pipeline**.


### Scene 2: Continuous Integration — The Assembly Line

Every time a developer pushes code to GitHub,
a robotic voice whispers in the cloud:

> “New part detected. Begin inspection.”

The **CI (Continuous Integration)** system starts its work:

1. 🧩 **Checkout stage** – The factory’s conveyor belt picks up the latest code.
2. 🧱 **Build stage** – The code is compiled or packaged into a working product.
3. 🔍 **Test stage** – Quality inspectors (automated tests) check for defects.
4. 🧾 **Report stage** – The system posts back a green tick ✅ or a red cross ❌.

If all tests pass —
the factory declares,

> “Integration successful. Ready for delivery.”

Every small change is integrated frequently, so the car never falls apart.
That’s **Continuous Integration** —
automated, repeatable, and fast.


### Scene 3: Continuous Delivery — The Paint and Polish Room

Once the build is verified, it’s time to **prepare it for delivery**.

Think of this like **the paint booth in a real factory** — polishing, checking aesthetics, and making sure it’s customer-ready.

The CD (Continuous Delivery) part ensures:

* The code can be **deployed to staging** automatically.
* Configuration, secrets, and dependencies are set properly.
* Deployments are **predictable** and **error-free**.

But — the product still waits for a human to click “Release.”
Like a finished car waiting for final inspection.


### Scene 4: Continuous Deployment — The Auto-Release System

Then comes the magic moment — **Continuous Deployment**.

Here, there’s **no human gatekeeper**.
When the build passes all tests, the invisible factory **automatically ships it to production** 🚀

Just imagine:
As soon as the code passes QA, it drives itself out of the factory, parks in the customer’s garage, and sends you a message —

> “New version deployed successfully.”

That’s the power of full automation.


### Scene 5: The Human Behind the Machines

The mentor smiled:
“Now, remember, automation doesn’t replace engineers — it *amplifies* them.”

The CI/CD factory never sleeps — it builds, tests, deploys, and monitors —
but it relies on human intelligence to **design**, **improve**, and **interpret results**.

The developer’s role evolves:

* from writing code → to crafting reliable pipelines,
* from debugging code → to debugging automation,
* from fearing deployment → to celebrating it.


### Scene 6: The Invisible Symphony

The students looked amazed.

The Mentor concluded:

> “CI/CD is not just a toolchain — it’s a mindset.
> It’s how modern software breathes — with every commit, it learns, tests, and evolves.”

“Think of it as the **heartbeat of your project** —
where every pulse means progress,
and every successful build is a sign that your invisible factory is alive and well.”

### 🌟 Moral of the Story

> “The best software teams don’t wait for release day.
> They live in a world where every day *is* release day.”

 
Imagine you’re running a **software factory**.
Developers are like **engineers on the assembly line**, writing and updating pieces of code every day.
Now the challenge begins — how do we make sure every new piece fits perfectly, works as expected, and reaches users quickly without breaking anything?

That’s where **CI/CD** comes into the picture.

### 🧩 CI — Continuous Integration

**Continuous Integration** is like a **testing robot** on your assembly line.

Every time a developer writes new code and pushes it to GitHub, CI automatically:

1. Pulls the latest code.
2. Compiles or builds it.
3. Runs tests.
4. Reports if something is broken.

So instead of waiting till the end of the month to discover 50 bugs, CI finds issues **within minutes of coding**.
It keeps the codebase **integrated, tested, and healthy** every day.

🧠 **In short:**

> CI = Automatically build and test the code whenever a change happens.

**Tools:** Jenkins, GitHub Actions, GitLab CI, CircleCI

### 🚀 CD — Continuous Delivery / Continuous Deployment

Once your code is built and tested, the next step is to **deliver or deploy** it.

That’s where **CD** comes in.
There are actually **two meanings** of CD, depending on how far you automate:

#### 1. Continuous Delivery

This means your code is **ready for deployment anytime** — but a human still clicks “Deploy.”
Example: Jenkins finishes the build, and the release manager reviews and approves before pushing to production.

#### 2. Continuous Deployment

This goes one step further — every successful build **automatically gets deployed** to production (or staging) with zero manual steps.

🧠 **In short:**

> CD = Automatically release or deploy the tested code.

### 💡 Let’s Connect It All

So together,
👉 **CI/CD = Continuous Integration + Continuous Delivery/Deployment**

It’s the **backbone of modern DevOps**, ensuring that:

* Code is always in a working state.
* Testing happens automatically.
* Deployment is fast and reliable.
* Developers focus on building features, not fixing deployment errors.

### 🎯 Real-World Example

Let’s say Ravi commits a change in GitHub.

1. Jenkins detects the commit (CI starts).
2. Jenkins pulls code → runs `npm install`, `npm test`, `npm run build`.
3. If everything passes, Jenkins deploys it to AWS EC2 or S3 (CD).
4. The new version goes live — automatically, safely, and quickly.

Excellent — this is a perfect follow-up question 👏

Let’s go step by step — **mentor storytelling style**, so you truly *feel* what Jenkins does rather than just memorize it.

## 🏗️ Imagine a Software Factory Again

Developers are coding day and night, pushing updates to GitHub.
But who will take care of all the repetitive work — building, testing, packaging, and deploying — **every single time**?

You could do it manually:

* Pull code from GitHub
* Run build commands
* Test everything
* Deploy to a server

…but that’s slow, error-prone, and exhausting.
You need an **automation engineer** who never sleeps, never forgets a step, and follows your instructions precisely.

💡 That “automation engineer” is **Jenkins**.

## ⚙️ What is Jenkins?

Jenkins is an **open-source automation server** used to **build, test, and deploy** your software automatically — the heart of a CI/CD pipeline.

It acts as the **orchestrator** of your software development workflow.
You give Jenkins a set of steps (in a Jenkinsfile), and it executes them whenever triggered — for example, when new code is pushed to GitHub.

### 🔁 Jenkins in Action (A Real-World Flow)

Let’s say you have a **Node.js web app**.
Here’s what Jenkins can do automatically after every code change:

1. **Checkout Code**

   * Pull the latest code from GitHub.

2. **Build Stage (CI)**

   * Run commands like `npm install`, `npm test`, and `npm run build`.
   * Verify that the code compiles and passes all tests.

3. **Package and Archive**

   * Create a `.zip` or `.jar` build artifact.

4. **Deploy Stage (CD)**

   * Copy the built app to your EC2 instance or Docker container.
   * Restart the service (e.g., `pm2 restart app`).

5. **Notify**

   * Send success/failure updates to Slack, email, or GitHub.

## 🧠 Why Jenkins Is So Suitable for CI/CD

| Feature               | Why It Matters                                                         |
| --------------------- | ---------------------------------------------------------------------- |
| **Automation**        | No manual builds — Jenkins runs automatically on every push.           |
| **Plugins**           | 1,800+ plugins — Git, Docker, AWS, Node, .NET, etc.                    |
| **Pipelines as Code** | You define your pipeline in a simple `Jenkinsfile`.                    |
| **Integration**       | Works with GitHub, GitLab, Bitbucket, AWS, Azure, etc.                 |
| **Scalability**       | Master–Agent architecture: multiple agents can run builds in parallel. |
| **Open Source**       | Free, flexible, and backed by a huge community.                        |

### 🧩 Jenkins in the CI/CD Pipeline

```
Developer → GitHub → Jenkins (Build + Test + Deploy) → Cloud Server
```

Each arrow represents automation:

* Jenkins **detects commits** automatically.
* Jenkins **runs the pipeline**.
* Jenkins **deploys the new version**.


### 🛠️ Example: Jenkinsfile (Node.js)

```groovy
pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/ravi/node-app.git'
            }
        }
        stage('Build') {
            steps {
                sh 'npm install'
                sh 'npm run build'
            }
        }
        stage('Test') {
            steps {
                sh 'npm test'
            }
        }
        stage('Deploy') {
            steps {
                sh 'scp -r ./dist ubuntu@ec2-ip:/var/www/html/app'
                sh 'ssh ubuntu@ec2-ip "pm2 restart app"'
            }
        }
    }
}
```

Jenkins reads this pipeline and executes every step automatically — that’s CI/CD in action.

### 🔒 Bonus Tip:

You can even run Jenkins **inside Docker** on your EC2 instance — safe, isolated, and easy to maintain.

 
## Let us explore by doing handson

“Alright team, let’s continue our hands-on session. So far, we’ve been using AWS services, and this time, we’ve created an **EC2 instance** with **Ubuntu** installed. Now, the next step is to **connect to that Ubuntu machine remotely**.

Today, I won’t use the browser-based connect option. Instead, we’ll use a Windows utility called **PuTTY**. I already have PuTTY installed, so let me start it.

*opens PuTTY*
Can everyone see the PuTTY interface? Great. Here’s what we do next:

1. **Specify the EC2 instance IP** – Under “Host Name (or IP address),” I’ll put the **public IP** of our EC2 instance.
2. **Port** – PuTTY always connects to Linux using **port 22**, which is the default for SSH.
3. **SSH Key Authentication** – Under **Connection → SSH → Auth**, we need to specify our **private key file (.ppk)** that we downloaded when creating the EC2 instance. This is essential for authentication.

Once that’s done, click **Open**. You might get a security alert; just accept it.

Now, the login prompt appears. We log in with the **Ubuntu** user. Press Enter, and… voilà! We’re inside our EC2 Ubuntu instance.

### Step 1: Adjust PuTTY Font (Optional)

To make the terminal easier to read:

* Go to **Change Settings → Appearance → Font**
* Increase the font size to, say, **14 bold**.

### Step 2: Update Ubuntu

Before installing anything, let’s update our system:

```bash
sudo apt update
```

### Step 3: Install Docker

Now, let’s install **Docker** on Ubuntu:

```bash
sudo apt install docker.io
```

Check if Docker is installed and running:

```bash
sudo docker -v        # Docker version
sudo systemctl status docker
```

Docker should be **active** and **enabled**.

### Step 4: Pull Jenkins Docker Image

Next, we need the **Jenkins image** from Docker Hub. You can search Docker Hub in your browser for the official Jenkins image. It comes prepackaged with **JDK 17**, so we don’t have to worry about manually installing Java.

Copy the pull command from Docker Hub and execute in PuTTY:

```bash
sudo docker pull jenkins/jenkins:lts-jdk17
```

### Step 5: Run Jenkins Container

Now, we run Jenkins on the standard port **8080**:

```bash
sudo docker run -d -p 8080:8080 --name jenkins jenkins/jenkins:lts-jdk17
```

* `-d` → runs the container in detached mode
* `-p 8080:8080` → maps EC2 port 8080 to container port 8080
* `--name jenkins` → gives the container a name

### Step 6: Verify

Check running containers:

```bash
sudo docker ps
```

You should see the Jenkins container running.

### Step 7: Access Jenkins

Open your **browser** and go to:

```
http://<EC2-Public-IP>:8080
```

This opens the Jenkins setup page, and you’re ready to continue with the initial configuration.

**Mentor Tip:**
If we were installing Jenkins on a physical Ubuntu server, we’d have to first install JDK, set environment variables, download Jenkins, configure it, and then start the service manually. Using Docker simplifies all that into a **single containerized step**. That’s the power of DevOps practices!

**Connecting to EC2, Installing Docker, and Running Jenkins**

“Alright team, let’s continue our AWS hands-on session. At this point, we’ve created an **EC2 instance** with **Ubuntu** installed. Now, I want to **connect to this Ubuntu machine remotely**.

Today, we won’t use the browser-based connect option. Instead, we’ll use **PuTTY**, a Windows SSH client. I already have it installed, so let me start PuTTY.


### Step 1: Open PuTTY and Connect to EC2

* **Host Name / IP**: Enter your EC2 instance’s **public IP**.
* **Port**: PuTTY connects to Linux via **port 22**.
* **SSH Authentication**:

  * Navigate to **Connection → SSH → Auth**.
  * Specify the **private key (.ppk) file** you downloaded when creating the EC2 instance.

Click **Open**. You might see a security alert; accept it.

* Login with the **Ubuntu** user. Press **Enter**.
* Authentication succeeds, and now we’re inside the EC2 Ubuntu terminal.

### Step 2: Adjust PuTTY Font (Optional)

* Go to **Change Settings → Appearance → Font**.
* Increase the font size to **14 bold** for better readability.


### Step 3: Update Ubuntu

Before installing anything, always update your system:

```bash
sudo apt update
```

### Step 4: Install Docker

Install Docker Engine on Ubuntu:

```bash
sudo apt install docker.io
```

Verify installation:

```bash
sudo docker -v             # Check Docker version
sudo systemctl status docker  # Check if Docker service is running
```

Docker should be **active** and **enabled**, ready to run containers.

### Step 5: Pull Jenkins Docker Image

Next, we need Jenkins from Docker Hub. Open a browser and search **Jenkins Docker image**. Choose the official image that includes **JDK 17** (so we don’t have to install Java manually).

Copy the pull command and run it in PuTTY:

```bash
sudo docker pull jenkins/jenkins:lts-jdk17
```

### Step 6: Run Jenkins Container

Run Jenkins in a container and map it to port **8080**:

```bash
sudo docker run -d -p 8080:8080 --name jenkins jenkins/jenkins:lts-jdk17
```

* `-d` → detached mode (runs in background)
* `-p 8080:8080` → maps EC2 port 8080 to container port 8080
* `--name jenkins` → names the container “jenkins”

Check running containers:

```bash
sudo docker ps
```

You should see Jenkins running.

### Step 7: Access Jenkins

Open a browser and visit:

```
http://<EC2-Public-IP>:8080
```

You will see the Jenkins setup page and can continue with the initial configuration.

**Mentor Tip:**
If we were installing Jenkins directly on Ubuntu, we’d have to:

1. Install JDK 17 manually.
2. Set environment variables.
3. Download Jenkins WAR package.
4. Configure Jenkins as a service.

With **Docker**, all these steps are simplified into a single container run. That’s the power of containerization in DevOps—it saves time, ensures consistency, and reduces setup errors.


**Jenkins Pipeline Setup on Transflower.in**

“Alright team, now that our Jenkins server is up and running, let’s move forward. I’ve saved the configuration, and you can see the **Jenkins URL**. Open it, and your Jenkins environment is ready to start building pipelines.

### Step 1: Create a New Pipeline

* Login as your user, for example **Ravi**.
* Click on **New Item**.
* You’ll see options like:

  * **Freestyle Project**
  * **Pipeline**
  * **Multi-configuration Project**

Let’s pick **Pipeline** for now—it’s simple and flexible.

### Step 2: Configure the Pipeline

* Give your pipeline a name, e.g., `SimplePipeline`.
* In the pipeline configuration:

  * **Pipeline Agent** → `any`
  * **Stages** → define sequential steps for your build.

For example:

```groovy
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building the project...'
            }
        }
        stage('Test') {
            steps {
                echo 'Running tests...'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying application...'
            }
        }
    }
}
```

* Each stage executes **one after another**, ensuring a clear workflow.

### Step 3: Source Code Integration

* Under **Pipeline → Definition**, select **Pipeline script from SCM**.
* Choose **Git** and provide the repository URL, e.g.:

```
http://github.com/ravi/TFL-store
```

* Specify your **branch** (e.g., `main`) and credentials if required.

### Step 4: Build and Trigger

* You can manually trigger the build by clicking **Build Now**.
* Or schedule builds with **Build Triggers** → e.g., every hour or via Git commits.

After triggering, Jenkins shows:

* **Build executor status**
* **Last build timestamp**
* Click on a build to see **logs, stages, and duration**.



### Step 5: Post-Build Actions

* You can configure post-build actions like:

  * Archive artifacts
  * Publish test reports (HTML, JUnit, etc.)
  * Deploy application automatically

**Mentor Tip:**
Think of the Jenkins pipeline as a **recipe**: each stage is a step in your cooking process. First, you gather ingredients (checkout code), then cook (build & test), and finally serve (deploy). Using pipelines makes the process **repeatable, consistent, and automated**.


**Setting Up a Node.js Pipeline in Jenkins**

“Alright team, now that our Jenkins server is ready, let’s try something new—setting up a **Node.js pipeline**.

This time, we’re going to work with a simple **Node.js project** hosted on GitHub.

### Step 1: Create a New Pipeline

* Click **New Item** in Jenkins.
* Enter a name, for example: `NodeJS-Pipeline`.
* Select **Pipeline** and click **Apply**.

At this stage, Jenkins is ready to build **our Node.js application**.

### Step 2: Configure the Pipeline

Initially, you might try a basic setup:

* Pull code from your GitHub repository.
* Run installation commands like `npm install`.

However, here’s a key point I observed during my setup:

> The **official Jenkins Docker image** is based on Debian and **does not include Node.js or tools like curl or bash**.

This is why your first build may fail if you try to install Node.js directly inside Jenkins.


### Step 3: Use Node.js Container Instead

A cleaner approach is to **run your pipeline inside a Node.js container**, rather than installing Node.js on the Jenkins container itself.

* In your **Jenkinsfile**, you can specify a **Node.js Docker agent**:

```groovy
pipeline {
    agent {
        docker { image 'node:20' }
    }
    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/yourusername/your-nodejs-repo.git'
            }
        }
        stage('Install') {
            steps {
                sh 'npm install'
            }
        }
        stage('Test') {
            steps {
                sh 'npm test'
            }
        }
        stage('Build') {
            steps {
                sh 'npm run build'
            }
        }
    }
}
```

* This ensures your pipeline runs in a **Node.js 20 environment** without worrying about missing tools inside the Jenkins container.

### Step 4: Save and Build

* Click **Apply** → **Save**.
* Trigger **Build Now**.
* Monitor the build progress: Jenkins shows **checkout status, npm install progress, test results**, and **build output**.

If a build fails, click on the pipeline and check the **stage logs** to identify which step caused the failure. Usually, it’s either a missing Node.js environment or a misconfigured path—both solved by running inside a Node.js container.

### Mentor Tip

Think of Jenkins pipelines as **playgrounds with different environments**:

* The Jenkins container is great for orchestration, but don’t overload it with development tools.
* Use **Docker containers as agents** for language-specific pipelines (Node.js, Java, Python).
* This approach is cleaner, faster, and avoids environment conflicts.
