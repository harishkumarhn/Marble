USE [Marbale] 

go 

/****** Object:  StoredProcedure [dbo].[sp_Insert_Discount]    Script Date: 1/13/2019 12:29:29 AM ******/ 
SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

CREATE PROC [dbo].[Sp_insert_discount] @AutomaticApply     BIT=NULL, 
                                       @CouponMendatory    BIT=NULL, 
                                       @DiscountAmount     FLOAT=NULL, 
                                       @DiscountID         INT=NULL, 
                                       @DiscountName       VARCHAR(100)=NULL, 
                                       @ActiveFlag         BIT=NULL, 
                                       @DiscountPercentage FLOAT=NULL, 
                                       @DiscountType       VARCHAR(100)=NULL, 
                                       @DisplayInPOS       BIT=NULL, 
                                       @DisplayOrder       INT=NULL, 
                                       @LastUpdatedDate    DATETIME=NULL, 
                                       @LastUpdatedUser    VARCHAR(100)=NULL, 
                                       @ManagerApproval    BIT=NULL, 
                                       @MinimumSaleAmount  FLOAT=NULL, 
                                       @MinimumUsedCredits FLOAT=NULL, 
                                       @RemarkMendatory    BIT=NULL 
AS 
  BEGIN 
      INSERT INTO discounts 
      VALUES     (@DiscountName, 
                  @DiscountPercentage, 
                  @AutomaticApply, 
                  @MinimumSaleAmount, 
                  @MinimumUsedCredits, 
                  @DisplayInPOS, 
                  1, 
                  @DisplayOrder, 
                  @ManagerApproval, 
                  @LastUpdatedDate, 
                  @LastUpdatedUser, 
                  NULL, 
                  @DiscountType, 
                  NULL, 
                  NULL, 
                  @CouponMendatory, 
                  NULL, 
                  @DiscountAmount, 
                  NULL, 
                  @RemarkMendatory ) 
  END 

go 