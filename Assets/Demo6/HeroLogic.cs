using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.DataTable;
using GameFramework.Event;

public class HeroLogic : EntityLogic
{
    protected HeroLogic() { }
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        Debug.Log("HeroLogic OnInit");
    }
    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
        Debug.Log("HeroLogic OnShow");
    }
    protected override void OnHide(bool isShutdown, object userData)
    {
        base.OnHide(isShutdown, userData);
        Debug.Log("HeroLogic OnHide");
    }
    protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
    {
        base.OnAttachTo(parentEntity, parentTransform, userData);
        Debug.Log("HeroLogic OnAttachTo");
    }
    protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
    {
        base.OnDetachFrom(parentEntity, userData);
        Debug.Log("HeroLogic OnDetachFrom");
    }
    protected override void OnDetached(EntityLogic childEntity, object userData)
    {
        base.OnDetached(childEntity, userData);
        Debug.Log("HeroLogic OnDetached");
    }
}
