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
    public class OpalCardControllerTests {
        private Mock<IFileReader> _mockFileReader;
        private OpalCardController _controller;

        [SetUp]
        public void Setup () {
            _mockFileReader = new Mock<IFileReader>();
            _controller = new OpalCardController( _mockFileReader.Object);
        }

        [Test]
        public void OpenFile_Verify_ShouldPassed () {
            var csvPath = Utility.GetFileFromDirectory ("OpalCard");
            var records = _controller.GetRecords();

            _mockFileReader.Verify(f => f.OpenFile(csvPath));
        }
    }
}