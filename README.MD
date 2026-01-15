# 💰 Home Finance

Personal finance management system built with **.NET 10**, **React**, and **PostgreSQL**.

The project allows managing **people, categories and financial transactions**, providing a **dashboard with reports and insights** about incomes, expenses and balances.

This project was developed focusing on **clean architecture, business rules, and real-world backend/frontend patterns**.

<div style="display: flex; gap: 8px; align-items: center; margin-top:10px;"> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" title="C#" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" title=".NET" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/react/react-original.svg" title="React" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/vitejs/vitejs-original.svg" title="Vite" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/typescript/typescript-original.svg" title="TypeScript" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/postgresql/postgresql-original.svg" title="PostgreSQL" /> <img height="32" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original.svg" title="Docker" /> </div>

---

## 📌 Features

* People management
* Categories management (Income, Expense, Both)
* Financial transactions (income and expenses)
* Dashboard with totals and reports
* Reports by person
* Reports by category (pie chart)
* Business rules validation
* Global error handling
* Automatic database migrations
* Dockerized environment

---

## 🏗️ Architecture

The backend follows **Clean Architecture**, separating responsibilities across layers:

* **Api** → HTTP endpoints, middlewares, dependency injection
* **Application** → Use cases, CQRS, validations, reports
* **Core** → Domain entities, business rules, domain exceptions
* **Infra** → Database access, repositories, EF Core, Dapper

### Backend patterns and tools

* **CQRS with Wolverine**
* **FluentValidation** for input validation
* **Centralized exception handlers** (validation, domain and global errors)
* **EF Core** for persistence
* **Dapper** for reporting queries
* **Automatic migrations on startup**

---

## 🎨 Frontend

The frontend is built with **React + Vite**, focusing on a clean UI and maintainable structure.

### Frontend highlights

* **Shadcn/UI** for design system
* **Reusable services** for API communication
* **Global Axios interceptor** for error handling
* **Toast notifications** for feedback
* **Dashboard with cards, tables and charts**
* **Modular pages (People, Categories, Transactions, Dashboard)**

---

## ⚙️ Tech Stack

### Backend

* .NET 10
* ASP.NET Core
* Wolverine (CQRS / Mediator)
* FluentValidation
* Entity Framework Core
* Dapper
* PostgreSQL

### Frontend

* React
* Vite
* TypeScript
* Shadcn/UI
* Sonner (toasts)

### Infrastructure

* Docker
* Docker Compose

---

## 📸 Application Screenshots

### Pages

#### Dashboard 
![Dashboard](docs/screenshots/dashboard.png)
#### Transactions
![Transactions](docs/screenshots/transactions.png)
#### Categories
![Categories](docs/screenshots/categories.png)
#### People
![People](docs/screenshots/people.png)


### 🗄️ Database Modeling

![ER Diagram](docs/database/home-finance.png)

---


## 🐳 Running with Docker

### 1️⃣ Create environment file

```bash
cp .env.example .env
```

Fill in the environment variables.

---

### 2️⃣ Build and start containers

```bash
docker compose --env-file .env up --build
```

---

### 📍 Services

| Service    | URL                                            |
| ---------- | ---------------------------------------------- |
| Frontend   | [http://localhost:3000](http://localhost:3000) |
| API        | [http://localhost:5000](http://localhost:5000) |
| PostgreSQL | localhost:5432                                 |

---

## 📂 Project Structure

```
home-finance/
├── api/        # .NET backend (Clean Architecture)
├── web-app/    # React + Vite frontend
├── docker-compose.yml
├── .env.example
└── README.md
```

