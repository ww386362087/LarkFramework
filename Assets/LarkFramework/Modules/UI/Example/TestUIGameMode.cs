using UnityEngine;
using System.Collections;

namespace LarkFramework.Test
{
    public class TestUIGameMode : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            Localization.Create().Language = Localization.CHINESE;

            UIManager.Create();
            ContextManager.Create();
        }
    }
}
