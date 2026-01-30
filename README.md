
---

## Setup & Run Instructions

Follow these steps to run the application locally:

1. **Clone the repository**

   ```bash
   git clone https://github.com/dayanatif/.net_project.git
   ```

2. **Open the project**

   * Open the project folder in **Visual Studio**
   * Make sure the correct `.csproj` file is loaded

3. **Restore dependencies**

   * Visual Studio usually restores packages automatically
   * If not, run:

     ```bash
     dotnet restore
     ```

4. **Configure the database**

   * Open `appsettings.json`
   * Update the connection string according to your local SQL Server setup
   * Apply migrations if required:

     ```bash
     dotnet ef database update
     ```

5. **Run the application**

   * Click **Run** in Visual Studio
     **OR**

     ```bash
     dotnet run
     ```

6. **Create the login table (first-time setup)**

   * Install the EF Core tools if needed: `dotnet tool install --global dotnet-ef`
   * Add and apply the migration for login users:

     ```bash
     dotnet ef migrations add AddAppUser
     dotnet ef database update
     ```

   * Or create the `app_user` table manually in MySQL with columns: `Id` (int, PK, auto-increment), `UserName` (varchar), `PasswordHash` (varchar), `Role` (varchar).

7. **Access the app**

   * Open the browser and go to:

     ```
     https://localhost:xxxx
     ```

8. **Login**

   * You will be redirected to the login page if not signed in.
   * **Default accounts:**
     * **Admin:** username `admin`, password `Admin@123` — can add, view, edit, and delete everything.
     * **User:** username `user`, password `User@123` — can only view subscriptions, email users, and domains (no add/edit/delete).

---


