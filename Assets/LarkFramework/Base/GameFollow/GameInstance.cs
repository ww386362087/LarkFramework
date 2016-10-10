/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:34:56
 * 修改：evesgf    修改时间：2016-10-2 00:35:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：程序主入口，一个项目只能有一个GameInstance
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{

    public class GameInstance : SingletonMono<GameInstance>
    {
        void Awake()
        {

        }

        void Start()
        {
            GameMode.Create().Init(this);
        }

        void Update()
        {
            GameMode.Instance.OnUpdate();
        }

        void OnDestroy()
        {
            GameMode.Instance.Destroy();
        }

        void OnApplicationQuit()
        {

        }

        void OnApplicationPause(bool pause)
        {

        }
    }
}
