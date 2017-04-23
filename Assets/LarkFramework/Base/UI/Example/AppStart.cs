using LarkFramework.UI;
using UnityEngine;

namespace LarkFramework.UI.Example
{
    public class AppStart : MonoBehaviour
    {
        private void Awake()
        {
            ViewMgr.ShowView<AccountView>();
        }
    }

}
