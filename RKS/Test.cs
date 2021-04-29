using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

public class TestOne
{
    [Theory]
    [InlineData("9 3", "1 3 3 3 2 2 2 1 1")]
    public void RKSTests(string x, string y)
    {
        var content = new StringBuilder();
        var writer = new StringWriter(content);
        writer.WriteLine(x);
        writer.WriteLine(y);
        // Assert.Equal()
    }
}