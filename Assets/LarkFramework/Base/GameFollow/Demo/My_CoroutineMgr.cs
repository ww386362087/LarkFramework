using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow.Demo
{
    public class My_CoroutineMgr //: ManagerBase<My_CoroutineMgr>
    {
        //public override void Init()
        //{
        //    base.Init();
        //}

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return My_GameInstance.Instance.StartCoroutine(routine);
        }
    }
}