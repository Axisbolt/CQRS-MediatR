# CQRS-MediatR

Setup Steps
1. Clone the repo
2. Setup the Microsoft SQL Server Management System
3. Paste the SQL script from SQL-Script.txt file and RUN. It will setup database , table and with some dummy data.
4. Change the connection sctring in appsettings.Development.json.
     "ConnectionStrings": {
    "DbContext": "Server=(localdb)\\Local;Database=Amazon;Trusted_Connection=True;" // Your connection string 

  }

5. Compile, Build and Run the Project
