/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-6-12 01:32:21
 * 修改：evesgf    修改时间：2016-6-12 01:32:28
 *
 * 版本：V0.0.1
 * 
 * 描述：显示问题
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using LarkFramework;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class MainQuestionContext : BaseContext
{
    public MainQuestionContext() : base(UIType.MainQuestionView){}

    /// <summary>
    /// 根据问题名字加载问题
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Question LoadQuestion(string name)
    {
        string path = "Questions/"+ name+"/"+ name;

        TextAsset text = Resources.Load(path) as TextAsset;
        JSONNode json = JSONNode.Parse(text.text);

        Question question = new Question();

        question.Content = json.AsObject["Content"];
        question.QuestionImg = json.AsObject["QuestionImg"];
        question.QIpercent = float.Parse(json.AsObject["QIpercent"]);
        question.QApercent = float.Parse(json.AsObject["QApercent"]);

        List<Answer> list = new List<Answer>();

        foreach (var a in json.AsObject["AnswerList"].Childs)
        {
            Answer answer = new Answer
            {
                Content = a.AsObject["Content"],
                AnswerImg = a.AsObject["AnswerImg"],
                IsRight = bool.Parse(a.AsObject["IsRight"]),
                AIpercent = float.Parse(a.AsObject["AIpercent"])
            };
            list.Add(answer);
        }
        question.AnswerList = list.ToArray();

        return question;
    }
}

public class MainQuestionView : AnimateView
{

    [SerializeField]
    private Text _question;
    [SerializeField]
    private Image _questionImg;
    [SerializeField]
    private GameObject _answerBox;
    [SerializeField]
    private GameObject _answerBtn;

    /// <summary>
    /// 传入问题类刷新View
    /// </summary>
    /// <param name="question"></param>
    public void RefreshView(string path,Question question)
    {
        _question.text = question.Content;

        //set question
        var qImg = Resources.Load(path + "/" + question.QuestionImg) as Texture2D;
        _questionImg.sprite = Sprite.Create(qImg, new Rect(0, 0, qImg.width, qImg.height), Vector2.zero);

        //set answer
        for (int i = 0; i < question.AnswerList.Length; i++)
        {
            var answer = (GameObject)Instantiate(_answerBtn, transform.position, transform.rotation);
            answer.transform.SetParent(_answerBox.transform);
            answer.name = "answer_" + i;

            var imgs=answer.GetComponentsInChildren<Image>();

            foreach (var m in imgs)
            {
                if (m.name.Equals("Image"))
                {
                    var aImg = Resources.Load(path + "/" + question.AnswerList[i].AnswerImg) as Texture2D;
                    m.GetComponent<Image>().sprite = Sprite.Create(aImg, new Rect(0, 0, aImg.width, aImg.height), Vector2.zero);
                }
            }
            answer.GetComponentsInChildren<Text>()[0].text = question.AnswerList[i].Content;
        }

        Debug.Log(System.DateTime.Now.ToString("yyyyMMddHHmmss"));
    }

    public override void OnEnter(BaseContext context)
    {
        string path = "Questions/20160612144906";
        MainQuestionContext MQC = (MainQuestionContext)context;

        RefreshView(path, MQC.LoadQuestion("20160612144906"));

        base.OnEnter(context);
    }

    public override void OnExit(BaseContext context)
    {
        base.OnExit(context);
    }

    public override void OnPause(BaseContext context)
    {
        _animator.SetTrigger("OnExit");
    }

    public override void OnResume(BaseContext context)
    {
        _animator.SetTrigger("OnEnter");
    }

    public void OptionCallBack()
    {
        //SingletonHelper<ContextManager>.Instance.Push(new OptionMenuContext());
    }

    public void HighScoreCallBack()
    {
        //SingletonHelper<ContextManager>.Instance.Push(new HighScoreContext());
    }
}
