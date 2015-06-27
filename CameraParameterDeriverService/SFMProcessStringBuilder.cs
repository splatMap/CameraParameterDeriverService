using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace CameraParameterDeriverService
{
    public class SFMProcessStringBuilder
    {
        private string SFMString;
        private string MatchOptions;
        private string SFMOptions;
        private string MiscOptions;
        private string MVSOption;
        private string InputDirectory;
        private string OutputDirectory;

        public SFMProcessStringBuilder()
        {
            this.SFMString = "VisualSFM sfm";
            this.MatchOptions = "";
            this.SFMOptions = "";
            this.MVSOption = "";
        }

        public void AddMatchOption(string matchOption)
        {
            this.MatchOptions = MatchOptions + "+" + matchOption;

        }

        public void AddSFMOption(string sfmOption)
        {
            this.SFMOptions = SFMOptions + "+" + sfmOption;
        }

        public void AddMiscOption(string miscOption)
        {
            this.MiscOptions = MiscOptions + "+" + miscOption;

        }

        public void AddMVSOption(string mvsOption)
        {
            this.MVSOption = MVSOption + "+" + mvsOption;

        }

        public void AddInputDirectory(string inputDirectory)
        {
            this.InputDirectory = inputDirectory;

        }

        public void AddOutputDirectory(string outputDirectory)
        {

            this.OutputDirectory = outputDirectory;
        }

        public string Build()
        {
            return SFMString+SFMOptions+MiscOptions+MVSOption+InputDirectory+OutputDirectory;

        }

    }
}