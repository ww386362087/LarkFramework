/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:56:43
 * 修改：evesgf    修改时间：2016-8-5 08:56:48
 *
 * 版本：V0.0.2
 * 
 * 描述：Animate类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public abstract class AnimateView : BaseView
    {
        [SerializeField]
        protected Animator _animator;

        public override void OnEnter(BaseContext context)
        {
            if (_animator != null)
            {
                _animator.SetTrigger("OnEnter");
            }
            Debug.Log(GetType().Name + " OnEnter");
        }

        public override void OnExit(BaseContext context)
        {
            if (_animator != null)
            {
                _animator.SetTrigger("OnExit");
            }
            Debug.Log(GetType().Name + " OnExit");
        }

        public override void OnPause(BaseContext context)
        {
            if (_animator != null)
            {
                _animator.SetTrigger("OnPause");
            }
            Debug.Log(GetType().Name + " OnPause");
        }

        public override void OnResume(BaseContext context)
        {
            if (_animator != null)
            {
                _animator.SetTrigger("OnResume");
            }
            Debug.Log(GetType().Name + " OnResume");
        }

    }
}
