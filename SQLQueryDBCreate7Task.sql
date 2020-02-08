CREATE DATABASE [SesRes];
GO

USE [SesRes];
GO

CREATE TABLE [dbo].[Subjects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [char](40) NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](40) NOT NULL,
	[specialty] [nchar](40) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Examners](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nchar](20) NOT NULL,
	[lastName] [nchar](20) NOT NULL,
	[patronymic] [nchar](20) NULL,
 CONSTRAINT [PK_Examiners] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Sessions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[year] [date] NOT NULL,
	[number] [int] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nchar](20) NOT NULL,
	[lastName] [nchar](20) NOT NULL,
	[patronymic] [nchar](20) NULL,
	[gender] [nchar](10) NOT NULL,
	[birthDate] [date] NOT NULL,
	[groupId] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Groups] FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([id])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Groups]
GO


CREATE TABLE [dbo].[Exams](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[subjectId] [int] NOT NULL,
	[sessionId] [int] NOT NULL,
	[examinerId] [int] NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Examners] FOREIGN KEY([examinerId])
REFERENCES [dbo].[Examners] ([id])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Examners]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Sessions] FOREIGN KEY([sessionId])
REFERENCES [dbo].[Sessions] ([id])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Sessions]
GO

ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Subjects] FOREIGN KEY([subjectId])
REFERENCES [dbo].[Subjects] ([id])
GO

ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Subjects]
GO


CREATE TABLE [dbo].[Results](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NOT NULL,
	[mark] [int] NOT NULL,
	[examId] [int] NOT NULL,
 CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Exams] FOREIGN KEY([examId])
REFERENCES [dbo].[Exams] ([id])
GO

ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Exams]
GO


ALTER TABLE [dbo].[Results]  WITH CHECK ADD  CONSTRAINT [FK_Results_Students] FOREIGN KEY([studentId])
REFERENCES [dbo].[Students] ([id])
GO

ALTER TABLE [dbo].[Results] CHECK CONSTRAINT [FK_Results_Students]
GO

