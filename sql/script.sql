USE [Roadmap]
GO
ALTER TABLE [dbo].[rdm_mails] DROP CONSTRAINT [FK_rdm_mails_rdm_mailSystems]
GO
ALTER TABLE [dbo].[rdm_mails] DROP CONSTRAINT [FK_rdm_mails_rdm_mailStatuses]
GO
ALTER TABLE [dbo].[rdm_documents] DROP CONSTRAINT [FK_rdm_documents_rdm_documentTypes]
GO
ALTER TABLE [dbo].[rdm_documents] DROP CONSTRAINT [FK_rdm_documents_rdm_documentStatuses]
GO
ALTER TABLE [dbo].[rdm_documents] DROP CONSTRAINT [FK_rdm_documents_rdm_documents_parent]
GO
ALTER TABLE [dbo].[rdm_documents] DROP CONSTRAINT [FK_rdm_documents_rdm_contractors]
GO
ALTER TABLE [dbo].[rdm_bills] DROP CONSTRAINT [FK_rdm_bills_rdm_contractors]
GO
ALTER TABLE [dbo].[rdm_bills] DROP CONSTRAINT [FK_rdm_bills_rdm_billStatuses]
GO
/****** Object:  Table [dbo].[rdm_mailSystems]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_mailSystems]
GO
/****** Object:  Table [dbo].[rdm_mailStatuses]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_mailStatuses]
GO
/****** Object:  Table [dbo].[rdm_mails]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_mails]
GO
/****** Object:  Table [dbo].[rdm_documentTypes]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_documentTypes]
GO
/****** Object:  Table [dbo].[rdm_documentStatuses]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_documentStatuses]
GO
/****** Object:  Table [dbo].[rdm_documents]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_documents]
GO
/****** Object:  Table [dbo].[rdm_contractors]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_contractors]
GO
/****** Object:  Table [dbo].[rdm_billStatuses]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_billStatuses]
GO
/****** Object:  Table [dbo].[rdm_bills]    Script Date: 01.11.2016 19:00:17 ******/
DROP TABLE [dbo].[rdm_bills]
GO
USE [master]
GO
/****** Object:  Database [Roadmap]    Script Date: 01.11.2016 19:00:17 ******/
DROP DATABASE [Roadmap]
GO
/****** Object:  Database [Roadmap]    Script Date: 01.11.2016 19:00:17 ******/
CREATE DATABASE [Roadmap]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Roadmap', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Roadmap.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Roadmap_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Roadmap_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Roadmap] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Roadmap].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Roadmap] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Roadmap] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Roadmap] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Roadmap] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Roadmap] SET ARITHABORT OFF 
GO
ALTER DATABASE [Roadmap] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Roadmap] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Roadmap] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Roadmap] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Roadmap] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Roadmap] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Roadmap] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Roadmap] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Roadmap] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Roadmap] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Roadmap] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Roadmap] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Roadmap] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Roadmap] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Roadmap] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Roadmap] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Roadmap] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Roadmap] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Roadmap] SET  MULTI_USER 
GO
ALTER DATABASE [Roadmap] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Roadmap] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Roadmap] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Roadmap] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Roadmap] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Roadmap]
GO
/****** Object:  Table [dbo].[rdm_bills]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_bills](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[billNumber] [nvarchar](128) NULL,
	[contractorID] [int] NOT NULL,
	[description] [nvarchar](2000) NULL,
	[statusID] [int] NOT NULL,
	[sum] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_rdm_bills] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_billStatuses]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_billStatuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_billStatuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_contractors]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_contractors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](256) NULL,
	[lastName] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_contractors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_documents]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_documents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documentUrl] [nvarchar](2000) NOT NULL,
	[contractorID] [int] NULL,
	[date] [datetime] NOT NULL,
	[parentDocumentID] [int] NULL,
	[documentNumber] [nvarchar](128) NULL,
	[sum] [decimal](18, 0) NULL,
	[description] [nvarchar](2000) NULL,
	[statusID] [int] NOT NULL,
	[typeID] [int] NOT NULL,
 CONSTRAINT [PK_rdm_documents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_documentStatuses]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_documentStatuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_documentStatuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_documentTypes]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_documentTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_documentTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_mails]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_mails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dateSent] [datetime] NULL,
	[dateRecieved] [datetime] NULL,
	[sender] [nvarchar](512) NULL,
	[recipient] [nvarchar](512) NULL,
	[description] [nvarchar](2000) NULL,
	[mailSystemID] [int] NULL,
	[replyDateSent] [datetime] NULL,
	[replyDateRecieved] [datetime] NULL,
	[trackingNumber] [nvarchar](64) NULL,
	[replyTrackingNumber] [nvarchar](64) NULL,
	[statusID] [int] NOT NULL,
 CONSTRAINT [PK_rdm_mails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_mailStatuses]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_mailStatuses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_mailStatuses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rdm_mailSystems]    Script Date: 01.11.2016 19:00:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rdm_mailSystems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](128) NOT NULL,
	[name] [nvarchar](256) NULL,
 CONSTRAINT [PK_rdm_mailSystems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[rdm_bills] ON 

INSERT [dbo].[rdm_bills] ([id], [date], [billNumber], [contractorID], [description], [statusID], [sum]) VALUES (2, CAST(N'2005-08-09 00:00:00.000' AS DateTime), N'111-111', 1, N'bill#1 description', 1, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[rdm_bills] ([id], [date], [billNumber], [contractorID], [description], [statusID], [sum]) VALUES (3, CAST(N'2005-07-11 00:00:00.000' AS DateTime), N'222-222', 2, N'bill#2 description', 2, CAST(200.44 AS Decimal(18, 2)))
INSERT [dbo].[rdm_bills] ([id], [date], [billNumber], [contractorID], [description], [statusID], [sum]) VALUES (4, CAST(N'2010-04-23 00:00:00.000' AS DateTime), N'333-333', 3, N'bill#3 description', 1, CAST(333.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[rdm_bills] OFF
SET IDENTITY_INSERT [dbo].[rdm_billStatuses] ON 

INSERT [dbo].[rdm_billStatuses] ([id], [code], [name]) VALUES (1, N'created', N'создан')
INSERT [dbo].[rdm_billStatuses] ([id], [code], [name]) VALUES (2, N'invoice', N'выставлен')
SET IDENTITY_INSERT [dbo].[rdm_billStatuses] OFF
SET IDENTITY_INSERT [dbo].[rdm_contractors] ON 

INSERT [dbo].[rdm_contractors] ([id], [firstName], [lastName]) VALUES (1, N'Иван', N'Иванов')
INSERT [dbo].[rdm_contractors] ([id], [firstName], [lastName]) VALUES (2, N'Юзер', N'Юзерович')
INSERT [dbo].[rdm_contractors] ([id], [firstName], [lastName]) VALUES (3, N'Контрагент', N'Петрович')
SET IDENTITY_INSERT [dbo].[rdm_contractors] OFF
SET IDENTITY_INSERT [dbo].[rdm_documents] ON 

INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (1, N'https://docs.google.com/document/d/1INw85ZDZWUSxjWTIMGeNi1Dr8UH2o2ze1_SE1DCjiLs/edit', 1, CAST(N'2005-08-10 00:00:00.000' AS DateTime), NULL, N'11-11-11', CAST(200 AS Decimal(18, 0)), N'document#1 description', 1, 1)
INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (2, N'https://docs.google.com/document/d/1cd8FCEOKxkVvCdPV4oDxeYa57qN2AFKOhyyYmFCyJ8k/edit', 2, CAST(N'2005-08-11 00:00:00.000' AS DateTime), 1, N'22-22-22', CAST(100 AS Decimal(18, 0)), N'act#1 description', 2, 2)
INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (3, N'https://docs.google.com/document/d/1zKKgIbKaYnSSSmhNs8DGOxhO9ebCddJIf6mYjL8yuo8/edit', 3, CAST(N'2005-08-12 00:00:00.000' AS DateTime), 1, N'33-3-33', CAST(50 AS Decimal(18, 0)), N'agreement#1 description', 3, 3)
INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (4, N'https://docs.google.com/document/d/1zKKgIbKaYnSSSmhNs8DGOxhO9ebCddJIf6mYjL8yuo8/edit', 1, CAST(N'2005-08-13 00:00:00.000' AS DateTime), NULL, N'44-44-44', CAST(1000 AS Decimal(18, 0)), N'document#2 description', 4, 1)
INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (5, N'https://docs.google.com/document/d/1W5THx578Obp5rh8kmPPzFYxcudYert7cC7J4WRhC0hA/edit', 2, CAST(N'2005-08-14 00:00:00.000' AS DateTime), 4, N'55-55-55', CAST(501 AS Decimal(18, 0)), N'act#2 description', 1, 2)
INSERT [dbo].[rdm_documents] ([id], [documentUrl], [contractorID], [date], [parentDocumentID], [documentNumber], [sum], [description], [statusID], [typeID]) VALUES (6, N'https://docs.google.com/document/d/1W5THx578Obp5rh8kmPPzFYxcudYert7cC7J4WRhC0hA/edit', 3, CAST(N'2005-08-15 00:00:00.000' AS DateTime), 4, N'66-66-66', CAST(301 AS Decimal(18, 0)), N'agreement#2 description', 2, 3)
SET IDENTITY_INSERT [dbo].[rdm_documents] OFF
SET IDENTITY_INSERT [dbo].[rdm_documentStatuses] ON 

INSERT [dbo].[rdm_documentStatuses] ([id], [code], [name]) VALUES (1, N'created', N'создан')
INSERT [dbo].[rdm_documentStatuses] ([id], [code], [name]) VALUES (2, N'approvement', N'на согласовании')
INSERT [dbo].[rdm_documentStatuses] ([id], [code], [name]) VALUES (3, N'signed', N'подписан')
INSERT [dbo].[rdm_documentStatuses] ([id], [code], [name]) VALUES (4, N'recieved', N'получена утверждённая копия')
SET IDENTITY_INSERT [dbo].[rdm_documentStatuses] OFF
SET IDENTITY_INSERT [dbo].[rdm_documentTypes] ON 

INSERT [dbo].[rdm_documentTypes] ([id], [code], [name]) VALUES (1, N'contract', N'договор')
INSERT [dbo].[rdm_documentTypes] ([id], [code], [name]) VALUES (2, N'act', N'акт')
INSERT [dbo].[rdm_documentTypes] ([id], [code], [name]) VALUES (3, N'supplementaryAgreement', N'дополнительное соглашение')
SET IDENTITY_INSERT [dbo].[rdm_documentTypes] OFF
SET IDENTITY_INSERT [dbo].[rdm_mails] ON 

INSERT [dbo].[rdm_mails] ([id], [dateSent], [dateRecieved], [sender], [recipient], [description], [mailSystemID], [replyDateSent], [replyDateRecieved], [trackingNumber], [replyTrackingNumber], [statusID]) VALUES (1, CAST(N'2005-08-10 00:00:00.000' AS DateTime), CAST(N'2005-08-15 00:00:00.000' AS DateTime), N'sender#1', N'recipient#1', N'mail#1 description', 1, CAST(N'2005-09-15 00:00:00.000' AS DateTime), CAST(N'2005-09-25 00:00:00.000' AS DateTime), N'12345-11', N'54321-11', 1)
INSERT [dbo].[rdm_mails] ([id], [dateSent], [dateRecieved], [sender], [recipient], [description], [mailSystemID], [replyDateSent], [replyDateRecieved], [trackingNumber], [replyTrackingNumber], [statusID]) VALUES (2, CAST(N'2006-08-10 00:00:00.000' AS DateTime), CAST(N'2006-08-15 00:00:00.000' AS DateTime), N'sender#2', N'recipient#2', N'mail#2 description', 2, CAST(N'2006-09-15 00:00:00.000' AS DateTime), CAST(N'2006-09-25 00:00:00.000' AS DateTime), N'12345-22', N'54321-22', 3)
SET IDENTITY_INSERT [dbo].[rdm_mails] OFF
SET IDENTITY_INSERT [dbo].[rdm_mailStatuses] ON 

INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (1, N'created', N'создано')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (2, N'approved', N'согласована отправка')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (3, N'sent', N'отправлено')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (4, N'recieved', N'получено')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (5, N'sentBack', N'отправлено обратно')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (6, N'recievedBack', N'получено обратно')
INSERT [dbo].[rdm_mailStatuses] ([id], [code], [name]) VALUES (7, N'completed', N'закрыто')
SET IDENTITY_INSERT [dbo].[rdm_mailStatuses] OFF
SET IDENTITY_INSERT [dbo].[rdm_mailSystems] ON 

INSERT [dbo].[rdm_mailSystems] ([id], [code], [name]) VALUES (1, N'courier', N'курьерская компания')
INSERT [dbo].[rdm_mailSystems] ([id], [code], [name]) VALUES (2, N'mail', N'почтовая компания')
SET IDENTITY_INSERT [dbo].[rdm_mailSystems] OFF
ALTER TABLE [dbo].[rdm_bills]  WITH CHECK ADD  CONSTRAINT [FK_rdm_bills_rdm_billStatuses] FOREIGN KEY([statusID])
REFERENCES [dbo].[rdm_billStatuses] ([id])
GO
ALTER TABLE [dbo].[rdm_bills] CHECK CONSTRAINT [FK_rdm_bills_rdm_billStatuses]
GO
ALTER TABLE [dbo].[rdm_bills]  WITH CHECK ADD  CONSTRAINT [FK_rdm_bills_rdm_contractors] FOREIGN KEY([contractorID])
REFERENCES [dbo].[rdm_contractors] ([id])
GO
ALTER TABLE [dbo].[rdm_bills] CHECK CONSTRAINT [FK_rdm_bills_rdm_contractors]
GO
ALTER TABLE [dbo].[rdm_documents]  WITH CHECK ADD  CONSTRAINT [FK_rdm_documents_rdm_contractors] FOREIGN KEY([contractorID])
REFERENCES [dbo].[rdm_contractors] ([id])
GO
ALTER TABLE [dbo].[rdm_documents] CHECK CONSTRAINT [FK_rdm_documents_rdm_contractors]
GO
ALTER TABLE [dbo].[rdm_documents]  WITH CHECK ADD  CONSTRAINT [FK_rdm_documents_rdm_documents_parent] FOREIGN KEY([parentDocumentID])
REFERENCES [dbo].[rdm_documents] ([id])
GO
ALTER TABLE [dbo].[rdm_documents] CHECK CONSTRAINT [FK_rdm_documents_rdm_documents_parent]
GO
ALTER TABLE [dbo].[rdm_documents]  WITH CHECK ADD  CONSTRAINT [FK_rdm_documents_rdm_documentStatuses] FOREIGN KEY([statusID])
REFERENCES [dbo].[rdm_documentStatuses] ([id])
GO
ALTER TABLE [dbo].[rdm_documents] CHECK CONSTRAINT [FK_rdm_documents_rdm_documentStatuses]
GO
ALTER TABLE [dbo].[rdm_documents]  WITH CHECK ADD  CONSTRAINT [FK_rdm_documents_rdm_documentTypes] FOREIGN KEY([typeID])
REFERENCES [dbo].[rdm_documentTypes] ([id])
GO
ALTER TABLE [dbo].[rdm_documents] CHECK CONSTRAINT [FK_rdm_documents_rdm_documentTypes]
GO
ALTER TABLE [dbo].[rdm_mails]  WITH CHECK ADD  CONSTRAINT [FK_rdm_mails_rdm_mailStatuses] FOREIGN KEY([statusID])
REFERENCES [dbo].[rdm_mailStatuses] ([id])
GO
ALTER TABLE [dbo].[rdm_mails] CHECK CONSTRAINT [FK_rdm_mails_rdm_mailStatuses]
GO
ALTER TABLE [dbo].[rdm_mails]  WITH CHECK ADD  CONSTRAINT [FK_rdm_mails_rdm_mailSystems] FOREIGN KEY([mailSystemID])
REFERENCES [dbo].[rdm_mailSystems] ([id])
GO
ALTER TABLE [dbo].[rdm_mails] CHECK CONSTRAINT [FK_rdm_mails_rdm_mailSystems]
GO
USE [master]
GO
ALTER DATABASE [Roadmap] SET  READ_WRITE 
GO
