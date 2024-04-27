# Job Listing Web Application

This web application is built using ASP.NET Razor Pages framework and utilizes a database named CareerConnector for job listings. It also integrates Identity for user authentication.

## Features

- User Authentication: Allows users to sign up, log in, and manage their accounts.
- Job Listing Management: Users can view job listings, Employers can create, edit, and delete job listings.
- Search Functionality: Users can search for job listings based on various criteria.
- Responsive Design: The application is designed to be responsive and accessible across different devices.
- Applications: Users may create applications for several jobs, and employers can view all of the applications for thier job listings.

## Installation

1. Clone this repository to your local machine.
2. Ensure you have the necessary prerequisites installed:
   - .NET SDK: [Download here](https://dotnet.microsoft.com/download)
   - Visual Studio or Visual Studio Code (optional)
3. Set up the CareerConnector database:
   - Use the provided SQL script (SQLSCRIPT.sql) to create the necessary tables and data.
	- Originally hosted on SQLServer in a docker container.
4. Configure Identity:
   - Modify the Identity settings in `Program.cs` according to your requirements, (also check out appsettings.json, as that holds all of the connection strings.)
5. Build and run the application:

dotnet build
dotnet run

6. Access the application in your web browser after running application. (localhost, Port Number: 7228)

## Usage

1. Register for a new account or log in if you already have one.
2. Navigate through the application to view, create, edit, or delete job listings.
3. Utilize the search functionality to find specific job listings.
4. Manage your account settings as needed.

## Technologies Used

- ASP.NET Core
- Razor Pages
- Entity Framework Core
- Identity
- HTML/CSS/JavaScript (Frontend)
- CareerConnector Database

## Contributing

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature-name`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add some feature'`).
5. Push to the branch (`git push origin feature/your-feature-name`).
6. Create a new Pull Request.

## Acknowledgements

- [ASP.NET Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Razor Pages Documentation](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [Identity Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
