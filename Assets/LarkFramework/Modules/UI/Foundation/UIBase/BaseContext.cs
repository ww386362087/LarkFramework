/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:53:57
 * 修改：evesgf    修改时间：2016-8-5 08:54:00
 *
 * 版本：V0.0.2
 * 
 * 描述：Context基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class BaseContext
    {
        public UIType ViewType { get; private set; }

        public BaseContext(UIType viewType)
        {
            ViewType = viewType;
        }
    }
}
