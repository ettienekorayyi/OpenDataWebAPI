using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OpalCard.Classes;
using OpalCard.Interfaces;

namespace Tests {
    [TestFixture]
    public class OpalCardControllerTests {
        private Mock<IFileReader> _mockFileReader;
        private OpalCardController _controller;

        [SetUp]
        public void Setup () {
            _mockFileReader = new Mock<IFileReader> ();
            _controller = new OpalCardController (_mockFileReader.Object);
        }

        [Test]
        public void GetRecords_WhenCalled_VerifyOpenFile () {
            var csvPath = Utility.GetFileFromDirectory ("OpalCard");
            var records = _controller.GetRecords ();

            _mockFileReader.Verify (f => f.OpenFile (csvPath));
        }

        [Test]
        public void GetRecords_InvalidModelState_ShouldReturnBadRequestResult () {
            _controller.ModelState.AddModelError ("key", "BadRequest");
            var actual = _controller.GetRecords ().Result;
            
            Assert.IsInstanceOf<BadRequestResult> (actual);
        }
    }
}