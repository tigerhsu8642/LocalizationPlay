# LocalizationPlay
WPF开发，支持国际化语音切换的播放器

1、点击Tool.exe启动语言切换，再运行LearningRobot.exe可切换语言

2、采用静态方式切换语言资源，代码大概如下：

        private void InitLanguage()
        {
            var dictionary = new ResourceDictionary();
            string language = Settings.Instance.Language;
            language = string.IsNullOrEmpty(language) ? WalklakeLanguage.CHINESE : language;
            dictionary.Source = new Uri("/Localization;component/Resources/" + language + ".xaml", UriKind.Relative);
            Resources.MergedDictionaries.Add(dictionary);
        }
