using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgConverter;

namespace SvgConverterTest
{
    [TestClass]
    public class CommandLineTests
    {
        [TestMethod]
        public void EmptyArgsTest1()
        {
            string arg = null;
            CmdLineHandler.HandleCommandLine(arg).Should().Be(0);
        }
        [TestMethod]
        public void EmptyArgsTest2()
        {
            CmdLineHandler.HandleCommandLine("").Should().NotBe(0);
        }
        [TestMethod]
        public void HelpTest()
        {
            CmdLineHandler.HandleCommandLine("-H").Should().Be(0);
        }

        [TestMethod]
        public void DirTest()
        {
            var resultFile = ".\\images.xaml";
            if (File.Exists(resultFile))
                File.Delete(resultFile);
            CmdLineHandler.HandleCommandLine("BuildDict /inputdir:\"..\\..\\TestFiles\\\" /outputname:images /outputdir:.").Should().Be(0);
            File.Exists(resultFile).Should().BeTrue();
        }

        [TestMethod]
        public void SubDirTest()
        {
            var resultFile = ".\\images.xaml";
            if (File.Exists(resultFile))
                File.Delete(resultFile);
            CmdLineHandler.HandleCommandLine("BuildDict /inputdir:\"..\\..\\TestFiles\\Subfolder1\\\" /handleSubFolders:true /outputname:images /outputdir:.").Should().Be(0);
            File.Exists(resultFile).Should().BeTrue();
        }

    }
}
