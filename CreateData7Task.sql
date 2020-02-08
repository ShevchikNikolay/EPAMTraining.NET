USE [SesRes]
GO

INSERT INTO [Subjects] ([name]) VALUES ('Maths');
INSERT INTO [Subjects] ([name]) VALUES ('VisualProgramming');
INSERT INTO [Subjects] ([name]) VALUES ('OOP');
INSERT INTO [Subjects] ([name]) VALUES ('DBEngeneering');
INSERT INTO [Subjects] ([name]) VALUES ('3DModeling');
INSERT INTO [Subjects] ([name]) VALUES ('Cryptology');

GO


INSERT INTO [Groups]  ([name],[specialty]) VALUES ('IT-31','specialty1');
INSERT INTO [Groups]  ([name],[specialty]) VALUES ('IT-32','specialty2');
INSERT INTO [Groups]  ([name],[specialty]) VALUES ('IT-33','specialty3');
INSERT INTO [Groups]  ([name],[specialty]) VALUES ('IT-34','specialty4');

GO

INSERT INTO [Examners] ([firstName],[lastName],[patronymic]) VALUES ('FName1', 'LName1','PName1');
INSERT INTO [Examners] ([firstName],[lastName],[patronymic]) VALUES ('FName2', 'LName2','PName2');


DECLARE @Iteration INT, @FirstNamePrefix NVARCHAR(40), @LastNamePrefix NVARCHAR(40), @PatronymicPrefix NVARCHAR(40), @Gender NVARCHAR(20), @Date NVARCHAR(12), @GroupId INT;
DECLARE @MinDate DATE, @MaxDate DATE;

SET @FirstNamePrefix = 'FirstName';
SET @LastNamePrefix = 'LastName'
SET @PatronymicPrefix = 'Patronymic';
SET @Iteration = 1;
SET @GroupId = 1;
SET @MinDate = '1980-01-01';
SET @MaxDate = '1995-12-31';

WHILE @Iteration < 81
	BEGIN
		SET @Date = DATEADD(DAY, 
               RAND(CHECKSUM(NEWID()))*(1+DATEDIFF(DAY, @MinDate, @MaxDate)), 
               @MinDate);
		
			IF (ROUND((RAND() * 10), 0) < 5)
				SET @Gender = 'Male';
			ELSE
				SET @Gender = 'Female';

		INSERT INTO [Students] ([firstName], [lastName], [patronymic], [gender], [birthDate], [groupId]) 
				VALUES (@FirstNamePrefix + CONVERT(NVARCHAR, @Iteration),
						@LastNamePrefix  + CONVERT(NVARCHAR, @Iteration),
						@PatronymicPrefix + CONVERT(NVARCHAR, @Iteration),
						@Gender, 
						@Date,
						@GroupId);				

		SET @Iteration = @Iteration + 1;
		IF @Iteration > 0 AND @Iteration <= 20 SET @GroupId = 1;
		IF @Iteration > 20 AND @Iteration <= 40 SET @GroupId = 2;
		IF @Iteration > 40 AND @Iteration <= 60 SET @GroupId = 3;
		IF @Iteration > 60 AND @Iteration <= 80 SET @GroupId = 4;

	END;

GO



DECLARE  @Iteration INT, @Number INT, @Year DATE;

SET @Iteration = 1;
SET @Year = '1999-01-01'
WHILE @Iteration < 11
	BEGIN
		SET @Year = DATEADD(YEAR, 1, @Year);
		
		IF ((@Iteration + 2) % 2 = 0) SET @Number =2;
		ELSE SET @Number = 1;

		INSERT INTO [Sessions] ([number], [year]) VALUES (@Number, @Year);

		SET @Iteration = @Iteration + 1;
	END
GO

DECLARE @Iteration INT, @Date DATE, @SubjectId INT, @SessionId INT;
DECLARE @SecIteration INT, @ExaminerId INT;

SET @Iteration = 1;
SET @ExaminerId = 0;

WHILE @Iteration < 11
	BEGIN
		SET @SessionId = @Iteration;
		SET @SecIteration = 1;

		WHILE @SecIteration < 7
			BEGIN
				SET @SubjectId = @SecIteration;
				IF ((@SessionId+2)%2 = 0) 
					SET @Date = DATEADD(DAY, (200 + ROUND((RAND() * 10), 0)) ,(SELECT [year] FROM [Sessions] where id = @Iteration));
				ELSE
					SET @Date = DATEADD(DAY, ( ROUND((RAND() * 10), 0)) ,(SELECT [year] FROM [Sessions] where id = @Iteration));

				IF ((@SessionId+2)%2 = 0)
					SET @ExaminerId = 1;
				ELSE
					SET @ExaminerId =2;

				INSERT INTO [Exams] ([date],[sessionId],[subjectId]) VALUES (@Date, @SessionId, @SubjectId);

				SET @SecIteration = @SecIteration + 1;
			END

		SET @Iteration = @Iteration + 1;
	END
GO

DECLARE @StudentId INT, @ExamId INT, @Mark INT;

SET @StudentId = 1;
WHILE @StudentId < 81
	BEGIN
		SET @ExamId = 1;
		WHILE @ExamId < 61
			BEGIN
				SET @Mark = ROUND((RAND() * 10), 0);

				INSERT INTO [Results] ([examId], [studentId], [mark]) VALUES (@ExamId, @StudentId, @Mark);

				SET @ExamId = @ExamId + 1;
			END

			SET @StudentId = @StudentId + 1;
	END
GO