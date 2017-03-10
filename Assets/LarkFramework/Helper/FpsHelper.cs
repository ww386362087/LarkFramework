using UnityEngine;
using System.Collections;

public class FpsHelper : MonoBehaviour {

    private float m_LastUpdateShowTime = 0f;  //上一次更新帧率的时间;  

    private float m_UpdateShowDeltaTime = 0.01f;//更新帧率的时间间隔;  

    private int m_FrameUpdate = 0;//帧数;  

    private float m_FPS = 0;

    private GUIStyle fontStyle = new GUIStyle();

    void Awake()
    {
        Application.targetFrameRate = 100;
    }

    // Use this for initialization  
    void Start()
    {
        fontStyle.normal.background = null;    //设置背景填充  
        fontStyle.normal.textColor = new Color(0, 1, 1);   //设置字体颜色  
        fontStyle.fontSize = 36;       //字体大小 

        m_LastUpdateShowTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame  
    void Update()
    {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width -200, Screen.height-60, 200, 60), "FPS: " + m_FPS.ToString("f2"),fontStyle);
    }
}
