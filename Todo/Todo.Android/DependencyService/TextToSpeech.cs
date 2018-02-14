using System.Collections.Generic;
using Android.Speech.Tts;
using Todo.DependencyService;
using Xamarin.Forms;
using Todo.Droid.DependencyService;

[assembly: Dependency(typeof(TextToSpeechAndroid))]
namespace Todo.Droid.DependencyService
{
    public class TextToSpeechAndroid : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _toSpeak;

        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                _toSpeak = text;
                if (_speaker == null)
                {
                    // https://forums.xamarin.com/discussion/106938/context-is-obsolete-as-of-version-2-5
                    _speaker = new TextToSpeech(Android.App.Application.Context, this);
                }
                else
                {
                    var p = new Dictionary<string, string>();
                    _speaker.Speak(_toSpeak, QueueMode.Flush, p);
                }
            }
        }

        #region IOnInitListener implementation

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                _speaker.Speak(_toSpeak, QueueMode.Flush, p);
            }
        }

        #endregion
    }
}