namespace PlaygroundTests;

using Playground;

[TestClass]
public class ExampleTest
{
    [TestMethod]
    public void TestThatTestingWorks()
    {
        var output = Example.add(1, 2);
        Assert.IsTrue(output.Equals(3));
    }
}