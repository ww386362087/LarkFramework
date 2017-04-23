using LarkFramework.Sound;
using LarkFramework.UI;
using UnityEngine;
using LarkFramework.Base;

namespace LarkFramework.UI.Example
{
    public class AppStart : MonoBehaviour
    {
        private void Awake()
        {
            ResourcesMgr.Create();
            SoundMgr.Create().Init();

            ViewMgr.ShowView<AccountView>();
        }
    }

}
