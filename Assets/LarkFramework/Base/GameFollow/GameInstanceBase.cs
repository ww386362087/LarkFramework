using UnityEngine;
using System.Collections;

namespace LarkFramework.GameFollow
{
    public class GameInstanceBase<T> : SingletonMono<T> where T : SingletonMono<T>
    {

    }
}
