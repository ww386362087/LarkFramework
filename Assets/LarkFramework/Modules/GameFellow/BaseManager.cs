using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class BaseManager:MonoBehaviour
    {
        private static BaseManager instance = null;
        public static BaseManager Instance()
        {
            if (instance == null)
            {
                instance = new BaseManager();
            }
            return instance;
        }

        public void Init()
        {
            print("BaseManager:Init");
            NotificationCenter.DefaultCenter().AddObserver(this, "ApplyDamage");
        }

        public void Update()
        {
            print("BaseManager:Update");
        }

        public void Reset()
        {
            print("BaseManager:Reset");
        }

        public void Destroy()
        {
            print("BaseManager:Destroy");
        }

        void ApplyDamage(Notification note)
        {
            Debug.Log("从:" + note.sender + ",接收一个信息内容:" + (string)note.data + ", 通知名称为:" + note.name);
        }
    }
}
