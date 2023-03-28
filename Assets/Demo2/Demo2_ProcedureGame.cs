using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo2_ProcedureGame : ProcedureBase
{
    protected override void OnInit(ProcedureOwer procedureOwner)
    {
        base.OnInit(procedureOwner);
        Log.Debug("进入游戏流程，可以在这里处理游戏逻辑，这条日志不会打印，因为没有切换到Game流程");
    }
}
