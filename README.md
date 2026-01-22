# Project Description

Our client requests the development of a version that includes an **ASP.NET 8.0 MVC Web application** with access via **email and password**.

When a user logs into the system, different options will be available depending on their role (**EMPLOYEE** or **MANAGER**). The system must ensure that users who are not authenticated or do not have the required permissions **cannot access unauthorized functionalities**, either through the menu or by directly entering the corresponding URL.

---

## User Roles and Functionalities

### Anonymous User
- **Login**  
  The user enters an email and password. If the credentials are valid, they will be authorized to access the functionalities corresponding to their role.

---

### Employee User
- **View registered payments**  
  View all payments registered during the current month (payment date or start date within the current month), ordered by **total amount in descending order**.  
  For recurring payments, the **monthly installment amount** must be used instead of the total amount.

- **Register a new payment**  
  Select a payment type and enter the required data to register a new payment.  
  The user must be able to choose an expense type from all those available in the system.

- **View profile**  
  View personal profile information, including:
  - Role
  - First name
  - Last name
  - Email
  - Date of incorporation
  - Team name
  - Total amount spent during the current month (sum of all payments made during the current month)

- **Logout**  
  Ends the user session.

---

### Manager User
- **View payment list**  
  View a list of payments made by members of their team.  
  By default, the list shows payments from the **current month and year**, but the manager can specify a different month and year.

  Payments must be ordered by **total amount in descending order**.  
  For recurring payments, the **monthly installment amount** must be used instead of the total amount.

  The system must:
  - Search among all payments registered by the manager’s team members
  - Filter payments corresponding to the selected month
  - Include recurring payments whose start date is **less than or equal to** the selected month and whose end date (if any) is **greater than or equal to** the selected month

  The list must display:
  - Base amount
  - Amount including applied benefits and surcharges

- **View profile**  
  View personal profile information, including:
  - Role
  - First name
  - Last name
  - Email
  - Date of incorporation
  - Team name
  - Total amount spent during the current month

  Additionally, the manager can view all team members **ordered by email in ascending order**.

- **Add new expense type**  
  Add new expense types to the system.

- **Delete expense type**  
  Delete an expense type that is not being used by any payment.  
  If the expense type is currently in use, an error message must be displayed indicating the reason.

- **Register a new payment**  
  Select a payment type and enter the required data to register a new payment.  
  The manager must be able to choose an expense type from all those available in the system.

- **View registered payments**  
  View all payments registered during the current month (payment date or start date within the current month).

  Azure URL: https://xn--obligatorioprogramacin2-fugvevbbaygygqfh-l4d.canadacentral-01.azurewebsites.net/

- **Logout**  
  Ends the user session.
