/*insert into table()
values ()
*/

use OnlineArtGallery;

insert into adminbox(adminFirstName, adminLastName, adminEmail, adminPassword, adminDOB, adminAddress, adminCity, adminZip, adminState, adminCountry, adminCellPhone)
values ( 'Abdullah','Mujeeb','abdullah@admin.com','admin','27-Dec-2000','Gulistan-e-Johar','Karachi','0436','Sindh','Pakistan','03462332672');


insert into  Member(memberFirstName,memberLastName,memberEmail,memberPassword,memberDOB,memberAddress,memberCity,memberZip,memberState,memberCountry,memberCellPhone,dateofjoining,memberapprovedbyadminid_fk,memberSoldProducts,memberBuyedProducts)
values ( 'Subhan','Ahmed','subhan@member.com','member','26-jan-2001','gulshan','Karachi','0876','Sindh','Pakistan','03463274321','today',1,0,0);

insert into ArtGallery(ArtTitle, ArtDescription ,ArtPrice ,ArtCategory ,ArtPic,IsSold ,approvalDate,artistId_FK ,approvedbyadminid_FK)
values ( 'Capurex','This is a good opic pic',12000,1,'~/Content/Data/Capture1.png',0,'today',1,1);
insert into ArtGallery(ArtTitle, ArtDescription ,ArtPrice ,ArtCategory ,ArtPic,IsSold ,approvalDate,artistId_FK ,approvedbyadminid_FK)
values ( 'Goku','Ultra Instinct is the best <3',9999999,1,'~/Content/Data/Goku.jpg',0,'today',1,1);

delete from ArtGallery where ArtId = 3;
insert into AuctionGallery(AucTitle, AucDescription, AucCategory, Currentbid, IsSold, DateUploaded, EndingDate, AucPic, ArtistId_FK, Approvedbyadminid_FK)
values ( '','','','','','','','','','','');

/*

	

ArtGallery(ArtTitle, ArtDescription ,ArtPrice ,ArtCategory ,ArtPic,IsSold ,approvalDate,artistId_FK ,approvedbyadminid_FK)

AuctionGallery(AucTitle, AucDescription, AucCategory, Currentbid, IsSold, DateUploaded, EndingDate, AucPic, ArtistId_FK, Approvedbyadminid_FK)
AuctionInvoice( datesold, customerid_FK, artid_FK, paymentmode, approvedbyadminid_FK)
insert into  ()
values ( '','','','','','','','','','','');



*/

insert into ArtCategories(cat_name) values ('Painting');

insert into AucCategories(cat_name) values ('Bekkar');



SELECT * FROM information_schema.tables;

select * from  Adminbox;
select * from  Member;

select * from AucCategories;
select * from ArtCategories;

select * from ArtGallery;
select * from auctionGallery;


select * from auctionInvoice;
select * from ArtInvoice;