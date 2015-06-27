using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CameraParameterDeriverService
{
    public class BundleFileAnalyzer : System.IO.StreamReader, IBundleFileAnalyser
    {
        private Dictionary<string, decimal> imageParametersDictionary;
        private Dictionary<string, decimal> pointParametersDictionary;
        private ArrayList pointParametersList;
        private ArrayList imageParametersList;
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
            this.imageParametersList = new ArrayList();
            this.pointParametersList = new ArrayList();
            this.filePath = path;
            
        }


        public CamAndPointsStructure Parse(string filePath)
        {
           
            string line;// Read Each line in the file, categorise it and produce the correct data structure
            StringReader reader = new StringReader(filePath);
            while ((line = reader.ReadLine()) != null)
            {
                this.lineType = AnalyseLine(line);
                ParseLine(line);
                // check the line against the type and add the requisite response to the response object

            }
            return new CamAndPointsStructure(imageParametersList,pointParametersList);

        }


        //analyseline takes a line and classifies it as a blank, a header, a pictureblock starter, a pointblock starter, a pictureblock end or a pointblock end
        private LineType AnalyseLine(string line)
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
            return null;
        }

        private Dictionary<string,string> ParseImageLine(string line)
        {
            Dictionary<string,string> ImageParameters = new Dictionary<string, string>();
            string[] splitLine = line.Split(' ');

            ImageParameters.Add("fileName", splitLine[0]);
            ImageParameters.Add("focalLength",splitLine[1]);
            ImageParameters.Add("quaternionW", splitLine[2]);
            ImageParameters.Add("quaternionX", splitLine[3]);
            ImageParameters.Add("quaternionY", splitLine[4]);
            ImageParameters.Add("quaternionZ", splitLine[5]);
            ImageParameters.Add("cameraCenter", splitLine[6]);
            ImageParameters.Add("cameraCenter", splitLine[7]);
            ImageParameters.Add("cameraCenterZ", splitLine[8]);

            return ImageParameters;

        }

        private Dictionary<string, string> ParsePointLine(string line)
        {
            Dictionary<string,string> PointParameters = new Dictionary<string, string>();

            string[] splitLine = line.Split(' ');

            PointParameters.Add("pointX",splitLine[0]);
            PointParameters.Add("pointY", splitLine[1]);
            PointParameters.Add("pointZ", splitLine[2]);

            return PointParameters;
        } 

        private void ParseLine(string line)
        {
            switch (this.lineType.GetType().Name)
            {
                case "Header":
                {
                    break;// Read the next line, return nothing
                }

                case "Blank":
                {
                    break;
                }

                case "PictureBlockStarter":
                {
                    this.isPictureBlock = true;
                    this.isPointBlock = false;
                    break;
                }
                case "PictureBlockBody":
                {
                    imageParametersList.Add(ParseImageLine(line));
                    break;
                }
                case "PictureBlockEnd":
                {
                    this.isPictureBlock = false;
                    break;
                }
                case "PointBlockStarter":
                {
                    this.isPointBlock = true;
                    this.isPictureBlock = false;
                    break;
                }
                case "PointBlockBody":
                {
                    pointParametersList.Add(ParsePointLine(line));
                    break;
                }
                case "PointBlockEnd":
                {
                    this.isPointBlock = false;
                    break;
                }
                default:
                {
                    break;
                }
            }

        }
      
        
    }
}