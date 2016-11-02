/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-2 00:34:56
 * 修改：evesgf    修改时间：2016-10-31 23:08:00
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：程序主入口，一个项目只能有一个GameInstance
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class GameInstanceBase<T> : SingletonMono<T> where T : SingletonMono<T>
    {

    }
}
