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
        // ��ȡ������ݱ����
        DataTableComponent DataTable = GameEntry.GetComponent<DataTableComponent>();
        // ������ݱ�
        IDataTable<DRHero> dtScene = DataTable.GetDataTable<DRHero>();

        // ���������
        DRHero[] drHeros = dtScene.GetAllDataRows();

        Log.Debug("drHeros:" + drHeros.Length);
        // �����кŻ��ĳһ��
        DRHero drScene = dtScene.GetDataRow(1); // ��ֱ��ʹ�� dtScene[1]
        if (drScene != null)
        {
            // ���д��ڣ����Ի�ȡ������
            string name = drScene.name;
            int atk = drScene.attack;
            Log.Debug("name:" + name + ", atk:" + atk);
        }
        else
        {
            // ���в�����
        }

        // �������������������
        DRHero[] drScenesWithCondition = dtScene.GetDataRows(x => x.Id > 0);

        // ������������ĵ�һ��
        DRHero drSceneWithCondition = dtScene.GetDataRow(x => x.name == "����");
        Log.Debug(drSceneWithCondition.name);
        Debug.Log("OnLoadDataTableSuccess");
    }
}
