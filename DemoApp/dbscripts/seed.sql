\connect SampleDb
CREATE TABLE carbrand
(
    id serial PRIMARY KEY,
    name VARCHAR (250) NOT NULL,
    description VARCHAR (250) NULL
);
INSERT INTO carbrand (name, description) VALUES ('Toyota', 'Description 1');
INSERT INTO carbrand (name, description) VALUES ('Lexus', 'Description 2');
INSERT INTO carbrand (name, description) VALUES ('Subaru', 'Description 3');
INSERT INTO carbrand (name, description) VALUES ('Hyundai', 'Description 4');