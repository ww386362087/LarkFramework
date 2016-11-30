using UnityEngine;
using System.Collections;
using LarkFramework.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GUIAnimatorExtensions
{
    public static void Show(GUIAnim[] items)
    {
        if (items.Length !=0)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].MoveIn();
            }
        }
    }

    public static void Hide(GUIAnim[] items)
    {
        if (items.Length != 0)
        {
            for (int i = 0; i < items.Length; i++)
            {
                items[i].MoveOut();
            }
        }
    }
}

#if UNITY_EDITOR

public class GUIAnimatorExtensionsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Add GUIAnims Objects"))
        {
            GameObject obj = Selection.activeGameObject;

            //TODO:无法找到Hieraacchy下隐藏的对象
            //用Resources.FindObjectsOfTypeAll(typeof(GameObject))
            obj.GetComponent<ViewBase>().guiAnimItems = obj.GetComponentsInChildren<GUIAnim>();
        }
    }
}

[CanEditMultipleObjects()]
[CustomEditor(typeof(ViewBase), true)]
public class CustomExtension : GUIAnimatorExtensionsEditor
{
}

#endif
