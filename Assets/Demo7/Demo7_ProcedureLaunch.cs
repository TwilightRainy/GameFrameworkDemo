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

public class Demo7_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(ProcedureOwer procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Debug.Log("Demo6_ProcedureLanuch OnEnter");

        EventComponent eventComponent = GameEntry.GetComponent<EventComponent>();
        eventComponent.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
        eventComponent.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);

        WebRequestComponent webRequestComponent = GameEntry.GetComponent<WebRequestComponent>();
        string url = "https://www.boy3d.com/zb_users/upload/demo7.txt";
        webRequestComponent.AddWebRequest(url, this);
    }
    //OnWebRequestSuccess
    private void OnWebRequestSuccess(object sender, GameEventArgs e)
    {
        WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }
        string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());
        Log.Debug("responseJson " + responseJson);

        Debug.Log("OnWebRequestSuccess");
    }
    //OnWebRequestFailure
    private void OnWebRequestFailure(object sender, GameEventArgs e)
    {
        WebRequestFailureEventArgs ne = (WebRequestFailureEventArgs)e;
        if (ne.UserData != this)
        {
            return;
        }
        Debug.Log("OnWebRequestFailure");
        Debug.Log(ne.ErrorMessage);
    }
}
