using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Moq;
using NUnit.Framework;

namespace Bongo.Core
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;

        private StudyRoomBookingService _bookingService;

        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRoom;


        [SetUp]
        public void SetUp()
        {
            _request = new StudyRoomBooking()
            {
                FirstName = "Ben",
                LastName = "Spark" , 
                Email = "ben@gmail.com",
                Date = DateTime.Now
            };

            _availableStudyRoom = new List<StudyRoom>()
            {
                new StudyRoom()
                {
                    Id = 10, RoomName = "Michigan", RoomNumber = "A202"
                }
            };

            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _bookingService = new StudyRoomBookingService(
                _studyRoomBookingRepoMock.Object
                , _studyRoomRepoMock.Object);
           

        }


        [TestCase]
        public void GetAllBookingInvokeMethod_CheckIfPossible()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x=>x.GetAll(null), Times.Once);
        }

        [TestCase]
        public void BookingException_NullRequest_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _bookingService.BookStudyRoom(null));

        }



    }
}
