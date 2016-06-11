/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 01:04:11
 * 修改：evesgf    修改时间：2016-6-12 01:04:15
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、切换场景
 ---------------------------------------------------------------*/

using UnityEngine;
using LarkFramework;
using UnityEngine.SceneManagement;

public class MainMenuScene : BaseScene
{
    public MainMenuScene() : base(SceneType.MainMenuScene) { }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneType.MainQuestionScene.Name);
    }
}
