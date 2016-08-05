using UnityEngine;
using System.Collections;
using LarkFramework;
using UnityEngine.SceneManagement;

namespace LarkFramework.Test
{

    public class ApplicationMgr : MonoBehaviour
    {

        void Awake()
        {
            
        }

        void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            InitializeUnity();
            InitializeGame();
        }

        public void xxxxx(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// unity相关设置
        /// </summary>
        void InitializeUnity()
        {
            //设置后台运行
            Application.runInBackground = true;
            //设置限定帧率
            Application.targetFrameRate = 60;
        }

        /// <summary>
        /// 游戏相关设置
        /// </summary>
        void InitializeGame()
        {
            //加载本地配置

            //检查更新

            //加载资源

            //程序初始化
            InitializeMgr();
        }

        void InitializeMgr()
        {
            NotificationCenter.DefaultCenter().AddObserver(this, "ApplyDamage");
        }

        void ApplyDamage(Notification note)
        {
            Debug.Log("从:" + note.sender + ",接收一个信息内容:" + (string)note.data + ", 通知名称为:" + note.name);
        }
    }
}
