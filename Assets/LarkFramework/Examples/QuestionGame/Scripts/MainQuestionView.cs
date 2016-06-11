/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 01:32:21
 * 修改：evesgf    修改时间：2016-6-12 01:32:28
 *
 * 版本：V0.0.1
 * 
 * 描述：显示问题
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using LarkFramework;
using UnityEngine.UI;

public class MainQuestionContext : BaseContext
{
    public MainQuestionContext() : base(UIType.MainQuestionView){}

    public string QuestionTitle="test title";


    public void LoadQuestion(string name)
    {

    }
}

public class MainQuestionView : AnimateView
{

    [SerializeField]
    private Text _title;
    [SerializeField]
    private Button _buttonOption;

    /// <summary>
    /// 刷新View
    /// </summary>
    /// <param name="context"></param>
    public void RefreshView(BaseContext context)
    {
        MainQuestionContext mqc = context as MainQuestionContext;

        _title.text = mqc.QuestionTitle;
    }

    public override void OnEnter(BaseContext context)
    {
        RefreshView(context);

        base.OnEnter(context);
    }

    public override void OnExit(BaseContext context)
    {
        base.OnExit(context);
    }

    public override void OnPause(BaseContext context)
    {
        _animator.SetTrigger("OnExit");
    }

    public override void OnResume(BaseContext context)
    {
        _animator.SetTrigger("OnEnter");
    }

    public void OptionCallBack()
    {
        //SingletonHelper<ContextManager>.Instance.Push(new OptionMenuContext());
    }

    public void HighScoreCallBack()
    {
        //SingletonHelper<ContextManager>.Instance.Push(new HighScoreContext());
    }
}
