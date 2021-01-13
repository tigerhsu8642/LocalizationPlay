using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Option;
using System.Windows;
using System.Windows.Threading;

namespace Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen screen = new SplashScreen(@"/Images/boot.png");
            screen.Show(false);

            screen.Close(new TimeSpan(0, 0, 1));

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Current.DispatcherUnhandledException += OnDispatcherUnhandledException;

            InitLanguage();
            base.OnStartup(e);
        }

        private void InitLanguage()
        {
            var dictionary = new ResourceDictionary();
            string language = Settings.Instance.Language;
            language = string.IsNullOrEmpty(language) ? WalklakeLanguage.CHINESE : language;
            dictionary.Source = new Uri("/Localization;component/Resources/" + language + ".xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dictionary);
        }

        /// <summary>
        /// 全局异常日志记录20180930
        /// </summary>
        #region Unexpected exception handler

        private void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
#if DEBUG
            System.Diagnostics.Debug.WriteLine(sender.ToString() + "\n" + e.ExceptionObject);
#endif
            LogExceptionInfo(exception, "AppDomain.CurrentDomain.UnhandledException");
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(e.Exception.TargetSite);
#endif
            LogExceptionInfo(e.Exception, "AppDomain.DispatcherUnhandledException");
        }

        private void LogExceptionInfo(Exception exception, string typeName = "Undefined Exception")
        {
            DisposeOnUnhandledException();
            var lb = new System.Text.StringBuilder();
            lb.AppendLine("***************************");
            lb.AppendLine("--------- Begin  ---------");
            lb.AppendLine("--------------------------");
            lb.AppendLine();
            lb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff"));
            lb.AppendLine();
            lb.AppendLine("--------------------------");
            lb.AppendLine();
            lb.AppendLine(typeName);
            lb.AppendLine();
            lb.AppendLine("[0].TargetSite");
            lb.AppendLine(exception.TargetSite.ToString());
            lb.AppendLine();
            lb.AppendLine("[1].StackTrace");
            lb.AppendLine(exception.StackTrace);
            lb.AppendLine();
            lb.AppendLine("[2].Source");
            lb.AppendLine(exception.Source);
            lb.AppendLine();
            lb.AppendLine("[3].Message");
            lb.AppendLine(exception.Message);
            lb.AppendLine();
            lb.AppendLine("[4].HResult");
            //       lb.AppendLine(exception.HResult.ToString()); // VS2015 .net Framework 4.5.2 支持，VS2010不支持 
            lb.AppendLine();
            if (exception.InnerException != null)
            {
                lb.AppendLine("--------------");
                lb.AppendLine("InnerException");
                lb.AppendLine("--------------");
                lb.AppendLine();
                lb.AppendLine("[5.0].TargetSite");
                lb.AppendLine(exception.InnerException.TargetSite.ToString());
                lb.AppendLine();
                lb.AppendLine("[5.1].StackTrace");
                lb.AppendLine(exception.InnerException.StackTrace);
                lb.AppendLine();
                lb.AppendLine("[5.2].Source");
                lb.AppendLine(exception.InnerException.Source);
                lb.AppendLine();
                lb.AppendLine("[5.3].Message");
                lb.AppendLine(exception.InnerException.Message);
                lb.AppendLine();
                lb.AppendLine("[5.4].HResult");
                //    lb.AppendLine(exception.InnerException.HResult.ToString()); // VS2015 .net Framework 4.5.2 支持，VS2010不支持
                lb.AppendLine();
            }
            lb.AppendLine("--------- End  ---------");
            lb.AppendLine();

            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dir = System.IO.Path.GetDirectoryName(location);
            string log = dir + @"\Workspace\log.txt";
            using (var sw = new System.IO.StreamWriter(log, true, System.Text.Encoding.UTF8))
            {
                sw.Write(lb.ToString());
            }
        }

        private void DisposeOnUnhandledException()
        {
        }

        #endregion
    }
}
