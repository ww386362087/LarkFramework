using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LarkFramework.Test
{
    public class StartMenuContext : BaseContext
    {
        public StartMenuContext() : base(UIType.StartNenu)
        {

        }
    }

    public class StartMenuView : AnimateView
    {
    //    public GEAnim[] geAnims;

    //    [SerializeField]
    //    private Button btn_Close;

    //    /// <summary>
    //    /// 执行UI动画
    //    /// </summary>
    //    /// <param name="isOpen"></param>
    //    public void DoGEAnims(bool isOpen)
    //    {
    //        for (int i = 0; i < geAnims.Length; i++)
    //        {
    //            if (isOpen)
    //            {
    //                geAnims[i].MoveIn();
    //            }
    //            else
    //            {
    //                geAnims[i].MoveOut();
    //            }
    //        }
    //    }

    //    public void CloseSelf()
    //    {
    //        OnExit(ContextManager.Instance.PopFirst());
    //    }

    //    public override void OnEnter(BaseContext context)
    //    {
    //        base.OnEnter(context);
    //        DoGEAnims(true);
    //    }

    //    public override void OnExit(BaseContext context)
    //    {
    //        base.OnExit(context);
    //        DoGEAnims(false);
    //    }

    //    public override void OnPause(BaseContext context)
    //    {
    //        base.OnPause(context);
    //    }

    //    public override void OnResume(BaseContext context)
    //    {
    //        base.OnResume(context);
    //    }

    //    public void OptionCallBack()
    //    {
    //        //Singleton<ContextManager>.Instance.Push(new OptionMenuContext());
    //    }

    //    public void HighScoreCallBack()
    //    {
    //        //Singleton<ContextManager>.Instance.Push(new HighScoreContext());
    //    }
    }
}
