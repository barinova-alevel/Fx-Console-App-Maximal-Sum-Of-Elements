using System.Text;
using NUnit.Framework.Legacy;
using Serilog;
namespace MaxSum.UnitTests
{
    [TestFixture]
    public class AnalizeLinesTests
    {
        SumCalculationResult _sumCalculationResult = new SumCalculationResult(0, 0, new List<int>());

        [OneTimeTearDown]
        public void Cleanup()
        {
            string path = "C:\\Temp\\UnitTests";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                Log.Information($"The directory {path} does not exist.");
            }
        }

        [Test]
        public void AnalizeLines_CorrectInput()
        {
            //Arrange
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "1,2,3\nnon numeric line\n mixed 67 line\n 4, 7.2, -100\n 2.222, -4, +15");
            SumCalculationResult expectedResult = new SumCalculationResult(13.222, 5, new List<int> { 2, 3 });

            //Act
            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);
            Log.Information($"Expected {expectedResult} {actualResult}. {DateTime.Now}");

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_MaxSumIsNegativeNumber()
        {
            //Arrange
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "non numeric line\nmixed 10000 line\n-5.09, -990\n 2, -4\n 2.8, 7.2, -100");
            SumCalculationResult expectedResult = new SumCalculationResult(-2, 4, new List<int> { 1, 2 });

            //Act
            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_AllLinesNonNumeric()
        {
            //Arrange
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, "non numeric line\nmixed 10000 line\nnon numeric line");
            SumCalculationResult expectedResult = new SumCalculationResult(0, -1, new List<int> { 1, 2, 3 });

            //Act
            SumCalculationResult actualResult = _sumCalculationResult.AnalizeLines(path);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void AnalizeLines_EmptyFile()
        {
            //Arrange
            string path = "C:\\Temp\\UnitTests\\test.txt";
            CreateFile(path, String.Empty);

            //Act & Assert
            Assert.DoesNotThrow(() => _sumCalculationResult.AnalizeLines(path));
        }

        [Test]
        public void AnalizeLines_NullPassing()
        {
            //Act & Assert
            //Assert.DoesNotThrow(() => _sumCalculationResult.AnalizeLines(null));
            ClassicAssert.NotNull(() => _sumCalculationResult.AnalizeLines(null));
        }

        [Test]
        public void AnalizeLines_UnauthorizedAccessException()
        {
            //Arrange
            _sumCalculationResult.FileWrapperField = new MockFileWrapper(true);
            string path = "C://Temp//UnitTests//TestAccess.txt";

            //Act
            CreateFile(path, String.Empty);

            //Assert
            Assert.DoesNotThrow(() => _sumCalculationResult.AnalizeLines(path));
        }

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

