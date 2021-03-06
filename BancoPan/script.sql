USE [BancoPan]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 07/03/2021 17:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [nchar](11) NOT NULL,
	[nome] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 07/03/2021 17:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[idEndereco] [int] IDENTITY(1,1) NOT NULL,
	[logradouro] [varchar](150) NOT NULL,
	[numero] [varchar](50) NOT NULL,
	[complemento] [varchar](150) NULL,
	[cidade] [varchar](200) NOT NULL,
	[estado] [char](2) NOT NULL,
	[pais] [varchar](150) NOT NULL,
	[cep] [nchar](10) NOT NULL,
	[idCliente] [int] NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[idEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Enderecos] CHECK CONSTRAINT [FK_Endereco_Cliente]
GO
