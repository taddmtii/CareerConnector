
-- Table: Applications
CREATE TABLE Applications (
    ApplicationID int  NOT NULL IDENTITY,
    UserID NVARCHAR(450)  NOT NULL,
    Company VARCHAR(100)  NOT NULL,
    FirstName VARCHAR(20)  NOT NULL,
    LastName VARCHAR(20)  NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    Skills VARCHAR(255)  NOT NULL,
    Resume varbinary(MAX)  NOT NULL,
    CONSTRAINT Applications_pk PRIMARY KEY  (ApplicationID)
);

-- Table: Employers
CREATE TABLE Employers (
    EmployerID int  NOT NULL IDENTITY,
    FIrstName VARCHAR(50)  NOT NULL,
    LastName VARCHAR(50)  NOT NULL,
    Company VARCHAR(100)  NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    CONSTRAINT Employers_pk PRIMARY KEY  (EmployerID)
);

-- Table: JobApplications
CREATE TABLE JobApplications (
    JobID int  NOT NULL,
    ApplicationID int  NOT NULL,
    CONSTRAINT JobApplications_pk PRIMARY KEY  (JobID,ApplicationID)
);

-- Table: Jobs
CREATE TABLE Jobs (
    JobID int  NOT NULL IDENTITY,
    EmployerID int  NOT NULL,
    Title VARCHAR(200)  NOT NULL,
    Description VARCHAR(500)  NOT NULL,
    CIty VARCHAR(25)  NOT NULL,
    State VARCHAR(15)  NOT NULL,
    PostalCode VARCHAR(11)  NOT NULL,
    Pay VARCHAR(20)  NOT NULL,
    JobType VARCHAR(50)  NOT NULL,
    CONSTRAINT Jobs_pk PRIMARY KEY  (JobID)
);

-- Table: UserJobs
CREATE TABLE UserJobs (
    UserID NVARCHAR(450)  NOT NULL,
    JobID int  NOT NULL,
    CONSTRAINT UserJobs_pk PRIMARY KEY  (UserID,JobID)
);

-- Table: Users
CREATE TABLE Users (
    UserID NVARCHAR(450)  NOT NULL IDENTITY,
    FirstName VARCHAR(20)  NOT NULL,
    LastName VARCHAR(20)  NOT NULL,
    Education VARCHAR(30)  NOT NULL,
    City VARCHAR(25)  NOT NULL,
    State VARCHAR(15)  NOT NULL,
    PostalCode VARCHAR(11)  NOT NULL,
    Email VARCHAR(255)  NOT NULL,
    CONSTRAINT Users_pk PRIMARY KEY  (UserID)
);

-- foreign keys
ALTER TABLE Applications ADD CONSTRAINT Applications_Users
    FOREIGN KEY (UserID)
    REFERENCES Users (UserID);

-- Reference: Favorites_Jobs (table: UserJobs)
ALTER TABLE UserJobs ADD CONSTRAINT Favorites_Jobs
    FOREIGN KEY (JobID)
    REFERENCES Jobs (JobID);

-- Reference: Favorites_Users (table: UserJobs)
ALTER TABLE UserJobs ADD CONSTRAINT Favorites_Users
    FOREIGN KEY (UserID)
    REFERENCES Users (UserID);

-- Reference: Job_Employer (table: Jobs)
ALTER TABLE Jobs ADD CONSTRAINT Job_Employer
    FOREIGN KEY (EmployerID)
    REFERENCES Employers (EmployerID);

ALTER TABLE JobApplications ADD CONSTRAINT Table_12_Applications
    FOREIGN KEY (ApplicationID)
    REFERENCES Applications (ApplicationID);

ALTER TABLE JobApplications ADD CONSTRAINT Table_12_Jobs
    FOREIGN KEY (JobID)
    REFERENCES Jobs (JobID);


