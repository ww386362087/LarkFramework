/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2017-3-16 16:55:07
 * 修改：evesgf    修改时间：2017-3-16 16:55:11
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：自动创建场景相关组件
 ---------------------------------------------------------------*/

using LarkFramework.GameFlow;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LarkFramework
{
    public class CreateSceneList : MonoBehaviour
    {
        [MenuItem("LarkFramework/CreateSceneList")]
        public static void CreateList()
        {
            //TODO:实例化出来的对象不关联预置体
            var gameMode=Instantiate(LarkSettingsMgr.GetLarkSettings().gameModePrefab);
            gameMode.name = typeof(GameMode).Name;

            Debug.Log("Create SceneList Finish!");
        }
    }

}