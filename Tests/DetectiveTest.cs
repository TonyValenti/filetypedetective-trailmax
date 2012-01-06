using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FileTypeDetective;
using System.IO;

namespace FileTypeDetective.Tests
{
    [TestFixture]
    public class DetectiveTest
    {
        String basePath;
        FileInfo emptyFile;
        FileInfo pdfFile;
        FileInfo wordFile;
        FileInfo excelFile;
        FileInfo jpegFile;
        FileInfo zipFile;
        FileInfo rarFile;
        FileInfo rtfFile;
        FileInfo noTypeFile;
        private readonly string FilesDir = "Files";

        [SetUp]
        protected void SetUp()
        {
            // we need to get base path of the test files 
            basePath = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
            // remove protocol name
            basePath = basePath.Replace("file:\\", "");
            // add the Files directory 
            basePath = Path.Combine(basePath, FilesDir);

            noTypeFile = new FileInfo(Path.Combine(basePath, "notypeFile.xxx"));
            emptyFile = new FileInfo(Path.Combine(basePath, "EmptyFile.txt"));
            pdfFile = new FileInfo(Path.Combine(basePath, "pdfFile.pdf"));
            wordFile = new FileInfo(Path.Combine(basePath, "WordFile.doc"));
            excelFile = new FileInfo(Path.Combine(basePath, "excelFile.xls"));
            jpegFile = new FileInfo(Path.Combine(basePath, "jpegFile.jpg"));
            zipFile = new FileInfo(Path.Combine(basePath, "zipFile.zip"));
            rarFile = new FileInfo(Path.Combine(basePath, "rarFile.rar"));
            rtfFile = new FileInfo(Path.Combine(basePath, "rtfFile.rtf")); 
        }

        [Test]
        public void EmptyFileTest()
        {
            FileType empty = emptyFile.GetFileType();
            Assert.IsNull(empty);

            empty = emptyFile.FullName.GetFileType();
            Assert.IsNull(empty);

        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void NoFileTest()
        {
            FileInfo noFile = new FileInfo("someLongNmame_of_file_that_does_notExists");
            if ( noFile.Exists )
            {
                Assert.Fail("Exists file that should not exist");
            }

            FileType type = noFile.GetFileType();
        }

        [Test]
        public void isPdfTest()
        {
            Assert.IsTrue(pdfFile.isPDF());
            Assert.IsFalse(noTypeFile.isPDF());
        }

        [Test]
        public void isWordTest()
        {
            Assert.True(wordFile.isWord());
            Assert.False(noTypeFile.isWord());
        }

        [Test]
        public void isExcelTest()
        {
            Assert.True(excelFile.isExcel());
            Assert.False(noTypeFile.isExcel());
        }

        [Test]
        public void isJpegTest()
        {
            Assert.IsTrue(jpegFile.isJpeg());
            Assert.IsFalse(noTypeFile.isJpeg());
        }

        [Test]
        public void isZipTest()
        {
            Assert.IsTrue(zipFile.isZip());
            Assert.IsFalse(noTypeFile.isZip());
        }

        [Test]
        public void isRarTest()
        {
            Assert.IsTrue(rarFile.isRar());
            Assert.IsFalse(noTypeFile.isRar());
        }


        [Test]
        public void isRtfTest()
        {
            Assert.IsTrue(rtfFile.isRtf());
            Assert.IsFalse(noTypeFile.isRtf());

        }

    }
}
