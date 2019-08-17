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
        private Mock<IFileReader> _fileReader;
        private Mock<IFolder> _folder;
        private OpalCardController _controller;

        [SetUp]
        public void Setup () {
            _fileReader = new Mock<IFileReader> ();
            _folder = new Mock<IFolder>();
            _controller = new OpalCardController (_fileReader.Object, _folder.Object);
            
        }

        [Test]
        public void GetRecords_WhenCalled_VerifyOpenFile () {
            _folder.Setup(f => f.GetFolderPath("OpalCard")).Returns(new Folder().GetFolderPath());

            var csvPath = new Folder().GetFolderPath ("OpalCard");
            var records = _controller.GetRecords ();
            
            _fileReader.Verify (f => f.OpenFile (csvPath));
        }

        [Test]
        public void GetRecords_InvalidModelState_ShouldReturnBadRequestResult () {
            _controller.ModelState.AddModelError ("key", "BadRequest");
            var actual = _controller.GetRecords ().Result;
            
            Assert.IsInstanceOf<BadRequestResult> (actual);
        }

        [Test]
        public void GetFileFromDirectory_NullPath_ShouldReturnNullReferenceException() {
            _fileReader.Setup(r => r.OpenFile(null)).Throws(new NullReferenceException());
            
            Assert.Throws<NullReferenceException>(() => _controller.GetRecords ());
        }
    }
}