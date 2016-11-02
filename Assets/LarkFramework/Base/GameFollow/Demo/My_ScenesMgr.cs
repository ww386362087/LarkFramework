﻿/*---------------------------------------------------------------
 * 作者：evesgf    创建时间：2016-10-21 15:09:50
 * 修改：evesgf    修改时间：2016-10-21 15:09:54
 * 联系：Email     821113542@qq.com
 *
 * 版本：V0.0.1
 * 
 * 描述：管理器基类
 ---------------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using LarkFramework.GameFollow;

public class My_ScenesMgr : ManagerBase<My_ScenesMgr> {

    public override void Init()
    {
        base.Init();

        print("My_ScenesMgr Init");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        print("My_ScenesMgr OnUpdate");
    }

    public override void OnDestory()
    {
        base.OnDestory();

        print("My_ScenesMgr OnDestory");
    }
}
