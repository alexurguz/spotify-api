CREATE DATABASE ApiSpotify;

USE [ApiSpotify]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[id] [varchar](50) NOT NULL,
	[external_urls] [varchar](4000) NOT NULL,
	[href] [varchar](4000) NOT NULL,
	[name] [varchar](1000) NOT NULL,
	[type] [varchar](100) NOT NULL,
	[uri] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Song](
	[id] [varchar](50) NOT NULL,
	[disc_number] [int] NOT NULL,
	[duration_ms] [int] NOT NULL,
    [explicit] [bit] NOT NULL,
	[external_urls] [varchar](4000) NOT NULL,
	[href] [varchar](4000) NOT NULL,
    [is_local] [bit] NOT NULL,
    [is_playable] [bit] NOT NULL,
	[name] [varchar](1000) NOT NULL,
	[preview_url] [varchar](4000) NOT NULL,
	[track_number] [int] NOT NULL,
	[type] [varchar](100) NOT NULL,
	[uri] [varchar](4000) NOT NULL,
 CONSTRAINT [PK_Song] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongsArtists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_artist] [varchar](50) NOT NULL,
	[id_song] [varchar](50) NOT NULL
,
 CONSTRAINT [PK_SongsArtists] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SongsArtists]  WITH NOCHECK ADD  CONSTRAINT [FK_SA_idArtist] FOREIGN KEY([id_artist])
REFERENCES [dbo].[Artist] ([id])
GO
ALTER TABLE [dbo].[SongsArtists] CHECK CONSTRAINT [FK_SA_idArtist]

ALTER TABLE [dbo].[SongsArtists]  WITH NOCHECK ADD  CONSTRAINT [FK_SA_idASong] FOREIGN KEY([id_song])
REFERENCES [dbo].[Song] ([id])
GO
ALTER TABLE [dbo].[SongsArtists] CHECK CONSTRAINT [FK_SA_idASong]


