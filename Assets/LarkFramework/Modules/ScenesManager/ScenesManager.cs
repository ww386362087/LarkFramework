/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 21:27:37
 * 修改：evesgf    修改时间：2016-6-11 21:27:40
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、场景管理器
 ---------------------------------------------------------------*/

using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace LarkFramework
{
    public class ScenesManager
    {
        //场景链
        private Stack<BaseScene> _scenesStack = new Stack<BaseScene>();

        public void Push(BaseScene nextScene)
        {

            if (_scenesStack.Count != 0)
            {
                BaseScene curContext = _scenesStack.Peek();
            }
        }

        public void Pop()
        {
            if (_scenesStack.Count != 0)
            {
                BaseScene curContext = _scenesStack.Peek();
                _scenesStack.Pop();
            }

            if (_scenesStack.Count != 0)
            {
                BaseScene lastContext = _scenesStack.Peek();
            }
        }

        public BaseScene PeekOrNull()
        {
            if (_scenesStack.Count != 0)
            {
                return _scenesStack.Peek();
            }
            return null;
        }
    }
}
