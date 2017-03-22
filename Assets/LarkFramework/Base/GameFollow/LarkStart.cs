﻿/*---------------------------------------------------------------
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

namespace LarkFramework.GameFollow
{
    public class LarkStart : MonoBehaviour
    {
        public static GameObject LarkFrameworkPrefab;

        // Use this for initialization
        void Start()
        {
            if (LarkFrameworkPrefab == null)
            {
                if (FindObjectOfType<LarkStart>() != null)
                {
                    LarkStart[] instances = Object.FindObjectsOfType<LarkStart>() as LarkStart[];
                    foreach (LarkStart instance in instances)
                    {
                        if (instance.gameObject.scene.name == "DontDestroyOnLoad")
                        {
                            print(instance.gameObject.name);
                        }
                    }
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