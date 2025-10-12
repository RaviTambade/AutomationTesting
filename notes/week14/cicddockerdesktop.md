### 🎓 ** The Journey of Connecting to Ubuntu and Running Jenkins on Docker**

👨‍🏫 **Mentor (Ravi Sir):**
Alright class, let’s pick up from where we left off.
So far, we have already entered the world of AWS — the powerful cloud kingdom.
From this kingdom, we have borrowed one of their most loyal services — **EC2**, which allows us to create our own **virtual machine**.

Imagine this EC2 instance as a computer sitting somewhere in Amazon’s data center, waiting for your command.
And what’s running inside it? — **Ubuntu Linux**, a clean and powerful open-source operating system.


### 🖥️ Step 1: Connecting to Our Cloud Machine (EC2) using PuTTY

👨‍🏫 “Now,” I told my students, “we could have easily used the browser-based connect option that AWS gives us — it’s quick and simple.
But developers who truly understand infrastructure love doing things manually once, to feel the real control.”

So today, instead of using the browser, I decided to use **PuTTY**, a classic Windows-based SSH client.

I launched **PuTTY**, and the classroom saw a familiar window appear on screen.

👨‍🏫 “Can you see the PuTTY window everyone?”
🧑‍🎓 “Yes, sir!”

Perfect. Now inside that window, I entered the **Public IP address** of our Ubuntu EC2 instance.

Then I reminded them:

> “Every Linux machine listens to SSH on **port 22**. That’s our entry door.”

Next, under the **SSH → Auth** section, I had to specify our **private key file** — the `.ppk` file we downloaded while setting up the instance.

That key is our digital fingerprint. It tells AWS, *“Yes, this user really is who they claim to be.”*

Once I loaded the `.ppk` file and hit **Open**, PuTTY asked:

> “Do you trust this host?”

“Yes,” I said, smiling, “I do.”
And just like that — 💥 **we were inside the Ubuntu terminal!**


### 🧑‍💻 Step 2: Exploring Our Ubuntu Machine

Inside the black terminal, I typed:

```bash
clear
```

to get a clean screen.

Then I adjusted the **font** size through **Change Settings → Appearance** — because as a mentor, the one rule is: *Everyone should be able to see the code clearly.*

Finally, I made it large and bold — “Now we’re ready!”


### 🧩 Step 3: Updating the System

👨‍🏫 “Before installing anything,” I explained,

> “always update your system so it fetches the latest package references.”

So I typed:

```bash
sudo apt update
```

Ubuntu started downloading the latest updates — like bringing new ingredients before cooking.



### 🐳 Step 4: Installing Docker Engine on Ubuntu

Once updated, we installed Docker — the container engine that runs applications like tiny isolated machines.

```bash
sudo apt install docker.io -y
```

When it was done, I said:

> “Now we have our **Docker Engine** running inside our **Ubuntu**, which itself is running inside **AWS EC2** — a perfect example of layered virtualization!”

To confirm Docker was active:

```bash
sudo systemctl status docker
```

It showed:

> *Docker service: active (running)* ✅

I paused for a moment to let the students absorb that —
“Now, Linux OS is ready, and Docker Engine is alive inside it.”


### 🧱 Step 5: Pulling Jenkins Image from Docker Hub

“Next,” I said, “we’re going to bring Jenkins — the heart of our CI/CD automation.”

I opened my browser and searched for **‘Jenkins Docker Image’** on **Docker Hub**.
We found the official one: `jenkins/jenkins`.

It even mentioned it includes **JDK 17**, so no need to install Java manually — Jenkins will come with it preconfigured.

I copied the pull command:

```bash
sudo docker pull jenkins/jenkins:lts
```

Then back to our PuTTY terminal — I ran it.
Docker began downloading layers — each layer representing a small part of the Jenkins environment.


### 📦 Step 6: Verifying the Image

After the download:

```bash
sudo docker images
```

Output showed:

```
REPOSITORY          TAG       IMAGE ID       CREATED         SIZE
jenkins/jenkins     lts       f2d6a8e...     4 days ago      600MB
```

“Beautiful,” I said, “the Jenkins image is ready.”


### ⚙️ Step 7: Running Jenkins Container

Now the grand finale — **running Jenkins inside Docker**.

I explained the run command piece by piece:

```bash
sudo docker run -d -p 8080:8080 --name myjenkins jenkins/jenkins:lts
```

* `-d` → Run in detached mode (in background)
* `-p 8080:8080` → Map container’s Jenkins port (8080) to EC2’s port (8080)
* `--name myjenkins` → Give your container a name
* `jenkins/jenkins:lts` → The image we pulled earlier

