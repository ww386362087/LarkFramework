/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 19:36:35
 * 修改：evesgf    修改时间：2016-6-11 19:36:39
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LarkFramework
{
    public class ContextManager
    {
        private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

        private ContextManager()
        {
            //TODO:默认打开的UI
            //Push(new MainMenuContext());
        }

        public void Push(BaseContext nextContext)
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                BaseView curView = SingletonHelper<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnPause(curContext);
            }

            _contextStack.Push(nextContext);
            BaseView nextView = SingletonHelper<UIManager>.Instance.GetSingleUI(nextContext.ViewType).GetComponent<BaseView>();
            nextView.OnEnter(nextContext);
        }

        public void Pop()
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                _contextStack.Pop();

                BaseView curView = SingletonHelper<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
            }

            if (_contextStack.Count != 0)
            {
                BaseContext lastContext = _contextStack.Peek();
                BaseView curView = SingletonHelper<UIManager>.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
                curView.OnResume(lastContext);
            }
        }

        /// <summary>
        /// 返回栈顶的Context
        /// </summary>
        /// <returns></returns>
        public BaseContext PeekOrNull()
        {
            if (_contextStack.Count != 0)
            {
                return _contextStack.Peek();
            }
            return null;
        }
    }
}