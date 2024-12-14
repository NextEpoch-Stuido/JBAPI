#  JBAPI 使用文档

## HINT
  JBAPI提供了四个Hint方法，分别是RuelHint(生成一个位置不变的Hint)、PosHint(自动变换位置的Hint，在上一条的下方)、AllTimeHint(永久显示的Hint)、DeleteRuelHint(移除Hint)
  下面将介绍每一种Hint的使用方法
### RuelHint
例子：
``` csharp
using JBAPI.Features.Hint;

player.RuelHint(400, "这是一条用于测试的Hint", 10);
```
特点：给指定的玩家发送一条Hint
参数：位置，文本，时间

### PosHint
``` csharp
using JBAPI.Features.Hint;

player.PosHint(400, "这是一条用于测试的Hint", 10);
```
特点：给指定的玩家发送一条自变位置的Hint
参数：位置，文本，时间

### AllTimeHint
``` csharp
using JBAPI.Features.Hint;

player.AllTimeHint(400, "这是一条用于测试的Hint");
```
特点：给指定的玩家发送一条永久显示的Hint
参数：位置，文本

### DeleteRuelHint
``` csharp
using JBAPI.Features.Hint;

player.DeleteRuelHint();
```
特点：移除指定玩家的Hint
参数：无

## 称号
本API提供了两种称号，分别为彩称，单色称号，他们的使用方法十分的简单

### 彩色称号
``` csharp
using JBAPI.Features.Badg;

player.RainbowTag("宇宙无敌超级神威霸王龙",0.5f,true);
```
特点：不断变换称号的颜色，彰显您无与伦比的尊贵
参数：称号文本，颜色变换频率, 是否启用（如果不启用则默认为红色）

### 单色称号
``` csharp
using JBAPI.Features.Badge;

player.Tags("宇宙无敌超级神威霸王龙","cyam",true);
```
特点：只有一种颜色的称号，更为便捷的称号!  
参数：称号文本，称号颜色，(可选)是否覆盖前称号

## 日志
### 服务器日志
JBAPI提供了***4***种服务器日志，这里使用默认日志与自定义日志为例子，另外两个日志相同性质
``` csharp
using JBAPI.Features.Log;

ServerLog.AddLog("这是一条用于测试用的日志"); // 默认日志  他会输出一条淡蓝色的日志
ServerLog.CustomLog("这是一条用于测试用的日志", System.ConsoleColor.Red); // 自定义颜色日志  他会输出一条指定颜色（示例为红色）的日志
```

## 角色
### 随机选取指定角色的玩家
该功能适用于使用事件实现的自定义角色，该方法帮您选取玩家！
``` csharp
using JBAPI.Features.CustomRole;
using Exiled.API.Features;

public Player ply;
var ply = RandomRolePlayer.RandomSelectPlayer(RoleTypeId.ClassD, new List<string> { "SCP181", "SCP457" }, true); // 随机选取角色为D级人员的玩家，同时跳过称号为SCP181和SCP457的玩家，允许发送日志
```
特点：随机选取一名玩家
参数：选取什么角色的玩家，跳过称号中带有什么的玩家，是否启用日志

***称号可用颜色:***
* pink
* red
* brown
* silver
* light_green
* crimson
* cyan
* aqua
* deep_pink
* tomato
* yellow
* magenta
* blue_green
* orange
* lime
* green
* emerald
* carmine
* nickel
* mint
* army_green
* pumpkin
--------------------
