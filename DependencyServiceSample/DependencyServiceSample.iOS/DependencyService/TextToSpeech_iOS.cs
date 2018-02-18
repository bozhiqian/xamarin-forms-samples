using AVFoundation;
using DependencyServiceSample.DependencyService;
using DependencyServiceSample.iOS.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]

namespace DependencyServiceSample.iOS.DependencyService
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}