using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class GameMode
    {
        private static GameMode instance = null;
        public static GameMode Instance()
        {
            if (instance == null)
            {
                instance = new GameMode();
            }
            return instance;
        }

        public StartGame StartGame { get; private set; }
        public GameObject gameObj { get; private set; }

        public void Init(StartGame startGame)
        {
            this.StartGame = startGame;
            this.gameObj = startGame.gameObject;

            //Init各类管理器


            BaseManager.Instance().Init();
            TestManager.Create().Init();
        }

        public void Update()
        {
            //Update各类管理器
            BaseManager.Instance().Update();
            TestManager.Instance.OnUpdate();
        }

        public void Destroy()
        {
            //Destory各类管理器
            BaseManager.Instance().Destroy();
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return this.StartGame.StartCoroutine(routine);
        }

        public void Coroutine(IEnumerator routine)
        {
            this.StartGame.StopCoroutine(routine);
        }
    }
}
