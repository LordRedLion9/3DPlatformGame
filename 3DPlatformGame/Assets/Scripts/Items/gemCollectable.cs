using UnityEngine;
using System.Collections;
using System;

public class gemCollectable : Collectable {

    protected override void toStart()
    {

    }

    protected override void toUpdate()
    {
        
        animate();
    }

    protected override void animate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    protected override void toTrigger()
    {
        remove();
    }


}
