using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo3_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        SceneComponent scene = GameEntry.GetComponent<SceneComponent>();
        scene.LoadScene("Assets/Demo3/Demo3_Menu.unity", this);
        ChangeState<Demo3_ProcedureMenu>(procedureOwner);
    }
}
