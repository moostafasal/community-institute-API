Community Institute API
The Community Institute API is a comprehensive and user-friendly application designed to facilitate effective communication and collaboration within a community of professors, administrators, and students. This project serves as my graduation project and is built using ASP .NET 6, EF Core 6, LINQ, Microsoft Identity, and JWT.

Features
Three types of users: professors, administrators, and students, each with distinct roles and capabilities.
Professors can review and approve/deny student join requests, upload class materials, assign assignments, create posts, and engage in discussions through comments.
Students can join classes, access class materials, view posts, submit assignment solutions, comment on posts, and download materials.
Administrators have comprehensive platform management capabilities, including adding subjects, creating classes, assigning professors, and managing posts.
Authentication and Authorization with JWT
The Community Institute API utilizes JSON Web Tokens (JWT) for secure authentication and authorization. JWT is a stateless, token-based approach that allows users to authenticate and access protected resources based on the roles and permissions assigned to them.

Users will receive a JWT upon successful authentication, which they will include in subsequent requests as an Authorization header.
The API will validate the JWT to ensure the user is authenticated and authorized to access the requested resource.
Permissions and roles are defined in the JWT claims, enabling fine-grained control over the actions users can perform.
JWTs are signed with a secret key to ensure their integrity and prevent tampering.
Technologies Used
ASP .NET 6: Provides a robust and scalable web development framework.
EF Core 6: Enables efficient database operations and data modeling.
LINQ: Simplifies data querying and manipulation.
Microsoft Identity: Ensures secure authentication and authorization for users.
JWT: Implements token-based authentication for secure API access.
Getting Started
To run the Community Institute API locally, follow these steps:

Clone the repository: git clone https://github.com/your-username/community-institute-api.git
Navigate to the project directory: cd community-institute-api
Install the required dependencies: dotnet restore
Update the database connection string in the appsettings.json file.
Apply the database migrations: dotnet ef database update
Build and run the project: dotnet run
