using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModel.Test
{
    class BookTicketOnEaseMytrip
    {
        [Test]
        public void Enter_Valid_Criteria_Get_Flight_Options()
        {
            var homepage = new EaseMyTripHomepage();

            homepage.SetDepartCity("Delhi");
            homepage.SetArrivalCity("Bangalore");
            homepage.SetDepartCity("Delhi");
            homepage.SetDepartDate("10/07/2021");
            homepage.Search();



            var resultpage = new EaseMyTripResultpage();

            float price = resultpage.GetPriceofFirstOption();

            Assert.That(price, Is.LessThan(10000));

        }

    }
}
