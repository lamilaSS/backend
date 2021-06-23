CREATE TABLE "Answer"
(
    "answerID"      uuid PRIMARY KEY NOT NULL,
    "questionID"    uuid,
    "answerContent" varchar(300),
    "isCorrect"     bit,
    "status"        int
);

CREATE TABLE "Game"
(
    "gameID"          uuid PRIMARY KEY NOT NULL,
    "gameDescription" varchar(100),
    "time"            varchar(50),
    "status"          int
);

CREATE TABLE "GameQuestion"
(
    "gameQuestionID" uuid PRIMARY KEY NOT NULL,
    "gameID"         uuid,
    "questionID"     uuid
);

CREATE TABLE "History"
(
    "historyID"     uuid PRIMARY KEY NOT NULL,
    "userID"        varchar(50),
    "gameID"        uuid,
    "score"         int,
    "session"       char(100),
    "timeFinished"  varchar(50),
    "date"          timestamptz,
    "totalQuestion" int,
    "numOfCorrect"  int,
    "scoreDetailID" uuid,
    "status"        int
);

CREATE TABLE "Lifeline"
(
    "lifelineID"  uuid PRIMARY KEY NOT NULL,
    "gameID"      uuid,
    "description" varchar(100),
    "status"      int
);

CREATE TABLE "Question"
(
    "questionID"      uuid PRIMARY KEY NOT NULL,
    "questionContent" varchar(500),
    "difficulty"      int,
    "creator"         varchar(50)
);

CREATE TABLE "ScoreDetail"
(
    "scoreDetailID" uuid PRIMARY KEY NOT NULL,
    "questionID"    uuid,
    "isCorrect"     bit
);

CREATE TABLE "User"
(
    "userID"     varchar(50) PRIMARY KEY NOT NULL,
    "phone"      char(10),
    "password"   char(60),
    "feedback"   varchar(500),
    "email"      varchar(50),
    "fullname"   varchar(50),
    "image"      varchar(100),
    "userStatus" int,
    "createDate" timestamptz
);

ALTER TABLE "Answer"
    ADD FOREIGN KEY ("questionID") REFERENCES "Question" ("questionID");

ALTER TABLE "GameQuestion"
    ADD FOREIGN KEY ("gameID") REFERENCES "Game" ("gameID");

ALTER TABLE "GameQuestion"
    ADD FOREIGN KEY ("questionID") REFERENCES "Question" ("questionID");

ALTER TABLE "History"
    ADD FOREIGN KEY ("userID") REFERENCES "User" ("userID");

ALTER TABLE "History"
    ADD FOREIGN KEY ("gameID") REFERENCES "Game" ("gameID");

ALTER TABLE "History"
    ADD FOREIGN KEY ("scoreDetailID") REFERENCES "ScoreDetail" ("scoreDetailID");

ALTER TABLE "Lifeline"
    ADD FOREIGN KEY ("gameID") REFERENCES "Game" ("gameID");

ALTER TABLE "ScoreDetail"
    ADD FOREIGN KEY ("questionID") REFERENCES "Question" ("questionID");

ALTER TABLE "ScoreDetail"
    ADD FOREIGN KEY ("questionID") REFERENCES "Game" ("gameID");
