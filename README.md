# LevelUp Rentals: Hybrid Booking System

LevelUp Rentals is a full-stack MVP designed to demonstrate cloud-native architecture, 
hybrid data modeling (SQL + NoSQL), and high-concurrency state management.

## 🚀 The Mission
To build a "Zero to Hero" rental platform that handles:
1. **Physical Inventory:** Strict 1-to-1 booking logic using PostgreSQL relational constraints.
2. **Digital Licenses:** Scalable, concurrent access using PostgreSQL JSONB (NoSQL) patterns.
3. **Cloud Security:** Azure Key Vault for secret management and Managed Identities.

## 🛠️ Current Tech Stack
- **Framework:** .NET 10 (C#)
- **Database:** PostgreSQL + EF Core 10
- **Security:** Azure Key Vault (Managed Identity via Azure CLI)
- **API Docs:** Native ASP.NET Core OpenAPI (`/openapi/v1.json`)

## ✅ Completed Features
- **Cloud-Local Bridge:** Securely fetching DB strings from Azure KV.
- **Physical Inventory:** Atomic transactions to handle disc stock.
- **Auto-Seeding:** Database initializes with Elden Ring, Halo, and Mario Kart.

## 🔜 Next Milestone: Sprint 2 (Digital Pivot)
- Transitioning `Game.cs` to a **Hybrid Schema**.
- Implementing **JSONB** for flexible digital metadata (License Keys, File Sizes).

## 🏗️ Architecture Decisions
- **Relational vs. Non-Relational:** We use standard SQL for physical discs to prevent over-booking (ACID). We use JSONB for digital game metadata and user-specific library data to allow for schema flexibility and high-read performance.
- **Security:** Zero "hard-coded" secrets. All environment variables are injected via Azure Key Vault.

## 🏃 Getting Started
1. `npm install` in /frontend and /backend.
2. Configure your `.env` using the `az keyvault secret show` command.
3. `npm run dev` to launch the local laboratory.