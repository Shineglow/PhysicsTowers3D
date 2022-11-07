using UnityEngine;
using UnityEngine.UI;

public class TriggerDebug : MonoBehaviour
{
    public Text text;
    public BoxCollider self;
    public Rigidbody rb;
    public float contactOfsetLimit;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    foreach(var i in collision.contacts)
    //    {
    //        if (i.separation > contactOfsetLimit) 
    //        {
    //            BlockContactHandler();
    //            return;
    //        }
    //    }
    //    self.isTrigger = true;
    //}

    //private void BlockContactHandler()
    //{
    //    Debug.Log("it's work");
    //}

    private void OnTriggerEnter(Collider other)
    {
        //if (Physics.Raycast(new Ray(), out RaycastHit hit, 3f, QueryTriggerInteraction.))
        //other.ClosestPoint();
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    string str = "";

    //    foreach(var i in collision.contacts)
    //    {
    //        str += i.separation + "\n";
    //        Debug.Log(str);
    //    }

    //    text.text = str;
    //}

    //private void OnCollisionExit(Collision collision)
    //{

    //}
}
