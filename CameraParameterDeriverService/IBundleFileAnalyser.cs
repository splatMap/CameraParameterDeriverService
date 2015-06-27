using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraParameterDeriverService
{
    public interface IBundleFileAnalyser
    {
        CamAndPointsStructure Parse(string filename);

    }
}
