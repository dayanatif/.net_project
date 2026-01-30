---

## Setup & Run Instructions

Follow these steps to run the application locally:

1. **Clone the repository**

   ```bash
   git clone https://github.com/dayanatif/.net_project.git
   ```

2. **Open the project**

   * Open the project folder in **Visual Studio**
   * Ensure the correct `.csproj` file is loaded

3. **Restore dependencies**

   * Visual Studio usually restores packages automatically
   * If not, run:

     ```bash
     dotnet restore
     ```

4. **Configure the database**

   * Open `appsettings.json`
   * Update the database connection string according to your local setup
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

6. **Access the application**

   * Open a browser and navigate to:

     ```
     https://localhost:xxxx
     ```

---

* Adjust it for **Viva / instructor reading**
* Align it with a **professional GitHub README style**
