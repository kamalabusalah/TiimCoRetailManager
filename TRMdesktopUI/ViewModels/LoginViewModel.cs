using Caliburn.Micro;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMdesktopUI.EventModelss;
using TRMdesktopUI.Helpers;
using TRMdesktopUI.Library.Api;

namespace TRMdesktopUI.ViewModels
{
    public class LoginViewModel:Screen
    {
		private string _username;
        private string _password;
		private Library.Api.IAPIHelper _apiHelper;
		private IEventAggregator _event;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
		{
			_apiHelper= apiHelper;
			_event= events;
		}

		public string UserName
		{
			get { return _username; }
			set 
			{ 
				_username = value;
				NotifyOfPropertyChange(() => UserName);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}
				public string Password
		{
			get { return _password; }
			set 
			{
				_password = value; 
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}
		public bool IsErrorVisible
        {
			get 
			{ 
				bool output=false;
				if (ErrorMessage?.Length>0)
				{
					output= true;	
				}
				return output;
			}
			
		}

		private string _errorMessage;

		public string ErrorMessage
        {
			get { return _errorMessage; }
			set {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
				 
			    }
		}

		public bool CanLogIn
		{
			get
			{
				bool output = false;
				if (UserName?.Length > 0 && Password?.Length > 0)
				{
					output = true;
				}
				return output;
			}

		}
		public async Task LogIn()
		{
			try
			{
				ErrorMessage = "";
				var result = await _apiHelper.Authenticate(UserName, Password);
				//capture More information about the user 
				 await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
				_event.PublishOnUIThreadAsync(new LogOnEvent());
			}
			catch (Exception ex)
			{

				ErrorMessage= ex.Message;	

			}
		}
	}

   
}