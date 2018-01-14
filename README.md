# TuringRobot

图灵机器人的 Unity 脚本 

* 图灵机器人官网：http://www.tuling123.com/
* 图灵机器人帮助文档：http://www.tuling123.com/help/h_cent_webapi.jhtml?nav=doc

## Usage

[TuringRobotDemo.cs](https://github.com/huihut/TuringRobot/blob/master/Demo/TuringRobotDemo.cs)

声明命名空间：
```
using HuiHut.Turing;
```

定义变量：
```
// 图灵机器人
private TuringRobot turingRobot = new TuringRobot();

// 图灵机器人API Key
public string API_Key = @"2ee6e84a755b4ac2b5b2cc25d992b03a";

// 随机生成用户ID，用于关联上下文语境
private string userID = new System.Random().Next(0, int.MaxValue).ToString();

// 用户输入消息
private string userMessage = string.Empty;

// 机器人回复的消息
private string robotMessage = string.Empty;

// 机器人返回链接列表
private List<string> robotLinks = new List<string>();
```

初始化图灵机器人：
```
// Use this for initialization
void Start()
{
    // 使用设备唯一标识
    userID = SystemInfo.deviceUniqueIdentifier;

    // 初始化图灵机器人
    turingRobot.initRobot(API_Key, userID);
}
```

聊天：
```
// 用户消息传入机器人，获取机器人回复信息、回复链接
turingRobot.Chat(userMessage, ref robotMessage, ref robotLinks);
```

使用回复信息、回复链接：
```
// 判断返回消息有无链接
if (robotLinks.Count == 0)  // 机器人回复的消息无链接
{
    // 把信息显示在测试的text中
    Debug.Log("TuringRobot: " + robotMessage);
}
else  // 机器人回复的消息有链接
{
    // 把信息显示在测试的text中
    Debug.Log("TuringRobot: " + robotMessage);
    // 显示每个链接
    foreach (string Link in robotLinks)
        Debug.Log("\n" + Link);
}
```