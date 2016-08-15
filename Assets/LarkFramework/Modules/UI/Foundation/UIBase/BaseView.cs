/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:55:30
 * 修改：evesgf    修改时间：2016-8-5 08:55:33
 *
 * 版本：V0.0.2
 * 
 * 描述：View基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public abstract class BaseView : MonoBehaviour
    {

        public virtual void OnEnter(BaseContext context)
        {

        }

        public virtual void OnExit(BaseContext context)
        {

        }

        public virtual void OnPause(BaseContext context)
        {

        }

        public virtual void OnResume(BaseContext context)
        {

        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
