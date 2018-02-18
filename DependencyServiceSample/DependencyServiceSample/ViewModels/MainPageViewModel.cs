using DependencyServiceSample.DependencyService;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace DependencyServiceSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _batteryText;
        private string _deviceOrientationText;
        private ImageSource _imageSource;
        private bool _pickPictureButtonIsEnabled = true;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Dependency Service Sample";

            BatteryText = "Click for battery info";
            DeviceOrientationText = "Get Orientation";

            SpeakCommand = new DelegateCommand(Speak);
            BatteryCommand = new DelegateCommand(Battery);
            DeviceOrientationCommand = new DelegateCommand(DeviceOrientation);
            PickPictureCommand = new DelegateCommand(PickPicture, () => _pickPictureButtonIsEnabled);

            TapGestureRecognizerCommand = new DelegateCommand(PickPicture);
        }
        public DelegateCommand TapGestureRecognizerCommand { get; }
        public DelegateCommand SpeakCommand { get; }
        public DelegateCommand BatteryCommand { get; }
        public DelegateCommand DeviceOrientationCommand { get; }
        public DelegateCommand PickPictureCommand { get; }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public string BatteryText
        {
            get => _batteryText;
            set => SetProperty(ref _batteryText, value);
        }

        public string DeviceOrientationText
        {
            get => _deviceOrientationText;
            set => SetProperty(ref _deviceOrientationText, value);
        }


        private async void PickPicture()
        {
            var stream = await Xamarin.Forms.DependencyService.Get<IPicturePicker>().GetImageStreamAsync();

            if (stream != null)
            {
                ImageSource = ImageSource.FromStream(() => stream);
                _pickPictureButtonIsEnabled = false;
            }
            else
            {
                _pickPictureButtonIsEnabled = true;
            }

            PickPictureCommand.RaiseCanExecuteChanged();
        }

        private void DeviceOrientation()
        {
            var orientation = Xamarin.Forms.DependencyService.Get<IDeviceOrientation>().GetOrientation();
            switch (orientation)
            {
                case DeviceOrientations.Undefined:
                    DeviceOrientationText = "Undefined";
                    break;
                case DeviceOrientations.Landscape:
                    DeviceOrientationText = "Landscape";
                    break;
                case DeviceOrientations.Portrait:
                    DeviceOrientationText = "Portrait";
                    break;
            }
        }

        private void Battery()
        {
            var bat = Xamarin.Forms.DependencyService.Get<IBattery>();

            switch (bat.PowerSource)
            {
                case PowerSource.Battery:
                    BatteryText = "Battery - ";
                    break;
                case PowerSource.Ac:
                    BatteryText = "AC - ";
                    break;
                case PowerSource.Usb:
                    BatteryText = "USB - ";
                    break;
                case PowerSource.Wireless:
                    BatteryText = "Wireless - ";
                    break;
                case PowerSource.Other:
                default:
                    BatteryText = "Unknown - ";
                    break;
            }

            switch (bat.Status)
            {
                case BatteryStatus.Charging:
                    BatteryText += "Charging";
                    break;
                case BatteryStatus.Discharging:
                    BatteryText += "Discharging";
                    break;
                case BatteryStatus.NotCharging:
                    BatteryText += "Not Charging";
                    break;
                case BatteryStatus.Full:
                    BatteryText += "Full";
                    break;
                case BatteryStatus.Unknown:
                default:
                    BatteryText += "Unknown";
                    break;
            }
        }

        private void Speak()
        {
            Xamarin.Forms.DependencyService.Get<ITextToSpeech>().Speak("Hello from Xamarin Forms");
        }
    }
}