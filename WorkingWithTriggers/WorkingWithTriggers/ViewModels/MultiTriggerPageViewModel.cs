using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkingWithTriggers.Behaviors;

namespace WorkingWithTriggers.ViewModels
{
    public class MultiTriggerPageViewModel : BindableBase
    {
        private string _title;
        private string _email;
        private string _mobilePhoneNumber;

        public MultiTriggerPageViewModel()
        {
            Title = "MultiTrigger";

            SaveCommand = new DelegateCommand(Save, () => IsEmailValid && IsMobilePhoneNumberValid);
        }

        private void Save()
        {

        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                IsEmailValid = EmailValidatorBehavior.IsEmailValid(_email);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsEmailValid { get; set; }

        public string MobilePhoneNumber
        {
            get => _mobilePhoneNumber;
            set
            {
                SetProperty(ref _mobilePhoneNumber, value);
                var isNumber = NumberValidationBehavior.IsNumber(_mobilePhoneNumber);
                if (_mobilePhoneNumber.Length <= 10 && isNumber)
                {
                    IsMobilePhoneNumberValid = true;
                }
                else
                {
                    IsMobilePhoneNumberValid = false;
                }
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsMobilePhoneNumberValid { get; set; }

        public DelegateCommand SaveCommand { get; }

    }
}
