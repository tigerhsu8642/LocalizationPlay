using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace LearningRobot
{
    class Time : INotifyPropertyChanged
    {
            // These fields hold the values for the public properties.
        private int allTime = 0;
        private int seconds = 0;
        private int minutes=0;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        // The constructor is private to enforce the factory pattern.
        
        // This property represents an ID, suitable
        // for use as a primary key in a database.


        public int AllTime
        {
            get
            {
                return this.allTime;
            }

            set
            {

                if (value != this.allTime)
                {
                    this.allTime = value;
                    NotifyPropertyChanged("AllTime");
                }
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }

            set
            {
                if (value != this.seconds)
                {
                    this.seconds = value;
                    NotifyPropertyChanged("Seconds");
                }
            }
        }
        public int Minutes
        {
            get
            {
                return this.minutes;
            }

            set
            {
                if (value != this.minutes)
                {
                    this.minutes = value;
                    NotifyPropertyChanged("Minutes");
                }
            }
        }
    }

}
