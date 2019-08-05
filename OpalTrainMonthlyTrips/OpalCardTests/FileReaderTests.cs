using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using OpalCard.Classes;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace Tests {
    public class FileReaderTests {
        private Mock<IFileReader> _mockFileReader;
        private string _path;
        private List<OpalTicket> _actual;
        
        [SetUp]
        public void Setup () {
            _mockFileReader = new Mock<IFileReader>();
            _path = @"C:\Users\Stephen\Documents\Visual Studio Code\C#\OpenDataWebAPI\OpalTrainMonthlyTrips\OpalCardTests\DataSet\OpalTrainMonthlyTrip.csv";
            _actual = new List<OpalTicket> () {
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
                },
                new OpalTicket () {
                    CardType = "Concession",
                    OpalTapCount = 790206,
                    Period = "July 2016",
                    TrainLine = "T1 North Shore, Northern and Western Line"
                },
                new OpalTicket () {
                    CardType = "Day Pass Child/Youth w/o SAF",
                    OpalTapCount = 0,
                    Period = "July 2016",
                    TrainLine = "T1 North Shore, Northern and Western Line"
                },
                new OpalTicket () {
                    CardType = "Day Pass Child/Youth w/o SAF",
                    OpalTapCount = 0,
                    Period = "July 2016",
                    TrainLine = "T1 North Shore, Northern and Western Line"
                },
                new OpalTicket () {
                    CardType = "Employee",
                    OpalTapCount = 101255,
                    Period = "July 2016",
                    TrainLine = "T1 North Shore, Northern and Western Line"
                }
            };
        }

        [Test]
        public void OpenFile_WhenCalled_ShouldReturnOpenCsvFile () {
            //var _mockFileReader = new Mock<IFileReader> ();
            _mockFileReader
                .Setup (fr => fr.OpenFile (_path));

            var expected = new FileReader (_mockFileReader.Object).OpenFile (_path);
            Assert.AreEqual (
                expected.Select (e => e.OpalTapCount),
                _actual.Select (a => a.OpalTapCount)
            );
        }
    }
}