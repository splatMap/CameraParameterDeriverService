using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;

namespace CameraParameterDeriverService
{
    public class LineType
    {
        // sets line types,
        static LineType()
        {
        }

        public static LineType Blank;
        public static LineType Header;
        public static LineType PictureBlockStarter;
        public static LineType PictureBlockBody;
        public static LineType PictureBlockEnd;
        public static LineType PointBlockStarter;
        public static LineType PointBlockBody;
        public static LineType PointBlockEnd;
        
    }
}