/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 08:51:39
 * 修改：evesgf    修改时间：2016-8-5 08:51:44
 *
 * 版本：V0.0.2
 * 
 * 描述：Dictionary扩展
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LarkFramework
{
    public static class DictionaryExtension
    {

        /// <summary>
        /// 尝试将键和值添加到字典中：如果不存在，才添加；存在，不添加也不抛导常
        /// </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            return dict;
        }
        /// <summary>
        /// 将键和值添加或替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }

    }

}