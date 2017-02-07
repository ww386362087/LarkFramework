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

            if (PlayerSettings.showUnitySplashScreen)
                PlayerSettings.showUnitySplashScreen = false;

            if (PlayerSettings.apiCompatibilityLevel != ApiCompatibilityLevel.NET_2_0)
                PlayerSettings.apiCompatibilityLevel = ApiCompatibilityLevel.NET_2_0;

            if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeLeft)
                PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;

            if (PlayerSettings.bundleIdentifier.Equals("com.Company.ProductName"))
                PlayerSettings.bundleIdentifier = "com.evesgf.product";

            if (EditorSettings.unityRemoteDevice.Equals("None"))
                EditorSettings.unityRemoteDevice = "Any Android Device";

            Debug.Log("Auto Set Project Settings Finish!");
        }
    }

}
#endif
