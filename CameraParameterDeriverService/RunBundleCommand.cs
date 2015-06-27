using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Windows.Input;

namespace CameraParameterDeriverService
{
    public class RunBundleCommand : ICommand
    {
        private Process RunBundleProcess;
        private Dictionary<string, string> FileList;
        private String ProcessPath = "VisualSFM";
        private string processString;
        private string DirectoryPath;

        public RunBundleCommand()
        {
        }

        public bool CanExecute(object parameter)
        {

            Dictionary<string,string> fileList = (Dictionary<string, string>) parameter;
            foreach (KeyValuePair<string, string> fileInfo in FileList)
            {
                if (Path.GetExtension(fileInfo.Value) != (".jpg") || RunBundleProcess == null) ;
                {
                    return false;
                }
            }
            this.FileList = fileList;
            return true;
            // The canexecute sets whether the input values are valid and then returns true if the command can be run, the command requires valid images.
            // Check the list of files is a valid set of jpg images.
        }

        public void Execute(object parameter)
        {

            GetStandardProcessString(FileList.First().Value,"");
            Process.Start(processString);
        }

        public event EventHandler CanExecuteChanged;

        private void GetStandardProcessString(string fileDirectoryPath, string outputDirectoryPath)
        {
            SFMProcessStringBuilder builder = new SFMProcessStringBuilder();
            builder.AddInputDirectory(fileDirectoryPath);
            builder.AddOutputDirectory(outputDirectoryPath);
            this.processString = builder.Build();

        }
    }
}