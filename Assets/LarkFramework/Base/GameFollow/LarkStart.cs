/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2017-3-16 17:10:36
 * 修改：evesgf    修改时间：2017-3-16 17:10:40
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：框架总体入口
 ---------------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LarkFramework;
using LarkFramework.Config;

namespace LarkFramework.GameFlow
{
    public class LarkStart : MonoBehaviour
    {
        protected GameObject gameInstancePrefab;

        void Start()
        {
            if (gameInstancePrefab == null)
            {
                if (FindObjectOfType<GameInstance>() != null)
                {
                    GameInstance[] instances = Object.FindObjectsOfType<GameInstance>() as GameInstance[];
                    foreach (var instance in instances)
                    {
                        if (instance.gameObject.scene.name == "DontDestroyOnLoad")
                        {
                            gameInstancePrefab = instance.gameObject;
                        }
                    }
                }
                else
                {
                    LarkSettings settings = Resources.Load<LarkSettings>(typeof(LarkSettings).Name);
                    gameInstancePrefab = Instantiate(settings.gameInstancePrefab);
                    DontDestroyOnLoad(gameInstancePrefab);
                    gameInstancePrefab.name = typeof(GameInstance).Name;
                    GameInstance.Create().Init();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene("Load");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene("Splash");
            }
        }
    }
}
