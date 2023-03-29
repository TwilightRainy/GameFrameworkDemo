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

public class Demo5_ProcedureLaunch : ProcedureBase
{
    private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo5_ProcedureLanuch OnEnter");
        EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
        eventComponent.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);
        string dataTableName = "Assets/Demo5/Hero.txt";
        m_LoadedFlag.Add(dataTableName, false);
        string[] splitedNames = dataTableName.Split('_');
        Log.Error("Length " + splitedNames.Length);
        if (splitedNames.Length > 2)
        {
            Log.Warning("Data table name is invalid.");
            return;
        }

        string dataRowClassName = "DRHero";
        Type dataRowType = Type.GetType(dataRowClassName);
        if (dataRowType == null)
        {
            Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
            return;
        }

        string name = splitedNames.Length > 1 ? splitedNames[1] : null;
        DataTableComponent dataTableComponent = GameEntry.GetComponent<DataTableComponent>();
        DataTableBase dataTable = dataTableComponent.CreateDataTable(dataRowType, name);
        dataTable.ReadData(dataTableName, 100, this);
        IDataTable<DRHero> dtHero = dataTableComponent.GetDataTable<DRHero>();
        DRHero drHero = dtHero.GetDataRow(1);
        if (drHero == null)
        {
            Log.Debug("Null");
            return;
        }
        Log.Debug(drHero.Id);
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
