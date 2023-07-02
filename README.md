# Community Institute API

The Community Institute API is a comprehensive and user-friendly application designed to facilitate effective communication and collaboration within a community of professors, administrators, and students. This project serves as my graduation project and is built using ASP .NET 6, EF Core 6, LINQ, Microsoft Identity, and JWT.

## Features

- Three types of users: professors, administrators, and students, each with distinct roles and capabilities.
- Professors can:
  - Review and approve/deny student join requests.
  - Upload class materials.
  - Upload assignments.
  - Create posts.
  - Engage in discussions through comments.
- Students can:
  - Join classes.
  - Access class materials.
  - View posts.
  - Submit assignment solutions.
  - Comment on posts.
  - Download materials.
- Administrators have comprehensive platform management capabilities, including:
  - Adding subjects.
  - Creating classes.
  - Assigning professors.
  - Managing posts.

## Authentication and Authorization with JWT

The Community Institute API utilizes JSON Web Tokens (JWT) for secure authentication and authorization. JWT is a stateless, token-based approach that allows users to authenticate and access protected resources based on the roles and permissions assigned to them.

- Users will receive a JWT upon successful authentication, which they will include in subsequent requests as an Authorization header.
- The API will validate the JWT to ensure the user is authenticated and authorized to access the requested resource.
- Permissions and roles are defined in the JWT claims, enabling fine-grained control over the actions users can perform.
- JWTs are signed with a secret key to ensure their integrity and prevent tampering.

## Technologies Used

- ASP .NET 6: Provides a robust and scalable web development framework.
- EF Core 6: Enables efficient database operations and data modeling.
- LINQ: Simplifies data querying and manipulation.
- Microsoft Identity: Ensures secure authentication and authorization for users.
- JWT: Implements token-based authentication for secure API access.

## Getting Started

To run the Community Institute API locally, follow these steps:

1. Clone the repository: `git clone https://github.com/moostafasal/community-institute-api.git`
2. Navigate to the project directory: `cd community-institute-api`
3. Install the required dependencies: `dotnet restore`
4. Update the database connection string in the `appsettings.json` file.
5. Apply the database migrations: `dotnet ef database update`
6. Build and run the project: `dotnet run`

## Contributing

Contributions are welcome! If you'd like to contribute to the Community Institute API, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature: `git checkout -b feature-name`
3. Commit your changes: `git commit -m "Add feature"`
4. Push to the branch: `git push origin feature-name`
5. Submit a pull request.

## License

The Community Institute API is licensed under the [MIT License](https://opensource.org/licenses/MIT).

## Contact

For any inquiries or feedback, please contact [mostafaasalem2@gmail.com](mailto:your-email@example.com).

Feel free to explore and use the Community Institute API to enhance collaboration and communication within your educational community. We hope you find it valuable and contribute to its growth.
