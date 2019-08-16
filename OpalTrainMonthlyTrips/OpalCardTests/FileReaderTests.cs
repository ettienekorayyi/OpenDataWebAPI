using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Moq;
using NUnit.Framework;
using OpalCard.Classes;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace Tests {
    [TestFixture]
    public class FileReaderTests {
        private Mock<IFileReader> _mockFileReader;
        private string _path;

        [SetUp]
        public void Setup () {
            _mockFileReader = new Mock<IFileReader> ();
            _path = @"C:\Users\Stephen\Documents\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\OpalCardTests\DataSet\OpalTrainMonthlyTrip.csv";
        }

        [Test]
        public void OpenFile_WhenCalled_ShouldReturnRecordsFromCsvFile () {
            var expected = new FileReader ().OpenFile (_path);
            var actual = new List<OpalTicket> () {
                new OpalTicket () {
                CardType = "Adult",
                OpalTapCount = 8575135,
                Period = "July 2016",
                TrainLine = "T1 North Shore, Northern and Western Line"
                },
                new OpalTicket () {
                CardType = "Child/Youth",
                OpalTapCount = 432083,
                Period = "July 2016",
                TrainLine = "T1 North Shore, Northern and Western Line"
                }
            };
            Assert.AreEqual (expected.Select (e => e.OpalTapCount),
                actual.Select (a => a.OpalTapCount));
        }

    }
}