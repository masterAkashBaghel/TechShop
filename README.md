# TechShop

TechShop is a console-based application for managing products, orders, inventory, and customers in a tech shop. This application allows users to perform various operations such as adding, updating, and retrieving details for products, orders, inventory, and customers.

## Features

- **Product Management**: Add, update, and retrieve product details.
- **Order Management**: Place, update, and cancel orders.
- **Inventory Management**: Add to inventory, remove from inventory, and check product availability.
- **Customer Management**: Add, update, and retrieve customer details.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)

### Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/masterAkashBaghel/TechShop
   ```

2. Navigate to the project directory:

   ```sh
   cd TechShop/TechShopSolution
   ```

3. Restore the dependencies:
   ```sh
   dotnet restore
   ```

### Running the Application

1. Build the project:

   ```sh
   dotnet build
   ```

2. Run the application:
   ```sh
   dotnet run --project TechShop
   ```

## Usage

Upon running the application, you will be presented with a menu of options to manage products, orders, inventory, and customers. Select an option by entering the corresponding number and follow the prompts.

### Example Operations

- **Add a Product**: Enter product details such as name, description, price, category, and quantity in stock.
- **Place an Order**: Enter customer name, order date, and total amount.
- **Add to Inventory**: Enter product ID and quantity to add.
- **Add a Customer**: Enter customer details such as first name, last name, email, and phone number.

## Project Structure

- **TechShop.Entities**: Contains the entity classes such as `Product`, `Order`, `Inventory`, and `Customer`.
- **TechShop.Services**: Contains the service classes for managing entities.
- **TechShopApp**: Contains the console application and operations for interacting with the services.
