using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Option
{
    // Settings
    public class Settings
    {
        // Device
        public enum Device
        {
            LEFT, RIGHT
        }

        #region XML文件标签
        private static readonly string OP_OPTION_XML_FILE = string.Format(@"{0}\{1}", Environment.CurrentDirectory, @"Option.xml");
        private static readonly string OP_SETTING_XML_FILE = string.Format(@"{0}\{1}", Environment.CurrentDirectory, @"Setting.xml");

        private static readonly string OP_NODE_ROOT_CONFIG = @"/robodoc/configs";
        private static readonly string OP_NODE_ROOT_LEFT = @"/robodoc/devices/left_device/";
        private static readonly string OP_NODE_ROOT_RIGHT = @"/robodoc/devices/right_device/";

        private static readonly string OP_TAG_PARAMETER = "parameter";
        //private static readonly string OP_TAG_OPTION = "option";

        private static readonly string OP_TAG_PID = "pid";
        private static readonly string OP_TAG_LOGIN = "login";

        private static readonly string OP_TAG_AUTOMODE = "auto-mode";
        private static readonly string OP_TAG_AUTOCLEAR = "auto-clear";

        private static readonly string OP_TAG_DEVLPMODE = "devlp-mode";
        private static readonly string OP_TAG_DEVLPAUTOTRG = "devlp-autotrg";
        private static readonly string OP_TAG_DEVLPSTOP4ABNORMAL = "devlp-stop4abnormal";
        private static readonly string OP_TAG_DEVLPCLEARJPG = "devlp-clearjpg";

        private static readonly string OP_TAG_DEVLPSHOWMOUTH = "devlp-showmouth";
        private static readonly string OP_TAG_DEVLPISDETAILLOG = "devlp-isDetailLog";

        private static readonly string OP_TAG_DEVLPISSHOWPOWER = "devlp-isShowPower";

        private static readonly string OP_TAG_DISPLAYLANGUAGE = "display-language";//语言选择
        private static readonly string OP_TAG_RARELANGUAGE = "rare-language";//小语种权限开关，会加载科大讯飞TTS

        private static readonly string OP_TAG_FACE_CT = "face-ct";
        private static readonly string OP_TAG_HAND_CT = "hand-ct";
        private static readonly string OP_TAG_MOUTH_CT = "mouth-ct";
        private static readonly string OP_TAG_MOUTH_ST = "mouth-st";

        private static readonly string OP_TAG_FACE_RD = "face-rd";
        private static readonly string OP_TAG_HAND_RD = "hand-rd";
        private static readonly string OP_TAG_MOUTH_RD = "mouth-rd";
        private static readonly string OP_TAG_RD_TO = "rd-to";

        private static readonly string OP_TAG_HOST = "host";
        private static readonly string OP_TAG_SALT = "salt";
        private static readonly string OP_TAG_PASSWORD = "psd";

        private static readonly string OP_TAG_SERIAL = "serial";
        private static readonly string OP_TAG_CAMERA = "camera";

        //private static readonly string OP_ARR_ENABLE = "enable";
        private static readonly string OP_ARR_OBJ = "obj";
        private static readonly string OP_ARR_IP = "ip";
        private static readonly string OP_ARR_PORT = "port";
        private static readonly string OP_ARR_VALUE = "value";

        private static readonly string OP_VALUE_ON = "on";
        private static readonly string OP_VALUE_OFF = "off";

        private static readonly string OP_VALUE_MOUTH_OPEN_ON = "on";
        private static readonly string OP_VALUE_MOUTH_OPEN_OFF = "off";
        private static readonly string OP_TAG_MOUTH_OPEN = "mouth-open";
        private static readonly string OP_TAG_GRADE = "grade";

        private static readonly string OP_VALUE_FACE = "face";
        private static readonly string OP_VALUE_MOUTH = "mouth";
        private static readonly string OP_VALUE_HAND = "hand";
        private static readonly string OP_VALUE_CARD = "card";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        protected Settings(Settings.Device device)
        {
            this.Side = device;

            if (device == Device.LEFT)
            {
                this.RootNode = OP_NODE_ROOT_LEFT;
            }
            else if (device == Device.RIGHT)
            {
                this.RootNode = OP_NODE_ROOT_RIGHT;
            }

            try
            {
                // 读取XML文件
                ReadOption(OP_OPTION_XML_FILE);
                ReadSetting(OP_SETTING_XML_FILE);
                //    ReadServerInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                FileLogUtil.WriteErrorLog(ex.ToString());
            }
        }

        #region 配置属性
        /// <summary>
        /// 设备位置
        /// </summary>
        public Device Side { get; set; }

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 加密秘钥
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 远程诊断
        /// </summary>
        public int RemoteDiagHand { get; set; }
        public int RemoteDiagMouth { get; set; }
        public int RemoteDiagFace { get; set; }
        public int RemoteDiagTimeOut { get; set; }

        /// <summary>
        /// 面部病灶识别可信度阈值
        /// </summary>
        private double _faceConfidenceThreshold;
        public double FaceConfidenceThreshold
        {
            get { return _faceConfidenceThreshold; }
            set
            {
                _faceConfidenceThreshold = value;
                SaveSetting(OP_TAG_FACE_CT, String.Format("{0:0.00}", value));
            }
        }

        /// <summary>
        /// 手部病灶识别可信度阈值
        /// </summary>
        private double _handConfidenceThreshold;
        public double HandConfidenceThreshold
        {
            get { return _handConfidenceThreshold; }
            set
            {
                _handConfidenceThreshold = value;
                SaveSetting(OP_TAG_HAND_CT, String.Format("{0:0.00}", value));
            }
        }

        /// <summary>
        /// 口腔病灶识别可信度阈值
        /// </summary>
        private double _mouthConfidenceThreshold;
        public double MouthConfidenceThreshold
        {
            get { return _mouthConfidenceThreshold; }
            set
            {
                _mouthConfidenceThreshold = value;
                SaveSetting(OP_TAG_MOUTH_CT, String.Format("{0:0.00}", value));
            }
        }

        public string PortName { get; set; }

        public string FaceCameraIP { get; set; }
        public int FaceCameraPort { get; set; }

        public string MouthCameraIP { get; set; }
        public int MouthCameraPort { get; set; }

        public string HandCameraIP { get; set; }
        public int HandCameraPort { get; set; }

        public string CardCameraIP { get; set; }
        public int CardCameraPort { get; set; }

        /// <summary>
        /// 设置项 -- 自动、手动模式
        /// </summary>
        private static bool _autoMode;
        public bool AutoMode
        {
            get { return _autoMode; }
            set
            {
                if (_autoMode != value)
                {
                    _autoMode = value;
                    SaveSetting(OP_TAG_AUTOMODE, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 是否显示电量
        /// </summary>
        private static bool _isShowPower = true;
        public bool IsShowPower
        {
            get { return _isShowPower; }
            set
            {
                if (_isShowPower != value)
                {
                    _isShowPower = value;
                    SaveSetting(OP_TAG_DEVLPISSHOWPOWER, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        private static bool _isAddOpenMouth;
        public bool IsAddOpenMouth
        {
            get { return _isAddOpenMouth; }

            set
            {
                if (_isAddOpenMouth != value)
                {
                    _isAddOpenMouth = value;
                    SaveSetting(OP_TAG_MOUTH_OPEN, value ? OP_VALUE_MOUTH_OPEN_ON : OP_VALUE_MOUTH_OPEN_OFF);
                }
            }
        }

        private static int gradeValue;
        public int GradeValue
        {
            get { return gradeValue; }

            set
            {
                gradeValue = value;
                SaveSetting(OP_TAG_GRADE, value.ToString());
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式
        /// </summary>
        private static bool _isDevlpMode;
        public bool IsDevlpMode
        {
            get { return _isDevlpMode; }
            set
            {
                if (_isDevlpMode != value)
                {
                    _isDevlpMode = value;
                    SaveSetting(OP_TAG_DEVLPMODE, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式，异常情况是否停止
        /// </summary>
        private static bool _devlpStop4Abnormal;
        public bool DevlpStop4Abnormal
        {
            get { return _devlpStop4Abnormal; }
            set
            {
                if (_devlpStop4Abnormal != value)
                {
                    _devlpStop4Abnormal = value;
                    SaveSetting(OP_TAG_DEVLPSTOP4ABNORMAL, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式，是否触发自动检查
        /// </summary>
        private static bool _devlpaAutotrg;
        public bool DevlpaAutotrg
        {
            get { return _devlpaAutotrg; }
            set
            {
                if (_devlpaAutotrg != value)
                {
                    _devlpaAutotrg = value;
                    SaveSetting(OP_TAG_DEVLPAUTOTRG, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式，自动清理测试图片
        /// </summary>
        private static bool _devlpaClearjpg;
        public bool DevlpaClearjpg
        {
            get { return _devlpaClearjpg; }
            set
            {
                if (_devlpaClearjpg != value)
                {
                    _devlpaClearjpg = value;
                    SaveSetting(OP_TAG_DEVLPCLEARJPG, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式高级，是否显示口腔框框
        /// </summary>
        private static bool _devlpaShowmouth;
        public bool DevlpaShowmouth
        {
            get { return _devlpaShowmouth; }
            set
            {
                if (_devlpaShowmouth != value)
                {
                    _devlpaShowmouth = value;
                    SaveSetting(OP_TAG_DEVLPSHOWMOUTH, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 语言选择
        /// </summary>
        private static string _language = WalklakeLanguage.CHINESE;
        public string Language
        {
            get { return _language; }
            set
            {
                if (_language != value)
                {
                    _language = value;
                    SaveSetting(OP_TAG_DISPLAYLANGUAGE, value.ToString());
                }
            }
        }

        /// <summary>
        /// 设置项 -- 小语种权限开关，会加载科大讯飞TTS
        /// </summary>
        private static bool _rare_language = false;
        public bool Rare_language
        {
            get { return _rare_language; }
            set
            {
                if (_rare_language != value)
                {
                    _rare_language = value;
                    SaveSetting(OP_TAG_RARELANGUAGE, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 设置项 -- 开发模式高级，是否显示详细日志
        /// </summary>
        private static bool _isDetailLog;
        public bool IsDetailLog
        {
            get { return _isDetailLog; }
            set
            {
                if (_isDetailLog != value)
                {
                    _isDetailLog = value;
                    SaveSetting(OP_TAG_DEVLPISDETAILLOG, value ? OP_VALUE_ON : OP_VALUE_OFF);
                }
            }
        }

        /// <summary>
        /// 自动清理缓冲区
        /// </summary>
        public bool AutoClear { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        private static string _PIN;
        public string PIN
        {
            get { return _PIN; }
            set
            {
                if (!_PIN.Equals(value))
                {
                    _PIN = value;
                    SaveConfig(OP_TAG_PID, value);
                }
            }
        }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        private static string _LoginDate = string.Empty;
        public string LoginDate
        {
            get { return _LoginDate; }
            set
            {
                if (!_LoginDate.Equals(value))
                {
                    _LoginDate = value;
                    SaveConfig(OP_TAG_LOGIN, value);
                }
            }
        }

        /// <summary>
        /// XML跟节点，区分左右侧设备
        /// </summary>
        private string RootNode { get; set; }

        /// <summary>
        /// 口腔诊断策略
        /// </summary>
        private int _mouthDiagnosisStrategy;
        public int MouthDiagnosisStrategy
        {
            get { return _mouthDiagnosisStrategy; }
            set
            {
                _mouthDiagnosisStrategy = value;
                SaveSetting(OP_TAG_MOUTH_ST, value.ToString());
            }
        }
        #endregion

        /// <summary>
        /// 从XML文件中读取设置项
        /// </summary>
        public void ReadSetting(string xml_file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xml_file);

            #region 系统配置项
            XmlNodeList nodeConfigList = xmlDoc.SelectSingleNode(OP_NODE_ROOT_CONFIG).ChildNodes;
            foreach (XmlNode node in nodeConfigList)
            {
                XmlElement element = (XmlElement)node;
                if (element.Name.Equals(OP_TAG_FACE_CT))
                {
                    _faceConfidenceThreshold = double.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_HAND_CT))
                {
                    _handConfidenceThreshold = double.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_MOUTH_CT))
                {
                    _mouthConfidenceThreshold = double.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_AUTOMODE))
                {
                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        AutoMode = true;
                    }
                    else
                    {
                        AutoMode = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_AUTOCLEAR))
                {
                    this.AutoClear = element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON);
                }
                else if (element.Name.Equals(OP_TAG_MOUTH_RD))
                {
                    this.RemoteDiagMouth = int.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_FACE_RD))
                {
                    this.RemoteDiagFace = int.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_HAND_RD))
                {
                    this.RemoteDiagHand = int.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_RD_TO))
                {
                    this.RemoteDiagTimeOut = int.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_MOUTH_ST))
                {
                    this.MouthDiagnosisStrategy = int.Parse(element.GetAttribute(OP_ARR_VALUE));
                }
                else if (element.Name.Equals(OP_TAG_MOUTH_OPEN))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_MOUTH_OPEN_ON))
                    {
                        IsAddOpenMouth = true;
                    }
                    else
                    {
                        IsAddOpenMouth = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPMODE))
                {
                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        IsDevlpMode = true;
                    }
                    else
                    {
                        IsDevlpMode = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPAUTOTRG))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        DevlpaAutotrg = true;
                    }
                    else
                    {
                        DevlpaAutotrg = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPSTOP4ABNORMAL))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        DevlpStop4Abnormal = true;
                    }
                    else
                    {
                        DevlpStop4Abnormal = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPCLEARJPG))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        DevlpaClearjpg = true;
                    }
                    else
                    {
                        DevlpaClearjpg = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPSHOWMOUTH))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        DevlpaShowmouth = true;
                    }
                    else
                    {
                        DevlpaShowmouth = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPISDETAILLOG))
                {

                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        IsDetailLog = true;
                    }
                    else
                    {
                        IsDetailLog = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DEVLPISSHOWPOWER))
                {
                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        IsShowPower = true;
                    }
                    else
                    {
                        IsShowPower = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_DISPLAYLANGUAGE))
                {
                    Language = element.GetAttribute(OP_ARR_VALUE); //语言选择
                }
                else if (element.Name.Equals(OP_TAG_RARELANGUAGE))//小语种权限开关，会加载科大讯飞TTS
                {
                    if (element.GetAttribute(OP_ARR_VALUE).Equals(OP_VALUE_ON))
                    {
                        Rare_language = true;
                    }
                    else
                    {
                        Rare_language = false;
                    }
                }
                else if (element.Name.Equals(OP_TAG_GRADE))
                {
                    string v = element.GetAttribute(OP_ARR_VALUE);
                    gradeValue = int.Parse(v);//等级赋值

                }
            }
            #endregion
        }

        /// <summary>
        /// 从XML文件中读取设置项
        /// </summary>
        public void ReadOption(string xml_file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xml_file);

            #region 系统配置项
            XmlNodeList nodeConfigList = xmlDoc.SelectSingleNode(OP_NODE_ROOT_CONFIG).ChildNodes;
            foreach (XmlNode node in nodeConfigList)
            {
                XmlElement element = (XmlElement)node;
                if (element.Name.Equals(OP_TAG_PID))
                {
                    _PIN = element.GetAttribute(OP_ARR_VALUE);
                }
                else if (element.Name.Equals(OP_TAG_LOGIN))
                {
                    _LoginDate = element.GetAttribute(OP_ARR_VALUE);
                }
            }
            #endregion

            #region 硬件参数
            XmlNodeList nodeParameterList = xmlDoc.SelectSingleNode(RootNode + OP_TAG_PARAMETER).ChildNodes;
            foreach (XmlNode node in nodeParameterList)
            {
                XmlElement element = (XmlElement)node;
                if (element.Name.Equals(OP_TAG_SERIAL))
                {
                    this.PortName = element.GetAttribute(OP_ARR_PORT);
                }
                else if (element.Name.Equals(OP_TAG_CAMERA))
                {
                    string obj = element.GetAttribute(OP_ARR_OBJ);
                    string ip = element.GetAttribute(OP_ARR_IP);
                    int port = int.Parse(element.GetAttribute(OP_ARR_PORT));

                    if (obj.Equals(OP_VALUE_FACE))
                    {
                        this.FaceCameraIP = ip;
                        this.FaceCameraPort = port;
                    }
                    else if (obj.Equals(OP_VALUE_MOUTH))
                    {
                        this.MouthCameraIP = ip;
                        this.MouthCameraPort = port;
                    }
                    else if (obj.Equals(OP_VALUE_HAND))
                    {
                        this.HandCameraIP = ip;
                        this.HandCameraPort = port;
                    }
                    else if (obj.Equals(OP_VALUE_CARD))
                    {
                        this.CardCameraIP = ip;
                        this.CardCameraPort = port;
                    }
                }
            }
            #endregion
        }
        
        /// <summary>
        /// 保存配置项
        /// </summary>
        private void SaveConfig(string tag, string value)
        {
        //    this.Save(OP_NODE_ROOT_CONFIG, tag, OP_ARR_VALUE, value, OP_OPTION_XML_FILE);
        }

        /// <summary>
        /// 保存配置项
        /// </summary>
        private void SaveSetting(string tag, string value)
        {
            this.Save(OP_NODE_ROOT_CONFIG, tag, OP_ARR_VALUE, value, OP_SETTING_XML_FILE);
        }

        /// <summary>
        /// 将设置项存储到XML文件中
        /// </summary>
        private void Save(string root, string tag, string attr, string value, string file)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);

            bool done = false;
            XmlNodeList nodeList = xmlDoc.SelectSingleNode(root).ChildNodes;
            foreach (XmlNode node in nodeList)
            {
                XmlElement element = (XmlElement)node;
                if (element.Name.Equals(tag))
                {
                    element.SetAttribute(attr, value);
                    done = true;
                    break;
                }
            }

            if (!done)
            {
                XmlElement element = xmlDoc.CreateElement(tag);
                element.SetAttribute(attr, value);
                xmlDoc.SelectSingleNode(root).AppendChild(element);
            }

            xmlDoc.Save(file);
        }

        private string getAvailableWorkPath(string englishPath, string chinesePath)
        {
            if (System.IO.File.Exists(englishPath))
            {
                return englishPath;
            }

            if (System.IO.File.Exists(chinesePath))
            {
                return chinesePath;
            }
               
            return null;
        }

        /// <summary>
        /// Singleton实例
        /// </summary>
        private static Settings _leftInstance = null;
        private static Settings _rightInstance = null;

        public static Settings Instance
        {
            get { return Settings.Left; }
        }

        public static Settings Left
        {
            get { return _leftInstance ?? (_leftInstance = new Settings(Settings.Device.LEFT)); }
        }

        public static Settings Right
        {
            get { return _rightInstance ?? (_rightInstance = new Settings(Settings.Device.RIGHT)); }
        }
    }
}
