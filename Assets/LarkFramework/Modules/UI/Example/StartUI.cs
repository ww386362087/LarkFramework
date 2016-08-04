using UnityEngine;
using System.Collections;

namespace LarkFramework.Test
{
    public class StartUI : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                UIManager.Instance.ShowPage<StartMenuView>();
            }
        }
    }

}