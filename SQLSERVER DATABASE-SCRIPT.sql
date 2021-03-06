/****** Object:  Table [dbo].[DocCategory]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [varchar](50) NOT NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_DocCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocHospital]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocHospital](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Hospitalname] [varchar](max) NOT NULL,
	[Hospitaladdress] [varchar](max) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Otherinfo] [varchar](max) NULL,
	[mobile] [nvarchar](50) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_DocHospital] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocRegistraton]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocRegistraton](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docname] [varchar](50) NULL,
	[hospital] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[state] [varchar](50) NULL,
	[docusername] [varchar](50) NOT NULL,
	[docpassword] [varchar](50) NOT NULL,
	[regdate] [datetime] NULL,
	[Specialty] [varchar](max) NULL,
	[OtherInfo] [varchar](max) NULL,
	[uploadfile] [varchar](max) NULL,
	[hostype] [int] NULL,
	[cattype] [int] NULL,
	[approve] [int] NULL,
 CONSTRAINT [PK_DocRegistraton] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocRemedies]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocRemedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[remtype] [int] NULL,
	[remdoctor] [int] NULL,
 CONSTRAINT [PK_DocRemedies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FrontPage]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FrontPage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[header] [varchar](max) NULL,
	[textbody] [varchar](max) NULL,
	[location] [varchar](max) NULL,
	[contact] [varchar](max) NULL,
 CONSTRAINT [PK_FrontPage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RemedyTable]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RemedyTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Remedy] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](max) NULL,
	[Causes] [nvarchar](max) NULL,
	[Prevention] [nvarchar](max) NULL,
	[cattype] [int] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_RemedyTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[symptomtable]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[symptomtable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[symptom] [varchar](50) NOT NULL,
	[remedy] [int] NOT NULL,
 CONSTRAINT [PK_symptomtable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[testempcat]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[testempcat](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](50) NULL,
	[catlevel] [varchar](50) NULL,
 CONSTRAINT [PK_testempcat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[testemptable]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[testemptable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[emname] [varchar](50) NULL,
	[empemail] [varchar](50) NULL,
	[emcat] [int] NULL,
	[emlevel] [int] NULL,
 CONSTRAINT [PK_testemptable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAppoint]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAppoint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[docid] [int] NULL,
	[username] [varchar](50) NULL,
	[docname] [varchar](50) NULL,
	[dochos] [varchar](50) NULL,
	[docaddress] [varchar](50) NULL,
	[ailment] [varchar](50) NULL,
	[dateofappoint] [date] NULL,
	[docdate] [date] NULL,
	[doctime] [varchar](50) NULL,
	[timeofvisit] [varchar](50) NULL,
	[date] [date] NULL,
	[booktype] [varchar](50) NULL,
	[approve] [int] NULL,
	[treatapprove] [int] NULL,
	[otherfee] [varchar](50) NULL,
 CONSTRAINT [PK_UserAppoint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userdata]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userdata](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[surname] [nvarchar](50) NULL,
	[firstname] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[phone] [nvarchar](50) NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[regdate] [date] NULL,
	[gender] [nvarchar](20) NULL,
	[age] [int] NULL,
	[dob] [nvarchar](10) NULL,
	[maritalstatus] [nvarchar](20) NULL,
	[address] [nvarchar](50) NULL,
	[medicalhistry] [nvarchar](50) NULL,
	[otherinfo] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Userdata] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserMedHistory]    Script Date: 9/9/2019 2:36:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMedHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[docid] [int] NULL,
	[userid] [int] NULL,
	[appointid] [int] NULL,
	[ailment] [varchar](max) NULL,
	[treatment_prescribe] [varchar](max) NULL,
	[test_done] [varchar](max) NULL,
	[testresult] [varchar](max) NULL,
	[recommendation] [varchar](max) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_UserMedHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DocCategory] ON 

INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (1, N'General/Internal Medicine', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (2, N'Gynecologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (3, N'Pediatrician', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (4, N'Ophthalmologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (5, N'Dermatologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (6, N'ENT doctor', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (7, N'Orthopedic', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (8, N'Cardiologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (9, N'Neurologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (10, N'Dentist ', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (11, N'Urologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (12, N'Psychiatrist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (13, N'Pathologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (14, N'Radiologists', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (15, N'Anesthesiologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (16, N'General Surgeon', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (17, N'Oncologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (18, N'Nephrologist', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (19, N'Veterinary Doctor ', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocCategory] ([id], [CatName], [date]) VALUES (21, N'testcategory123', CAST(0xA83E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[DocCategory] OFF
SET IDENTITY_INSERT [dbo].[DocHospital] ON 

INSERT [dbo].[DocHospital] ([id], [Hospitalname], [Hospitaladdress], [State], [Otherinfo], [mobile], [date]) VALUES (1, N'Citizen Medical Centre', N'86 Norman Williams Street, Ikoyi, Lagos Nigeria', N'Lagos', N'Citizen Medical Centre is located in Ikoyi, Lagos, with top-of-the-line medical equipment and a modern fully-equipped ambulance.', N'014597234', CAST(0xB23E0B00 AS Date))
INSERT [dbo].[DocHospital] ([id], [Hospitalname], [Hospitaladdress], [State], [Otherinfo], [mobile], [date]) VALUES (2, N'mily Health Hospital', N'29 Akobi Crescent Off Ishaga Road, Surulere, Lagos Nigeria', N'Lagos', N'Family Health Hospital is a community based private health establishment that offers medical services in the areas of general clinic, specialist clinic, laboratory, scan, ECG, heart monitor and mobile health services.', N'080 33034048, 01 470 4382', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocHospital] ([id], [Hospitalname], [Hospitaladdress], [State], [Otherinfo], [mobile], [date]) VALUES (4, N'First Foundation Healthcare', N'16/24 Ikoyi Road, Ikoyi, Obalende, Lagos, Nigeria', N'LAGOS', N'First Foundation Healthcare provides improved secondary healthcare services and improves tertiary healthcare and other high-level interventions such as diagnostics centres and multi-specialty facilities.', N'01 741 8621', CAST(0xA83E0B00 AS Date))
INSERT [dbo].[DocHospital] ([id], [Hospitalname], [Hospitaladdress], [State], [Otherinfo], [mobile], [date]) VALUES (5, N'test hospital', N'victoria island ', N'Bauchi', N'cool', N'09903348921', CAST(0xB23E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[DocHospital] OFF
SET IDENTITY_INSERT [dbo].[DocRegistraton] ON 

INSERT [dbo].[DocRegistraton] ([id], [docname], [hospital], [address], [state], [docusername], [docpassword], [regdate], [Specialty], [OtherInfo], [uploadfile], [hostype], [cattype], [approve]) VALUES (1, N'Dr Doc Emeka Kalu', N'mily Health Hospital', N'29 Akobi Crescent Off Ishaga Road, Surulere, Lagos Nigeria', N'Lagos', N'doctor', N'password', CAST(0x0000A958010D4B5E AS DateTime), N'General Practitioner, medicals', N'good', NULL, 2, 1, 0)
INSERT [dbo].[DocRegistraton] ([id], [docname], [hospital], [address], [state], [docusername], [docpassword], [regdate], [Specialty], [OtherInfo], [uploadfile], [hostype], [cattype], [approve]) VALUES (2, N'Dr Manny  Rita', N'mily Health Hospital', N'29 Akobi Crescent Off Ishaga Road, Surulere, Lagos Nigeria', N'Lagos', N'doctor1', N'password1', CAST(0x0000A9A900000000 AS DateTime), N'Specialict Gynecologist', NULL, NULL, 2, 2, 0)
INSERT [dbo].[DocRegistraton] ([id], [docname], [hospital], [address], [state], [docusername], [docpassword], [regdate], [Specialty], [OtherInfo], [uploadfile], [hostype], [cattype], [approve]) VALUES (8, N'Dr Chike Kalu', N'Citizen Medical Centre', N'86 Norman Williams Street, Ikoyi, Lagos Nigeria', N'Lagos', N'doctorsabi', N'software//', CAST(0x0000A95400DB2B1C AS DateTime), N'General Practitioner, medicals', N'cool doctor', N'1619793hotel-balcony.JPG', 1, 1, 1)
SET IDENTITY_INSERT [dbo].[DocRegistraton] OFF
SET IDENTITY_INSERT [dbo].[DocRemedies] ON 

INSERT [dbo].[DocRemedies] ([id], [remtype], [remdoctor]) VALUES (1, 1, 1)
INSERT [dbo].[DocRemedies] ([id], [remtype], [remdoctor]) VALUES (2, 1, 2)
INSERT [dbo].[DocRemedies] ([id], [remtype], [remdoctor]) VALUES (3, 2, 2)
INSERT [dbo].[DocRemedies] ([id], [remtype], [remdoctor]) VALUES (4, 2, 1)
SET IDENTITY_INSERT [dbo].[DocRemedies] OFF
SET IDENTITY_INSERT [dbo].[FrontPage] ON 

INSERT [dbo].[FrontPage] ([id], [header], [textbody], [location], [contact]) VALUES (1, N'About E-App', N'Online Registration System (ORS) is a framework to link various hospitals across the country for Aadhaar based online registration and appointment system, where counter based OPD registration and appointment system through Hospital Management Information System (HMIS) has been digitalized. The application has been hosted on the cloud services of NIC. Portal facilitates online appointments with various departments of different Hospitals using eKYC data of Aadhaar number, if patient''s mobile number is registered with UIDAI. And in case mobile number is not registered with UIDAI it uses patient''s name. New Patient will get appointment as well as Unique Health Identification (UHID) number. If Aadhaar number is already linked with UHID number, then appointment number will be given and UHID will remain ', NULL, N'Mobile: 08023456789 | Email: docapp2007@gmail.com')
SET IDENTITY_INSERT [dbo].[FrontPage] OFF
SET IDENTITY_INSERT [dbo].[RemedyTable] ON 

INSERT [dbo].[RemedyTable] ([id], [Remedy], [Definition], [Causes], [Prevention], [cattype], [date]) VALUES (1, N'Malaria', N'It is transmitted to humans through the bite of the Anopheles mosquito.
Once an infected mosquito bites a human, the parasites multiply in the host''s liver before infecting and destroying red blood cells.', N'Malaria happens when a bite from the female Anopheles mosquito infects the body with Plasmodium. Only the Anopheles mosquito can transmit malaria.', N'Travelers to places where malaria is prevalent should take precautions, for example, using mosquito nets.', 1, CAST(0x0000A9BF00000000 AS DateTime))
INSERT [dbo].[RemedyTable] ([id], [Remedy], [Definition], [Causes], [Prevention], [cattype], [date]) VALUES (2, N'Diabetes', N'a disease in which the body’s ability to produce or respond to the hormone insulin is impaired, resulting in abnormal metabolism of carbohydrates and elevated levels of glucose in the blood.', N'Genetics, diet, obesity and lack of exercise may play a role in developing diabetes, especially Type 2 diabetes.', N'Sometimes a routine exam by an eye doctor or foot doctor will reveal diabetes', 1, CAST(0x0000A9BF00000000 AS DateTime))
INSERT [dbo].[RemedyTable] ([id], [Remedy], [Definition], [Causes], [Prevention], [cattype], [date]) VALUES (3, N'Migraine', N'Definition', N'feefeer', N'ewrweewe', 1, CAST(0x0000A9BF00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[RemedyTable] OFF
SET IDENTITY_INSERT [dbo].[symptomtable] ON 

INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (1, N'headache', 1)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (2, N'stooling', 1)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (3, N'weakness', 1)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (4, N'cough', 1)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (6, N'excessive thirst', 2)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (10, N'urination', 2)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (11, N'fatigue', 2)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (12, N'weight loss', 2)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (13, N'blurred vision', 2)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (14, N'dizzyness', 3)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (15, N'pounding headache', 3)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (17, N'body ache', 1)
INSERT [dbo].[symptomtable] ([id], [symptom], [remedy]) VALUES (18, N'chronic heat', 1)
SET IDENTITY_INSERT [dbo].[symptomtable] OFF
SET IDENTITY_INSERT [dbo].[testempcat] ON 

INSERT [dbo].[testempcat] ([id], [category], [catlevel]) VALUES (1, N'market', N'one')
INSERT [dbo].[testempcat] ([id], [category], [catlevel]) VALUES (2, N'sales', N'two')
SET IDENTITY_INSERT [dbo].[testempcat] OFF
SET IDENTITY_INSERT [dbo].[testemptable] ON 

INSERT [dbo].[testemptable] ([id], [emname], [empemail], [emcat], [emlevel]) VALUES (2, N'jiro', N'jir@yahoo.com', 2, NULL)
INSERT [dbo].[testemptable] ([id], [emname], [empemail], [emcat], [emlevel]) VALUES (3, N'david', N'san21@yahoo.com', 2, NULL)
INSERT [dbo].[testemptable] ([id], [emname], [empemail], [emcat], [emlevel]) VALUES (4, N'one', N'ert@yahoo.com', 1, NULL)
INSERT [dbo].[testemptable] ([id], [emname], [empemail], [emcat], [emlevel]) VALUES (5, N'erww', N'san21@yahoo.com', 1, 1)
SET IDENTITY_INSERT [dbo].[testemptable] OFF
SET IDENTITY_INSERT [dbo].[UserAppoint] ON 

INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1, 4, NULL, N'dcdcdsc fdfgf', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x903E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xA73E0B00 AS Date), N'HME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (2, 4, NULL, N'dcdcdsc fdfgf', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x9F3E0B00 AS Date), NULL, NULL, N'Evening', CAST(0xA73E0B00 AS Date), N'GME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (3, 4, NULL, N'dcdcdsc fdfgf', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x973E0B00 AS Date), NULL, NULL, N'Evening', CAST(0xA73E0B00 AS Date), N'GME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (4, 4, NULL, N'Therapy  Akande', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x973E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xA73E0B00 AS Date), N'GME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (5, 4, NULL, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x963E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xA73E0B00 AS Date), N'HME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (6, 4, NULL, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x9D3E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xA73E0B00 AS Date), N'HME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (7, 15, 1, N'Okon  Agbi', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x963E0B00 AS Date), NULL, NULL, N'Afternoon', CAST(0xA73E0B00 AS Date), N'HME', 1, 1, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (8, 15, 1, N'Okon Agbi', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0x9E3E0B00 AS Date), NULL, NULL, N'Afternoon', CAST(0xA73E0B00 AS Date), N'HME', 1, 1, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1007, 12, 2, N'Therapy  Popuola', N'Dr Manny  Rita', N'Rector Hospital', N'Rector Hospital', N'BODY PAINS ALL OVER', CAST(0xD63E0B00 AS Date), NULL, NULL, N'08:55:00 AM', CAST(0xAA3E0B00 AS Date), N'HME', 1, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1008, 12, 1, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Diabetes', CAST(0xBB3E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xAA3E0B00 AS Date), N'GME', 1, 1, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1009, 12, 1, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Malaria', CAST(0xBC3E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xAA3E0B00 AS Date), N'HME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1010, 12, 1, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Chronic body pain', CAST(0xB03E0B00 AS Date), NULL, NULL, N'Morning', CAST(0xAC3E0B00 AS Date), N'GME', 0, 0, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1011, 12, 1, N'Therapy  Popuola', N'Dr Okafor Eta', N'Rector Hospital', N'Rector Hospital', N'Complicated headache', CAST(0xD63E0B00 AS Date), CAST(0x463F0B00 AS Date), N'05:25:00 AM', N'08:51:00 AM', CAST(0xAC3E0B00 AS Date), N'HME', 0, 2, NULL)
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1012, 12, 8, N'Therapy  Popuola', N'Dr Chike Kalu', N'Citizen Medical Centre', N'Citizen Medical Centre', N'Malaria, HEADACHE, COUGH ', CAST(0xDE3E0B00 AS Date), CAST(0xD73E0B00 AS Date), N'12:53:00 PM', N'08:51:00 AM', CAST(0xB43E0B00 AS Date), N'GME', 0, 1, N'all fees from #5000.00')
INSERT [dbo].[UserAppoint] ([id], [userid], [docid], [username], [docname], [dochos], [docaddress], [ailment], [dateofappoint], [docdate], [doctime], [timeofvisit], [date], [booktype], [approve], [treatapprove], [otherfee]) VALUES (1013, 12, 8, N'Therapy  Popuola', N'Dr Chike Kalu', N'Citizen Medical Centre', N'Citizen Medical Centre', N'back pain', CAST(0xD63E0B00 AS Date), CAST(0xD63E0B00 AS Date), N'03:31:00 PM', N'03:31:00 PM', CAST(0xC83E0B00 AS Date), N'GME', 0, 1, N'Cost #5000 ')
SET IDENTITY_INSERT [dbo].[UserAppoint] OFF
SET IDENTITY_INSERT [dbo].[Userdata] ON 

INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (12, N'Popuola', N'Therapy ', N'swesdfdde@yahoo.com', N'2323234342', N'sandy222', N'software//', CAST(0xA73E0B00 AS Date), N'Male', 34, N'08/11/1970', N'Single', N'wewe  rdfdff', N'Pneumonia,Thyroid Disease,Ulcer', N'never sick', N'user')
INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (15, N'Agbi', N'Okon ', N'ssdde@yahoo.com', N'23232322', N'onemanshow2', N'software//', CAST(0xA73E0B00 AS Date), N'Male', 40, N'08/29/1980', N'Single', N'2 kadiri street main town loagos', N'Anemia,Asthma,', N'always fine', N'user')
INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (17, N'Agbi2', N'Okon1', N'ssdde@yahoo.com', N'23322323', N'onemanshow4', N'software//', CAST(0xA73E0B00 AS Date), N'Male', 53, N'08/13/2018', N'Married', N'2 okon street', N'Anemia,Asthma', N'having recurring headache', N'user')
INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (19, N'Administrator', NULL, NULL, NULL, N'admin', N'D033E22AE348AEB5660FC2140AEC35850C4DA997', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin')
INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (20, N'Administrator', NULL, NULL, NULL, N'omotola', N'kobiko', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin')
INSERT [dbo].[Userdata] ([id], [surname], [firstname], [email], [phone], [username], [password], [regdate], [gender], [age], [dob], [maritalstatus], [address], [medicalhistry], [otherinfo], [role]) VALUES (21, N'Administrator', NULL, NULL, NULL, N'admin2', N'admin2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin')
SET IDENTITY_INSERT [dbo].[Userdata] OFF
SET IDENTITY_INSERT [dbo].[UserMedHistory] ON 

INSERT [dbo].[UserMedHistory] ([id], [docid], [userid], [appointid], [ailment], [treatment_prescribe], [test_done], [testresult], [recommendation], [date]) VALUES (1, 1, 12, 7, N'Malaria', N'AMATEM', N'NONE', N'NONE', N'EAT GOOD FOOD, STAY HEALTHY', CAST(0xB13E0B00 AS Date))
INSERT [dbo].[UserMedHistory] ([id], [docid], [userid], [appointid], [ailment], [treatment_prescribe], [test_done], [testresult], [recommendation], [date]) VALUES (2, 1, 15, 8, N'Malaria', N'amatem', N'NONE', N'NONE', N'stay clean always', CAST(0xB13E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[UserMedHistory] OFF
ALTER TABLE [dbo].[testemptable]  WITH CHECK ADD  CONSTRAINT [FK_testemptable_testempcat] FOREIGN KEY([emcat])
REFERENCES [dbo].[testempcat] ([id])
GO
ALTER TABLE [dbo].[testemptable] CHECK CONSTRAINT [FK_testemptable_testempcat]
GO
ALTER TABLE [dbo].[testemptable]  WITH CHECK ADD  CONSTRAINT [FK_testemptable_testempcat1] FOREIGN KEY([emlevel])
REFERENCES [dbo].[testempcat] ([id])
GO
ALTER TABLE [dbo].[testemptable] CHECK CONSTRAINT [FK_testemptable_testempcat1]
GO
