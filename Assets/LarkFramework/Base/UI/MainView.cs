using UnityEngine;
using System.Collections;
using LarkFramework.UI;

public class MainView : ViewBase
{
    public GUIAnim[] guiAnims;

    public MainView():base(ViewType.Normal,ViewMode.DoNothing,ViewCollider.None)
    {
        viewPath = "Views/MainView";
    }

    public void Start()
    {
        ShowView();
    }

    public override void ShowView()
    {
        base.ShowView();

        if (guiAnims.Length == 0) return;

        for (int i = 0; i < guiAnims.Length; i++)
        {
            guiAnims[i].MoveIn();
        }
    }
}
