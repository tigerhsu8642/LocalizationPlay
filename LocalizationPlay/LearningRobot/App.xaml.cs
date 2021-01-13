using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using System.Windows.Threading;
using Option;

namespace LearningRobot
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static Dictionary<string, Window> _cacheWindow = new Dictionary<string, Window>();
        private Mutex _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            {
                bool ret;
                _mutex = new Mutex(true, @"com.walklake.gondor", out ret);
                if (!ret)
                {
                    Environment.Exit(0);
                }
            }

            SplashScreen screen = new SplashScreen(@"Images/boot.png");
            screen.Show(false);

            screen.Close(new TimeSpan(0, 0, 1));

            // 全局异常日志记录20180930
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Current.DispatcherUnhandledException += OnDispatcherUnhandledException;

            UpdateUpdater();
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

        private void UpdateUpdater()
        {
            string APPLI_NAME = "Updater";
            string APPLI_BAK_NAME = "Updater_bak.exe";
            string APPLI_FULLNAME = string.Format(@"{0}\{1}.exe", Environment.CurrentDirectory, APPLI_NAME);
            string APPLI_BAK_FULLNAME = string.Format(@"{0}\{1}", Environment.CurrentDirectory, APPLI_BAK_NAME);
            try
            {
                // kill updater process
                Process[] processList = Process.GetProcesses();
                foreach (Process process in processList)
                {
                    if (APPLI_NAME.Equals(process.ProcessName))
                    {
                        process.Kill();
                        break;
                    }
                }

                if (File.Exists(APPLI_BAK_FULLNAME))
                {
                    File.Delete(APPLI_FULLNAME);
                    File.Move(APPLI_BAK_FULLNAME, APPLI_FULLNAME);
                    File.Delete(APPLI_BAK_FULLNAME);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 销毁窗口
        /// </summary>
        public static void DestoryWindow()
        {
            foreach (var item in _cacheWindow)
            {
                item.Value.Close();
            }

            _cacheWindow.Clear();
        }

        /// <summary>
        /// 跳转到指定的窗口
        /// </summary>
        public static Window NavigateToWindow(string wndUri)
        {
            Window window = null;

            if (_cacheWindow.ContainsKey(wndUri))
            {
                window = _cacheWindow[wndUri];
            }
            else
            {
                window = App.Current.GetType().Assembly.CreateInstance(wndUri) as Window;
                if (window != null)
                {
                    _cacheWindow.Add(wndUri, window);
                }
            }

            return window;
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        public static void ShowDialog(string windowURI, object content = null, Window parent = null)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(windowURI))
                {
                    Window wnd = NavigateToWindow(windowURI);
                    if (wnd != null)
                    {
                        wnd.Owner = parent;
                        wnd.DataContext = content;
                        if (!wnd.IsVisible)
                        {
                            wnd.ShowDialog();
                        }
                    }
                }
            }));
        }

        /// <summary>
        /// 显示窗口
        /// </summary>
        public static void ShowWindow(string windowURI, object content = null, Window parent = null)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(windowURI))
                {
                    Window wnd = NavigateToWindow(windowURI);
                    if (wnd != null)
                    {
                        wnd.Owner = parent;
                        wnd.DataContext = content;
                        if (!wnd.IsVisible)
                        {
                            wnd.Show();
                        }
                    }
                }
            }));
        }

        /// <summary>
        /// 隐藏窗口
        /// </summary>
        public static void HideWindow(string windowURI)
        {
            App.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (!string.IsNullOrWhiteSpace(windowURI))
                {
                    Window wnd = NavigateToWindow(windowURI);
                    if (wnd != null)
                    {
                        if (wnd.IsVisible)
                        {
                            wnd.Hide();
                        }
                    }
                }
            }));
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
            lb.AppendLine(exception.HResult.ToString());  
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
                lb.AppendLine(exception.InnerException.HResult.ToString()); 
                lb.AppendLine();
            }
            lb.AppendLine("--------- End  ---------");
            lb.AppendLine();

            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dir = System.IO.Path.GetDirectoryName(location);
            string log = dir + "\\log.txt";
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
