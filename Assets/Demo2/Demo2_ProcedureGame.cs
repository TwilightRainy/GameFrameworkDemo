using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwer = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo2_ProcedureGame : ProcedureBase
{
    protected override void OnInit(ProcedureOwer procedureOwner)
    {
        base.OnInit(procedureOwner);
        Log.Debug("������Ϸ���̣����������ﴦ����Ϸ�߼���������־�����ӡ����Ϊû���л���Game����");
    }
}
