using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraParameterDeriverService
{
    public class CamAndPointsStructure
    {
        private ArrayList imageParametersList;
        private ArrayList pointsArrayList;

        public CamAndPointsStructure(ArrayList imageParametersList, ArrayList pointsArrayList)
        {
            this.imageParametersList = imageParametersList;
            this.pointsArrayList = pointsArrayList;
        }
    }
}
