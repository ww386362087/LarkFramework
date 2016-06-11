/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 01:17:17
 * 修改：evesgf    修改时间：2016-6-12 01:17:21
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、主场景
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using LarkFramework;

public class MainQuestionScene : BaseScene
{
    public MainQuestionScene() : base(SceneType.MainQuestionScene) { }

    void Start()
    {
        SingletonHelper<ContextManager>.Instance.Push(new MainQuestionContext());
    }
}
