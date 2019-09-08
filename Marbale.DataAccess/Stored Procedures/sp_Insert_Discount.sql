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
    @RemarkMendatory bit=null,      
    @Type bit=null      
    as begin   
 if not exists(select discount_id from discounts where discount_id=@DiscountID)   
 begin     
    insert into discounts      
    --(discount_id,discount_name,discount_percentage,automatic_apply,minimum_sale_amount,      
    --minimum_credits,display_in_POS,active_flag,sort_order,manager_approval_required,last_updated_date,      
    --last_updated_user,discount_type,CouponMandatory,DiscountAmount,RemarksMandatory)      
    values(@DiscountName,      
    @DiscountPercentage,@AutomaticApply,@MinimumSaleAmount,@MinimumUsedCredits,@DisplayInPOS,1,      
    @DisplayOrder,@ManagerApproval,GETDATE(),'Shridhar Naik',null,@DiscountType,null,null,@CouponMendatory,null,@DiscountAmount,null,      
    @RemarkMendatory      
    )  end  
 else   
 begin  
 update discounts set discount_name=@DiscountName,discount_percentage=@DiscountPercentage,automatic_apply=@AutomaticApply,  
 minimum_sale_amount=@MinimumSaleAmount,minimum_credits=@MinimumUsedCredits,display_in_POS=@DisplayInPOS,  
 active_flag=@ActiveFlag,sort_order=@DisplayOrder,manager_approval_required=@ManagerApproval,last_updated_date=@LastUpdatedDate,  
 last_updated_user=@LastUpdatedUser,discount_type=@DiscountType,CouponMandatory=@CouponMendatory,DiscountAmount=@DiscountAmount,  
RemarksMandatory=@RemarkMendatory where discount_id=@DiscountID  
 end  
   
     
    end 