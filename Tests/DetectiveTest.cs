using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileTypeDetective.Tests
{
    [TestFixture]
    public class DetectiveTest
    {
        String _basePath;
        FileInfo _emptyFile;
        FileInfo _pdfFile;
        FileInfo _wordFile;
        FileInfo _excelFile;
        FileInfo _jpegFile;
        FileInfo _zipFile;
        FileInfo _rarFile;
        FileInfo _rtfFile;
        FileInfo _noTypeFile;
        FileInfo _pngFile;
        FileInfo _pptFile;
        FileInfo _gifFile;
        FileInfo _exeFile;
        FileInfo _msiFile;
        private const string FilesDir = "Files";


        public static int Main(string[] args)
        {
            DetectiveTest dt = new DetectiveTest();
            dt.SetUp();
            dt.IsMsiTest();
            return 0;
        }

        [SetUp]
        protected void SetUp()
        {
            // we need to get base path of the test files 
            _basePath = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
            // remove protocol name
            _basePath = _basePath.Replace("file:\\", "");
            // add the Files directory 
            _basePath = Path.Combine(_basePath, FilesDir);

            _noTypeFile = new FileInfo(Path.Combine(_basePath, "notypeFile.xxx"));
            _emptyFile = new FileInfo(Path.Combine(_basePath, "EmptyFile.txt"));
            _pdfFile = new FileInfo(Path.Combine(_basePath, "pdfFile.pdf"));
            _wordFile = new FileInfo(Path.Combine(_basePath, "WordFile.doc"));
            _excelFile = new FileInfo(Path.Combine(_basePath, "excelFile.xls"));
            _jpegFile = new FileInfo(Path.Combine(_basePath, "jpegFile.jpg"));
            _zipFile = new FileInfo(Path.Combine(_basePath, "zipFile.zip"));
            _rarFile = new FileInfo(Path.Combine(_basePath, "rarFile.rar"));
            _rtfFile = new FileInfo(Path.Combine(_basePath, "rtfFile.rtf"));
            _pngFile = new FileInfo(Path.Combine(_basePath, "pngFile.png"));
            _pptFile = new FileInfo(Path.Combine(_basePath, "pptFile.ppt"));
            _gifFile = new FileInfo(Path.Combine(_basePath, "gif.gif"));
            _exeFile = new FileInfo(Path.Combine(_basePath, "cacheCopy.exe"));
            _msiFile = new FileInfo(Path.Combine(_basePath, "cacheCopySetup.msi"));
        }

        [Test]
        public void EmptyFileTest()
        {
            FileType empty = _emptyFile.GetFileType();
            Assert.IsNull(empty);

            empty = _emptyFile.GetFileType();
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

            noFile.GetFileType();
        }

        [Test]
        public void IsPdfTest()
        {
            Assert.IsTrue(_pdfFile.IsPdf());
            Assert.IsFalse(_noTypeFile.IsPdf());
        }

        [Test]
        public void IsWordTest()
        {
            Assert.True(_wordFile.IsWord());
            Assert.False(_noTypeFile.IsWord());
        }

        [Test]
        public void IsExcelTest()
        {
            Assert.True(_excelFile.IsExcel());
            Assert.False(_noTypeFile.IsExcel());
        }

        [Test]
        public void IsJpegTest()
        {
            Assert.IsTrue(_jpegFile.IsJpeg());
            Assert.IsFalse(_noTypeFile.IsJpeg());
        }

        [Test]
        public void IsZipTest()
        {
            Assert.IsTrue(_zipFile.IsZip());
            Assert.IsFalse(_noTypeFile.IsZip());
        }

        [Test]
        public void IsRarTest()
        {
            Assert.IsTrue(_rarFile.IsRar());
            Assert.IsFalse(_noTypeFile.IsRar());
        }


        [Test]
        public void IsRtfTest()
        {
            Assert.IsTrue(_rtfFile.IsRtf());
            Assert.IsFalse(_noTypeFile.IsRtf());

        }
        
        [Test]
        public void IsFileOfTypesCsvTest()
        {
            Assert.IsTrue( _jpegFile.isFileOfTypes("JPG,RAR,DOC,XLS") );
            Assert.IsFalse(_jpegFile.isFileOfTypes(""));
            Assert.IsFalse(_jpegFile.isFileOfTypes("RAR"));
            Assert.IsTrue(_jpegFile.isFileOfTypes("JPG"));
        }
        
        [Test]
        public void IsFileOfTypesList()
        {
            Assert.IsTrue(_jpegFile.isFileOfTypes(new List<FileType> {Detective.JPEG}));
            Assert.IsFalse(_jpegFile.isFileOfTypes(new List<FileType> {Detective.RAR}));
            Assert.IsFalse(_jpegFile.isFileOfTypes(new List<FileType>()));
            Assert.IsFalse(_jpegFile.isFileOfTypes(new List<FileType>{Detective.RTF, Detective.PDF, Detective.EXCEL}));
            Assert.IsTrue(_jpegFile.isFileOfTypes(new List<FileType> {Detective.JPEG, Detective.RTF, Detective.PDF, Detective.EXCEL}));
            
        }
        
        [Test]
        public void IsPngTest()
        {
            Assert.IsTrue(_pngFile.IsPng());
            Assert.IsFalse(_pngFile.IsPdf());
            Assert.IsFalse(_pngFile.IsJpeg());
        }
        
        [Test]
        public void IsPptTest()
        {
            Assert.IsTrue(_pptFile.IsPpt());
            Assert.IsFalse(_pptFile.IsJpeg());
            Assert.IsFalse(_pptFile.IsPng());
        }
        
        [Test]
        public void IsGifTest()
        {
            Assert.IsFalse(_gifFile.IsPdf());
            Assert.IsTrue(_gifFile.IsGif());
        }

        [Test]
        public void IsExeTest()
        {
            Assert.IsFalse(_exeFile.IsJpeg());
            Assert.IsTrue(_exeFile.IsExe());
        }

        [Test]
        public void IsMsiTest()
        {
            Assert.IsFalse(_msiFile.IsExe());
            Assert.IsTrue(_msiFile.IsMsi());
        }
    }
}
