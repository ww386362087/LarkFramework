/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 16:10:13
 * 修改：evesgf    修改时间：2016-6-12 16:10:16
 *
 * 版本：V0.0.1
 * 
 * 描述：问题类
 ---------------------------------------------------------------*/

 /// <summary>
 /// 问题类
 /// </summary>
public class Question  {
    /// <summary>
    /// 问题内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 问题配图
    /// </summary>
    public string QuestionImg { get; set; }
    /// <summary>
    /// 内容和配图宽度比例
    /// </summary>
    public float QIpercent { get; set; }
    /// <summary>
    /// 题目和答案高度比例
    /// </summary>
    public float QApercent { get; set; }
    /// <summary>
    /// 答案列表
    /// </summary>
    public Answer[] AnswerList { get; set; }
}

/// <summary>
/// 答案类
/// </summary>
public class Answer
{
    /// <summary>
    /// 答案内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 答案配图
    /// </summary>
    public string AnswerImg { get; set; }
    /// <summary>
    /// 是否是正确答案
    /// </summary>
    public bool IsRight { get; set; }
    /// <summary>
    /// 内容和配图高度比例
    /// </summary>
    public float AIpercent { get; set; }
}
