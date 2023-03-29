using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
public class Demo4_ProcedureLaunch : ProcedureBase
{

    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo4_ProcedureLanuch OnEnter");
        SceneComponent sceneComponent = GameEntry.GetComponent<SceneComponent>();
        sceneComponent.LoadScene("Assets/Demo4/Demo4_Menu.unity", this);
        ChangeState<Demo4_ProcedureMenu>(procedureOwner);
    }
}
