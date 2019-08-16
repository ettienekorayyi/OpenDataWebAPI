using System.Collections.Generic;
using System.Linq;
using System;
using Moq;
using NUnit.Framework;
using OpalCard.Classes;
using OpalCard.Interfaces;
using OpalCard.Model;
using Controllers;

namespace Tests {
    [TestFixture]
    public class FileReaderTests {
        private Mock<IFileReader> _mockFileReader;
        private string _path;
        //private List<OpalTicket> _actual;
        
        [SetUp]
        public void Setup () {
            _mockFileReader = new Mock<IFileReader>();
            _path = @"C:\Users\Stephen\Documents\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\OpalCardTests\DataSet\OpalTrainMonthlyTrip.csv";
        }

        [Test]
        public void OpenFile_WhenCalled_ShouldReturnRecordsFromCsvFile () {
            _mockFileReader.Setup (fr => fr.OpenFile (_path));
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

        [Test]
        public void OpenFile_Verify_ShouldPassed () {
            var controller = new OpalCardController(_mockFileReader.Object);
            var records = controller.GetRecords();

            _mockFileReader.Verify(f => f.OpenFile(_path));
            
        }
    }
}