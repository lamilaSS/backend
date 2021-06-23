CREATE TABLE [Answer](
	[answerID] [uuid] NOT NULL PRIMARY KEY,
	[questionID] [int] NULL REFERENCES [Question](questionID),
	[answerContent] [nvarchar](200) NULL,
	[isCorrect] [bit] NULL,
	[status] [int] NULL
)
CREATE TABLE [Game](
	[gameID] [int] NOT NULL PRIMARY KEY,
	[gameDescription] [nvarchar](100) NULL,
	[time] [nvarchar](50) NULL,
	[status] [int] NULL
)

CREATE TABLE [GameQuestion](
	[gameQuestionID] [int] NOT NULL PRIMARY KEY,
	[gameID] [int] NULL REFERENCES [Game] ([gameID]),
	[questionID] [int] NULL REFERENCES [Question] ([questionID])
)
/****** Object:  Table [History]    Script Date: 6/1/2021 10:30:24 AM ******/

CREATE TABLE [History](
	[historyID] [int] NOT NULL PRIMARY KEY,
	[userID] [varchar](50) NULL REFERENCES [User] ([userID]),
	[gameID] [int] NULL REFERENCES [Game] ([gameID]),
	[score] [int] NULL,
	[session] [char](100) NULL,
	[timeFinished] [nvarchar](50) NULL,
	[date] [datetime] NULL,
	[totalQuestion] [int] NULL,
	[numOfCorrect] [int] NULL,
	[scoreDetailID] [int] NULL REFERENCES [ScoreDetail] ([scoreDetailID]),
	[status] [int] NULL
)


CREATE TABLE [Lifeline](
	[lifelineID] [int] NOT NULL PRIMARY KEY,
	[gameID] [int] NULL REFERENCES [Game] ([gameID]),
	[description] [nvarchar](100) NULL,
	[status] [int] NULL   
)

CREATE TABLE [Question](
	[questionID] [int] NOT NULL PRIMARY KEY,
	[questionContent] [nvarchar](200) NULL,
	[difficulty] [int] NULL,
	[creator] [varchar](50) NULL
)
/****** Object:  Table [ScoreDetail]    Script Date: 6/1/2021 10:30:24 AM ******/

CREATE TABLE [ScoreDetail](
	[scoreDetailID] [int] NOT NULL PRIMARY KEY,
	[questionID] [int] NULL REFERENCES [Question] ([questionID]),
	[isCorrect] [bit] NULL
)
/****** Object:  Table [User]    Script Date: 6/1/2021 10:30:24 AM ******/

CREATE TABLE [User](
	[userID] [varchar](50) NOT NULL PRIMARY KEY,
	[phone] [char](10) NULL,
	[password] [char](60) NULL,
	[feedback] [nvarchar](500) NULL,
	[email] [varchar](50) NULL,
	[fullname] [nvarchar](50) NULL,
	[image] [varchar](100) NULL,
	[userStatus] [int] NULL,
	[createDate] [datetime] NULL
)




