using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

public class GameInstance : GameInstanceBase<GameInstance>
{
    void Awake()
    {

    }

    public GameInstance Init()
    {
        //初始化GameMode
        //My_GameMode.Create().Init(this, gameObject);

        Debug.Log(this.name + " Init Finished");
        return this;
    }

    void OnApplicationQuit()
    {

    }

    void OnApplicationPause(bool pause)
    {

    }
}
