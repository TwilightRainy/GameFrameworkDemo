using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;


public class Demo4_ProcedureMenu : ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo4_ProcedureMenu OnEnter");
        EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
        eventComponent.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

        UIComponent uIComponent = GameEntry.GetComponent<UIComponent>();
        uIComponent.OpenUIForm("Assets/Demo3/UI_Menu.prefab", "DefaultGroup", this);
    }
    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }
        Debug.Log("UI_Menu Success");
    }
}
