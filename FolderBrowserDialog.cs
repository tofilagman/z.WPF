using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z.WPF
{
    /// <summary>
    /// LJ20161215
    /// </summary>
    public class FolderBrowserDialog
    {

        private OpenFileDialog opd;
        public string SelectedPath { get; private set; }

        public FolderBrowserDialog()
        {
            opd = new OpenFileDialog();
            opd.Filter = "(Folder)|*.FOLDER";
            opd.CheckFileExists = false;
            opd.CheckPathExists = true;
            opd.Multiselect = false;
            opd.FileName = "(Folder)";
        }

        public bool ShowDialog()
        {
            if (opd.ShowDialog() == true)
            {
                if (opd.FileName.Length > 15)
                {
                    SelectedPath = opd.FileName.Substring(0, opd.FileName.Length - 15);
                    if (SelectedPath != "") return true;
                    else return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

    }
}
