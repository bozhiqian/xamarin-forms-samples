using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using DependencyServiceSample.DependencyService;
using DependencyServiceSample.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]

namespace DependencyServiceSample.UWP.DependencyService
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}