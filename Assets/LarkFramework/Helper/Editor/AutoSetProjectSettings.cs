/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-11-25 14:53:12
 * 修改：evesgf    修改时间：2016-11-25 14:53:17
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：自动配置Project Settings
 ---------------------------------------------------------------*/

#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;
namespace LarkFramework
{
    public class AutoSetProjectSettings : MonoBehaviour
    {
        [MenuItem("LarkFramework/AutoSetProjectSettings")]
        internal static void AutoSet()
        {
            if (EditorSettings.externalVersionControl != "Visible Meta Files")
                EditorSettings.externalVersionControl = "Visible Meta Files";

            if (EditorSettings.serializationMode != SerializationMode.ForceText)
                EditorSettings.serializationMode = SerializationMode.ForceText;

            if (PlayerSettings.displayResolutionDialog != ResolutionDialogSetting.HiddenByDefault)
                PlayerSettings.displayResolutionDialog = ResolutionDialogSetting.HiddenByDefault;

            //关闭unity自带过场动画
            //TODO:5.5 关闭过场动画API升级
            //if (!PlayerSettings.SplashScreen.show)
            //    PlayerSettings.SplashScreen.show = false;

            if (!PlayerSettings.showUnitySplashScreen)
                PlayerSettings.showUnitySplashScreen = false;

            if (PlayerSettings.apiCompatibilityLevel != ApiCompatibilityLevel.NET_2_0)
                PlayerSettings.apiCompatibilityLevel = ApiCompatibilityLevel.NET_2_0;

            if (PlayerSettings.bundleIdentifier.Equals("com.Company.ProductName"))
                PlayerSettings.bundleIdentifier = "com.evesgf."+ Application.productName;

            //用于unity remote调试
            if (EditorSettings.unityRemoteDevice.Equals("None"))
                EditorSettings.unityRemoteDevice = "Any Android Device";

            //限制只能运行一个实例
            //if (!PlayerSettings.forceSingleInstance)
            //    PlayerSettings.forceSingleInstance = true;

#region 移动端配置

            //开启自动旋转
            if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.AutoRotation)
                PlayerSettings.defaultInterfaceOrientation = UIOrientation.AutoRotation;

            //开启左右横屏旋转支持
            if (!PlayerSettings.allowedAutorotateToLandscapeLeft)
                PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            if (!PlayerSettings.allowedAutorotateToLandscapeRight)
                PlayerSettings.allowedAutorotateToLandscapeRight = true;

            //关闭竖屏旋转支持
            if (!PlayerSettings.allowedAutorotateToPortrait)
                PlayerSettings.allowedAutorotateToPortrait = false;
            if (!PlayerSettings.allowedAutorotateToPortraitUpsideDown)
                PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;
#endregion

            Debug.Log("Auto Set Project Settings Finish!");
        }
    }

}
#endif
