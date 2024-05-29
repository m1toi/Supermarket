# Supermarket Management Application

## Overview
This application is a comprehensive system designed to manage supermarket operations. Built using C#, WPF, and SQL Server for the database, it adheres to the MVVM (Model-View-ViewModel) architecture. The application manages various entities within a supermarket such as products, manufacturers, categories, stocks, users, and receipts, and provides functionality tailored to two types of users: administrators and cashiers.

## Features

### Administrator Functionalities
1. **CRUD Operations:**
   - Manage users, categories, manufacturers, products, and stocks with create, read, update, and delete operations.
   - Logical deletion of data (data becomes inactive instead of being removed from the database).

2. **Stock Management:**
   - Manually input purchase price; sale price is auto-calculated.
   - Purchase price is immutable post-entry; only sale price can be updated, ensuring it is not lower than the purchase price.
   - Validation of form fields during data entry, modification, and deletion.


### Cashier Functionalities
1. **Product Search:**
   - Search products by name, barcode, expiration date, manufacturer, or category.

2. **Receipt Management:**
   - Add products to receipts, displaying their prices and calculating subtotals and total amounts.
   - Finalized receipts cannot be modified.
   - Automatically manage stock quantities and deactivate empty or expired stocks.


