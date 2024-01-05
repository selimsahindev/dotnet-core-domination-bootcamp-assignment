# .Net Core Domination Bootcamp - Project Assignment
The web API project I prepared for the .NET Core Domination Bootcamp organized by Techcareer.net.

### How to Use
1. Clone the repository.
2. Set up your database and connection string in the appsettings.json file.
3. Run the migrations (dotnet ef database update) to create the database.
4. Build and run the project.

<br />

## Features and Best Practices

| Feature                          | Description                                                  |
| -------------------------------- | ------------------------------------------------------------ |
| Dependency Injection             | Services are registered in the Dependency Injection container for easy management. |
| Data Transfer Objects (DTOs)     | Separate DTOs are used to transfer data between layers.      |
| AutoMapper                       | AutoMapper is used to simplify mapping between entities and DTOs. |
| Api Versioning                   | Api Versioning is implemented using the Asp.Versioning.WebApi package. |
| Business Logic in ReservationService | Business logic is separated from the controller and placed in the ReservationService. |

<br />

## Data Models
### Reservation

| Property       | Type                    | Attributes                  | Description                                            |
| -------------- | ----------------------- | --------------------------- | ------------------------------------------------------ |
| Id             | `int`                     | [Key]                       | Unique identifier for the reservation.                  |
| ClientId       | `int`                     | [Required]                  | Identifier of the associated client.                   |
| CompanyId      | `int?`                    |                             | Nullable identifier of the associated company.         |
| RoomId         | `int`                     | [Required]                  | Identifier of the associated room.                     |
| ReservationDate| `DateTime`                | [Required, Default: DateTime.Now] | Date when the reservation was made.                |
| CheckInDate    | `DateTime`                | [Required]                  | Date when the reservation check-in is scheduled.       |
| CheckOutDate   | `DateTime`                | [Required]                  | Date when the reservation check-out is scheduled.      |
| Status         | `ReservationStatus`       | [Required, Default: Pending]| Current status of the reservation (e.g., Pending, Confirmed, Canceled). |
| AddDate        | `DateTime`                | [Default: DateTime.Now]     | Date when the record is added.                          |

### Company

| Property | Type   | Attributes                         | Description                        |
| -------- | ------ | ---------------------------------- | ---------------------------------- |
| Id       | `int`    | [Key]                              | Unique identifier for the company. |
| Name     | `string` | [Required, StringLength(120)]       | Name of the company.               |
| Address  | `string` | [Required, StringLength(400)]       | Address of the company.            |
| AddDate  | `DateTime`  | [Default: DateTime.Now]     | Date when the record is added.      |

### Client

| Property  | Type      | Attributes                        | Description                                    |
| --------- | --------- | --------------------------------- | ---------------------------------------------- |
| Id        | `int`       | [Key]                             | Unique identifier for the client.               |
| Name      | `string`    | [Required, MaxLength(50)]          | First name of the client.                      |
| Surname   | `string`    | [Required, MaxLength(50)]          | Last name of the client.                       |
| BirthDate | `DateTime`  | [Required]                        | Birth date of the client.                      |
| Address   | `string`    | [MaxLength(100)]                   | Address of the client.                         |
| EMail     | `string`    | [Required, EmailAddress]           | Email address of the client.                   |
| CompanyId | `int`       | [Required]                        | Identifier of the associated company.         |
| AddDate   | `DateTime`  | [Default: DateTime.Now]     | Date when the record is added.          |

### Room

| Property   | Type      | Attributes                        | Description                                    |
| ---------- | --------- | --------------------------------- | ---------------------------------------------- |
| Id         | `int`       | [Key]                             | Unique identifier for the room.                |
| Name       | `string`    | [Required, MaxLength(80)]          | Name of the room.                             |
| Type       | `RoomType`  |                                   | Type of the room (e.g., Standard, Premium).   |
| Description| `string?`   | [MaxLength(200)]                   | Description of the room (nullable).           |
| AddDate   | `DateTime`  | [Default: DateTime.Now]     | Date when the record is added.          |

