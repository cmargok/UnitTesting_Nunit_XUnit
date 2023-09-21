using Base.Mocking;

namespace NUnit.TestingBase.Mocking.Fakes
{
    public class FakingFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }

}
