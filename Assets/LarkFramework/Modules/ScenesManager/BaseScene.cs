/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 21:50:04
 * 修改：evesgf    修改时间：2016-6-11 21:50:07
 *
 * 版本：V0.0.1
 * 
 * 描述：场景基类
 ---------------------------------------------------------------*/

using UnityEngine;

namespace LarkFramework
{
    public abstract class BaseScene : MonoBehaviour
    {
        public SceneType _sceneype { get; private set; }

        public BaseScene(SceneType sceneype)
        {
            _sceneype = sceneype;
        }

        public virtual void OnEnter(BaseScene scene)
        {

        }

        public virtual void OnExit(BaseScene scene)
        {

        }

        public virtual void OnPause(BaseScene scene)
        {

        }

        public virtual void OnResume(BaseScene scene)
        {

        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
