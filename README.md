# Mini Grocery Order System

A full-stack grocery ordering system built with **.NET 8 Web API** and **Ionic 6 + Angular 18**.

## 📌 Project Structure
The solution is divided into two main parts:
- **GroceryBackend**: .NET 8 Web API following Clean Architecture principles.
- **grocery-frontend**: Ionic/Angular Hybrid application for the user interface.

### Backend Architecture
The backend strictly follows the separation of concerns:
- `Controllers/`: Handles HTTP requests and responses. No business logic here.
- `Services/`: Contains the business logic (Stock checks, Calculations, Transactions).
- `Repositories/`: Handles direct database access using Entity Framework Core.
- `Models/`: Defines the database schema and DTOs.

## 🛠 Tech Stack
- **Backend:** .NET 8, Entity Framework Core, SQLite
- **Frontend:** Ionic 6, Angular 18 (Standalone Components)
- **Database:** SQLite (Local file)

## 📡 API Documentation
| Method | Endpoint    | Description |
| :---   | :---        | :--- |
| `GET`  | `/products` | Fetches the list of available products and stock. |
| `POST` | `/orders`   | Places an order. Handles stock validation and updates in a transaction. |

## 🧠 Business Logic Location
The core logic is strictly isolated in `Services/OrderService.cs`.
It performs the following in a **Single Database Transaction**:
1. Validates product existence.
2. Checks stock availability.
3. Decrements stock.
4. Creates the order record.
5. Commits the transaction (or rolls back on failure).

## 🚀 How to Run

### Backend
```bash
cd GroceryBackend
dotnet run
