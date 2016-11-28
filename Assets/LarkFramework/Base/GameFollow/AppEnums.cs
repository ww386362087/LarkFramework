/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-28 10:12:56
 * 修改：evesgf    修改时间：2016-11-28 10:13:01
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：提供程序集用到的枚举
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class AppEnums  {

    /// <summary>
    /// APP当前的开发状态
    /// </summary>
    public enum AppMode
    {
        /// <summary>
        /// 开发阶段
        /// </summary>
        Developing,
        /// <summary>
        /// 测试阶段
        /// </summary>
        QA,
        /// <summary>
        /// 发布阶段
        /// </summary>
        Release
    }
}
