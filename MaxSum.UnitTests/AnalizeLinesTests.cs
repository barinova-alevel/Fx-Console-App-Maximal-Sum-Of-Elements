using System.IO;
using System.Text;
using NSubstitute;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Serilog;
namespace MaxSum.UnitTests
{
    [TestFixture]
    public class AnalizeLinesTests
    {
        private SumCalculationResult _sumCalculationResult = new SumCalculationResult(0, 0, new List<int>());

        [Test]
        public void AnalizeLines_CorrectInput()
        {
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "1,2,3\nnon numeric line\n mixed 67 line\n 4, 7.2, -100\n 2.222, -4, +15");
            SumCalculationResult expectedResult = new SumCalculationResult(13.222, 5, new List<int> { 2, 3 });

            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);

            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_MaxSumIsNegativeNumber()
        {
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "non numeric line\nmixed 10000 line\n-5.09, -990\n 2, -4\n 2.8, 7.2, -100");
            SumCalculationResult expectedResult = new SumCalculationResult(-2, 4, new List<int> { 1, 2 });

            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);

            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_AllLinesNonNumeric()
        {
            //AAA
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "non numeric line\nmixed 10000 line\nnon numeric line");
            SumCalculationResult expectedResult = new SumCalculationResult(0, -1, new List<int> { 1, 2, 3 });

            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);

            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_EmptyFile()
        {
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, String.Empty);

            Assert.DoesNotThrow(() => _sumCalculationResult.AnalizeLines(path));
        }
        //file access denied
        //null pathing

        //Tear down - delete file

        private void CreateFile(string path, string content)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(path);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }
    }
}
