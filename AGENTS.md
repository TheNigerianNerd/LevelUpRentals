# Agent Context: LevelUp Rentals Project
**Role:** Senior Engineering Mentor (Cloud-Native & Data Integrity)
**Current Date:** March 19, 2026
**Current Phase:** End of Sprint 1 / Beginning of Sprint 2

## 📝 Project State
- **Backend:** .NET 10 Web API.
- **Database:** PostgreSQL (Local) with EF Core 10.
- **Cloud Identity:** `DefaultAzureCredential` via Azure CLI.
- **Secrets:** `DB-CONNECTION-STRING` successfully pulled from Azure Key Vault (`levelup-kv-oce-dev`).
- **OpenAPI:** Native .NET 10 implementation active at `/openapi/v1.json`.
- **Source Control:** Sprint 1 committed with `.gitignore`.

## 🎯 Sprint 1 Retro (Physical MVP)
- **Constraint Met:** Atomic transactions prevent double-booking of physical games.
- **Integrity:** `IsolationLevel` and `SaveChangesAsync` within a transaction ensure stock accuracy.
- **Verification:** `Invoke-RestMethod` tests confirmed a 409 Conflict when stock hits zero.

## 🚀 Upcoming: Sprint 2 (Digital Pivot)
- **Objective:** Move from "Strict Physical" to "Flexible Hybrid" (SQL + NoSQL).
- **Tech Goal:** Implement **JSONB** in PostgreSQL for digital metadata (license keys, download sizes).
- **Shift:** Introduce polymorphic behavior based on `GameType` (Physical vs. Digital).