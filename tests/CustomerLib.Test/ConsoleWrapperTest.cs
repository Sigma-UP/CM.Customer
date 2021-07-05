using Xunit;
using System.Collections.Generic;
using CustomerLib;

namespace ConsoleWrapper.Test
{
    public class ConsoleWrapperTest
    {
        [Fact]
        public void ShouldReceiveCorrectValuesFromUserAndCreateAnInstanceOfCustomer()
        {
            Program.ConsoleWrapper = new MockConsoleWrapper();
            Program.Main(new string [0]);
            int lastOutputItemIdx = ((MockConsoleWrapper)Program.ConsoleWrapper).outputLog.Count - 1;
            Assert.Equal("Success", ((MockConsoleWrapper)Program.ConsoleWrapper).outputLog[lastOutputItemIdx]);

            Program.Main(new string[0]);
            lastOutputItemIdx = ((MockConsoleWrapper)Program.ConsoleWrapper).outputLog.Count - 1;
            Assert.Equal("Fail", ((MockConsoleWrapper)Program.ConsoleWrapper).outputLog[lastOutputItemIdx]);
        }
        public class WrappedConsoleTest
        {
            [Fact]
            public void ShouldOutputCorrectString()
            {
                IConsoleWrapper consoleWrapper = new MockConsoleWrapper();
                consoleWrapper.WriteLine("Customer 1:");
                consoleWrapper.Write("Name: ");
                string FirstName = consoleWrapper.ReadLine();
                consoleWrapper.Write("Surname: ");
                string LastName = consoleWrapper.ReadLine();

                Assert.Equal("Till", ((MockConsoleWrapper)consoleWrapper).inputLog[0]);
                Assert.Equal("Lindemann", ((MockConsoleWrapper)consoleWrapper).inputLog[1]);

                Assert.Equal("Customer 1:", ((MockConsoleWrapper)consoleWrapper).outputLog[0]);
                Assert.Equal("Name: ", ((MockConsoleWrapper)consoleWrapper).outputLog[1]);
                Assert.Equal("Surname: ", ((MockConsoleWrapper)consoleWrapper).outputLog[2]);

            }
        }
        public class MockConsoleWrapper : IConsoleWrapper
        {
            public List<string> outputLog = new List<string>();
            public List<string> inputLog = new List<string>();
            int inCount = -1;

            public string ReadLine()
            {
                inCount++;
                if (inCount == 0 || inCount == 14)
                {
                    inputLog.Add("Till");
                    return "Till";
                }
                else if (inCount == 1  || inCount == 15)
                {
                    inputLog.Add("Lindemann");
                    return "Lindemann";
                }
                else if (inCount == 2  || inCount == 16)
                {
                    inputLog.Add("+38090");
                    return "+38090";
                }
                else if (inCount == 3  || inCount == 17)
                {
                    inputLog.Add("d@mail.com");
                    return "d@mail.com";
                }
                else if (inCount == 4  || inCount == 18)
                {
                    inputLog.Add("13,9");
                    return "13,9";
                }
                else if (inCount == 5  || inCount == 19)
                {
                    inputLog.Add("Some note");
                    return "Some note";
                }
                else if (inCount == 6  || inCount == 20)
                {
                    inputLog.Add("n");
                    return "n";
                }
                else if (inCount == 7  || inCount == 21)
                {
                    inputLog.Add("Line 1");
                    return "Line 1";
                }
                else if (inCount == 8  || inCount == 22)
                {
                    inputLog.Add("1");
                    return "1";
                }
                else if (inCount == 9 || inCount == 23)
                {
                    inputLog.Add("City");
                    return "City";
                }
                else if (inCount == 10  || inCount == 24)
                {
                    inputLog.Add("112233");
                    return "112233";
                }
                else if (inCount == 11 || inCount == 25)
                {
                    inputLog.Add("Ilinois");
                    return "Ilinois";
                }
                else if (inCount == 12)
                {
                    inputLog.Add("United States");
                    return "United States";
                }
                else if(inCount == 13 || inCount == 27)
                {
                    inputLog.Add("n");
                    return "n";
                }
                else
                {
                    inputLog.Add("UKRAINE EBAT");
                    return "UKRAINE EBAT";
                }
            }
            public void WriteLine(string str)
            {
                outputLog.Add(str);
            }
            public void Write(string str)
            {
                outputLog.Add(str);
            }
        }
    }
}
