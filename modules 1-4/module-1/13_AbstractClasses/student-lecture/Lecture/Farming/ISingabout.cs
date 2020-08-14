using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISingAbout
    {
        // Properties
        string Name { get; } // Always Public

        // Methods
        string MakeSoundOnce();
        string MakeSoundTwice();
    }
}
