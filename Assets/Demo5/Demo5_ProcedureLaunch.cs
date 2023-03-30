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

        DataTableComponent DataTable = GameEntry.GetComponent<DataTableComponent>();
        Type dataRowType = Type.GetType("DRHero");
        DataTableBase dataTableBase = DataTable.CreateDataTable(dataRowType);
        dataTableBase.ReadData("Assets/Demo5/Hero.txt");

    }
    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        //LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
        //if (ne.UserData != this)
        //{
        //    return;
        //}
        // 获取框架数据表组件
        DataTableComponent DataTable = GameEntry.GetComponent<DataTableComponent>();
        // 获得数据表
        IDataTable<DRHero> dtScene = DataTable.GetDataTable<DRHero>();

        // 获得所有行
        DRHero[] drHeros = dtScene.GetAllDataRows();

        Log.Debug("drHeros:" + drHeros.Length);
        // 根据行号获得某一行
        DRHero drScene = dtScene.GetDataRow(1); // 或直接使用 dtScene[1]
        if (drScene != null)
        {
            // 此行存在，可以获取内容了
            string name = drScene.name;
            int atk = drScene.attack;
            Log.Debug("name:" + name + ", atk:" + atk);
        }
        else
        {
            // 此行不存在
        }

        // 获得满足条件的所有行
        DRHero[] drScenesWithCondition = dtScene.GetDataRows(x => x.Id > 0);

        // 获得满足条件的第一行
        DRHero drSceneWithCondition = dtScene.GetDataRow(x => x.name == "三笠");
        Log.Debug(drSceneWithCondition.name);
        Debug.Log("OnLoadDataTableSuccess");
    }
}
