/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 21:27:37
 * 修改：evesgf    修改时间：2016-6-11 21:27:40
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、启动展示画面，播放完毕后自动卸载
 ---------------------------------------------------------------*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using LarkFramework;

public class LogoScene : BaseScene {

    public Text text;

    private bool isFirstUpdate=true;                 //第一帧检测

    public LogoScene() : base(SceneType.LogoScene) { }

    void Start () {
        //加载Loading场景，由于本场景Canvas层级为10高于loading，故显示Logo界面
        SceneManager.LoadScene(SceneType.LoadingScene.Name, LoadSceneMode.Additive);
	}

    void Update()
    {
        if (isFirstUpdate)
        {
            StartCoroutine(TimeCount(GlobalManager.projectSetting.LogoDuration));
            isFirstUpdate = false;
        }
    }

    IEnumerator TimeCount(float timer)
    {
        for (float i = 0; i < timer; i += Time.deltaTime)
        {
            text.text = "当前进度：" + i;
            yield return null;
        }
        //卸载自身场景
        SceneManager.UnloadScene(SceneType.LogoScene.Name);
    }
}
