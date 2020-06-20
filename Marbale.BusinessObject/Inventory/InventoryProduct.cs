﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marbale.BusinessObject.Inventory
{
     public class InventoryProduct
    {
        private bool notifyingObjectIsChanged;
        private readonly object notifyingObjectIsChangedSyncRoot = new Object();

        public enum SearchByProductParameters
        {
            PRODUCT_ID = 0,
            IS_ACTIVE = 1,
            PRODUCT_NAME=2,
            PRODUCT_CODE=3,
            DESCRIPTION = 4,
            DEFAULT_LOCATION= 5
        }

        int productId;
        string code;
        string productName;
        string description;
        string remarks;
        string barCode;
        string barCode1;
        int categoryId;
        int uomId;
        int defaultVendorId;
        int defaultLocationId;
        int taxId;
        int outboundLocationId;

        double reorderPoint;
        double reorderQuantity;
        double priceInTickets;
        double masterPackQty;

        bool taxInclusiveCost;
        bool isPurchaseable;
        bool isSellable;
       
        bool isActive;
        bool isRedeemable;
        

        double innerPackQty;
        double lowerLimitCost;
        double costVariancePercentage;
        double salePrice;
        double cost;
        double upperLimitCost;
        double lastPurchasePrice;

        int turnInPriceInTickets;
         
         

        string createdBy;
        string lastUpdatedBy;
        DateTime createdDate;
        DateTime lastUpdatedDate;

        //Extra column
        int avail_Quantity;
        int allocatedQuantity;
        int storeLocationId;
        string storeRemarks;


        public InventoryProduct()
        {
            productId = -1;
            categoryId = -1;
            defaultLocationId = -1;
            uomId = -1;
            defaultVendorId = -1;
            outboundLocationId = -1;
            taxId = -1;
            turnInPriceInTickets = 0;
            isActive = false;
            isRedeemable = false;
            isSellable = false;
            isPurchaseable = false;
            
        }

        public InventoryProduct(int productId, string code, string productName, string description, string remarks, string barCode, int categoryId, int uomId, int defaultVendorId, int defaultLocationId, int taxId, int outboundLocationId, double reorderPoint, double reorderQuantity, double priceInTickets, double masterPackQty, bool taxInclusiveCost, bool isPurchaseable, bool isSellable,   bool isActive, bool isRedeemable,  double innerPackQty, double lowerLimitCost, double costVariancePercentage, double salePrice, double cost, double upperLimitCost, double lastPurchasePrice, int turnInPriceInTickets,   string createdBy, string lastUpdatedBy, DateTime createdDate, DateTime lastUpdatedDate
)
        {
            this.productName = productName;

            this.productId = productId;
            this.code = code;
            this.description = description;
            this.remarks = remarks;
            this.categoryId = categoryId;
            this.defaultLocationId = defaultLocationId;
            this.reorderPoint = reorderPoint;
            this.reorderQuantity = reorderQuantity;
            this.uomId = uomId;
            this.masterPackQty = masterPackQty;
            this.innerPackQty = innerPackQty;
            this.defaultVendorId = defaultVendorId;
            this.cost = cost;
            this.lastPurchasePrice = lastPurchasePrice;
            this.isRedeemable = isRedeemable;
            this.isSellable = isSellable;
            this.isPurchaseable = isPurchaseable;
            
            this.isActive = isActive;
            this.priceInTickets = priceInTickets;
            this.outboundLocationId = outboundLocationId;
            this.salePrice = salePrice;
            this.taxId = taxId;
            this.taxInclusiveCost = taxInclusiveCost;
            this.lowerLimitCost = lowerLimitCost;
            this.upperLimitCost = upperLimitCost;
            this.costVariancePercentage = costVariancePercentage;
           
            this.turnInPriceInTickets = turnInPriceInTickets;
         
        
            this.barCode = barCode;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;

        }

        public InventoryProduct(int productId, string code, string productName, string description, string remarks, string barCode, int categoryId, int uomId, int defaultVendorId, int defaultLocationId, int taxId, int outboundLocationId, double reorderPoint, double reorderQuantity, double priceInTickets, double masterPackQty, bool taxInclusiveCost, bool isPurchaseable, bool isSellable,  bool isActive, bool isRedeemable,  double innerPackQty, double lowerLimitCost, double costVariancePercentage, double salePrice, double cost, double upperLimitCost, double lastPurchasePrice, int turnInPriceInTickets,   string createdBy, string lastUpdatedBy, DateTime createdDate, DateTime lastUpdatedDate,string barcode1
)
        {
            this.productName = productName;

            this.productId = productId;
            this.code = code;
            this.description = description;
            this.remarks = remarks;
            this.categoryId = categoryId;
            this.defaultLocationId = defaultLocationId;
            this.reorderPoint = reorderPoint;
            this.reorderQuantity = reorderQuantity;
            this.uomId = uomId;
            this.masterPackQty = masterPackQty;
            this.innerPackQty = innerPackQty;
            this.defaultVendorId = defaultVendorId;
            this.cost = cost;
            this.lastPurchasePrice = lastPurchasePrice;
            this.isRedeemable = isRedeemable;
            this.isSellable = isSellable;
            this.isPurchaseable = isPurchaseable;

            this.isActive = isActive;
            this.priceInTickets = priceInTickets;
            this.outboundLocationId = outboundLocationId;
            this.salePrice = salePrice;
            this.taxId = taxId;
            this.taxInclusiveCost = taxInclusiveCost;
            this.lowerLimitCost = lowerLimitCost;
            this.upperLimitCost = upperLimitCost;
            this.costVariancePercentage = costVariancePercentage;

            this.turnInPriceInTickets = turnInPriceInTickets;

            
            this.barCode = barCode;
            this.barCode1 = barcode1;
            this.createdBy = createdBy;
            this.createdDate = createdDate;
            this.lastUpdatedBy = lastUpdatedBy;
            this.lastUpdatedDate = lastUpdatedDate;

        }
        public int ProductId { get { return productId; } set { productId = value; this.IsChanged = true; } }
        public string Code { get { return code; } set { code = value; this.IsChanged = true; } }
        public string Description { get { return description; } set { description = value; this.IsChanged = true; } }
        public string Remarks { get { return remarks; } set { remarks = value; this.IsChanged = true; } }
        public int CategoryId { get { return categoryId; } set { categoryId = value; this.IsChanged = true; } }
        public int DefaultLocationId { get { return defaultLocationId; } set { defaultLocationId = value; this.IsChanged = true; } }
        public double ReorderPoint { get { return reorderPoint; } set { reorderPoint = value; this.IsChanged = true; } }
        public double ReorderQuantity { get { return reorderQuantity; } set { reorderQuantity = value; this.IsChanged = true; } }
        public int UomId { get { return uomId; } set { uomId = value; this.IsChanged = true; } }
        public double MasterPackQty { get { return masterPackQty; } set { masterPackQty = value; this.IsChanged = true; } }
        public double InnerPackQty { get { return innerPackQty; } set { innerPackQty = value; this.IsChanged = true; } }
        public int DefaultVendorId { get { return defaultVendorId; } set { defaultVendorId = value; this.IsChanged = true; } }
        public double Cost { get { return cost; } set { cost = value; this.IsChanged = true; } }
        public double LastPurchasePrice { get { return lastPurchasePrice; } set { lastPurchasePrice = value; this.IsChanged = true; } }
        public bool IsRedeemable { get { return isRedeemable; } set { isRedeemable = value; this.IsChanged = true; } }
        public bool IsSellable { get { return isSellable; } set { isSellable = value; this.IsChanged = true; } }
        public bool IsPurchaseable { get { return isPurchaseable; } set { isPurchaseable = value; this.IsChanged = true; } }
     
        public bool IsActive { get { return isActive; } set { isActive = value; this.IsChanged = true; } }
        public double PriceInTickets { get { return priceInTickets; } set { priceInTickets = value; this.IsChanged = true; } }
        public int OutboundLocationId { get { return outboundLocationId; } set { outboundLocationId = value; this.IsChanged = true; } }
        public double SalePrice { get { return salePrice; } set { salePrice = value; this.IsChanged = true; } }
        public int TaxId { get { return taxId; } set { taxId = value; this.IsChanged = true; } }
        public bool TaxInclusiveCost { get { return taxInclusiveCost; } set { taxInclusiveCost = value; this.IsChanged = true; } }
        public double LowerLimitCost { get { return lowerLimitCost; } set { lowerLimitCost = value; this.IsChanged = true; } }
        public double UpperLimitCost { get { return upperLimitCost; } set { upperLimitCost = value; this.IsChanged = true; } }
        public double CostVariancePercentage { get { return costVariancePercentage; } set { costVariancePercentage = value; this.IsChanged = true; } }
        public int TurnInPriceInTickets { get { return turnInPriceInTickets; } set { turnInPriceInTickets = value; this.IsChanged = true; } }
       
        public string BarCode { get { return barCode; } set { barCode = value; this.IsChanged = true; } }
        public string BarCode1 { get { return barCode1; } set { barCode1 = value; this.IsChanged = true; } }
        public string ProductName { get { return productName; } set { productName = value; this.IsChanged = true; } }
        public string CreatedBy { get { return createdBy; } set { createdBy = value; this.IsChanged = true; } }
        public string LastUpdatedBy { get { return lastUpdatedBy; } set { lastUpdatedBy = value; this.IsChanged = true; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; this.IsChanged = true; } }
        public DateTime LastUpdatedDate { get { return lastUpdatedDate; } set { lastUpdatedDate = value; this.IsChanged = true; } }

        public int Avail_Quantity { get { return avail_Quantity; } set { avail_Quantity = value; this.IsChanged = true; } }
        public int AllocatedQuantity { get { return allocatedQuantity; } set { allocatedQuantity = value; this.IsChanged = true; } }
        public int StoreLocationId { get { return storeLocationId; } set { storeLocationId = value; this.IsChanged = true; } }
        public string StoreRemarks { get { return storeRemarks; } set { storeRemarks = value; this.IsChanged = true; } }
        

        public bool IsChanged
        {
            get
            {
                lock (notifyingObjectIsChangedSyncRoot)
                {
                    return notifyingObjectIsChanged;
                }
            }

            set
            {
                lock (notifyingObjectIsChangedSyncRoot)
                {
                    if (!Boolean.Equals(notifyingObjectIsChanged, value))
                    {
                        notifyingObjectIsChanged = value;
                    }
                }
            }
        }
        public void AcceptChanges()
        {
            this.IsChanged = false;
        }
    }
}