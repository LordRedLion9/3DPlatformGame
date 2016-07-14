using UnityEngine;
using System.Collections;

public abstract class Collectable : MonoBehaviour {

    protected GameObject gObj;
    protected Rigidbody rb;


	
	void Start () {
        gObj = this.gameObject;
        rb = this.GetComponent<Rigidbody>();

        toStart();
    }
	
	
	void Update () {
        toUpdate();
	}

    
    void remove()
    {
        Destroy(gObj);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Parent trigger");
            toTrigger();
        }
    }

    protected abstract void toTrigger();
    protected abstract void toStart();
    protected abstract void toUpdate();
    protected abstract void animate();

}
