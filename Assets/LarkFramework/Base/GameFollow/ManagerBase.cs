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

namespace LarkFramework.GameFollow
{
    public class ManagerBase<T> : SingletonMono<T> where T : SingletonMono<T>
    {
        public virtual void Init() { }

        public virtual void OnStart() { }

        public virtual void OnUpdate() { }

        public virtual void OnFixedUpdate() { }

        public virtual void OnLatedUpdate() { }

        public virtual void OnGUI() { }

        public virtual void OnDestroy() { }

        public virtual void OnApplicationQuit() { }
    }
}
