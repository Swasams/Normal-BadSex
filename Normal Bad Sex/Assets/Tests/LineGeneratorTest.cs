using NUnit.Framework;
using UnityEngine;


public class LineGeneratorTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void LineGeneratorTestSimplePasses()
    {

        Line lineTest = ScriptableObject.CreateInstance<Line>();
        lineTest.ProcessPauses("This is a test {1}with one second{5} pause{6}");

        Assert.AreEqual(lineTest.lineText, "This is a test with one second pause");
        Assert.AreEqual(lineTest.pauseTime.Length,3);
        Assert.AreEqual(lineTest.pauseIndexes.Length,3);
        Assert.AreEqual(lineTest.pauseIndexes[0],15);
        Assert.AreEqual(lineTest.pauseTime[0], 1f);
    }
    
}
