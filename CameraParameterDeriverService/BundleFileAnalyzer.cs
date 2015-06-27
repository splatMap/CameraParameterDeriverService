using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace CameraParameterDeriverService
{
    public class BundleFileAnalyzer : System.IO.StreamReader, IBundleFileAnalyser
    {
        private Dictionary<string, decimal> imageParametersDictionary;
        private Dictionary<string, decimal> pointParametersDictionary;
        private ArrayList points;
        private string filePath;
        private bool isPictureBlock;
        private bool isPointBlock;
        private LineType lineType;
        private string lastLine;
        private LineType lastLineType;
        public BundleFileAnalyzer(string path) : base(path)
        {
            this.points = new ArrayList();
            this.imageParametersDictionary = new Dictionary<string, decimal>();
            this.pointParametersDictionary = new Dictionary<string, decimal>();
            this.filePath = path;
            
        }

        //analyseline takes a line and classifies it as a blank, a header, a pictureblock starter, a pointblock starter, a pictureblock end or a pointblock end
        public LineType AnalyseLine(string line)
        {
            // Parse the line to check for file header,
            

            if (line == ("NVM_V3"))
            {
                return LineType.Header;
            }
            if (string.IsNullOrWhiteSpace(line) && (this.lastLineType != (LineType.PictureBlockBody) || this.lastLineType != LineType.PointBlockBody) )
            {
                return LineType.Blank;
            }
            // This is the camera point header which comes before a point block header, the camera block should be false

            if (Convert.ToInt32(line) >= 0 && (!isPictureBlock) && (!isPointBlock))
            {
                return LineType.PictureBlockStarter;
            }

            // The line is the start of a camera block after its header, it should return the type
            



            // The file contains a number, signifies start of camera parameters block
            

        }
       

        
    }
}