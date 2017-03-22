using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LarkFramework.Config;
using LarkFramework.GameFlow;

namespace LarkFramework
{
    public class LarkSettingsMgr : MonoBehaviour
    {
        public static LarkSettings settings;

        //资源保存路径
        private static string assetsDir = "Assets/LarkFramework/Resources/{0}.asset";

        #region 预置体路径
        private static string gameInstancePrefab = "GameFlow/" + typeof(GameInstance).Name;
        private static string gameModePrefab = "GameFlow/" + typeof(GameMode).Name;
        #endregion

        /// <summary>
        /// 创建项目配置
        /// </summary>
        [MenuItem("LarkFramework/CreateLarkSettings")]
        public static void CreateLarkSettings()
        {
            string dir = string.Format(assetsDir, (typeof(LarkSettings).Name));
            ScriptableObject settings = ScriptableObject.CreateInstance<LarkSettings>();
            AssetDatabase.CreateAsset(settings, dir);
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 返回项目配置
        /// </summary>
        /// <returns></returns>
        public static LarkSettings GetLarkSettings()
        {
            if (settings == null)
            {
                settings = AssetDatabase.LoadAssetAtPath<LarkSettings>(string.Format(assetsDir, typeof(LarkSettings).Name));
            }
            return settings;
        }
    }
}
