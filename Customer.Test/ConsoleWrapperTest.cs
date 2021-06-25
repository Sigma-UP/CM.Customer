using Xunit;
using CustomerLib.Main;
using System.Collections.Generic;
namespace ConsoleWrapper.Test
{
    public class ConsoleWrapperTest
    {
        [Fact]
        public void ShouldReceiveCorrectValuesFromUserAndCreateAnInstanceOfCustomer()
        {
            Program.ConsoleWrapper = new MockConsoleWrapper();
            Program.Main(new string [0]);
            int lastOutputItemIdx = ((MockConsoleWrapper)(Program.ConsoleWrapper)).outputLog.Count - 1;
            Assert.Equal("Success", ((MockConsoleWrapper)(Program.ConsoleWrapper)).outputLog[lastOutputItemIdx]);

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
                if (inCount == 0)
                {
                    inputLog.Add("Till");
                    return "Till";
                }
                else if (inCount == 1)
                {
                    inputLog.Add("Lindemann");
                    return "Lindemann";
                }
                else if (inCount == 2)
                {
                    inputLog.Add("+38090");
                    return "+38090";
                }
                else if (inCount == 3)
                {
                    inputLog.Add("d@mail.com");
                    return "d@mail.com";
                }
                else if (inCount == 4)
                {
                    inputLog.Add("13,9");
                    return "13,9";
                }
                else if (inCount == 5)
                {
                    inputLog.Add("Some note");
                    return "Some note";
                }
                else
                {
                    inputLog.Add("2");
                    return "2";
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
