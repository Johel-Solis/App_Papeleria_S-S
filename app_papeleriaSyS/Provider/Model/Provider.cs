using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_papeleriaSyS.Provider.Model
{
    internal class Provider
    {
        #region attribute 
        private int nit;
        private string nameProvider;
        private string emailProvider;
        private int phoneNumberProvider;
        private string bank;
        private string accountNumber;

        #endregion
        #region
        public Provider()
        {
        }

        public Provider(int nit, string nameProvider, string emailProvider, int phoneNumberProvider, string bank, string accountNumber)
        {
            this.nit = nit;
            this.nameProvider = nameProvider;
            this.emailProvider = emailProvider;
            this.phoneNumberProvider = phoneNumberProvider;
            this.bank = bank;
            this.accountNumber = accountNumber;
        }
        #endregion

    }
}
