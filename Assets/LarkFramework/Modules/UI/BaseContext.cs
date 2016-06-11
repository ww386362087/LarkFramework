/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 19:40:18
 * 修改：evesgf    修改时间：2016-6-11 19:40:21
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

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
