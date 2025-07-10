# 🧱 Distributed Logging Sample

A simple .NET solution demonstrating distributed logging between microservices using Serilog and Seq.

---

## 🛠️ Requirements

Make sure you have the following tools installed:

- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) *(only needed if you want to run or debug services locally without Docker)*
- (Optional) [JetBrains Rider](https://www.jetbrains.com/rider/) or [Visual Studio Code](https://code.visualstudio.com/)

---

## 📦 Project Structure

```
/
├── ServiceA.API/
│   └── Dockerfile
├── ServiceB.API/
│   └── Dockerfile
├── compose.yaml
└── README.md
```

---

## 🚀 How to Run the Project

Run the following commands from the root folder:

```bash
docker compose down --volumes
docker compose build
docker compose up -d
```

---

## 🔗 Endpoints

Once running, you can access the services here:

| Service        | URL                   |
|----------------|-----------------------|
| Service A API  | http://localhost:5100 |
| Service B API  | http://localhost:5200 |
| Seq Dashboard  | http://localhost:8081 |

---

## 🔐 Seq Default Login

- **Username:** `admin`  
- **Password:** `admin123`

---

## 📬 Example Request (Postman)

**POST** to:

```
http://localhost:5100/api/message
```

With body:

```json
{
  "content": "Hello from Postman"
}
```

---

## 🧹 Clean Up

To stop and remove containers and volumes:

```bash
docker compose down --volumes
```