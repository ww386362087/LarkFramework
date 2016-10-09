/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 09:00:12
 * 修改：evesgf    修改时间：2016-8-5 09:00:17
 *
 * 版本：V0.0.2
 * 
 * 描述：ContextManager管理类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LarkFramework
{
    public class ContextManager:Singleton<ContextManager>
    {
        private Stack<BaseContext> _contextStack = new Stack<BaseContext>();

        private ContextManager()
        {

        }

        /// <summary>
        /// 打开新的UI并将UI加入栈
        /// </summary>
        /// <param name="nextContext"></param>
        public void Push(BaseContext nextContext)
        {

            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                BaseView curView = UIManager.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnPause(curContext);
            }

            _contextStack.Push(nextContext);
            BaseView nextView = UIManager.Instance.GetSingleUI(nextContext.ViewType).GetComponent<BaseView>();
            nextView.OnEnter(nextContext);
        }

        /// <summary>
        /// 关闭栈顶UI并返回上一级UI
        /// </summary>
        public void Pop()
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                _contextStack.Pop();

                BaseView curView = UIManager.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
            }

            if (_contextStack.Count != 0)
            {
                BaseContext lastContext = _contextStack.Peek();
                BaseView curView = UIManager.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
                curView.OnPause(lastContext);
            }
        }

        public BaseContext PopFirst()
        {
            if (_contextStack.Count != 0)
            {
                BaseContext curContext = _contextStack.Peek();
                _contextStack.Pop();

                BaseView curView = UIManager.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
                return curContext;
            }
            return null;
        }

        /// <summary>
        /// 取得栈顶的UI
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
