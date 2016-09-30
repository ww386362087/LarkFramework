using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{

    public class StartGame : MonoBehaviour
    {

        void Awake()
        {

        }

        void Start()
        {
            GameMode.Instance().Init(this);
        }

        void Update()
        {
            GameMode.Instance().Update();
        }

        void OnDestroy()
        {
            GameMode.Instance().Destroy();
        }

        void OnApplicationQuit()
        {

        }

        void OnApplicationPause(bool pause)
        {

        }
    }
}
