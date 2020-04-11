using System;

namespace MerchantData.Models
{
    public sealed class MerchantInfo
    {
        public int Id
        {
            get;
            set;
        }

        public string ShopName
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Location location
        {
            get;
            set;
        }

        public int LocationId
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public bool Deleted
        {
            get;
            set;
        }

        public int[] ServiceType
        {
            get;
            set;
        }

        public  bool FreeDeliveryActive 
        {
            get;
            set;
        }

        public bool HasPromoCode
        {
            get;
            set;
        }

        public DateTime StartWorkingHour
        {
            get;
            set;
        }

        public DateTime StopWorkingHour
        {
            get;
            set;
        }

        public int[] AcceptedTypeOfPayment
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public DateTime ModifiedBy
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
    }
}
