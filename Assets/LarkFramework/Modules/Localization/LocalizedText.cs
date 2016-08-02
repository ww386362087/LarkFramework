/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：$time$
 * 修改：evesgf    修改时间：$time$
 *
 * 版本：
 * 
 * 描述：
 ---------------------------------------------------------------*/

using UnityEngine;
using UnityEngine.UI;

namespace LarkFramework
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField]
        private string _textID;
        public string TextID
        {
            get
            {
                return _textID;
            }
        }

        private Text _label;

        public void Start()
        {
            _label = GetComponent<Text>();
            SetupTextID(_textID);
        }

        public void SetupTextID(string textID)
        {
            _label.text = Singleton<Localization>.Instance.GetText(_textID);
        }

        public void SetupTextID(string textID, params object[] replaceParams)
        {

        }
    }
}
