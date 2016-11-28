/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-28 14:38:53
 * 修改：evesgf    修改时间：2016-11-28 14:38:56
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：其实就是在Hierarchy面板上加个图标
 ---------------------------------------------------------------*/

#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace LarkFramework
{
    [InitializeOnLoad]
    public class LarkFrameworkHierarchyCallBack
    {
        // 层级窗口项回调
        private static readonly EditorApplication.HierarchyWindowItemCallback hiearchyItemCallback;

        private static Texture2D hierarchyIcon;
        private static Texture2D HierarchyIcon
        {
            get
            {
                if (LarkFrameworkHierarchyCallBack.hierarchyIcon == null)
                {
                    LarkFrameworkHierarchyCallBack.hierarchyIcon = (Texture2D)Resources.Load("LarkFramework_Logo");
                }
                return LarkFrameworkHierarchyCallBack.hierarchyIcon;
            }
        }

        private static Texture2D hierarchyEventIcon;
        private static Texture2D HierarchyEventIcon
        {
            get
            {
                if (LarkFrameworkHierarchyCallBack.hierarchyEventIcon == null)
                {
                    LarkFrameworkHierarchyCallBack.hierarchyEventIcon = (Texture2D)Resources.Load("LarkFramework_Logo");
                }
                return LarkFrameworkHierarchyCallBack.hierarchyEventIcon;
            }
        }

        /// <summary>
        /// 静态构造
        /// </summary>
        static LarkFrameworkHierarchyCallBack()
        {
            LarkFrameworkHierarchyCallBack.hiearchyItemCallback = new EditorApplication.HierarchyWindowItemCallback(LarkFrameworkHierarchyCallBack.DrawHierarchyIcon);
            EditorApplication.hierarchyWindowItemOnGUI = (EditorApplication.HierarchyWindowItemCallback)Delegate.Combine(
                EditorApplication.hierarchyWindowItemOnGUI,
                LarkFrameworkHierarchyCallBack.hiearchyItemCallback);
        }

        // 绘制icon方法
        private static void DrawHierarchyIcon(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            // 设置icon的位置与尺寸（Hierarchy窗口的左上角是起点）
            Rect rect = new Rect(0, 0, 16, 16);
            //Rect rect = new Rect(selectionRect.x + selectionRect.width - 16f, selectionRect.y, 16f, 16f);
            // 画icon
            GUI.DrawTexture(rect, LarkFrameworkHierarchyCallBack.HierarchyEventIcon);
        }
    }
}

#endif