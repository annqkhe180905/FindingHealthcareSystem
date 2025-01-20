USE [master]
GO

CREATE DATABASE [FindingHealthcareSystem]
GO

USE [FindingHealthcareSystem]
GO

CREATE TABLE [User] (
  [UserID] UNIQUEIDENTIFIER,
  [Role] NVARCHAR(255),
  [Password] NVARCHAR(MAX),
  [PhoneNumber] NVARCHAR(50),
  [Fullname] NVARCHAR(255),
  [Email] NVARCHAR(255),
  [Gender] NVARCHAR(50),
  [Birthday] DATE,
  PRIMARY KEY ([UserID])
);

CREATE TABLE [Patient] (
  [PatientID] UNIQUEIDENTIFIER,
  [UserID] UNIQUEIDENTIFIER,
  [Note] NVARCHAR(MAX),
  PRIMARY KEY ([PatientID]),
  CONSTRAINT [FK_Patient_UserID]
	FOREIGN KEY ([UserID]) 
		REFERENCES [User]([UserID])
			ON DELETE CASCADE
);

CREATE TABLE [UnderlyingDisease] (
  [ID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([ID])
);

CREATE TABLE [PatientUnderlyingDisease] (
  [ID] UNIQUEIDENTIFIER,
  [UnderlyingDiseaseID] UNIQUEIDENTIFIER,
  [PatientID] UNIQUEIDENTIFIER,
  PRIMARY KEY ([ID]),
  CONSTRAINT [FK_PatientUnderlyingDisease_UnderlyingDiseaseID]
    FOREIGN KEY ([UnderlyingDiseaseID])
      REFERENCES [UnderlyingDisease]([ID])
		ON DELETE CASCADE,
  CONSTRAINT [FK_PatientUnderlyingDisease_PatientID]
    FOREIGN KEY ([PatientID])
      REFERENCES [Patient]([PatientID])
		ON DELETE CASCADE
);

CREATE TABLE [Expertise] (
  [ExpertiseID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([ExpertiseID])
);

CREATE TABLE [Professional] (
  [ProfessionalID] UNIQUEIDENTIFIER,
  [UserID] UNIQUEIDENTIFIER UNIQUE,
  [ExpertiseID] UNIQUEIDENTIFIER,
  [Province] NVARCHAR(255),
  [District] NVARCHAR(255),
  [Commune] NVARCHAR(255),
  [Address] NVARCHAR(MAX),
  [Degree] NVARCHAR(255),
  [Experience] NVARCHAR(255),
  [WorkingHours] NVARCHAR(255),
  PRIMARY KEY ([ProfessionalID]),
  CONSTRAINT [FK_Professional_UserID]
	FOREIGN KEY ([UserID]) 
		REFERENCES [User]([UserID])
			ON DELETE CASCADE,
  CONSTRAINT [FK_Professional_ExpertiseID]
	FOREIGN KEY ([ExpertiseID]) 
		REFERENCES [Expertise]([ExpertiseID])
);

CREATE TABLE [Specialty] (
  [SpecialtyID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([SpecialtyID])
);


CREATE TABLE [ProfessionalSpecialty] (
  [ID] UNIQUEIDENTIFIER,
  [ProfessionalID] UNIQUEIDENTIFIER,
  [SpecialtyID] UNIQUEIDENTIFIER,
  PRIMARY KEY ([ID]),
  CONSTRAINT [FK_ProfessionalSpecialty_SpecialtyID]
    FOREIGN KEY ([SpecialtyID])
      REFERENCES [Specialty]([SpecialtyID])
		ON DELETE CASCADE,
  CONSTRAINT [FK_ProfessionalSpecialty_ProfessionalID]
    FOREIGN KEY ([ProfessionalID])
      REFERENCES [Professional]([ProfessionalID])
		ON DELETE CASCADE,
);

CREATE TABLE [Service] (
  [ServiceID] UNIQUEIDENTIFIER,
  [Price] DECIMAL(19, 0),
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX)
  PRIMARY KEY ([ServiceID])
);


CREATE TABLE [PrivateService] (
  [ServiceID] UNIQUEIDENTIFIER,
  [ProfessionalID] UNIQUEIDENTIFIER,
  PRIMARY KEY ([ServiceID]),
  CONSTRAINT [FK_PrivateService_ServiceID] 
	FOREIGN KEY ([ServiceID])
		REFERENCES [Service]([ServiceID]),
  CONSTRAINT [FK_PrivateService_ProfessionalID]
    FOREIGN KEY ([ProfessionalID])
      REFERENCES [Professional]([ProfessionalID])
		ON DELETE CASCADE
);


CREATE TABLE [FacilityType] (
  [TypeID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([TypeID])
);

CREATE TABLE [Facility] (
  [FacilityID] UNIQUEIDENTIFIER,
  [TypeID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [OperationDay] DATE,
  [Province] NVARCHAR(255),
  [District] NVARCHAR(255),
  [Commune] NVARCHAR(255),
  [Address] NVARCHAR(MAX),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([FacilityID]),
  CONSTRAINT [FK_Facility_TypeID]
    FOREIGN KEY ([TypeID])
      REFERENCES [FacilityType]([TypeID])
);

CREATE TABLE [Department] (
  [DepartmentID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([DepartmentID])
);

CREATE TABLE [FacilityDepartment] (
  [ID] UNIQUEIDENTIFIER,
  [FacilityID] UNIQUEIDENTIFIER,
  [DepartmentID] UNIQUEIDENTIFIER,
  PRIMARY KEY ([ID]),
  CONSTRAINT [FK_FacilityDepartment_FacilityID]
    FOREIGN KEY ([FacilityID])
      REFERENCES [Facility]([FacilityID])
		ON DELETE CASCADE,
  CONSTRAINT [FK_FacilityDepartment_DepartmentID]
    FOREIGN KEY ([DepartmentID])
      REFERENCES [Department]([DepartmentID])
		ON DELETE CASCADE
);

CREATE TABLE [PublicService] (
  [ServiceID] UNIQUEIDENTIFIER,
  [FacilityID] UNIQUEIDENTIFIER,
  PRIMARY KEY ([ServiceID]),
  CONSTRAINT [FK_PublicService_FacilityID]
    FOREIGN KEY ([FacilityID])
      REFERENCES [Facility]([FacilityID]),
  CONSTRAINT [FK_PublicService_ServiceID] 
	FOREIGN KEY ([ServiceID])
		REFERENCES [Service]([ServiceID]),
);


CREATE TABLE [Payment] (
  [PaymentID] UNIQUEIDENTIFIER,
  [PaymentMethod] NVARCHAR(255),
  [TransactionID] NVARCHAR(255),
  [PaymentStatus] NVARCHAR(255),
  [Price] DECIMAL(19, 0),
  [PaymentDate] DATETIME,
  PRIMARY KEY ([PaymentID])
);

CREATE TABLE [Appointment] (
  [AppointmentID] UNIQUEIDENTIFIER,
  [PatientID] UNIQUEIDENTIFIER,
  [ProfessionalID] UNIQUEIDENTIFIER,
  [ServiceID] UNIQUEIDENTIFIER,
  [Status] NVARCHAR(255),
  [PaymentID] UNIQUEIDENTIFIER,
  [Description] NVARCHAR(MAX),
  [Date] DATETIME,
  PRIMARY KEY ([AppointmentID]),
  CONSTRAINT [FK_Appointment_PatientID]
    FOREIGN KEY ([PatientID])
      REFERENCES [Patient]([PatientID]),
  CONSTRAINT [FK_Appointment_ProfessionalID]
    FOREIGN KEY ([ProfessionalID])
      REFERENCES [Professional]([ProfessionalID]),
  CONSTRAINT [FK_Appointment_ServiceID]
    FOREIGN KEY ([ServiceID])
      REFERENCES [Service]([ServiceID]),
  CONSTRAINT [FK_Appointment_PaymentID]
    FOREIGN KEY ([PaymentID])
      REFERENCES [Payment]([PaymentID])
);

CREATE TABLE [MedicalRecord] (
  [MedicalRecordID] UNIQUEIDENTIFIER,
  [AppointmentID] UNIQUEIDENTIFIER,
  [DateCreated] DATETIME,
  [Symptoms] NVARCHAR(MAX),
  [Diagnosis] NVARCHAR(MAX),
  [Prescription] NVARCHAR(MAX),
  [Note] NVARCHAR(MAX),
  PRIMARY KEY ([MedicalRecordID]),
  CONSTRAINT [FK_MedicalRecord_AppointmentID]
    FOREIGN KEY ([AppointmentID])
      REFERENCES [Appointment]([AppointmentID])
);

CREATE TABLE [Attachments] (
  [ID] UNIQUEIDENTIFIER,
  [MedicalRecordID] UNIQUEIDENTIFIER,
  [Url] NVARCHAR(MAX),
  PRIMARY KEY ([ID]),
  CONSTRAINT [FK_Attachments_MedicalRecordID]
    FOREIGN KEY ([MedicalRecordID])
      REFERENCES [MedicalRecord]([MedicalRecordID])
);


CREATE TABLE [Review] (
  [ReviewID] UNIQUEIDENTIFIER,
  [ProfessionalID] UNIQUEIDENTIFIER,
  [PatientID] UNIQUEIDENTIFIER,
  [Rating] INT,
  [Comment] NVARCHAR(MAX),
  [Date] DATETIME,
  PRIMARY KEY ([ReviewID]),
  CONSTRAINT [FK_Review_ProfessionalID]
    FOREIGN KEY ([ProfessionalID])
      REFERENCES [Professional]([ProfessionalID]),
  CONSTRAINT [FK_Review_PatientID]
    FOREIGN KEY ([PatientID])
      REFERENCES [Patient]([PatientID])
);

CREATE TABLE [Category] (
  [CategoryID] UNIQUEIDENTIFIER,
  [Name] NVARCHAR(255),
  [Description] NVARCHAR(MAX),
  PRIMARY KEY ([CategoryID])
);

CREATE TABLE [Article] (
  [ArticleID] UNIQUEIDENTIFIER,
  [CategoryID] UNIQUEIDENTIFIER,
  [Title] NVARCHAR(255),
  [CreatedAt] DATETIME,
  [CreatedBy] NVARCHAR(255),
  [Content] NVARCHAR(MAX),
  PRIMARY KEY ([ArticleID]),
  CONSTRAINT [FK_Article_CategoryID]
    FOREIGN KEY ([CategoryID])
      REFERENCES [Category]([CategoryID])
);

