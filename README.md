
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

6. **Access the app**

   * Open the browser and go to:

     ```
     https://localhost:xxxx
     ```

---


