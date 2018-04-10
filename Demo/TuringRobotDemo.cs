using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HuiHut.Turing;

class TuringRobotDemo : MonoBehaviour
{
	#region
    /*
    * 
    * Repository: https://github.com/huihut/TuringRobot
    * Email: huihut@outlook.com
    * 
    * 图灵机器人：http://www.tuling123.com/
    * 帮助文档：http://www.tuling123.com/help/h_cent_webapi.jhtml?nav=doc
    * 
    */
    #endregion
    
    /// <summary>
    /// 图灵机器人
    /// </summary>
    private TuringRobot turingRobot = new TuringRobot();

    /// <summary>
    /// 图灵机器人API Key（此处改为你的 API_Key ）
    /// </summary>
    public string API_Key = @"2ee6e84a755b4ac2b5b2cc25d992b03a";

    /// <summary>
    /// 随机生成用户ID，用于关联上下文语境
    /// </summary>
    private string userID = new System.Random().Next(0, int.MaxValue).ToString();

    /// <summary>
    /// 用户输入消息
    /// </summary>
    private static string userMessage = string.Empty;

    /// <summary>
    /// 机器人回复的消息
    /// </summary>
    private static string robotMessage = string.Empty;

    /// <summary>
    /// 机器人返回链接列表
    /// </summary>
    private static List<string> robotLinks = new List<string>();

    /// <summary>
    /// 测试图灵机器人回复的文本
    /// </summary>
    private Text testMessageText;

    // Use this for initialization
    void Start()
    {
        // 关联Text组件，用于显示机器人回复的文本
        testMessageText = GameObject.Find("TestMessageText").GetComponent<Text>();

        // 使用设备唯一标识
        userID = SystemInfo.deviceUniqueIdentifier;

        // 初始化图灵机器人
        turingRobot.initRobot(API_Key, userID);
    }

    // 按下发送按钮
    public void OnUserMessageSendButton()
    {
        // 关联InputField组件，获取用户输入的内容
        userMessage = GameObject.Find("userMessageInputField").GetComponent<InputField>().text;

        // 用户消息传入机器人，获取机器人回复信息、回复链接
        turingRobot.Chat(userMessage, ref robotMessage, ref robotLinks);

        // 判断返回消息有无链接
        if (robotLinks.Count == 0)  // 机器人回复的消息无链接
        {
            // 把信息显示在测试的text中
            testMessageText.text = robotMessage;
        }
        else  // 机器人回复的消息有链接
        {
            // 把信息显示在测试的text中
            testMessageText.text = robotMessage;
            // 显示每个链接
            foreach (string Link in robotLinks)
                testMessageText.text += ("\n" + Link);
        }

    }

}