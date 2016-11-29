using UnityEngine;
using System.Collections;
using System;

public class UIPage : MonoBehaviour {

    public static void ShowPage<T>() where T : UIBase, new()
    {
        T instance = new T();

        Show(instance.uiPath);
    }

    public static void Show(string uiPath)
    {
        var canvas= GameObject.Find("Canvas").transform;
        GameObject page = GameObject.Instantiate(Resources.Load(uiPath)) as GameObject;

        Vector3 anchorPos = Vector3.zero;
        Vector2 sizeDel = Vector2.zero;
        Vector3 scale = Vector3.one;

        anchorPos = page.GetComponent<RectTransform>().anchoredPosition;
        sizeDel = page.GetComponent<RectTransform>().sizeDelta;
        scale = page.GetComponent<RectTransform>().localScale;

        page.transform.parent = canvas.transform;

        page.GetComponent<RectTransform>().anchoredPosition = anchorPos;
        page.GetComponent<RectTransform>().sizeDelta = sizeDel;
        page.GetComponent<RectTransform>().localScale = scale;
    }
}
