using UnityEngine;
using System.Collections;

public abstract class DestructableObject : MonoBehaviour {

    protected GameObject gObj;
    protected Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        gObj = this.gameObject;
        rb = this.GetComponent<Rigidbody>();

        toStart();
    }

    // Update is called once per frame
    void Update () {
        toUpdate();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            toTrigger();
        }
    }

    protected abstract void toTrigger();
    protected abstract void toStart();
    protected abstract void toUpdate();
}
