create table Countries
(
ID int constraint country_pki primary key identity(1,1),
Name nvarchar(50) not null constraint country_uqn unique
)

create table ApplicationTypes
(
ID int constraint applicationtype_pki primary key identity(1,1),
Name nvarchar(150) not null constraint applicationtype_uqn unique,
Fees smallmoney not null
)

create table People
(
ID int constraint person_pki primary key identity(1,1),
Gender tinyint not null,
FirstName nvarchar(20) not null,
SecondName nvarchar(20) not null,
ThirdName nvarchar(20) null,
LastName nvarchar(20) not null,
DateOfBirth date not null,
CountryID int not null constraint person_fkci foreign key references Countries(ID),
NationalNumber varchar(20) not null constraint person_uqnn unique,
Address varchar(500) not null,
Phone varchar(20) not null,
Email varchar(50),
ImagePath varchar(250)
)

create table Users
(
ID int constraint user_pki primary key identity(1,1),
PersonID int not null constraint user_uqpi unique constraint user_fkpi foreign key references People(ID),
Username nvarchar(20) not null constraint user_uqu unique,
Password nvarchar(20) not null,
IsActive bit not null
)

create table Drivers
(
ID int constraint driver_pki primary key identity(1,1),
PersonID int not null constraint driver_uqpi unique constraint driver_fkpi foreign key references People(ID),
Date datetime not null,
UserID int not null constraint driver_fkui foreign key references Users(ID)
)

create table Applications
(
ID int constraint application_pki primary key identity(1,1),
PersonID int not null constraint application_fkpi foreign key references People(ID),
ApplicationTypeID int not null constraint application_fkati foreign key references ApplicationTypes(ID),
Date datetime not null,
PaidFees smallmoney not null,
Status tinyint not null,
LastStatusDate datetime not null,
UserID int not null constraint application_fkui foreign key references Users(ID)
)

create table LicenseClasses
(
ID int constraint licenseclass_pki primary key identity(1,1),
Name nvarchar(50) not null constraint licenseclass_uqn unique,
Description nvarchar(500) not null,
MinimumAllowedAge tinyint not null,
ValidityLength tinyint not null,
Fees smallmoney not null
)

create table LocalLicenseApplications
(
ID int constraint locallicenseapplication_pki primary key identity(1,1),
ApplicationID int not null constraint locallicenseapplication_uqai unique constraint locallicenseapplication_fkai foreign key references Applications(ID),
LicenseClassID int not null  constraint locallicenseapplication_fklci foreign key references LicenseClasses(ID)
)

create table TestTypes
(
ID int constraint testtype_pki primary key identity(1,1),
Name nvarchar(100) not null constraint testtype_uqn unique,
Description nvarchar(500) not null,
Fees smallmoney not null
)

create table Appointments
(
ID int constraint appointment_pki primary key identity(1,1),
LocalLicenseApplicationID int constraint appointment_fkllai foreign key references LocalLicenseApplications(ID),
TestTypeID int constraint appointment_fktti foreign key references TestTypes(ID),
Date datetime not null,
PaidFees smallmoney not null,
IsLocked bit not null,
UserID int not null constraint appointment_fkui foreign key references Users(ID),
RetakeTestApplicationID int constraint appointment_uqrtai unique constraint appointment_fkrtai foreign key references Applications(ID)
)

create table Tests
(
ID int constraint test_pki primary key identity(1,1),
AppointmentID int constraint test_uqai unique constraint test_fkai foreign key references Appointments(ID),
Result bit not null,
Notes nvarchar(500),
UserID int not null constraint test_fkui foreign key references Users(ID)
)

create table Licenses
(
ID int constraint license_pki primary key identity(1,1),
DriverID int not null constraint license_fkdi foreign key references Drivers(ID),
LicenseClassID int not null constraint license_fklci foreign key references LicenseClasses(ID),
IssueDate datetime not null ,
ExpirationDate datetime not null,
IssueReason tinyint not null,
PaidFees smallmoney not null,
IsActive bit not null,
Notes nvarchar(500),
ApplicationID int not null constraint license_fkai foreign key references Applications(ID),
UserID int not null constraint license_fkui foreign key references Users(ID),
constraint license_uqdilci unique(DriverID,LicenseClassID)
)

create table DetainedLicenses
(
ID int constraint detainedlicense_pki primary key identity(1,1),
LicenseID int not null constraint detainedlicensee_fkli foreign key references Licenses(ID),
DetainDate datetime not null,
FineFees smallmoney not null,
ReleaseDate datetime null,
ReleasedApplicationID int null constraint detainedlicense_fkrai foreign key references Applications(ID),
CreatedByUserID int not null constraint detainedlicense_fkcbui foreign key references Users(ID),
ReleasedByUserID int constraint detainedlicense_fkrbui foreign key references Users(ID)
)

create table InternationalLicenses
(
ID int constraint internationallicense_pki primary key identity(1,1),
DriverID int not null constraint internationallicense_fkdi foreign key references Drivers(ID),
IssuedUsingLocalLicenseID int not null constraint internationallicense_fkiulli foreign key references Licenses(ID),
IssueDate datetime not null,
ExpirationDate datetime not null,
IsActive bit not null,
ApplicationID int not null constraint internationallicense_fkai foreign key references Applications(ID),
UserID int not null constraint internationallicense_fkui foreign key references Users(ID)
)