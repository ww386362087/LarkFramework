/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:35:58
 * 修改：evesgf    修改时间：2016-10-2 00:36:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：实例化组件
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class GameModeBase<T1> : SingletonMono<T1> where T1 : SingletonMono<T1>
    {

        public virtual void OnUpdate() { }
    }
}
