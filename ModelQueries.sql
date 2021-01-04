create database OnlineArtGallery;
use OnlineArtGallery;
create table Adminbox
(
	adminId int NOT NULL PRIMARY KEY identity,
	adminFirstName nvarchar(30),
	adminLastName nvarchar(30),
	adminPassword nvarchar(30),
	adminDOB nvarchar(30),
	adminAddress nvarchar(30),
	adminCity nvarchar(30),
	adminZip nvarchar(10),
	adminState nvarchar(30),
	adminCountry nvarchar(30),
	adminCellPhone nvarchar(30), --nvarchar because cellphone is always ssame and we dont want to change it
	adminEmail nvarchar(50),
	
);



create table Member
(
	memberId int NOT NULL PRIMARY KEY identity,
	memberFirstName varchar(50),
	memberLastName nvarchar(50),
	memberPassword varchar(50),

	memberDOB nvarchar(50),
	memberAddress nvarchar(50),
	memberCity nvarchar(50),
	memberZip nvarchar(50),
	memberState nvarchar(50),
	memberCountry nvarchar(50),
	memberCellPhone nvarchar(50), --nvarchar because cellphone is always ssame and we dont want to change it
	memberEmail nvarchar(50),
	dateofjoining nvarchar(50),
	memberapprovedbyadminid_fk int FOREIGN KEY REFERENCES adminbox(adminId),
	memberSoldProducts int,
	memberBuyedProducts int,
	


);



create table AucCategories
(
	cat_id int NOT NULL PRIMARY KEY identity,
	cat_name nvarchar(30)

)
create table AuctionGallery
(
	AucId int NOT NULL PRIMARY KEY identity,
	AucTitle nvarchar(50),
	AucDescription nvarchar(500),
	AucCategory int NOT NULL foreign key references AucCategories(cat_id),
	Currentbid int,
	IsSold bit,--ds
	DateUploaded nvarchar(50),
	EndingDate nvarchar(50),
	AucPic nvarchar(max),
	ArtistId_FK int FOREIGN KEY REFERENCES Member(memberId),
	Approvedbyadminid_FK int FOREIGN KEY REFERENCES Adminbox(adminId)
	
);


create table AuctionInvoice
(
	AucInvoiceId int NOT NULL PRIMARY KEY identity,
	datesold varchar(50),

	customerid_FK int FOREIGN KEY REFERENCES Member(memberId),--get address
	artid_FK int FOREIGN KEY REFERENCES AuctionGallery(AucId),--get statingBid and artistid
	

	paymentmode varchar(50),
	approvedbyadminid_FK int FOREIGN KEY REFERENCES Adminbox(adminId),
	
);

create table ArtCategories
(
	cat_id int NOT NULL PRIMARY KEY identity,
	cat_name nvarchar(30)

)

create table ArtGallery --forFixed Priced GAllery
(
	ArtId int NOT NULL PRIMARY KEY identity,
	ArtTitle varchar(50), --name of art
	ArtDescription varchar(500),
	ArtPrice int not Null,
	ArtCategory int  NOT NULL foreign key references ArtCategories(cat_id),
	ArtPic nvarchar(max),
	
	IsSold bit, --Yes or No
	approvalDate varchar(20),
	

	artistId_FK int FOREIGN KEY REFERENCES Member(memberId),
	approvedbyadminid_FK int FOREIGN KEY REFERENCES Adminbox(adminId)
	
);



create table ArtInvoice
(
	ArtinvoiceId int NOT NULL PRIMARY KEY identity,
	datesold varchar(20),

	customerid_FK int FOREIGN KEY REFERENCES Member(memberId), --get custumerAdress from Here
	artid_FK int FOREIGN KEY REFERENCES ArtGallery(ArtId), --get artist id & price from pic
	
	paymentmode varchar(20),
	approvedbyadminid_FK int FOREIGN KEY REFERENCES Adminbox(adminId),
	
);
/*
	script to Add Table:

ALTER TABLE table_name
ADD column_name datatype; 

	script to delete Table:
ALTER TABLE table_name
DROP COLUMN column_name; 


	script to change data type of existing table
ALTER TABLE table_name
ALTER COLUMN column_name datatype; 
*/

use OnlineArtGallery;


drop table ArtInvoice;
drop table auctionInvoice;
drop table ArtGallery;
drop table ArtCategories;
drop table auctionGallery;
drop table AucCategories;
drop table member;
drop table adminbox;
 drop database OnlineArtGallery;