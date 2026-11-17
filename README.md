🦷 DentalisApp – Dental Clinic Management System
DentalisApp is a web-based dental clinic management system developed with ASP.NET Core MVC. 
📋 Table of Contents
•	About the Project
•	Technologies Used
•	Prerequisites
•	Getting Started
•	Project Structure
•	Features
•	Usage
•	Database Setup
•	Configuration
•	Contributing
•	License
📖 About the Project
DentalisApp is a web-based dental clinic management system developed using ASP.NET Core MVC. It helps dentists organize and manage patient information and maintain patient medical records in one centralized application. The project demonstrates practical implementation of MVC architecture, Entity Framework Core, ASP.NET Core Identity, and a service-based architecture with DTOs and ViewModels.
🛠️ Technologies Used
Technology	Version	Purpose
ASP.NET Core MVC	8.0	Web framework
Entity Framework Core	8.0	ORM / Database access
SQL Server	-	Database
Bootstrap	5.3	Frontend styling
Razor Pages / Views	-	Server-side HTML rendering

✅ Prerequisites
Make sure you have the following installed before running the project:
·	.NET SDK 8.0+
·	Visual Studio 2022 or VS Code
·	SQL Server or SQLite (if used)
·	Git
🚀 Getting Started
Follow these steps to get the project running locally.
1.	Clone the repository:
git clone https://github.com/IrinaShumkova/DentalisApp.git
      cd DentalisApp
2.	Restore dependencies
	dotnet restore
3.	Configure the database
Update the connection string in appsettings.json to match your local SQL Server configuration.
4.	Apply database migrations
	dotnet ef database update
If the EF Core CLI tool is not installed, install it using:
	dotnet tool install --global dotnet-ef

5.	Run the application
	dotnet run
Open the URL displayed in the terminal to access DentalisApp in your browser.
🏗️ Project Architecture
The application follows a layered architecture to separate responsibilities and improve maintainability.
•	Controllers – Handle HTTP requests and coordinate application operations.
•	Services – Contain business logic and communicate with the database.
•	DTOs (Data Transfer Objects) – Transfer data between application layers.
•	ViewModels – Provide data to Razor Views.
•	Models – Represent the application's database entities.
•	Views – Display the user interface using Razor and Bootstrap.
•	Data – Contains the database context and database configuration.
✨ Features
👥 Patient Management
•	Add new patients.
•	View a list of all patients.
•	View detailed patient information.
•	Edit patient information.
•	Deactivate patients without permanently deleting their records.
•	Validate patient data and prevent duplicate EGN entries.
🔐 Authentication and Authorization
•	User registration and login.
•	Secure authentication using ASP.NET Core Identity.
•	Associate patients with their responsible dentist.
•	Restrict access to patient records based on user permissions.
🔒 Security and Data Protection
DentalisApp handles patient-related information. The application uses authentication and authorization mechanisms to protect access to patient records.
Patient records are associated with individual dentists, and sensitive information should only be accessible to authorized users.
Note: This project is intended for educational and development purposes. It should undergo appropriate security, privacy, and regulatory reviews before being used with real patient data.
💻 Usage 
After launching DentalisApp, follow these steps to start using the application:
1.	Register an account – Navigate to /Identity/Account/Register to create a new dentist account.
2.	Log in – Sign in using your registered email and password.
3.	View your patients – Navigate to the patient management section to see your patient list.
4.	Add a patient – Create a new patient record by entering their personal and contact information.
5.	View patient details – Open a patient's profile to view their information and medical history.
6.	Edit patient information – Update patient details whenever necessary.
7.	Delete a patient – Remove a patient record from the system after confirming the deletion.
🗄️ Database Setup
DentalisApp uses Microsoft SQL Server as its database and Entity Framework Core with the Code-First approach for database management.
Connection String
The database connection string is configured in appsettings.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=DentalisApp;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
Replace YOUR_SERVER with your local SQL Server instance.
Database Migrations
Entity Framework Core migrations are used to create and update the database schema.
To create the initial migration (only if one does not already exist):
dotnet ef migrations add InitialCreate
To apply migrations and create or update the database:
dotnet ef database update
To create a new migration after making changes to your entity models:
dotnet ef migrations add YourMigrationName
Then apply the changes:
dotnet ef database update
Note: If migrations already exist in the repository, you only need to run dotnet ef database update. You do not need to create the initial migration again.
⚙️ Configuration
DentalisApp uses appsettings.json to store application configuration settings, including the database connection string and logging configuration.
Application Settings
Example configuration:
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Database Configuration
Update the DefaultConnection value to match your local SQL Server configuration before running the application.
Security
⚠️ Never commit sensitive information such as database passwords, API keys, or other credentials to source control.
For local development, use:
•	appsettings.Development.json (without committing secrets).
•	User Secrets for storing local development credentials.
•	Environment variables for deployment configuration.
Note: Keep your public appsettings.json free of real passwords and sensitive connection details.
🤝 Contributing
Contributions, suggestions, and improvements are welcome! If you would like to contribute to DentalisApp, follow these steps:
1.	Fork the repository – Create your own copy of the project.
2.	Clone your fork – Download the repository to your local machine.
3.	Create a new branch:
git checkout -b feature/your-feature-name
4.	Make your changes – Implement your feature or bug fix.
5.	Commit your changes:
git commit -m "feat: add your feature"
6.	Push your branch:
git push origin feature/your-feature-name
7.	Open a Pull Request – Submit your changes for review.
Thank you for your interest in improving DentalisApp! ❤️
📄 License
This project is licensed under the MIT License.
See the LICENSE file for more information.
📌 Project Status
The project is currently under development. New features and improvements will be added over time.
👩‍💻 Author
Developer: Your Name
GitHub: IrinaShumkova
Project Link: https://github.com/IrinaShumkova/DentalisApp.git

