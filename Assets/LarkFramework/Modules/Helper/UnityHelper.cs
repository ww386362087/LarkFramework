/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 16:54:31
 * 修改：evesgf    修改时间：2016-6-12 16:54:34
 *
 * 版本：V0.0.1
 * 
 * 描述：
 * 1、一个unity的帮助类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class UnityHelper {

    /// <summary>
    /// 将texture转换为Sprite
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static Sprite TextureToSprite(Texture texture)
    {
        var tex2d=new Texture2D(128, 128);
        return Sprite.Create(tex2d, new Rect(0, 0, 128, 128), Vector2.zero);
    }
}
