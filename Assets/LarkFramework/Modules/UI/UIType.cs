/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-11 16:28:56
 * 修改：evesgf    修改时间：2016-6-11 16:29:00
 *
 * 版本：V0.0.1
 * 
 * 描述：
 ---------------------------------------------------------------*/


namespace LarkFramework
{
    public class UIType
    {

        public string Path { get; private set; }

        public string Name { get; private set; }

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/') + 1);
        }

        //输出View的Path和Name
        public override string ToString()
        {
            return string.Format("path : {0} name : {1}", Path, Name);
        }

        #region 注册View

        public static readonly UIType MainQuestionView = new UIType("Views/MainQuestionView");

        #endregion

    }
}
