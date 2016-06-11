/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 19:38:10
 * 修改：evesgf    修改时间：2016-6-11 19:38:14
 *
 * 版本：
 * 
 * 描述：
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