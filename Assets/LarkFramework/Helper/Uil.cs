using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Uil : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    public static Uri AppContentDataUri
    {
        get
        {
            string dataPath = Application.dataPath;
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return new UriBuilder
                {
                    Scheme = "file",
                    Path = Path.Combine(dataPath, "Raw/")
                }.Uri;
            }

            if (Application.platform == RuntimePlatform.Android)
            {
                return new Uri("jar:file//" + dataPath + "!/assets/");
            }

            return new UriBuilder
            {
                Scheme = "file",
                Path = Path.Combine(dataPath, "StreamingAssets/")
            }.Uri;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static Uri AppPersistentDataUri
    {
        get
        {
            return new UriBuilder
            {
                Scheme = "file",
                Path = Application.persistentDataPath + "/"
            }.Uri;
        }
    }

    /// <summary>
    /// 安全销毁GameObject
    /// </summary>
    /// <param name="go"></param>
    public static void SafeDestroy(GameObject go)
    {
        if (go != null)
        {
            UnityEngine.Object.Destroy(go);
        }
    }

    /// <summary>
    /// 安全销毁Transform
    /// </summary>
    /// <param name="go"></param>
    public static void SafeDestroy(Transform go)
    {
        if (go != null)
        {
            Uil.SafeDestroy(go.gameObject);
        }
    }

    //清除GC
    public static void ClearMemory()
    {
        GC.Collect();
        Resources.UnloadUnusedAssets();
    }
}
