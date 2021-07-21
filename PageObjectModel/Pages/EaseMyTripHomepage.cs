using PageObjectModel.Common;
using System;

namespace PageObjectModel.Test
{
    internal class EaseMyTripHomepage: BasePOM
    {
        public EaseMyTripHomepage()
        {
            driver.Navigate().GoToUrl("https://www.easemytrip.com/");

        }

        internal void SetDepartCity(string v)
        {
            throw new NotImplementedException();
        }

        internal void SetArrivalCity(string v)
        {
            throw new NotImplementedException();
        }

        internal void SetDepartDate(string v)
        {
            throw new NotImplementedException();
        }

        internal void Search()
        {
            throw new NotImplementedException();
        }
    }
}