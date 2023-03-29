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
using System.Data;
using Unity.VisualScripting;

public class Demo5_ProcedureLaunch : ProcedureBase
{
    private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo5_ProcedureLanuch OnEnter");
        EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
        eventComponent.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
        IDataTable<DRHero> dtWeapon = dataTableComponent.GetDataTable<DRHero>();
        DRHero drWeapon = dtWeapon.GetDataRow(1);
        Debug.LogError(drWeapon.Id);
    }
    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }
        Debug.Log("OnLoadDataTableSuccess");
    }
}
