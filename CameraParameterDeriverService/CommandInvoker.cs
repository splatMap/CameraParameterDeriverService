using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Windows.Input;

namespace CameraParameterDeriverService
{
    public interface ICommandInvoker : ICommand 
    {
        // The command invoker takes a command pattern to execute command line parameters given a command type, and a set of parameters for that command. 
        
    }
}   