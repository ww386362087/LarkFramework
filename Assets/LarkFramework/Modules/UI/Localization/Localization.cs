/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-8-5 12:10:40
 * 修改：evesgf    修改时间：2016-8-5 12:10:43
 *
 * 版本：V0.0.2
 * 
 * 描述：本地化管理
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;

namespace LarkFramework
{
    public class Localization:Singleton<Localization>
    {
        /* Language Types */
        public const string CHINESE = "Localization/Chinese.json";
        public const string ENGLISH = "Localization/English.json";

        private string _language;
        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                TextAsset asset = Resources.Load<TextAsset>(_language);
                _languageNode = SimpleJSON.JSON.Parse(asset.text);
            }
        }

        private SimpleJSON.JSONNode _languageNode;

        private Localization()
        {
            Language = CHINESE;
        }

        public string GetText(string id)
        {
            return _languageNode[id];
        }
    }
}
