﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Services.DalcFile
{
    public interface IFile
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        void ClearFile(string filename);
        bool FileExists(string filename);

    }
}
