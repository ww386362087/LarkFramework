/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-3 14:51:25
 * 修改：evesgf    修改时间：2016-8-3 14:51:29
 *
 * 版本：V0.0.1
 * 
 * 描述：Bind Some Delegate Func For Yours.
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class UIBind : MonoBehaviour
    {
        static bool isBind = false;

        public static void Bind()
        {
            if (!isBind)
            {
                isBind = true;
                //Debug.LogWarning("Bind For UI Framework.");

                //bind for your loader api to load UI.
                UIPage.delegateSyncLoadUI = Resources.Load;
                //UIPage.delegateAsyncLoadUI = UILoader.Load;

            }
        }
    }
}