When I pressed **Enter**, Docker replied with a long container ID — our Jenkins server was born.


### 🌍 Step 8: Accessing Jenkins via Browser

“Now class,” I said, “this is where it all comes together.”

In the browser, I typed:

```
http://<your-ec2-public-ip>:8080
```

After a few seconds — the Jenkins setup screen appeared.

That’s when I turned to the students and said:

> “Remember, what you just did —
> you used AWS to create a cloud computer,
> connected securely using SSH,
> installed Docker (a container engine),
> pulled an image (Jenkins) from Docker Hub,
> and finally ran it as a container.”

> “You didn’t just install Jenkins...
> you **built your own CI/CD infrastructure from scratch**.”



### 🧭 Mentor’s Closing Thought

👨‍🏫 “This is how modern DevOps professionals work — not just by running commands, but by understanding each layer:
Cloud → OS → Container Engine → Application.”

Every layer has a purpose, every command has a meaning.
And when you connect all of them with curiosity — that’s where real learning happens.


# 🎓 **Jenkins on Docker + Node.js Pipeline Cheat Sheet**

---

## **1️⃣ Connect to EC2 via PuTTY**

| Step                | Command / Action        | Purpose / Notes                      |
| ------------------- | ----------------------- | ------------------------------------ |
| Open PuTTY          | Launch PuTTY on Windows | SSH client to connect to Linux       |
| Enter EC2 public IP | `xx.xx.xx.xx`           | Connect to your Ubuntu instance      |
| Set port            | `22`                    | Standard SSH port                    |
| Load Private Key    | `.ppk` file             | Authenticate securely using key pair |
| Login as user       | `ubuntu`                | Default EC2 user for Ubuntu          |

---

## **2️⃣ Update Ubuntu System**

```bash
sudo apt update
sudo apt upgrade -y
```

* Update package info and install latest updates.
* Keeps system secure and compatible.

---

## **3️⃣ Install Docker Engine**

```bash
sudo apt install docker.io -y
sudo systemctl enable docker
sudo systemctl start docker
sudo systemctl status docker
```

* Installs Docker engine.
* `enable` → start on boot, `start` → start now.
* `status` → verify Docker is running.

---

## **4️⃣ Pull Jenkins Docker Image**

```bash
sudo docker pull jenkins/jenkins:lts
sudo docker images
```

* Pulls official Jenkins LTS image with Java preinstalled.
* `docker images` → verify download.

---

## **5️⃣ Run Jenkins Container**

```bash
sudo docker run -d -p 8080:8080 --name jenkins jenkins/jenkins:lts
```

* `-d` → detached mode (run in background)
* `-p 8080:8080` → map host port 8080 → container port 8080
* `--name jenkins` → name your container

---

## **6️⃣ Access Jenkins in Browser**

1. Go to: `http://<EC2-public-IP>:8080`
2. Get **initial admin password**:

```bash
sudo docker exec jenkins cat /var/jenkins_home/secrets/initialAdminPassword
```

* Copy the password → paste into browser login.

3. Setup first user:

* Full Name: `Ravi Tamade`
* Email: `ravi.tamade@transflower.in`
* Password: `P@SSW0rd123`

4. Install default plugins. ✅

---

## **7️⃣ Configure AWS Security Group**

* Ensure **Inbound Rules** allow:

| Protocol | Port | Source               |
| -------- | ---- | -------------------- |
| HTTP     | 8080 | Anywhere (0.0.0.0/0) |
| SSH      | 22   | Your IP              |

* Ensures Jenkins and SSH are accessible externally.

---

## **8️⃣ Create a Node.js Pipeline in Jenkins**

**Jenkinsfile Example:**

```groovy
pipeline {
    agent {
        docker {
            image 'node:20'
        }
    }
    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/raviTFL/nodejs-sample.git'
            }
        }
        stage('Install Dependencies') {
            steps {
                sh 'npm install'
            }
        }
        stage('Run Tests') {
            steps {
                sh 'npm test'
            }
        }
    }
}
```

* Uses **Node.js container** → no need to install Node inside Jenkins.
* Stages run sequentially: **Checkout → Install → Test**.

---

## **9️⃣ Run and Monitor Pipeline**

1. In Jenkins → **New Item → Pipeline → Name it → OK**
2. Paste Jenkinsfile contents → **Save**
3. Click **Build Now**
4. Monitor **Build Executor** → check logs per stage

* Failed stage → pipeline stops, logs show errors.
* Success → pipeline completes automatically. ✅

---

## **10️⃣ Troubleshooting Tips**

