using UnityEngine;
using System.Collections;
using System.IO;

public class ScreenShot : MonoBehaviour
{

    public ScreenShotType sstype = ScreenShotType.Default;
    public int size = 4;
    public string fileName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            switch (sstype)
            {
                case ScreenShotType.Default:
                    DefaultSS();
                    break;
            }
        }
    }

    void Start()
    {
    }

    /// <summary>
    /// 检测文件夹是否存在，不存在则创建
    /// </summary>
    void CheckFolder(string path)
    {
        if (Directory.Exists(path))
        {
            return;
        }
        else
        {
            Debug.Log("截图文件夹不存在，正在创建");
            Debug.Log(Directory.CreateDirectory(path));
        }
    }

    /// <summary>
    /// 默认自带截图
    /// </summary>
    void DefaultSS()
    {
        var path = Application.dataPath + "/ScreenShot/";
        CheckFolder(path);

        var name = "";
        if (string.IsNullOrEmpty(fileName))
        {
            name = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
        else
        {
            name = fileName;
        }

        Application.CaptureScreenshot(path + name + ".png", size);
        Debug.Log("截图：" + name + ".png，存储于：" + path);
    }

    public enum ScreenShotType
    {
        Default = 0
    }
}
