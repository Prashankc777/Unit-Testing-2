using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bongo.Core.Services.IServices;
using Bongo.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Bongo.Web
{
    [TestFixture]
    public class RoomBookingControllerTest
    {

        private Mock<IStudyRoomBookingService> _studyRoomBookingService;

        private RoomBookingController _bookingController;

        [SetUp]

        public void Setup()
        {
            _studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            _bookingController = new RoomBookingController(_studyRoomBookingService.Object);
        }

        [Test]
        public void IndexPage_callRequest_VerifyGetInvoked()
        {
            _bookingController.Index();
            _studyRoomBookingService.Verify(x=>x.GetAllBooking(), Times.Once);
        }









    }
}
