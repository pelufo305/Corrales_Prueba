/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4259)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [Corrales]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[edad] [int] NULL,
	[typecode] [int] NULL,
	[corralcode] [int] NULL,
	[isdangerous] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corral]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corral](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[limit] [int] NULL,
	[typecode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[type_animal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[type_animal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Animal] ON 

INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (1, N'cerdo', 2, 1, 1, 0)
INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (2, N'string', 8, 1, 1, 1)
INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (3, N'string', 8, 1, 1, 1)
INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (4, N'string', 0, 1, 1, 1)
INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (5, N'string', 78, 1, 1, 1)
INSERT [dbo].[Animal] ([id], [name], [edad], [typecode], [corralcode], [isdangerous]) VALUES (6, N'string', 78, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Animal] OFF
SET IDENTITY_INSERT [dbo].[Corral] ON 

INSERT [dbo].[Corral] ([id], [name], [limit], [typecode]) VALUES (1, N'prueba', 5, 1)
INSERT [dbo].[Corral] ([id], [name], [limit], [typecode]) VALUES (2, N'prueba', 10, 1)
INSERT [dbo].[Corral] ([id], [name], [limit], [typecode]) VALUES (3, N'string', 12, 1)
INSERT [dbo].[Corral] ([id], [name], [limit], [typecode]) VALUES (4, N'string', 0, 1)
SET IDENTITY_INSERT [dbo].[Corral] OFF
SET IDENTITY_INSERT [dbo].[type_animal] ON 

INSERT [dbo].[type_animal] ([id], [name]) VALUES (1, N'Omnivoro')
INSERT [dbo].[type_animal] ([id], [name]) VALUES (2, N'Carnivoro')
INSERT [dbo].[type_animal] ([id], [name]) VALUES (3, N'Herbivoro')
SET IDENTITY_INSERT [dbo].[type_animal] OFF
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD FOREIGN KEY([corralcode])
REFERENCES [dbo].[Corral] ([id])
GO
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD FOREIGN KEY([typecode])
REFERENCES [dbo].[type_animal] ([id])
GO
ALTER TABLE [dbo].[Corral]  WITH CHECK ADD FOREIGN KEY([typecode])
REFERENCES [dbo].[type_animal] ([id])
GO
/****** Object:  StoredProcedure [dbo].[Createanimal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Createanimal]
@id int ,
@name varchar(50),
@edad int ,
@typecode int,
@corralcode int,
@isdangerous bit
AS
BEGIN
   IF @id > 0
    UPDATE Animal SET  name= @name , edad= @edad, typecode= @typecode, corralcode = @corralcode,@isdangerous=@isdangerous WHERE id = @id
   ELSE
    INSERT INTO Animal VALUES (@name,@edad,@typecode,@corralcode,@isdangerous)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateCorral]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[CreateCorral]
@id int ,
@name varchar(50),
@limit int ,
@typecode int
AS
BEGIN
   IF @id > 0
    UPDATE Corral SET  name= @name , limit= @limit, typecode= @typecode WHERE id = @id
   ELSE
    INSERT INTO Corral VALUES (@name,@limit,@typecode)
END

GO
/****** Object:  StoredProcedure [dbo].[ProcessAnimal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProcessAnimal]
@id int ,
@name varchar(50),
@edad int ,
@typecode int,
@corralcode int,
@isdangerous bit
AS
BEGIN
   IF @id > 0
    UPDATE Animal SET  name= @name , edad= @edad, typecode= @typecode, corralcode = @corralcode, isdangerous=@isdangerous WHERE id = @id
   ELSE
    INSERT INTO Animal VALUES (@name,@edad,@typecode,@corralcode,@isdangerous)
END

GO
/****** Object:  StoredProcedure [dbo].[PromEdadAnimal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PromEdadAnimal]
@corralcode int
AS
BEGIN
SELECT AVG(edad) from Animal where corralcode = @corralcode
END

GO
/****** Object:  StoredProcedure [dbo].[ReportAnimal]    Script Date: 2/05/2021 8:23:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReportAnimal]
AS
BEGIN
SELECT * from Animal 
END
GO
