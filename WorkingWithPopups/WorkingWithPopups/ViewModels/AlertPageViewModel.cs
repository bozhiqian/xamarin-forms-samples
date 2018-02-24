using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using WorkingWithPopups.Events;

namespace WorkingWithPopups.ViewModels
{
    public class AlertPageViewModel : ViewModelBase
    {
        public AlertPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            AlertSimpleCommand = new DelegateCommand(AlertSimple, () => EventAggregator != null);
            AlertYesNoCommand = new DelegateCommand(AlertYesNo, () => EventAggregator != null);
        }

        private void AlertYesNo()
        {
            EventAggregator.GetEvent<AlertEvent>().Publish(new AlertEventArgs("Would you like to play a game") { Title = "Question?", Accept = "Yes", Cancel = "No" });
        }

        private void AlertSimple()
        {
            EventAggregator.GetEvent<AlertEvent>().Publish(new AlertEventArgs("You have been alerted") { Title = "Alert", Cancel = "OK" });
        }

        public DelegateCommand AlertSimpleCommand { get; }
        public DelegateCommand AlertYesNoCommand { get; }
    }
}
