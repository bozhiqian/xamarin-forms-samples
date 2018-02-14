using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.DependencyService
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
