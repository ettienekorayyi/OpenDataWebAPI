using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpalCard.Classes;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class OpalCardController : ControllerBase {
        private IFileReader _fileReader;
        private IFolder _folder;

        public OpalCardController (IFileReader fileReader = null, IFolder folder = null) {
            _fileReader = fileReader ?? new FileReader ();
            _folder = folder ?? new Folder();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OpalTicket>> GetRecords () {
            if (!ModelState.IsValid)
                return BadRequest ();

            string csvPath = String.Empty;
            try {
                csvPath = _folder.GetFolderPath ();
            } catch (NullReferenceException nullReferenceException) {
                Console.WriteLine (nullReferenceException.Message);
            }
            var csvFile = _fileReader.OpenFile (csvPath);
            return csvFile.ToList ();
        }

    }
}