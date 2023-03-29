using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo3_ProcedureMenu :ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        UIComponent ui= GameEntry.GetComponent<UIComponent>();
        ui.OpenUIForm("Assets/Demo3/UI_Menu.prefab", "DefaultGroup");
    }
}
