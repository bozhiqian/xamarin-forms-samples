﻿using System;
using System.Diagnostics;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Todo.DependencyService;
using Todo.UWP.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechUwp))]
namespace Todo.UWP.DependencyService
{
    public class TextToSpeechUwp : ITextToSpeech
    {
        // http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207057(v=vs.105).aspx
        public async void Speak(string text)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            try
            {
                var stream = await synth.SynthesizeTextToStreamAsync(text);

                var mediaElement = new MediaElement();
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
            catch (Exception pe)
            {
                Debug.WriteLine("couldn't play voice " + pe.Message);
            }
        }
    }
}