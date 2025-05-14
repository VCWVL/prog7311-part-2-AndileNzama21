Agri-Energy Connect Platform Prototype

User to Login : Employee: employee1@example.com / Password123!
📌 Project Overview

The Agri-Energy Connect Platform aims to connect **farmers** with **employees** in the agricultural energy sector by managing farmer profiles and their products. This prototype showcases:

- Database-driven farmer and product management
- Role-based access for farmers and employees
- Responsive and user-friendly UI
- Validated and secure data entry

---

 🧑‍💻 User Roles and Permissions

 👨‍🌾 Farmer
- Can log in securely
- Add new products (name, category, production date)
- View their own product listings

 👨‍💼 Employee
- Can log in securely
- Add new farmer profiles (with essential details)
- View and filter products from any farmer based on:
  - Date range
  - Product type/category

---

 🛠️ Technologies Used

- **C# ASP.NET Core MVC**
- **Entity Framework Core**
- **SQL Server LocalDB**
- **Bootstrap 5**
- **Identity Framework for Authentication**
- **Razor Pages**

---

 🗃️ Database

The application uses a relational SQL database with the following key tables:

- `Farmers` – stores farmer profile information
- `Products` – stores product details and links to farmers
- `AspNetUsers`, `AspNetRoles` – for managing user authentication and roles

 🧪 Sample Data
Sample data is included via the `DbInitializer` class to simulate real-world usage.

---

 📲 Features

 For Farmers
- Secure login and role-based dashboard
- Product creation form with validation
- View list of their products

 For Employees
- Secure login and role-based dashboard
- Create and manage farmer profiles
- Filter products by farmer, category, and date range

---

 ✅ Data Validation & Error Handling

- All forms use **server-side and client-side validation**
- Proper error messages and required field indicators
- Try-catch blocks and exception logging where necessary

---

🧪 Testing

- Manual testing was done on:
  - User authentication
  - Role-based redirection
  - Form validation
  - Product filtering
- UX testing conducted using sample users to verify usability and clarity

---

 🚀 How to Set Up the Development Environment

 Prerequisites

- Visual Studio 2022+
- .NET 6 SDK or later
- SQL Server (LocalDB or full instance)


