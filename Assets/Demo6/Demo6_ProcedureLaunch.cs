using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.DataTable;
using GameFramework.Event;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using System;

public class Demo6_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo6_ProcedureLanuch OnEnter");

        EntityComponent entityComponent=GameEntry.GetComponent<EntityComponent>();
        entityComponent.ShowEntity<HeroLogic>(1, "Assets/Demo6/HeroEntity.prefab", "HeroGroup");
    }
}
