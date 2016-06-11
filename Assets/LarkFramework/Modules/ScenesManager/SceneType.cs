/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 21:37:31
 * 修改：evesgf    修改时间：2016-6-11 21:37:35
 *
 * 版本：V0.0.1
 * 
 * 描述：场景类型
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class SceneType
    {
        public string Name { get; private set; }

        public SceneType(string name)
        {
            Name = name;
        }

        //输出View的Path和Name
        public override string ToString()
        {
            return string.Format("scene name : {0}", Name);
        }

        #region 注册Scenes

        public static readonly SceneType DefaultScene = new SceneType("DefaultScene");

        public static readonly SceneType LogoScene = new SceneType("Logo");
        public static readonly SceneType LoadingScene = new SceneType("Loading");
        public static readonly SceneType MainMenuScene = new SceneType("MainMenu");
        public static readonly SceneType MainQuestionScene = new SceneType("MainQuestion");
        #endregion
    }
}
