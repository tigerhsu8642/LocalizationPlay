using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.IO;

namespace LearningRobot
{
    class Music
    {
        public int musicTime{set; get;}
        public string musicName { set; get; }
        public string musicPath { set; get; }  
        //实现保存播放列表功能
        public static void WriteMusicList(string listName, ObservableCollection<Music> music)
        {
            string saveListName;
            saveListName = listName;
            StreamWriter w = new StreamWriter(saveListName,false);
            foreach (Music temp in music)
            {
                
                w.WriteLine(temp.musicPath);
                
            }
            w.Close();
        }

        //用于精简歌曲文件名称，去除目录路径
        public static string GetMusicName(string musicAllPath)
        {
            if (musicAllPath == null) return "?";
            string musicName;
            int musicLastWord=0;
            if (musicLastWord <= 0)
            {
                musicLastWord = musicAllPath.LastIndexOf("\\") + 1;
            }
            musicName = musicAllPath.Substring(musicLastWord, musicAllPath.Length - musicLastWord);
            return musicName;
        }
    } 

}
