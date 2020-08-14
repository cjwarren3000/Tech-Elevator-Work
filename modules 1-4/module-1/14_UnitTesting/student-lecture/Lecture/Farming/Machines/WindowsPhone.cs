using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface IPhoneApp
    {
        void Crash();
        string AppName { get; }
    }

    public class YouTubeApp : IPhoneApp
    {
        public string AppName { get { return "YouTube";  } }

        public void Crash()
        {
            // Not going to crash. Don't have to.
        }
    }

    public class WindowsPhone // : ISingAbout
    {
        public void BecomeObsolete()
        {

        }

        public void RunApplication(IPhoneApp app)
        {

        }
    }
}
