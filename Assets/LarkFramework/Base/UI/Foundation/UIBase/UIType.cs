/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:51:39
 * 修改：evesgf    修改时间：2016-8-5 08:51:44
 *
 * 版本：V0.0.2
 * 
 * 描述：注册UI类型
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class UIType
    {
        public string Path { get; private set; }
        public string Name { get; private set; }

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/') + 1);
        }

        public override string ToString()
        {
            return string.Format("path : {0} name : {1}", Path, Name);
        }

        public static readonly UIType StartNenu = new UIType("Views/StartMenuView");
        public static readonly UIType NextNenu = new UIType("Views/NextMenuView");
    }
}