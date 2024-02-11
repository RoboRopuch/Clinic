# Project Overview: Medical Clinic Management System 🩺

<div align="center">
    <img src="https://github.com/RoboRopuch/Clinic/assets/128647614/56cc493e-aab7-4984-84ed-51f4c6a1e1b8" alt="Image" />
</div>

## Description:

This Medical Clinic Management System represents a comprehensive solution for modern healthcare facilities, 
offering a user-friendly interface, robust functionality, and efficient performance.  It encompasses various functionalities catering to doctors, patients, and administrative staff, facilitating efficient clinic operations and patient care.

## Key Features:
 - User Authentication: Secure authentication for doctors and patients. Account creation and activation overseen by the clinic director (user with admin role).

   View of sara's screen (new created user). She can not perform any action beacouse her account is being authorised by admin:

    ![image](https://github.com/RoboRopuch/Clinic/assets/128647614/d7539353-f0e7-4527-962c-4ef4b25336f7)

    View of admin's screen:
    ![image](https://github.com/RoboRopuch/Clinic/assets/128647614/31869f17-bb6e-43a1-9031-730900516b3f)


 - Appointment Scheduling: Patients can easily schedule appointments based on doctor specialties. Chronological display of available appointment slots for patient convenience.

    sara has been authorized and now can perform appointment related actions!: 
    ![image](https://github.com/RoboRopuch/Clinic/assets/128647614/2d5d118d-b7d5-42af-87b4-16d162cfbc4d)

  

 
 - Appointment Management: Doctors can view and manage appointments, add consultation notes, and track patient visits. Patients have access to appointment history and consultation notes for reference.
 - Weekly Schedule Management: Clinic director (admin user) can efficiently manage weekly schedules for doctors, making adjustments as needed.
 - Database Storage: Data is stored in a robust database system with migration capabilities, ensuring seamless data management, integrity, and consistency throughout the application.
 - Concurrency: Implements concurrency techniques to handle simultaneous database operations efficiently.

## Technologies Used:
 - Programming Language: C#
 - Web Framework: ASP.NET Core MVC
 - Database: Entity Framework Core (Code-First Approach)
 - Frontend: HTML, CSS, JavaScript (with Razor syntax), Bootstrap
 - Authentication: ASP.NET Core Identity
 - Database Management: SQL Server
 - Concurrency: Task Parallel Library (TPL)
 - Version Control: Git

## How to Run:
To run the app, I recommend using Visual Studio 2022. Be sure to install all necessary packages with Package Manager. 

## Future Enhancements:
 - Improve exception handling. 
 - Implement additional user notifications, such as "User Authorization Successful," to enhance user experience and clarity.
