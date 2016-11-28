/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-21 15:09:50
 * 修改：evesgf    修改时间：2016-10-21 15:09:54
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：管理器基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

namespace LarkFramework.GameFollow.Demo
{
    public class My_ScenesMgr : ManagerBase<My_ScenesMgr>
    {
        public override void Init()
        {
            base.Init();

            LarkLog.Log(this.name + " Init Finished!");
        }
    }
}
