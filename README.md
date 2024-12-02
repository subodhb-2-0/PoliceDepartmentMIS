# Police Department MIS

## Description
This project is a system for managing inmate information and their bookings. The system allows for tracking details about inmates, their bookings, and other related data.

The project consists of three main parts:
- **Backend**: Developed with .NET Core (ASP.NET Core API)
- **Frontend**: Built with React
- **Database**: MySQL to store inmate and booking information

## Prerequisites
Before running the project, ensure that you have the following software installed:

- [Node.js](https://nodejs.org/) (for the React frontend)
- [npm](https://www.npmjs.com/) (Node package manager, usually installed with Node.js)
- [MySQL](https://www.mysql.com/) (for the database)
- [.NET SDK](https://dotnet.microsoft.com/download) (for the backend)

## Importing Data into MySQL

If you have a `.sql` file in the `database` folder that contains the data you want to import into your MySQL database, follow the steps below:

### 1. Navigate to the Database Folder

The `.sql` file is located in the `database` folder of this project.

### 2. Open MySQL Workbench and Go to Data Import/Restore

Go to the **Administrator** tab and click on **Data Import/Restore**.

### 3. Select the Folder Where `.sql` File is Located

Select **Dump Structure and Data** and click **Start Import**.

---
## Running the .NET Core Backend

To start the .NET Core backend, follow these steps:

### 1. Navigate to the Backend Directory

Open your terminal and navigate to the directory where the .NET Core project is located. This should be the directory containing the `.sln` file. open the file and Visual Studio should open or write the below code  in terminal.

```bash
dotnet restore
```

### 2. Add appsettings.Developement.json

Go to **PoliceDepartmentMIS.API** and Create appsettings.developement.json file and put the below code in there:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultMySqlConnection": "Server=localhost;Port=3306;Database=PoliceDepartmentMIS;Uid=root;Pwd=Password;"
  },
  "JwtSettings": {
    "ValidAudience": "PoliceDepartment_Audience",
    "ValidIssuer": "PoliceDepartment_Issuer",
    "Secret": "WhatIsThisSecretIHaveNoIdea.CanYouTellMeAboutItInDetail?"
  }
}
```
### 3. Run the application
Run the project using visual studio 

OR,

Go to **PoliceDepartmentMIS.API** folder, open the terminal and write the below code.
```bash
dotnet run
```

---

## Running the React App with Vite

To run the React frontend using Vite, follow the steps below:

### 1. Navigate to the Frontend Directory

In your terminal, navigate to the frontend directory where the React project is located. This should be the directory where `vite.config.js` is present. If it's not already installed, make sure you're in the right folder.

```bash
cd Frontend/PoliceDepartmentMIS
```
### 2. Install Dependencies

Before running the app, you need to install the required dependencies. Run the following command to install all necessary packages:

```bash
npm install
```
This will install the packages listed in the package.json file.

### 3. Start the Development Server

After the dependencies are installed, run the following command to start the React development server using Vite:

```bash
npm run dev
```
This will start the Vite development server, and you should see output similar to:


```bash
VITE v2.x.x  ready in x.xxxs

  ➜  Local:   http://localhost:3000/
  ➜  Network: use `--host` to expose
```
---

## How to Use the Application

### 1. Login Screen

The first screen you will see is the login page. To log into the system, use the following credentials:

- **Username**: `Admin@123`
- **Password**: `Admin@123`

Once you enter these credentials and click the **Login** button, you will be directed to the main dashboard of the application.

### 2. Navigation via Sidebar

After logging in, you will see a sidebar on the left side of the screen. This sidebar allows you to navigate to different pages of the application. Simply click on the menu options to switch between different sections, such as:

- **Dashboard**: The main overview of the system.
- **Inmates**: A page to view and manage inmate information.
- **Bookings**: A page to view and manage booking records.

Clicking on any of these links will navigate you to the respective page where you can manage the data associated with that section.

---

