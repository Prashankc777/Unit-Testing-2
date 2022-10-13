using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyBookRepoTest
    {
        private StudyRoomBooking studyRoom_One;
        private StudyRoomBooking studyRoom_Two;
        private DbContextOptions<ApplicationDbContext> Options;

        public StudyBookRepoTest()
        {
            studyRoom_One = new StudyRoomBooking()
            {
                FirstName = "Ben1",
                LastName = "Ben12",
                Date = DateTime.Now,
                Email = "abc@gmail.com",
                BookingId = 11,
                StudyRoomId = 1
            };
            studyRoom_Two = new StudyRoomBooking()
            {
                FirstName = "Ben2",
                LastName = "Ben22",
                Date = DateTime.Now,
                Email = "abc2@gmail.com",
                BookingId = 22,
                StudyRoomId = 1
            };
        }

        [SetUp]
        public void Setup()
        {
            Options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }



        [Test]
        [Order(1)]
        public void SaveBooking_Booking_One_CheckValueFromDatabase()
        {
            //arraange
          
            //act
            using var context = new ApplicationDbContext(Options);
            var repository = new StudyRoomBookingRepository(context);
            context.Database.EnsureDeleted();
            repository.Book(studyRoom_One);
            //assert
            var bookingFromDb = context.StudyRoomBookings.FirstOrDefault();
            Assert.AreEqual(studyRoom_One , bookingFromDb);
        }

        [Test]
        [Order(2)]
        public void GetAllBooking_Booking_One_CheckValueFromDatabase()
        {
            var expectedResult = new List<StudyRoomBooking>() {studyRoom_One, studyRoom_Two};
            

            using (var context = new ApplicationDbContext(Options))
            {
                var repo = new StudyRoomBookingRepository(context);
                context.Database.EnsureDeleted();
                repo.Book(studyRoom_One);
                repo.Book(studyRoom_Two);
            }

            List<StudyRoomBooking> acutalList;
            using (var context = new ApplicationDbContext(Options))
            {
                var repo = new StudyRoomBookingRepository(context);
                acutalList = repo.GetAll(null).ToList();

            }
            CollectionAssert.AreEqual(expectedResult , acutalList , new BookingCompare());
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object? x, object? y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;
                return booking1!.BookingId != booking2!.BookingId ? 1 : 0;
            }
        }

    }
}
