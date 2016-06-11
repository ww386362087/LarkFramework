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
    public class Localization 
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
