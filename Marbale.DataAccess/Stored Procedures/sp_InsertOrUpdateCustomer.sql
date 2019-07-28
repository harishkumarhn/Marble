USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCustomer]    Script Date: 27/07/2019 15:24:10 ******/
DROP PROCEDURE [dbo].[sp_InsertOrUpdateCustomer]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateCustomer]    Script Date: 27/07/2019 15:24:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_InsertOrUpdateCustomer
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateCustomer] @CustomerId        INT, 
                                               @CustomerName      NVARCHAR(50) = NULL, 
                                               @Address1          NVARCHAR(50) = NULL, 
                                               @Address2          NVARCHAR(50) = NULL,  
                                               @Address3          NVARCHAR(50)= NULL, 
                                               @City              NVARCHAR(50)= NULL, 
                                               @State             NVARCHAR(50)= NULL, 
                                               @Pin               NVARCHAR(50)= NULL,  
                                               @Country           NVARCHAR(50) = NULL, 
                                               @Email             NVARCHAR(50)= NULL, 
                                               @Gender            CHAR(1), 
                                               @DateOfBirth       DATETIME = NULL, 
                                               @Anniversary       DATETIME= NULL,
                                               @ContactPhone1     NVARCHAR(50) = NULL, 
                                               @ContactPhone2     NVARCHAR(50) = NULL, 
                                               @Notes             NVARCHAR(max) = NULL, 
                                               @LastUpdatedDate   DATETIME = NULL, 
                                               @LastUpdatedUser   NVARCHAR(50) = NULL, 
                                               @MiddleName        NVARCHAR(50) = NULL,  
                                               @LastName          NVARCHAR(50) = NULL,
                                               @CustomDataSetId   INT = 0,
                                               @Company           NVARCHAR(200) = NULL, 
                                               @Designation       NVARCHAR(200) = NULL, 
                                               @PhotoFileName     NVARCHAR(100) = NULL, 
                                               @UniqueID          VARCHAR(100) = NULL, 
                                               @Username          NVARCHAR(50) = NULL, 
                                               @FBUserId          NVARCHAR(20) = NULL, 
                                               @FBAccessToken     NVARCHAR(20) = NULL, 
                                               @TWAccessToken     NVARCHAR(20) = NULL, 
                                               @TWAccessSecret    NVARCHAR(20) = NULL, 
                                               @RightHanded       BIT = false,
                                               @TeamUser          BIT = false, 
                                               @Verified          CHAR(1) = 'N', 
                                               @Password          NVARCHAR(100) = NULL, 
                                               @LastLoginTime     DATETIME = NULL, 
                                               @ExternalSystemRef NVARCHAR(50) = NULL, 
                                               @IsValid           BIT = 0, 
                                               @DownloadBatchId   INT = 0, 
                                               @IDProofFileName   NVARCHAR(100) = NULL, 
                                               @Title             NVARCHAR(20) = NULL, 
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


GO


