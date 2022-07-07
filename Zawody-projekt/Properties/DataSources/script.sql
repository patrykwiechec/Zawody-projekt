USE [Turniej]
GO
/****** Object:  Table [dbo].[trenerzy]    Script Date: 07.07.2022 18:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trenerzy](
	[id_trenera] [int] IDENTITY(1,1) NOT NULL,
	[imie_t] [varchar](20) NOT NULL,
	[nazwisko_t] [varchar](25) NOT NULL,
	[ile_medali_t] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_trenera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uczestnictwo]    Script Date: 07.07.2022 18:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uczestnictwo](
	[id_uczestnictwa] [int] IDENTITY(1,1) NOT NULL,
	[id_zawodnika] [int] NULL,
	[id_zawodow] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_uczestnictwa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zawodnicy]    Script Date: 07.07.2022 18:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zawodnicy](
	[id_zawodnika] [int] IDENTITY(1,1) NOT NULL,
	[imie] [varchar](20) NOT NULL,
	[nazwisko] [varchar](25) NOT NULL,
	[kraj] [varchar](20) NOT NULL,
	[ile_medali_t] [int] NOT NULL,
	[id_trenera] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_zawodnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zawody]    Script Date: 07.07.2022 18:50:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zawody](
	[id_zawodow] [int] IDENTITY(1,1) NOT NULL,
	[nazwa] [varchar](50) NOT NULL,
	[lokalizacja] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_zawodow] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[uczestnictwo]  WITH CHECK ADD FOREIGN KEY([id_zawodnika])
REFERENCES [dbo].[zawodnicy] ([id_zawodnika])
GO
ALTER TABLE [dbo].[uczestnictwo]  WITH CHECK ADD FOREIGN KEY([id_zawodow])
REFERENCES [dbo].[zawody] ([id_zawodow])
GO
ALTER TABLE [dbo].[zawodnicy]  WITH CHECK ADD FOREIGN KEY([id_trenera])
REFERENCES [dbo].[trenerzy] ([id_trenera])
GO
