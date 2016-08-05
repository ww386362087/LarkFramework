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
                ContextManager.Instance.Push(new StartMenuContext());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var a = UIManager.Instance.GetSingleUI(ContextManager.Instance.PeekOrNull().ViewType).GetComponent<BaseView>();
                a.OnExit(ContextManager.Instance.PopFirst());
            }
        }
    }

}