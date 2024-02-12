# Project Overview: Medical Clinic Management System 🩺

<div align="center">
    <img src="https://github.com/RoboRopuch/Clinic/assets/128647614/56cc493e-aab7-4984-84ed-51f4c6a1e1b8" alt="project overview" />
</div>

## Description:

This Medical Clinic Management System represents a comprehensive solution for modern healthcare facilities, 
offering a user-friendly interface, robust functionality, and efficient performance.  It encompasses various functionalities catering to doctors, patients, and administrative staff, facilitating efficient clinic operations and patient care.

## Key Features:
 - **User Authentication**: Secure authentication for doctors and patients. Account creation and activation overseen by the clinic director (user with admin role).
 - **Appointment Scheduling**: Patients can easily schedule appointments based on doctor specialties. Chronological display of available appointment slots for patient convenience.
 - **Appointment Management**: Doctors can view and manage appointments, add consultation notes, and track patient visits. Patients have access to appointment history and consultation notes for reference.
 - **Weekly Schedule Management**: Clinic director (admin user) can efficiently manage weekly schedules for doctors, making adjustments as needed.
 - **Database Storage**: Data is stored in a robust database system with migration capabilities, ensuring seamless data management, integrity, and consistency throughout the application.
 - **Concurrency**: Implements a concurrency handling mechanism using row versioning technique to effectively manage simultaneous database operations, particularly when booking an appointment.

## Technologies Used:
 - **Programming Language**: C#
 - **Web Framework**: ASP.NET Core MVC
 - **Database**: Entity Framework Core (Code-First Approach)
 - **Frontend**: HTML, CSS, JavaScript (with Razor syntax), Bootstrap
 - **Authentication**: ASP.NET Core Identity
 - **Database Management**: SQL Server
 - **Version Control**: Git

## How to Run:
To run simply open project in Visual Studio 2022, install all necessary packages and execute Program.cs file. 

## Future Enhancements:
 - Improve exception handling. 
 - Implement additional user notifications, such as "User Authorization Successful," to enhance user experience and clarity.
