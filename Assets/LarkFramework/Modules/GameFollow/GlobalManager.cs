/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 22:57:48
 * 修改：evesgf    修改时间：2016-6-11 22:57:51
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、全局配置管理
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using SimpleJSON;

namespace LarkFramework
{
    public class GlobalManager
    {
        public static ProjectSetting projectSetting = new ProjectSetting();

        public GlobalManager()
        {
            LoadSetting();
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        public void LoadSetting()
        {
            TextAsset text = Resources.Load("ProjectSetting") as TextAsset;
            JSONNode json = JSONNode.Parse(text.text);

            projectSetting.ProjectName = json.AsObject["ProjectName"];
            projectSetting.Vision = json.AsObject["Vision"];
            projectSetting.LogoDuration=float.Parse(json.AsObject["LogoDuration"]);
        }
    }
}
