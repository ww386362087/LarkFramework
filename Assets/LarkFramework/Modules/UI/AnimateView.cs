/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 19:41:57
 * 修改：evesgf    修改时间：2016-6-11 19:42:00
 *
 * 版本：
 * 
 * 描述：
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
            if(_animator!=null)
                _animator.SetTrigger("OnEnter");
        }

        public override void OnExit(BaseContext context)
        {
            if (_animator != null)
                _animator.SetTrigger("OnExit");
        }

        public override void OnPause(BaseContext context)
        {
            if (_animator != null)
                _animator.SetTrigger("OnPause");
        }

        public override void OnResume(BaseContext context)
        {
            if (_animator != null)
                _animator.SetTrigger("OnResume");
        }

    }
}
