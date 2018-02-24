using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using WorkingWithPopups.Events;

namespace WorkingWithPopups.ViewModels
{
    public class ActionSheetPageViewModel : ViewModelBase
    {
        private string _action;

        public ActionSheetPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            ActionSheetSimpleCommand = new DelegateCommand(ActionSheetSimple, () => EventAggregator != null);
            ActionSheetCancelDeleteCommand = new DelegateCommand(ActionSheetCancelDelete, () => EventAggregator != null);
        }

        public string Action
        {
            get => _action;
            set => SetProperty(ref _action, value);
        }

        private void ActionSheetCancelDelete()
        {
            EventAggregator.GetEvent<ActionSheetEvent>().Publish(new ActionSheetEventArgs()
            {
                Title = "ActionSheet: SavePhoto?",
                Cancel = "Cancel",
                Destruction = "Delete",
                Buttons = new[] { "Photo Roll", "Email" }
            });
        }

        private void ActionSheetSimple()
        {
            EventAggregator.GetEvent<ActionSheetEvent>().Publish(new ActionSheetEventArgs()
            {
                Title = "ActionSheet: Send to?",
                Cancel = "Cancel",
                Buttons = new[] { "Email", "Twitter", "Facebook" }
            });
        }

        public DelegateCommand ActionSheetSimpleCommand { get; }
        public DelegateCommand ActionSheetCancelDeleteCommand { get; }
    }
}
