using System;
using System.IO;

namespace OpalCard.Interfaces {
    public interface IFolder {
        string GetFolderPath (string folderName = "OpalCard");
    }
}