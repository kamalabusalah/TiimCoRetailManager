﻿
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TRMdesktopUI.Helpers;
using TRMdesktopUI.Library.Api;
using TRMdesktopUI.ViewModels;
using TRMDesktopUI.Library.Models;

namespace TRMdesktopUI
{
    public class Bootstrapper:BootstrapperBase
    {
        private SimpleContainer _container=new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");

        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserModel,LoggedInUserModel>()
                .Singleton<IAPIHelper, APIHelper>();

            GetType().Assembly.GetTypes()
                .Where(Type => Type.IsClass)
                .Where(Type => Type.Name.EndsWith("ViewModel")).ToList()
                
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

        }

        private void Singleton<T1, T2>()
        {
            throw new NotImplementedException();
        }

        protected override void  OnStartup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(sender, e);  
            DisplayRootViewForAsync<ShellViewModel>();  
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);

        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service); 
        }
        protected override void BuildUp(object instance)
        {
           _container.BuildUp(instance);    
        }
    }
}

