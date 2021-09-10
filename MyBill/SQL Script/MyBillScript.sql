CREATE DATABASE [MyBill]
GO
ALTER DATABASE [MyBill] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyBill].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyBill] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyBill] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyBill] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyBill] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyBill] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyBill] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyBill] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyBill] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyBill] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyBill] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyBill] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyBill] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyBill] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyBill] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyBill] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyBill] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyBill] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyBill] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyBill] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyBill] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyBill] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyBill] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyBill] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyBill] SET  MULTI_USER 
GO
ALTER DATABASE [MyBill] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyBill] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyBill] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyBill] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [MyBill]
GO
/****** Object:  UserDefinedFunction [dbo].[AmountToWords]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create function [dbo].[AmountToWords]
	(
		@InNumber Numeric(18,2) 
	) 
--Returns the number as words.
returns VARCHAR(2000) 
as
BEGIN

--Set NoCount ON

Declare @Num Varchar(20)
Declare @Dec Varchar(3)
Declare @Return Varchar(2000)
Set @Return='Nothing'

Set @Dec = SubString(Convert(Varchar(20),@Innumber),Len(Convert(Varchar(20),@Innumber))-2,3)
Set @Num = SubString(Convert(Varchar(20),@Innumber),1, Len(Convert(Varchar(20),@Innumber))-3)

Declare @Hundred Char(8)
Declare @HundredAnd Char(12)
Declare @Thousand Char(9)
Declare @Lakh Char(5)
Declare @Lakhs Char(6)
Declare @Crore Char(6)
Declare @Crores Char(7)

Set @Hundred = 'Hundred '
Set @Thousand = 'Thousand '
Set @Lakh = 'Lakh '
Set @Lakhs = 'Lakhs '
Set @Crore = 'Crore '
Set @Crores = 'Crores '
Set @HundredAnd = 'Hundred and '

if Len(@Num) = 1 -- One
Begin
	Set @Return = dbo.GetTextValue(@Num)
End
Else if Len(@Num) = 2 -- Ten
Begin
	Set @Return = dbo.GetTextValue(@Num)
End
Else if Len(@Num) = 3 -- Hundred
Begin
	Set @Return = dbo.GetTextValue(SubString(@Num,1,1)) + @Hundred 

	IF SubString(@num,2,2) <>  '00'
	begin
		Set @Return = @Return + 'And '	
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,2,2)) 
	end
End
Else if Len(@Num) = 4 -- thousand
Begin
	Set @Return = dbo.GetTextValue(SubString(@Num,1,1)) + @Thousand
	If SubString(@Num,2,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,2,1)) + @Hundred
	IF SubString(@num,3,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,3,2)) 
	end
End
Else if Len(@Num) = 5 -- Ten Thousand
Begin
	Set @Return = dbo.GetTextValue(SubString(@Num,1,2)) + @Thousand
	If SubString(@Num,3,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,3,1)) + @Hundred 
	IF SubString(@num,4,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,4,2)) 
	end
End
Else if Len(@Num) = 6 -- Lakh
Begin
	If SubString(@Num,1,1) = '1'
		Set @Return = dbo.GetTextValue(SubString(@Num,1,1)) + @Lakh
	Else
		Set @Return = dbo.GetTextValue(SubString(@Num,1,1)) + @Lakhs 

	If SubString(@Num,2,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,2,2)) + @Thousand
	If SubString(@Num,4,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,4,1)) + @Hundred 
	IF SubString(@num,5,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,5,2)) 
	end
End
Else if Len(@Num) = 7 -- Ten Lakhs
Begin
	
	Set @Return = dbo.GetTextValue(SubString(@Num,1,2)) + @Lakhs
	If SubString(@Num,3,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,3,2)) + @Thousand
	If SubString(@Num,6,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,5,1)) + @Hundred
	IF SubString(@num,6,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,6,2)) 
	end
End
Else if Len(@Num) = 8 -- Crore
Begin
	Set @Return = dbo.GetTextValue(SubString(@Num,1,1)) + @Crore
	If SubString(@Num,2,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,2,2)) + @Lakhs

	If SubString(@Num,4,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,4,2)) + @Thousand
	If SubString(@Num,6,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,6,1)) + @Hundred
	IF SubString(@num,7,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,7,2)) 
	end
End
Else if Len(@Num) = 9 -- Ten Crore
Begin
	Set @Return = dbo.GetTextValue(SubString(@Num,1,2)) + @Crores
	If SubString(@Num,3,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,3,2)) + @Lakhs
	If SubString(@Num,5,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,5,2)) + @Thousand
	If SubString(@Num,7,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,7,1)) + @Hundred
	IF SubString(@num,8,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,8,2)) 
	end
End
Else if Len(@Num) = 10 -- Hundred Crore
Begin
	Set @Return = dbo.GetTextValue(Substring(@Num,1,1)) + @Hundred
	IF Substring(@Num,2,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,2,2)) 
	Set @Return = @Return + @Crores

	If SubString(@Num,4,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,4,2)) + @Lakhs
	If SubString(@Num,6,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,6,2)) + @Thousand
	If SubString(@Num,8,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,8,1)) + @Hundred
	IF SubString(@num,9,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,9,2)) 
	end
End
Else if Len(@Num) = 11 -- Thousand Crore
Begin
	Set @Return = dbo.GetTextValue(Substring(@Num,1,1)) + @Thousand
	IF SubString(@Num,2,1) <> '0'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,2,1)) + @Hundred
	IF Substring(@Num,3,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,3,2)) 

	Set @Return = @Return + @Crores

	If SubString(@Num,5,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,5,2)) + @Lakhs
	If SubString(@Num,7,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,7,2)) + @Thousand
	If SubString(@Num,9,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,9,1)) + @Hundred
	IF SubString(@num,10,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,10,2)) 
	end
End
Else if Len(@Num) = 12 -- Ten thousand Crore
Begin

	Set @Return = dbo.GetTextValue(Substring(@Num,1,2)) + @Thousand
	IF SubString(@Num,3,1) <> '0'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,3,1)) + @Hundred
	IF Substring(@Num,4,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,4,2)) 

	Set @Return = @Return + @Crores

	If SubString(@Num,6,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,6,2)) + @Lakhs
	If SubString(@Num,8,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,8,2)) + @Thousand
	If SubString(@Num,10,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,10,1)) + @Hundred
	IF SubString(@num,11,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,11,2)) 
	end
End
Else if Len(@Num) = 13 -- Lakh Crore
Begin

	Set @Return = dbo.GetTextValue(Substring(@Num,1,1)) + @Lakh
	If Substring(@Num,2,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,2,2)) + @Thousand
	IF SubString(@Num,4,1) <> '0'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,4,1)) + @Hundred
	IF Substring(@Num,5,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,5,2)) 

	Set @Return = @Return + @Crores

	If SubString(@Num,7,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,7,2)) + @Lakhs
	If SubString(@Num,9,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,9,2)) + @Thousand
	If SubString(@Num,11,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,11,1)) + @Hundred
	IF SubString(@num,12,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,12,2)) 
	end
End
Else if Len(@Num) = 14 -- Ten Lakh Crore
Begin
	Set @Return = dbo.GetTextValue(Substring(@Num,1,2)) + @Lakhs
	If Substring(@Num,3,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,3,2)) + @Thousand
	IF SubString(@Num,5,1) <> '0'
		Set @Return = @Return + dbo.GetTextValue(Substring(@Num,5,1)) + @Hundred
	IF Substring(@Num,6,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,6,2)) 

	Set @Return = @Return + @Crores

	If SubString(@Num,8,2) <> '00'
		Set @Return = @Return + dbo.GetTextValue(SubString(@Num,8,2)) + @Lakhs
	If SubString(@Num,10,2) <> '00'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,10,2)) + @Thousand
	If SubString(@Num,12,1) <> '0'
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,12,1)) + @Hundred
	IF SubString(@num,13,2) <>  '00'
	begin
		Set @Return = @Return + 'And '
		Set @Return = @Return +	dbo.GetTextValue(SubString(@Num,13,2)) 
	end

End

If @Dec <> '.00'
	Set @Return = @Return + 'And ' + dbo.GetTextValue(SubString(@Dec,2,2)) 	+ 'Paise'	

Return @return
End






































GO
/****** Object:  UserDefinedFunction [dbo].[GetTextValue]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Function [dbo].[GetTextValue]
(
	@dblNumber Numeric
)
Returns Varchar(1000) 
As
Begin
Declare @StrWord Varchar(400)
SEt @strWord = Case @dblNumber 
	When 1 Then 'One '
	When 2 Then 'Two '
	When 3 Then 'Three '
	When 4 Then 'Four '
	When 5 Then 'Five '
	When 6 Then 'Six '
	When 7 Then 'Seven '
	When 8 Then 'Eight '
	When 9 Then 'Nine '
	When 10 Then 'Ten '
	When 11 Then 'Eleven '
	When 12 Then 'Twelve '
	When 13 Then 'Thirteen '
	When 14 Then 'Fourteen '
	When 15 Then 'Fifteen '
	When 16 Then 'Sixteen '
	When 17 Then 'Seventeen '
	When 18 Then 'Eighteen '
	When 19 Then 'Nineteen '
	When 20 Then 'Twenty '
	When 21 Then 'Twenty One '
	When 22 Then 'Twenty Two '
	When 23 Then 'Twenty Three '
	When 24 Then 'Twenty Four '
	When 25 Then 'Twenty Five '
	When 26 Then 'Twenty Six '
	When 27 Then 'Twenty Seven '
	When 28 Then 'Twenty Eight '
	When 29 Then 'Twenty Nine '
	When 30 Then 'Thirty '
	When 31 Then 'Thirty One '
	When 32 Then 'Thirty Two '
	When 33 Then 'Thirty Three '
	When 34 Then 'Thirty Four '
	When 35 Then 'Thirty Five '
	When 36 Then 'Thirty Six '
	When 37 Then 'Thirty Seven '
	When 38 Then 'Thirty Eight '
	When 39 Then 'Thirty Nine '
	When 40 Then 'Forty '
	When 41 Then 'Forty One '
	When 42 Then 'Forty Two '
	When 43 Then 'Forty Three '
	When 44 Then 'Forty Four '
	When 45 Then 'Forty Five '
	When 46 Then 'Forty Six '
	When 47 Then 'Forty Seven '
	When 48 Then 'Forty Eight '
	When 49 Then 'Forty Nine '
	When 50 Then 'Fifty '
	When 51 Then 'Fifty One '
	When 52 Then 'Fifty Two '
	When 53 Then 'Fifty Three '
	When 54 Then 'Fifty Four '
	When 55 Then 'Fifty Five '
	When 56 Then 'Fifty Six '
	When 57 Then 'Fifty Seven '
	When 58 Then 'Fifty Eight '
	When 59 Then 'Fifty Nine '
	When 60 Then 'Sixty '
	When 61 Then 'Sixty One '
	When 62 Then 'Sixty Two '
	When 63 Then 'Sixty Three '
	When 64 Then 'Sixty Four '
	When 65 Then 'Sixty Five '
	When 66 Then 'Sixty Six '
	When 67 Then 'Sixty Seven '
	When 68 Then 'Sixty Eight '
	When 69 Then 'Sixty Nine '
	When 70 Then 'Seventy '
	When 71 Then 'Seventy One '
	When 72 Then 'Seventy Two '
	When 73 Then 'Seventy Three '
	When 74 Then 'Seventy Four '
	When 75 Then 'Seventy Five '
	When 76 Then 'Seventy Six '
	When 77 Then 'Seventy Seven '
	When 78 Then 'Seventy Eight '
	When 79 Then 'Seventy Nine '
	When 80 Then 'Eighty '
	When 81 Then 'Eighty One '
	When 82 Then 'Eighty Two '
	When 83 Then 'Eighty Three '
	When 84 Then 'Eighty Four '
	When 85 Then 'Eighty Five '
	When 86 Then 'Eighty Six '
	When 87 Then 'Eighty Seven '
	When 88 Then 'Eighty Eight '
	When 89 Then 'Eighty Nine '
	When 90 Then 'Ninety '
	When 91 Then 'Ninety One '
	When 92 Then 'Ninety Two '
	When 93 Then 'Ninety Three '
	When 94 Then 'Ninety Four '
	When 95 Then 'Ninety Five '
	When 96 Then 'Ninety Six '
	When 97 Then 'Ninety Seven '
	When 98 Then 'Ninety Eight '
	When 99 Then 'Ninety Nine '
	When 100 Then 'One hundred  '
End
Return @strWord
End
GO
/****** Object:  Table [dbo].[CompanyInfo]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyInfo](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[CompanyHOAddress1] [varchar](100) NULL,
	[CompanyHOAddress2] [varchar](100) NULL,
	[CompanyHOAddress3] [varchar](100) NULL,
	[CompanyHOPINCode] [varchar](50) NULL,
	[CompanyBOAddress1] [varchar](100) NULL,
	[CompanyBOAddress2] [varchar](100) NULL,
	[CompanyBOAddress3] [varchar](100) NULL,
	[CompanyBOPINCode] [varchar](50) NULL,
	[CompanyMobileNo] [varchar](100) NULL,
	[CompanyEMailId] [varchar](150) NULL,
	[CompanyGSTN] [varchar](50) NULL,
	[CompanyBankName] [varchar](250) NULL,
	[CompanyBankACNo] [varchar](100) NULL,
	[CompanyBankIFSCCode] [varchar](100) NULL,
	[CompanyBankBranch] [varchar](100) NULL,
	[CompanyPAN] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceMain]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceMain](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[InvoicePaID] [int] NOT NULL,
	[InvoiceGrossAmount] [numeric](18, 2) NOT NULL,
	[InvoiceTaxAmount] [numeric](18, 2) NOT NULL,
	[InvoiceRoundOff] [numeric](18, 2) NOT NULL,
	[InvoiceNetAmount] [numeric](18, 2) NOT NULL,
	[InvoiceInsertData] [datetime] NULL,
	[InvoiceStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceSub]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceSub](
	[InvoiceSubId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[InvoicePrId] [int] NOT NULL,
	[InvoicePrQty] [numeric](18, 2) NOT NULL,
	[InvoicePrRate] [numeric](18, 2) NOT NULL,
	[InvoiceTaxId] [int] NOT NULL,
	[InvoiceCGSTAmount] [numeric](18, 2) NULL,
	[InvoiceSGSTAmount] [numeric](18, 2) NULL,
	[InvoiceIGSTAmount] [numeric](18, 2) NULL,
	[InvoiceUGSTAmount] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceSubId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaHSN]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaHSN](
	[HSNId] [int] IDENTITY(1,1) NOT NULL,
	[HSNCode] [varchar](50) NOT NULL,
	[HSNDescription] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[HSNId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaParty]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaParty](
	[PaID] [int] IDENTITY(1,1) NOT NULL,
	[PaName] [varchar](50) NULL,
	[PaAddress1] [varchar](200) NULL,
	[PaAddress2] [varchar](200) NULL,
	[PaAddress3] [varchar](200) NULL,
	[PaPINCode] [varchar](10) NULL,
	[PaGSTN] [varchar](50) NULL,
	[PaPAN] [varchar](25) NULL,
	[PaMailId] [varchar](100) NULL,
	[PaStateID] [int] NULL,
	[PaTypeID] [int] NULL,
	[PaMobileNo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaState]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaState](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](50) NULL,
	[StateCode] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaTax]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaTax](
	[TaxId] [int] IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](100) NOT NULL,
	[CGSTCaption] [varchar](50) NULL,
	[CGSTTaxRate] [numeric](18, 2) NULL,
	[SGSTCaption] [varchar](50) NULL,
	[SGSTTaxRate] [numeric](18, 2) NULL,
	[IGSTCaption] [varchar](50) NULL,
	[IGSTTaxRate] [numeric](18, 2) NULL,
	[UGSTCaption] [varchar](50) NULL,
	[UGSTTaxRate] [numeric](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[TaxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaUnit]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaUnit](
	[UnitId] [int] IDENTITY(1,1) NOT NULL,
	[UnitDesc] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrMaster]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrMaster](
	[PrId] [int] IDENTITY(1,1) NOT NULL,
	[PrCode] [varchar](50) NULL,
	[PrDesc] [varchar](500) NULL,
	[PrUnit] [varchar](50) NULL,
	[Pr_HSNId] [int] NULL,
	[Pr_TaxID] [int] NULL,
	[PrOpenBalance] [numeric](18, 2) NULL,
	[PrPurchaseRate] [numeric](18, 2) NULL,
	[PrSalesRate] [numeric](18, 2) NULL,
	[Pr_UnitId] [int] NULL,
 CONSTRAINT [PK_PrMaster] PRIMARY KEY CLUSTERED 
(
	[PrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CompanyInfo] ON 
GO
INSERT [dbo].[CompanyInfo] ([CompanyId], [CompanyName], [CompanyHOAddress1], [CompanyHOAddress2], [CompanyHOAddress3], [CompanyHOPINCode], [CompanyBOAddress1], [CompanyBOAddress2], [CompanyBOAddress3], [CompanyBOPINCode], [CompanyMobileNo], [CompanyEMailId], [CompanyGSTN], [CompanyBankName], [CompanyBankACNo], [CompanyBankIFSCCode], [CompanyBankBranch], [CompanyPAN]) VALUES (1, N'Your Company Name', N'35G, Annai Sathya Nagar ********************', N'', N'', N'', N'***********************************', N'JG Complex , Nirmala Nagar******************', N'', N'', N'9843******', N'testmail@gmail.com', N'33CBMPM6394****', N'', N'', N'', N'', N'')
GO
SET IDENTITY_INSERT [dbo].[CompanyInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceMain] ON 
GO
INSERT [dbo].[InvoiceMain] ([InvoiceId], [InvoiceNo], [InvoiceDate], [InvoicePaID], [InvoiceGrossAmount], [InvoiceTaxAmount], [InvoiceRoundOff], [InvoiceNetAmount], [InvoiceInsertData], [InvoiceStatus]) VALUES (3, 1, CAST(N'2021-07-30T00:00:00.000' AS DateTime), 1, CAST(388.00 AS Numeric(18, 2)), CAST(69.84 AS Numeric(18, 2)), CAST(0.16 AS Numeric(18, 2)), CAST(458.00 AS Numeric(18, 2)), CAST(N'2021-07-30T21:01:08.907' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[InvoiceMain] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceSub] ON 
GO
INSERT [dbo].[InvoiceSub] ([InvoiceSubId], [InvoiceId], [InvoicePrId], [InvoicePrQty], [InvoicePrRate], [InvoiceTaxId], [InvoiceCGSTAmount], [InvoiceSGSTAmount], [InvoiceIGSTAmount], [InvoiceUGSTAmount]) VALUES (1, 3, 1, CAST(1.00 AS Numeric(18, 2)), CAST(275.00 AS Numeric(18, 2)), 1, CAST(24.75 AS Numeric(18, 2)), CAST(24.75 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[InvoiceSub] ([InvoiceSubId], [InvoiceId], [InvoicePrId], [InvoicePrQty], [InvoicePrRate], [InvoiceTaxId], [InvoiceCGSTAmount], [InvoiceSGSTAmount], [InvoiceIGSTAmount], [InvoiceUGSTAmount]) VALUES (2, 3, 3, CAST(1.00 AS Numeric(18, 2)), CAST(85.00 AS Numeric(18, 2)), 1, CAST(7.65 AS Numeric(18, 2)), CAST(7.65 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[InvoiceSub] ([InvoiceSubId], [InvoiceId], [InvoicePrId], [InvoicePrQty], [InvoicePrRate], [InvoiceTaxId], [InvoiceCGSTAmount], [InvoiceSGSTAmount], [InvoiceIGSTAmount], [InvoiceUGSTAmount]) VALUES (3, 3, 8, CAST(1.00 AS Numeric(18, 2)), CAST(28.00 AS Numeric(18, 2)), 1, CAST(2.52 AS Numeric(18, 2)), CAST(2.52 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[InvoiceSub] OFF
GO
SET IDENTITY_INSERT [dbo].[MaHSN] ON 
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (1, N'2301', N'FLOURS-MEALS')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (2, N'07139010', N'DAL')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (3, N'250100', N'SALT')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (4, N'15121920', N'SUNFLOWER OIL')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (5, N'1513', N'COCONUT')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (6, N'0910910', N'SPICES')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (7, N'802', N'NUTS')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (8, N'040900', N'NATURAL HONEY')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (9, N'1006', N'RICE')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (10, N'0405', N'DAIRY PRODUCTS')
GO
INSERT [dbo].[MaHSN] ([HSNId], [HSNCode], [HSNDescription]) VALUES (11, N'3401', N'BATH SOAP')
GO
SET IDENTITY_INSERT [dbo].[MaHSN] OFF
GO
SET IDENTITY_INSERT [dbo].[MaParty] ON 
GO
INSERT [dbo].[MaParty] ([PaID], [PaName], [PaAddress1], [PaAddress2], [PaAddress3], [PaPINCode], [PaGSTN], [PaPAN], [PaMailId], [PaStateID], [PaTypeID], [PaMobileNo]) VALUES (1, N'DEMO USER', N'CHENNAI', N'*********', N'*********', N'600106', N'*********', N'BA206**', N'', 1, 1, N'')
GO
SET IDENTITY_INSERT [dbo].[MaParty] OFF
GO
SET IDENTITY_INSERT [dbo].[MaState] ON 
GO
INSERT [dbo].[MaState] ([StateID], [StateName], [StateCode]) VALUES (1, N'Tamil Nadu', N'33')
GO
SET IDENTITY_INSERT [dbo].[MaState] OFF
GO
SET IDENTITY_INSERT [dbo].[MaTax] ON 
GO
INSERT [dbo].[MaTax] ([TaxId], [TaxName], [CGSTCaption], [CGSTTaxRate], [SGSTCaption], [SGSTTaxRate], [IGSTCaption], [IGSTTaxRate], [UGSTCaption], [UGSTTaxRate]) VALUES (1, N'CGST 9% AND SGST 9%', N'CGST', CAST(9.00 AS Numeric(18, 2)), N'SGST', CAST(9.00 AS Numeric(18, 2)), N'IGST', CAST(0.00 AS Numeric(18, 2)), N'UGST', CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[MaTax] ([TaxId], [TaxName], [CGSTCaption], [CGSTTaxRate], [SGSTCaption], [SGSTTaxRate], [IGSTCaption], [IGSTTaxRate], [UGSTCaption], [UGSTTaxRate]) VALUES (2, N'CGST 2.5% & SGST 2.5%', N'CGST 2.5%', CAST(2.50 AS Numeric(18, 2)), N'SGST 2.5%', CAST(2.50 AS Numeric(18, 2)), N'', CAST(0.00 AS Numeric(18, 2)), N'', CAST(0.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[MaTax] ([TaxId], [TaxName], [CGSTCaption], [CGSTTaxRate], [SGSTCaption], [SGSTTaxRate], [IGSTCaption], [IGSTTaxRate], [UGSTCaption], [UGSTTaxRate]) VALUES (3, N'CGST 6% & SGST 6%', N'CGST', CAST(6.00 AS Numeric(18, 2)), N'SGST', CAST(6.00 AS Numeric(18, 2)), N'IGST', CAST(0.00 AS Numeric(18, 2)), N'UGST', CAST(0.00 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[MaTax] OFF
GO
SET IDENTITY_INSERT [dbo].[MaUnit] ON 
GO
INSERT [dbo].[MaUnit] ([UnitId], [UnitDesc]) VALUES (1, N'No(s).')
GO
INSERT [dbo].[MaUnit] ([UnitId], [UnitDesc]) VALUES (2, N'Litre(s).')
GO
INSERT [dbo].[MaUnit] ([UnitId], [UnitDesc]) VALUES (3, N'Dozen')
GO
SET IDENTITY_INSERT [dbo].[MaUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[PrMaster] ON 
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (1, N'001', N'BOILED RICE -5KG BAG', N'No(s).', 9, 1, CAST(10.00 AS Numeric(18, 2)), CAST(250.00 AS Numeric(18, 2)), CAST(275.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (2, N'002', N'BASMATI RICE 1 KG BAG', N'No(s).', 9, 1, CAST(10.00 AS Numeric(18, 2)), CAST(85.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (3, N'003', N'WHEAT FLOUR 5 KG BAG', N'No(s).', 1, 1, CAST(10.00 AS Numeric(18, 2)), CAST(75.00 AS Numeric(18, 2)), CAST(85.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (4, N'004', N'BUTTER 100 GRAM', N'No(s).', 10, 3, CAST(5.00 AS Numeric(18, 2)), CAST(70.00 AS Numeric(18, 2)), CAST(75.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (5, N'005', N'CRYSTAL SALT 1KG', N'No(s).', 3, 3, CAST(5.00 AS Numeric(18, 2)), CAST(8.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (6, N'006', N'PEPPER - 100 GRAM', N'No(s).', 6, 2, CAST(8.00 AS Numeric(18, 2)), CAST(75.00 AS Numeric(18, 2)), CAST(85.00 AS Numeric(18, 2)), 1)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (7, N'007', N'SUN FLOWER OIL - 1 LTR', N'No(s).', 4, 2, CAST(8.00 AS Numeric(18, 2)), CAST(120.00 AS Numeric(18, 2)), CAST(130.00 AS Numeric(18, 2)), 2)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (8, N'0052', N'LUX 25 GRAM', N'1', 11, 1, CAST(10.00 AS Numeric(18, 2)), CAST(25.00 AS Numeric(18, 2)), CAST(28.00 AS Numeric(18, 2)), 3)
GO
INSERT [dbo].[PrMaster] ([PrId], [PrCode], [PrDesc], [PrUnit], [Pr_HSNId], [Pr_TaxID], [PrOpenBalance], [PrPurchaseRate], [PrSalesRate], [Pr_UnitId]) VALUES (9, N'0053', N'HAMAM 25GRAM', N'1', 11, 1, CAST(8.00 AS Numeric(18, 2)), CAST(25.00 AS Numeric(18, 2)), CAST(28.00 AS Numeric(18, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[PrMaster] OFF
GO
/****** Object:  Index [UC_InvoiceNO]    Script Date: 11-09-2021 02:22:53 ******/
ALTER TABLE [dbo].[InvoiceMain] ADD  CONSTRAINT [UC_InvoiceNO] UNIQUE NONCLUSTERED 
(
	[InvoiceNo] ASC,
	[InvoiceStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceMain] ADD  DEFAULT ((1)) FOR [InvoiceStatus]
GO
ALTER TABLE [dbo].[PrMaster] ADD  DEFAULT ((0)) FOR [PrOpenBalance]
GO
ALTER TABLE [dbo].[InvoiceMain]  WITH CHECK ADD FOREIGN KEY([InvoicePaID])
REFERENCES [dbo].[MaParty] ([PaID])
GO
ALTER TABLE [dbo].[InvoiceSub]  WITH CHECK ADD FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[InvoiceMain] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceSub]  WITH CHECK ADD FOREIGN KEY([InvoicePrId])
REFERENCES [dbo].[PrMaster] ([PrId])
GO
ALTER TABLE [dbo].[InvoiceSub]  WITH CHECK ADD FOREIGN KEY([InvoiceTaxId])
REFERENCES [dbo].[MaTax] ([TaxId])
GO
ALTER TABLE [dbo].[MaParty]  WITH CHECK ADD FOREIGN KEY([PaStateID])
REFERENCES [dbo].[MaState] ([StateID])
GO
ALTER TABLE [dbo].[PrMaster]  WITH CHECK ADD FOREIGN KEY([Pr_TaxID])
REFERENCES [dbo].[MaTax] ([TaxId])
GO
/****** Object:  StoredProcedure [dbo].[DeleteInvoice]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[DeleteInvoice](@InvId int)  
as  
update InvoiceMain set InvoiceStatus=0 where InvoiceId=@InvId
/*
Delete from InvoiceSub where InvId=@InvId  
Delete from InvoiceMain where InvId=@InvId
*/
-- Alter Table InvoiceMain Add InvoiceStatus int default 1

GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[DeleteProduct](@PrId int)
as
Delete from PrMaster where PrId=@PrId
--where 

GO
/****** Object:  StoredProcedure [dbo].[getInvoiceMainList]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[getInvoiceMainList](  
 @InvFrom DateTime,  
 @InvTo DateTime  
)  
as  
Begin  
 SELECT     InvoiceId, InvoiceNo, InvoiceDate, PaName,isnull(InvoiceNetAmount,0) as InvoiceNetAmount ,  
 isnull(InvoiceTaxAmount,0) as InvoiceTaxAmount ,ISNULL(InvoiceStatus,1) InvoiceStatus
 FROM   dbo.InvoiceMain  
 inner join dbo.MaParty on PaID=InvoicePaID   
 where InvoiceDate between @InvFrom and @InvTo  
 order by InvoiceId Desc  
End
GO
/****** Object:  StoredProcedure [dbo].[getInvoiceNo]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[getInvoiceNo]  
as  
Select isnull(Max(InvoiceNo),0)+1 as InvoiceNo from InvoiceMain  
where InvoiceStatus=1
GO
/****** Object:  StoredProcedure [dbo].[getPartyList]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[getPartyList]
as
Select PaID,PaName, PaAddress1,PaAddress2,PaAddress3,PaPINCode,PaGSTN,
		PaPAN,PaMailId,isnull(PaMobileNo,'') as PaMobileNo,StateName,StateCode
from dbo.MaParty 
inner join dbo.MaState on PaStateID=StateID
order by PaName
GO
/****** Object:  StoredProcedure [dbo].[getProductList]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[getProductList](@Prid int=null)  
as  
Begin  
 Select Prid,PrCode,PrDesc,UnitDesc,isnull(Pr_HSNId,0) Pr_HSNId,  
 isnull(Pr_TaxID,0) Pr_TaxID,isnull(PrOpenBalance,0) as PrOpenBalance,  
   
 ISNULL(CGSTTaxRate,0) CGSTTaxRate,  
 ISNULL(SGSTTaxRate,0) SGSTTaxRate,  
 ISNULL(IGSTTaxRate,0) IGSTTaxRate,  
 ISNULL(UGSTTaxRate,0) UGSTTaxRate,  
 ISNULL(PrPurchaseRate,0) PrPurchaseRate,  
 ISNULL(PrSalesRate,0) as PrSalesRate  
 from dbo.PrMaster pr  
 inner join [dbo].[MaHSN] hsn on hsn.HSNId = pr.Pr_HSNId   
 inner join [dbo].[MaTax]  tax on tax.TaxId = pr.Pr_TaxID  
 inner join [dbo].[MaUnit] unit on unit.UnitId = pr.Pr_UnitId
 where Prid=coalesce(@Prid,pr.Prid)  
End
GO
/****** Object:  StoredProcedure [dbo].[InsertInvoiceMain]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[InsertInvoiceMain](
	@InvoiceNo int,@InvoiceDate DateTime,
	@InvoiceCustomerId int,
	@InvoiceGrossAmount numeric(18,2),
	@InvoiceTaxAmount numeric(18,2),
	@InvoiceRoundOff numeric(18,2),
	@InvoiceNetAmount numeric(18,2),
	@InvoiceId int out,
	@InvoiceSaveRemarks varchar(500) out
)  
as  
Begin
set @InvoiceId=0;
set @InvoiceSaveRemarks='';
	if Not Exists(Select InvoiceNo from InvoiceMain where InvoiceNo = @InvoiceNo and InvoiceStatus=1) 
		Begin
				INSERT INTO InvoiceMain  
						   (InvoiceNo,
						   InvoiceDate,
						   InvoicePaID,
						   InvoiceGrossAmount,
						   InvoiceTaxAmount,
						   InvoiceRoundOff,
						   InvoiceNetAmount,
						   InvoiceInsertData)  
				VALUES(@InvoiceNo,
						@InvoiceDate,
						@InvoiceCustomerId,
						@InvoiceGrossAmount,
						@InvoiceTaxAmount,
						@InvoiceRoundOff,
						@InvoiceNetAmount,
						GETDATE()
				);  
				set @InvoiceId=SCOPE_IDENTITY();
		End
	Else
		Begin
			set @InvoiceSaveRemarks='Invoice number duplication.'
		End
	
End


GO
/****** Object:  StoredProcedure [dbo].[InsertInvoiceSub]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[InsertInvoiceSub](
	@InvId int,
	@PrId int,
	@PrQty numeric(18,2),
	@PrRate numeric(18,2),
	@PrTaxId int,
	@InvoiceCGSTAmount numeric(18,2),
	@InvoiceSGSTAmount numeric(18,2),
	@InvoiceIGSTAmount numeric(18,2),
	@InvoiceUGSTAmount numeric(18,2)	
	)
as
Begin
	INSERT INTO InvoiceSub
			   (
				   InvoiceId,
				   InvoicePrId,
				   InvoicePrQty,
				   InvoicePrRate,
				   InvoiceTaxId,
				   InvoiceCGSTAmount,
				   InvoiceSGSTAmount,
				   InvoiceIGSTAmount,
				   InvoiceUGSTAmount
			   )
	VALUES(
				@InvId,
				@PrId,
				@PrQty,
				@PrRate,
				@PrTaxId,
				@InvoiceCGSTAmount,
				@InvoiceSGSTAmount,
				@InvoiceIGSTAmount,
				@InvoiceUGSTAmount
		)
           
End           
GO
/****** Object:  StoredProcedure [dbo].[InsertProduct]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[InsertProduct]
(
	@PrCode varchar(50),@PrDesc varchar(500),@PrUnit varchar(10),
	@HSNID int,@TaxID int,@PrOpenBalance numeric(18,2),
	@PrPurchaseRate numeric(18,2),
	@PrSalesRate numeric(18,2)
	)
as
INSERT INTO [PrMaster]
           ([PrCode]
           ,[PrDesc]
           ,[PrUnit]
		   ,Pr_HSNId
		   ,Pr_TaxID
		   ,PrOpenBalance,PrPurchaseRate,PrSalesRate
		    )
     VALUES(@PrCode,@PrDesc,@PrUnit,@HSNID,@TaxID,@PrOpenBalance,@PrPurchaseRate,@PrSalesRate)  
GO
/****** Object:  StoredProcedure [dbo].[PrintInvoice]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[PrintInvoice](@InvId int)
as
Begin
	SELECT
	main.InvoiceId,InvoiceNo,InvoiceDate,InvoicePaID,InvoiceGrossAmount,InvoiceTaxAmount,InvoiceRoundOff,InvoiceNetAmount,InvoiceInsertData,
	InvoiceSubId,InvoicePrId,InvoicePrQty,InvoicePrRate,cast(InvoicePrQty*InvoicePrRate as numeric(18,2)) InvoiceAmount,
	InvoiceTaxId,InvoiceCGSTAmount,InvoiceSGSTAmount,InvoiceIGSTAmount,InvoiceUGSTAmount,
	cast(InvoicePrQty*InvoicePrRate as numeric(18,2))+isnull(InvoiceCGSTAmount,0)+
	isnull(InvoiceSGSTAmount,0)+isnull(InvoiceIGSTAmount,0)+isnull(InvoiceUGSTAmount,0) as InvoiceAmountWithTax,
	PrId,PrCode,PrDesc,PrUnit,Pr_HSNId,Pr_TaxID,PrOpenBalance, 
	PaName,PaAddress1,PaAddress2,PaAddress3,PaPINCode,PaGSTN,PaPAN,PaMailId,PaStateID,PaTypeID,ISNULL(PaMobileNo,'') PaMobileNo,
	TaxId,TaxName,CGSTCaption,CGSTTaxRate,SGSTCaption,SGSTTaxRate,IGSTCaption,IGSTTaxRate,UGSTCaption,UGSTTaxRate,
	 dbo.AmountToWords(InvoiceNetAmount)+' only.' as Amountinwords,StateName,StateCode,
	 HSNCode,HSNDescription,
	 CompanyName,CompanyHOAddress1,CompanyHOAddress2,CompanyHOAddress3,CompanyHOPINCode,CompanyBOAddress1,
CompanyBOAddress2,CompanyBOAddress3,CompanyBOPINCode,CompanyMobileNo,CompanyEMailId,CompanyGSTN,
CompanyBankName,CompanyBankACNo,CompanyBankIFSCCode,CompanyBankBranch,CompanyPAN

	 from dbo.InvoiceMain main INNER JOIN  InvoiceSub sub on main.InvoiceId = sub.InvoiceId
		inner join dbo.PrMaster on PrId = InvoicePrId
		inner join dbo.MaParty on PaID = InvoicePaID
		inner join dbo.MaTax on TaxId=InvoiceTaxId
		inner join dbo.MaState on StateID=PaStateID
		inner join dbo.MaHSN on HSNId=Pr_HSNId
		cross join CompanyInfo
	where main.InvoiceId=@InvId
	order by InvoiceSubId
	
	
End

 
GO
/****** Object:  StoredProcedure [dbo].[ResetData]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[SaveTaxMaster]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE Proc [dbo].[SaveTaxMaster](
 @TaxName varchar(100),
 @CGSTCaption varchar(50),
 @CGSTTaxRate numeric(18,2),
 @SGSTCaption varchar(50),
 @SGSTTaxRate  numeric(18,2),
 @IGSTCaption [varchar](50),
 @IGSTTaxRate numeric(18,2),
 @UGSTCaption [varchar](50),
 @UGSTTaxRate numeric(18,2)
 )
 as
 Begin
	Insert into MaTax(TaxName,CGSTCaption,CGSTTaxRate,SGSTCaption,SGSTTaxRate,
		IGSTCaption,IGSTTaxRate,UGSTCaption,UGSTTaxRate)
	SELECT @TaxName,@CGSTCaption,@CGSTTaxRate,@SGSTCaption,@SGSTTaxRate,
	@IGSTCaption,@IGSTTaxRate,@UGSTCaption,@UGSTTaxRate
	
 End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 11-09-2021 02:22:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE Proc [dbo].[UpdateProduct]  
(  
 @PrId int,@PrCode varchar(50),@PrDesc varchar(500),@UnitId varchar(10),  
 @HSNID int,@TaxID int,@PrOpenBalance numeric(18,2),  
 @PrPurchaseRate numeric(18,2),  
 @PrSalesRate numeric(18,2)  
   
)  
as  
Begin  
  Update PrMaster set   
  PrCode=@PrCode,  
  PrDesc=@PrDesc,  
  Pr_UnitId=@UnitId,  
  Pr_HSNId=@HSNID,  
  Pr_TaxID=@TaxID,  
  PrOpenBalance=@PrOpenBalance,  
  PrPurchaseRate=@PrPurchaseRate,  
  PrSalesRate=@PrSalesRate  
   where PrId=@PrId  
End
GO
USE [master]
GO
ALTER DATABASE [MyBill] SET  READ_WRITE 
GO
