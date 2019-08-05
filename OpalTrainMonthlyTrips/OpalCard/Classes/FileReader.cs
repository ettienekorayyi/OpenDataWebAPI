using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using OpalCard.Interfaces;
using OpalCard.Model;

namespace OpalCard.Classes {
    public class FileReader : IFileReader {
        private IFileReader _fileReader;

        public FileReader (IFileReader fileReader = null) {
            _fileReader = fileReader ?? new FileReader();
        }
        public IEnumerable<OpalTicket> OpenFile (string csvPath) {
            var list = new List<OpalTicket> ();
            // What if file is empty?
            // What if file or directory does not exists?
            using (var reader = new StreamReader (csvPath)) {
                var header = reader.ReadLine ();
                var quote = '"'; // refactor
                var regex = $"(?:,?)((?<={quote})[^{quote}]+(?={quote})|[^{quote},]+)"; // refactor

                while (!reader.EndOfStream) {
                    var line = reader.ReadLine ();
                    var values = Regex.Split (line, regex);
                    var opalTapOnTapOff = (values[3] != "nan") ? Int32.Parse (values[3].Replace (",", "")) : 0; // refactor

                    list.Add (
                        new OpalTicket {
                            CardType = values[1],
                                OpalTapCount = opalTapOnTapOff,
                                Period = values[5],
                                TrainLine = values[7]
                        });
                }
                return list;
            }
        }
    }
}