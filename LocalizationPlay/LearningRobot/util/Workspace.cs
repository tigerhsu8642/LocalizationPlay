using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LearningRobot.util
{
    // Workspace
    public class Workspace
    {

        private static readonly string STORY = "story";

        private string WORKSPACE_PATH = string.Empty;

        public string getStoryPath
        {
            get {
                if (string.Empty.Equals(WORKSPACE_PATH))
                {
                    return string.Format(@"{0}\Workspace\{1}", Environment.CurrentDirectory, STORY);
                }
                return WORKSPACE_PATH; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Workspace()
        {
            WORKSPACE_PATH = string.Format(@"{0}\Workspace\{1}", Environment.CurrentDirectory, STORY);
            CreateDirectory(WORKSPACE_PATH);
        }

        /// <summary>
        /// 清空工作目录
        /// </summary>
        public void Clear()
        {
            ClearDirectory(string.Format(@"{0}\{1}", WORKSPACE_PATH, STORY));
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {

        }

        /// <summary>
        /// 创建目录
        /// </summary>
        public static void CreateDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 清空目录下的所有子目录和文件，保留目录
        /// </summary>
        public static void ClearDirectory(string dir)
        {
            Director(dir);
        }

        //清除3天前的图片文件
        public static void Director(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();

            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo.Attributes.ToString().IndexOf("ReadOnly") != -1)
                {
                    fsinfo.Attributes = FileAttributes.Normal;
                }
                if (fsinfo is DirectoryInfo)     
                {
                    Director(fsinfo.FullName);
                }
                else
                {
                    //Console.WriteLine(fsinfo.FullName);//输出文件的全部路径

                    string fName = Path.GetFileNameWithoutExtension(fsinfo.FullName).Substring(0,10);
                    DateTime begTime = DateTime.Today;
                    try
                    {
                      
                        begTime  = DateTime.ParseExact(fName, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    if (begTime != DateTime.Today)
                    {
                        int num = DateTime.Today.Subtract(begTime).Days;
                        if (num > 3)
                        {
                            fsinfo.Delete();
                        }
                    }
                }
            }
        }
    }
}
