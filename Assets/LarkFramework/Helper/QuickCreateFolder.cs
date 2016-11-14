/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-1 01:26:39
 * 修改：evesgf    修改时间：2016-10-1 01:26:43
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：自动创建常用文件夹
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuickCreateFolder : MonoBehaviour {

#if UNITY_EDITOR

    [MenuItem("LarkFramework/GenerateFolders")]
    private static void CreateBaseFolder()
    {
        GenerateFolder();
        Debug.Log("Folders Created!");
    }

    private static void GenerateFolder()
    {
        //创建项目文件夹
        Directory.CreateDirectory(Application.dataPath + "/" + Application.productName);

        //文件路径
        string path = Application.dataPath + "/"+ Application.productName+"/";

        CreateDirectoryAndFile(path,"Scripts");
        CreateDirectoryAndFile(path, "Resources");
        CreateDirectoryAndFile(path, "Scenes");
        CreateDirectoryAndFile(path, "Textures");
        CreateDirectoryAndFile(path, "Audios");
        CreateDirectoryAndFile(path, "Materials");
        CreateDirectoryAndFile(path, "Animations");
        CreateDirectoryAndFile(path, "Parks");
        CreateDirectoryAndFile(path, "Shaders");
        CreateDirectoryAndFile(path, "Prefabs");
        CreateDirectoryAndFile(path, "SandBoxs");
        CreateDirectoryAndFile(path, "_Documnets");
        CreateDirectoryAndFile(path, "Terrains");

        CreateTxt(Application.dataPath + "/" + Application.productName+"/ReadMe");
        WriteTxt(Application.dataPath + "/" + Application.productName + "/ReadMe.txt","欢迎使用LarkFramework框架！项目："+ Application.productName+" 创建于："+DateTime.Now);

        AssetDatabase.Refresh();
    }

    /// <summary>
    /// 创建指定路径文件夹和说明文件
    /// 说明文件是为了防止空文件夹被版本管理干掉
    /// </summary>
    /// <param name="path"></param>
    /// <param name="name"></param>
    private static void CreateDirectoryAndFile(string path,string name)
    {
        Directory.CreateDirectory(path + name);
        CreateTxt(path + name + "/" + name);
    }

    private static void CreateTxt(string path)
    {
        if (!File.Exists(path+".txt"))
        {
            FileStream fs = new FileStream(path + ".txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.Close();
            fs.Close();

            WriteTxt(path + ".txt", "欢迎使用LarkFramework框架！项目：" + Application.productName + " 创建于：" + DateTime.Now);
        }
        else
        {
            Debug.LogWarning("txt说明文件创建失败，冲突文件："+ path + ".txt");
        }
    }

    private static void WriteTxt(string path,string context)
    {
        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            //ps:此处为简单的单行输入，多行输入需修改
            sw.WriteLine(context);

            sw.Close();
            fs.Close();
        }
        else
        {
            Debug.LogError("写入文件失败，冲突文件：" + path);
        }
    }

#endif
}
