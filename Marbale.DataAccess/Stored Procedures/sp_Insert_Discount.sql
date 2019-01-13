USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_Insert_Discount]    Script Date: 1/13/2019 12:29:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_Insert_Discount]

 
 @AutomaticApply bit=null,
   @CouponMendatory bit=null, 
  @DiscountAmount float=null, 
   @DiscountID int=null,
    @DiscountName varchar(100)=null, 
	 @ActiveFlag bit=null, 
    @DiscountPercentage float=null,
     @DiscountType varchar(100)=null,
	  @DisplayInPOS bit=null,
	   @DisplayOrder int=null, 
	   @LastUpdatedDate DateTime=null,
	    @LastUpdatedUser varchar(100)=null,
	     @ManagerApproval bit=null,
		  @MinimumSaleAmount float=null, 
		  @MinimumUsedCredits float=null, 
		  @RemarkMendatory bit=null
		  as begin 
		  insert into discounts
		  --(discount_id,discount_name,discount_percentage,automatic_apply,minimum_sale_amount,
		  --minimum_credits,display_in_POS,active_flag,sort_order,manager_approval_required,last_updated_date,
		  --last_updated_user,discount_type,CouponMandatory,DiscountAmount,RemarksMandatory)
		  values(@DiscountName,
		  @DiscountPercentage,@AutomaticApply,@MinimumSaleAmount,@MinimumUsedCredits,@DisplayInPOS,1,
		  @DisplayOrder,@ManagerApproval,@LastUpdatedDate,@LastUpdatedUser,null,@DiscountType,null,null,@CouponMendatory,null,@DiscountAmount,null,
		  @RemarkMendatory
		  )
		  end
		  
GO


