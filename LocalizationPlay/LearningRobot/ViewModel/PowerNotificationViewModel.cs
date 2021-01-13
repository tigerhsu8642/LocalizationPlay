using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace LearningRobot.ViewModel
{
    class PowerNotificationViewModel : ViewModelBase
    {
        #region 命令
        private RelayCommand _closeCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand(
                    () =>
                    {
                        App.HideWindow(@"HMI.PowerNotificationView");
                    }));
            }
        }
        #endregion
    }
}
