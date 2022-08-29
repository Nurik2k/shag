using System;
using System.Collections.Generic;
using System.Text;

namespace ls4
{
    class Account
    {
        public int AccountID { get; set; }
        public string IBAN { get; set; }
        private double Balance_;
        public double Balance {
            get
            {
                return Balance_;
            }
            set
            {
                if(value < 0)
                {
                    Balance_ = null;
                }
                else
                {
                    Balance_= value
                }
            }
        }
        public DateTime CreationDate{ get; set; }= DateTime.Now//default значение
        public int Currency { get; set; } = 1;//1-kzt, 2-usd
        public Account[] Accounts { get; set; }
        public string GetCurrencyName
        {
            get
            {
                if(Currency == 1)
                {
                    return "tenge"
                }
                else
                {
                    retrun "usd"
                }
            }
        }
        public string GetBalance
        {
            get
            {
                return string.Format("{0} {1}", Balance, GetCurrencyName); 
            }
        }
    }
