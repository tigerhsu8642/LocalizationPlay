using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Option;

namespace Tool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            initLanguageMode();
        }
        
        private void initLanguageMode()
        {
            List<ComBoxItem> language_list = new List<ComBoxItem>();
            language_list.Add(new ComBoxItem(1, "中文", WalklakeLanguage.CHINESE));
            language_list.Add(new ComBoxItem(2, "粤语", WalklakeLanguage.CANTONESE));
            language_list.Add(new ComBoxItem(1, "English", WalklakeLanguage.ENGLISH));
            language_list.Add(new ComBoxItem(2, "Spanish", WalklakeLanguage.SPANISH));

            _language_comboBox.ItemsSource = language_list;

            string default_code = Settings.Instance.Language;

            for (int index = 0; index < language_list.Count; index++)
            {
                if (default_code.Equals(language_list[index].Value))
                {
                    _language_comboBox.SelectedItem = language_list[index];
                    break;
                }
            }
        }        

        private void LanguageComboxBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComBoxItem item = _language_comboBox.SelectedItem as ComBoxItem;
            Settings.Instance.Language = item.Value;
        }        

        public class ComBoxItem
        {
            public long Id { get; private set; }
            public int Code { get; private set; }
            public string Name { get; private set; }
            public string Value { get; private set; }

            public override string ToString()
            {
                return string.Format("{0}", Name);
            }

            public ComBoxItem(int code, string name)
            {
                Code = code;
                Name = name;
            }

            public ComBoxItem(int code, string name, string value)
            {
                Code = code;
                Name = name;
                Value = value;
            }
        }
    }
}
