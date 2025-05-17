```markdown
# 🛒 ECommerceVC-Project

A full-featured e-commerce desktop application developed in C# using the Windows Forms platform and layered with Onion Architecture. The application supports customer and admin roles, featuring product catalog browsing, shopping cart, order processing, and user management.

## 📁 Project Structure

This solution follows a layered Onion Architecture for better separation of concerns and maintainability:

```

ECommerceVC-Project/
│
├── ECommerceApplication     # Business logic and services
├── ECommerceContext         # Entity Framework DbContext
├── ECommerceDTOs            # Data Transfer Objects (DTOs)
├── ECommerceInfrastructure  # Data access and repository implementations
├── ECommercePresentation    # Windows Forms UI for Admin and Client
├── EcommerceData            # Entity models and database configuration
└── EcommerceProjectVC#.sln  # Solution file

````

---

## 🚀 Features

- 🛍️ **Customer View**
  - Browse available products
  - Add items to shopping cart
  - Place orders

- 🔐 **Admin View**
  - Add, edit, or delete products
  - Manage users and orders
  - View sales reports

- 💡 **Architecture**
  - Onion Architecture for clear separation between UI, business logic, and data access
  - Uses Entity Framework for data persistence
  - Repository and service patterns

---

## 🛠️ Tech Stack

- **Language**: C#
- **Framework**: .NET Windows Forms
- **ORM**: Entity Framework Core
- **Architecture**: Onion Architecture
- **Database**: SQL Server LocalDB or Express

---

## 🧰 Getting Started

### Prerequisites

- Visual Studio 2022 or newer
- .NET Desktop Development workload
- SQL Server (LocalDB or full installation)

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/3laamobarak/ECommerceVC-Project.git
````

2. Open the solution file `EcommerceProjectVC#.sln` in Visual Studio.

3. Set `ECommercePresentation` as the startup project.

4. Apply the migrations and create the database using Package Manager Console:

   ```powershell
   Update-Database
   ```

5. Run the project.

---

## 👥 Team Members

* [Alaa Mobarak](https://github.com/3laamobarak)
* [Aya Ashour](https://github.com/ayaashour2002)
* [Mostafa Rasheedy](https://github.com/MOSTAFA17RASHEEDY)
* [Aya El Warrdany](https://github.com/ayaalwarrdany)

---

## 📄 License

This project is licensed for educational use. Feel free to fork and explore.

