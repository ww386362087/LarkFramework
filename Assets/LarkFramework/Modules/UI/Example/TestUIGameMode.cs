using UnityEngine;
using System.Collections;

namespace LarkFramework.Test
{
    public class TestUIGameMode : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            UIManager.Create().transform.SetParent(transform);
        }
    }
}
