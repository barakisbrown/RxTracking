﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:RxTracking.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MongoDB.Driver;
using RxTracking.Model;

namespace RxTracking.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        private static readonly IMongoDatabase Database;
        public const string USERS_COLL_NAME = "users";
        public const string ORDERS_COLL_NAME = "orders";
        public const string ITEMS_COLL_NAME = "items";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IUserService>())
            {
                SimpleIoc.Default.Register<IUserService, UserService>();
            }

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<UserDetailsViewModel>();
            SimpleIoc.Default.Register<OrderViewModel>();
            
            // Authentication per credentials
            var user = Properties.Settings.Default._dbUserName;
            var pass = Properties.Settings.Default._dbUserPwd;
            var server = Properties.Settings.Default._serverName;
            var dbName = Properties.Settings.Default._dbName;

            var conn = "mongodb://" + user + ":" + pass + "@" + server + "/" + dbName;
            Client = new MongoClient(conn);
            Database = Client.GetDatabase(dbName);
        }



        public static IMongoClient Client { get; }

        public static IMongoCollection<User> Users => Database.GetCollection<User>(USERS_COLL_NAME);

        public static IMongoCollection<Orders> Orders => Database.GetCollection<Orders>(ORDERS_COLL_NAME);

        public static IMongoCollection<Items> Items => Database.GetCollection<Items>(ITEMS_COLL_NAME);

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        
        public LoginViewModel MainLogin => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public UserDetailsViewModel UserDetails => ServiceLocator.Current.GetInstance<UserDetailsViewModel>();

        public OrderViewModel OrderVM => ServiceLocator.Current.GetInstance<OrderViewModel>();

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            var viewModelLocator = (ViewModelLocator)App.Current.Resources["Locator"];
            viewModelLocator.MainLogin.Cleanup();
            viewModelLocator.UserDetails.Cleanup();            
        }
    }
}