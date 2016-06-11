using UnityEngine;
using System.Collections;
using LarkFramework;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : BaseScene
{
    public Text text;

    public LoadingScene() : base(SceneType.LoadingScene) { }

    void Start()
    {
        StartCoroutine(LoadingOver());
    }

    IEnumerator LoadingOver()
    {
        SceneManager.LoadScene(SceneType.MainMenuScene.Name,LoadSceneMode.Additive);
        for (float i = 0; i < 2; i += Time.deltaTime)
        {
            text.text = "Loading..." + i;
            yield return null;
        }
        SceneManager.UnloadScene(SceneType.LoadingScene.Name);
    }
}
