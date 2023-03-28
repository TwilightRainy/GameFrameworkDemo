using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo1_ProcedureInital : ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        string welcomeMessage = "Hello World!";
        GameFrameworkLog.Info(welcomeMessage);
        GameFrameworkLog.Warning(welcomeMessage);
        GameFrameworkLog.Error(welcomeMessage);
    }
}
