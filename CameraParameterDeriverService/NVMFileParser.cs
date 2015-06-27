using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Input;

namespace CameraParameterDeriverService
{
    public class NVMFileParserCommand : ICommand
    {
        public IBundleFileAnalyser NVMFileParser;
        public NVMFileParserCommand(IBundleFileAnalyser nvmFileParser)
        {
            this.NVMFileParser = nvmFileParser;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            NVMFileParser.Parse((string)parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}

// the command runs the convertNVMfile toobjectparameters