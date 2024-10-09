# Objective

## Introduction
The objective of the ask here is to identify the knowledge in:

1. Object-Oriented Programming (OOP)
2. Session Management
3. Database Connections
4. Security understanding (Access, restrictions, etc.)
5. Data Sanitization
6. MVC or MVVC implemented (Model, View, Controller)

All code must be uploaded to GitHub, including your database file, and a link to this must be provided.

Based on the assessment, a strengths and weaknesses skills matrix can be created to identify areas of improvement and concern, as well as benchmark the experience and knowledge of the candidate.

## Assessment Task
For this assessment, we ask that the candidate creates a CRUD (Create, Read, Update, and Delete) interface. The interface should include the following:

1. **Login to web app using Username/Password**
   - There should be two levels of access:
     - **Admin**: Can Add/Edit, and Remove
     - **Staff**: Can only Add/Edit

2. **Once logged in, the user should be presented with a Table Grid of data**. This data could contain any type of information, such as:
   - Tasks
   - Projects
   - Clients
   - Stock
   - Etc.

3. **Based on access rights, users should be allowed to:**
   - Add
   - Edit
   - Remove

## Assessment Criteria
During our assessment of the code supplied, we will evaluate the following:

1. **Correct use of Forms**
2. **Base Configuration settings**
3. **Class Structure**:
   - Is the code neat?
   - Is the code organized?
   - Is the code documented?






##
## USAGE:
##
<div class="readme-container p-3 bg-light border rounded">
    <h3>README Instructions</h3>
    <p class="text-muted">Welcome to the .NET Core 8 MVC CRUD Interface application. Below are some guidelines:</p>
    <ul class="list-unstyled">
        <li><i class="fa fa-check-circle text-success"></i> NB! First this solution makes use of EntityFrameworkCore Code-First approach - so you have to run migrations from PackageManagerConsole or the dotNetTool first so that your database gets created with the schema first then you can proceed to test functionality.</li>
        <li><i class="fa fa-check-circle text-success"></i> Do not modify the connectionstring.</li>
        <li><i class="fa fa-check-circle text-success"></i> Commands to run on PackageManagerConsole: <p class="font-weight-bold"> update-database </p></li>
        <li><i class="fa fa-check-circle text-success"></i> Sample data will get seeded to your database (MS-SQL database) on startup of solution.<p class="font-weight-bold"> DatabaseName='MVC_CRUD_Interface_DB'. </p></li>
        <li><i class="fa fa-check-circle text-success"></i> There are 4 Roles that gets seeded to database on app-startup <p class="font-weight-bold"> 1: SuperAdmin - has permissions do everything. </p> <p class="font-weight-bold"> 2: Admin - has permissions to only Add/Edit, and Remove Clients/Customers. </p> <p class="font-weight-bold"> 3: Moderator - not hookedup no user has this role in the seeded sample data. </p>  <p class="font-weight-bold"> 4: Basic - consider this role to be a staff member as per criteria & only has permissions to Add/Edit Clients/Customers </p>  </li>
        <li><i class="fa fa-check-circle text-success"></i> Credentials: <p class="font-weight-bold"> SuperAdmin-RoleUser Username: superadmin@gmail.com. </p>  <p class="font-weight-bold"> Admin-RoleUser Username: admin@gmail.com. </p>  <p class="font-weight-bold"> Basic-RoleUser (Staff) Username: basic@gmail.com. </p>  The Password for all these 3 users is: <p class="font-weight-bold font-italic "> P@ssword123 </p> </li>
        <li><i class="fa fa-check-circle text-success"></i> Use the form on the left to log in using the provided credentials above.</li>
        <li><i class="fa fa-check-circle text-success"></i> After logging in, you will have access to the CRUD interface for managing data based on roles.</li>
    </ul>
</div>

**[Download the Database File or Script](./MVC_CRUD_Interface_DB.sql)**
