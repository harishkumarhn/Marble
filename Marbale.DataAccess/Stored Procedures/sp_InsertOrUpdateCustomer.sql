USE marbale 

go 

/****** Object:  StoredProcedure dbo.sp_InsertOrUpdateGame    Script Date: 6/22/2019 10:07:54 PM ******/
SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

-- DROP PROC sp_InsertOrUpdateCustomer
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE dbo.sp_InsertOrUpdateCustomer @CustomerId        INT, 
                                               @CustomerName      NVARCHAR(50), 
                                               @Address1          NVARCHAR(50), 
                                               @Address2          NVARCHAR(50), 
                                               @Address3          NVARCHAR(50), 
                                               @City              NVARCHAR(50), 
                                               @State             NVARCHAR(50), 
                                               @Pin               NVARCHAR(50), 
                                               @Country           NVARCHAR(50), 
                                               @Email             NVARCHAR(50), 
                                               @Gender            CHAR(1), 
                                               @DateOfBirth       DATETIME, 
                                               @Anniversary       DATETIME, 
                                               @ContactPhone1     NVARCHAR(50), 
                                               @ContactPhone2     NVARCHAR(50), 
                                               @Notes             NVARCHAR(max), 
                                               @LastUpdatedDate   DATETIME, 
                                               @LastUpdatedUser   NVARCHAR(50), 
                                               @MiddleName        NVARCHAR(50), 
                                               @LastName          NVARCHAR(50), 
                                               @CustomDataSetId   INT, 
                                               @Company           NVARCHAR(200), 
                                               @Designation       NVARCHAR(200), 
                                               @PhotoFileName     NVARCHAR(100), 
                                               @UniqueID          VARCHAR(100) = NULL, 
                                               @Username          NVARCHAR(50), 
                                               @FBUserId          NVARCHAR(20), 
                                               @FBAccessToken     NVARCHAR(20), 
                                               @TWAccessToken     NVARCHAR(20), 
                                               @TWAccessSecret    NVARCHAR(20), 
                                               @RightHanded       BIT = false,
                                               @TeamUser          BIT = false, 
                                               @Verified          CHAR(1) = 'N', 
                                               @Password          NVARCHAR(100), 
                                               @LastLoginTime     DATETIME, 
                                               @ExternalSystemRef NVARCHAR(50), 
                                               @IsValid           BIT, 
                                               @DownloadBatchId   INT, 
                                               @IDProofFileName   NVARCHAR(100), 
                                               @Title             NVARCHAR(20), 
											   @custId  INT OUT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      BEGIN TRAN 

      IF EXISTS (SELECT customerid 
                 FROM   customers WITH (updlock, serializable) 
                 WHERE  customerid = @CustomerId) 
        BEGIN 
            -- update statements for procedure here 
            UPDATE dbo.customers 
            SET    customername = @CustomerName, 
                   address1 = @Address1, 
                   address2 = @Address2, 
                   address3 = @Address3, 
                   city = @City, 
                   [state] = @State, 
                   country = @Country, 
                   pin = @Pin, 
                   email = @Email, 
                   dateofbirth = @DateOfBirth, 
                   gender = @Gender, 
                   anniversary = @Anniversary, 
                   contactphone1 = @ContactPhone1, 
                   contactphone2 = @ContactPhone2, 
                   notes = @Notes, 
                   lastupdateddate = @LastUpdatedDate, 
                   lastupdateduser = @LastUpdatedUser, 
                   middlename = @MiddleName, 
                   lastname = @LastName, 
                   customdatasetid = @CustomDataSetId, 
                   company = @Company, 
                   designation = @Designation, 
                   photofilename = @PhotoFileName, 
                   uniqueid = @UniqueID, 
                   username = @Username, 
                   fbuserid = @FBUserId, 
                   fbaccesstoken = @FBAccessToken, 
                   twaccesstoken = @TWAccessToken, 
                   twaccesssecret = @TWAccessSecret, 
                   righthanded = @RightHanded, 
                   teamuser = @TeamUser, 
                   verified = @Verified, 
                   [password] = @Password, 
                   lastlogintime = @LastLoginTime, 
                   externalsystemref = @ExternalSystemRef, 
                   isvalid = @IsValid, 
                   downloadbatchid = @DownloadBatchId, 
                   idprooffilename = @IDProofFileName, 
                   title = @Title 
            WHERE  customerid = @CustomerId 

			set @custId = @CustomerId
        END 
      ELSE 
        BEGIN 
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[customers] 
                        ([customername], 
                         [address1], 
                         [address2], 
                         [address3], 
                         [city], 
                         [state], 
                         [country], 
                         [pin], 
                         [email], 
                         [dateofbirth], 
                         [gender], 
                         [anniversary], 
                         [contactphone1], 
                         [contactphone2], 
                         [notes], 
                         [lastupdateddate], 
                         [lastupdateduser], 
                         [middlename], 
                         [lastname], 
                         [customdatasetid], 
                         [company], 
                         [designation], 
                         [photofilename], 
                         [guid], 
                         [uniqueid], 
                         [username], 
                         [fbuserid], 
                         [fbaccesstoken], 
                         [twaccesstoken], 
                         [twaccesssecret], 
                         [righthanded], 
                         [teamuser], 
                         [verified], 
                         [password], 
                         [lastlogintime], 
                         [externalsystemref], 
                         [isvalid], 
                         [downloadbatchid], 
                         [idprooffilename], 
                         [title]) 

            VALUES      (@CustomerName, 
                         @Address1, 
                         @Address2, 
                         @Address3, 
                         @City, 
                         @State, 
                         @Country, 
                         @Pin, 
                         @Email, 
                         @DateOfBirth, 
                         @Gender, 
                         @Anniversary, 
                         @ContactPhone1, 
                         @ContactPhone2, 
                         @Notes, 
                         @LastUpdatedDate, 
                         @LastUpdatedUser, 
                         @MiddleName, 
                         @LastName, 
                         @CustomDataSetId, 
                         @Company, 
                         @Designation, 
                         @PhotoFileName, 
                         NEWID(), 
                         @UniqueID, 
                         @Username, 
                         @FBUserId, 
                         @FBAccessToken, 
                         @TWAccessToken, 
                         @TWAccessSecret, 
                         @RightHanded, 
                         @TeamUser, 
                         @Verified, 
                         @Password, 
                         @LastLoginTime, 
                         @ExternalSystemRef, 
                         @IsValid, 
                         @DownloadBatchId, 
                         @IDProofFileName, 
                         @Title) 

						 SET @custId = (SELECT SCOPE_IDENTITY())

				
        END 

				 select @custId

      COMMIT TRAN 
  END 

go 

