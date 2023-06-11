using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgConverter;

namespace SvgConverterTest
{
    [TestClass]
    public class FileUtilsTests
    {
        [DataTestMethod]
        [DataRow(@"C:\Temp\", PathIs.Folder, @"C:\Temp\Sub", PathIs.Folder, @"Sub")]
        [DataRow(@"C:\Temp", PathIs.Folder, @"C:\Temp\Sub", PathIs.Folder, @"Sub")]
        [DataRow(@"C:\Temp", PathIs.Folder, @"C:\Temp\", PathIs.Folder, @".")]
        [DataRow(@"C:\Temp", PathIs.Folder, @"C:\", PathIs.Folder, @"..")]
        [DataRow(@"D:\Projects\SvgToXaml\WpfDemoApp\ImagesC\Svg", PathIs.Folder, @"D:\Projects\SvgToXaml\WpfDemoApp\ImagesC", PathIs.Folder, @"..")]
        [DataRow(@"C:\Temp\", PathIs.Folder, @"C:\Temp\Sub", PathIs.File, @"Sub")]
        [DataRow(@"C:\Temp", PathIs.File, @"C:\Temp\Sub", PathIs.Folder, @"Temp\Sub")]
        [DataRow(@"C:\Temp\Sub", PathIs.Folder, @"C:\Temp\file", PathIs.File, @"..\file")]
        [DataRow(@"C:\Temp", PathIs.File, @"C:\Temp", PathIs.File, @".")]
        [DataRow(@"C:\Temp", PathIs.Folder, @"C:\Temp", PathIs.Folder, @".")]
        public void MakeRelativePath(string fromPath, PathIs fromIs, string toPath, PathIs toIs, string result)
        {
            FileUtils.MakeRelativePath(fromPath, fromIs, toPath, toIs).Should().Be(result);
        }
    }
}
