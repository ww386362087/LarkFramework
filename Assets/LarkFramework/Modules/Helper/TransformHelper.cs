/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：$time$
 * 修改：evesgf    修改时间：$time$
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using UnityEngine;

namespace LarkFramework
{
    public static class TransformExtension 
    {
        public static void DestroyChildren(this Transform trans)
        {
            foreach (Transform child in trans)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static Transform AddChildFromPrefab(this Transform trans, Transform prefab, string name = null)
        {
            Transform childTrans = GameObject.Instantiate(prefab) as Transform;
            childTrans.SetParent(trans, false);
            if (name != null)
	        {
                childTrans.gameObject.name = name;
	        }
            return childTrans;
        }
	}
}