| Issue                      | Solution                                                   |
| -------------------------- | ---------------------------------------------------------- |
| Node.js not found          | Use Node.js container instead of installing inside Jenkins |
| Permissions errors         | Ensure container has access to project files               |
| AWS firewall blocks access | Verify Security Group inbound rules                        |
| Jenkins login failed       | Use `initialAdminPassword` from container                  |

---

✅ **Pro Tip for Students:**

> Always think **layered infrastructure**: AWS → Ubuntu → Docker → Jenkins → Node.js container → Your application.
> Each layer is independent but works together.


 

### 🎓 ** Exploring Docker & Jenkins Locally on Windows 11**

---

👨‍🏫 **Mentor (Ravi Sir):**

Class, today we’re going to explore something very exciting — **Docker, Jenkins, and pipelines** — entirely on your **Windows 11 machine**. No AWS, Azure, or GCP needed. Your computer itself becomes a mini cloud.

> Think of it like building your own software factory right on your laptop.

---

### 🖥 Step 1: Install Docker Desktop

1. Go to the official Docker Desktop page:
   [Docker Desktop for Windows](https://docs.docker.com/desktop/setup/install/windows-install/)
2. Download and install Docker Desktop.
3. After installation, **sign in** to Docker Desktop (optional, but recommended for pulling images).
4. Verify installation:

```bash
docker --version
```

> Output should show Docker version installed.

---

### 🐳 Step 2: Explore Docker

* Check existing images:

```bash
docker images
```

* Check running containers:

```bash
docker ps
```

> Think of **images** as blueprints and **containers** as running instances of those blueprints.

---

### 🏗 Step 3: Run Jenkins Container

For **Node.js applications** that require multiple ports:

```bash
docker run -d \
  -p 8080:8080 -p 50000:50000 -p 8000:8000 \
  -v /var/run/docker.sock:/var/run/docker.sock \
  -v /b/deployments/jenkins_home:/var/jenkins_home \
  -v /b/deployments/deployments:/deployments \
  --name jenkins12345 \
  jenkins/jenkins:lts
```

For **simple applications**:

```bash
docker run -d \
  -p 8080:8080 -p 50000:50000 \
  -v /var/run/docker.sock:/var/run/docker.sock \
  -v /b/deployments/jenkins_home:/var/jenkins_home \
  -v /b/deployments/deployments:/deployments \
  --name jenkins56 \
  jenkins/jenkins:lts
```

> Access Jenkins in browser:
> `http://localhost:8080`

---

### 🔑 Step 4: Retrieve Jenkins Admin Password

```bash
docker logs jenkins56
```

* Use this password to log in for the first time.
* Install **default plugins** and create **admin user**.

---

### 🛠 Step 5: Install Node.js in Jenkins Container

If your pipeline requires Node.js:

```bash
docker exec -u root -it jenkins56 bash
curl -fsSL https://deb.nodesource.com/setup_18.x | bash -
apt-get install -y nodejs
exit
```

> This installs Node.js inside the Jenkins container, allowing you to run Node.js commands during builds.

---

### 💀 Step 6: Stop / Kill a Container

```bash
docker kill <container-id>
```

* Replace `<container-id>` with the actual container ID from `docker ps`.

---

### 🚀 Step 7: Create Pipelines

**1. Basic Hello World Pipeline**

```groovy
pipeline {
    agent any
    stages {
        stage('Hello') {
            steps {
                echo 'Hello World'
            }
        }
    }
}
```

---

**2. Multi-stage Pipeline**

```groovy
pipeline {
    agent any
    stages {
        stage('Build') {
            steps { sh 'echo "Building..."' }
        }
        stage('Test') {
            steps { sh 'echo "Testing..."' }
        }
        stage('Deploy') {
            steps { sh 'echo "Deploying..."' }
        }
    }
}
```

---

**3. Node.js TFLstore Application Pipeline**

```groovy
pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/RaviTambade/tflstore.git'
            }
        }
        stage('Install Dependencies') {
            steps { sh 'npm install' }
        }
        stage('Run App') {
            steps { sh 'node server.js' }
        }
    }
}
```

> Access your TFLstore app in browser:
> `http://localhost:8000`

---

### 🌟 Step 8: Mentor’s Key Takeaways

1. Docker on Windows allows you to **experiment locally** without cloud.
2. Jenkins inside Docker is **isolated** and easy to reset if needed.
3. Pipelines can automate **build, test, deploy** steps for Node.js or other applications.
4. Volumes (`-v`) allow Jenkins to persist data outside containers — important for configuration and pipelines.
5. Using `docker exec` to install additional tools gives flexibility **without touching host OS**.

> “Class, your Windows laptop is now your **DevOps playground**. You can explore pipelines, CI/CD, and containerized applications — all without spending a rupee on the cloud!”

 