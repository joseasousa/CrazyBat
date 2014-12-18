using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class ButonMessagerBehavior : MonoBehaviour
{
    public GameObject target;
    public string message;

    void Start()
    {
        GetComponent<PressGesture>().StateChanged += HandleStateChanged;
    }

    void HandleStateChanged(object sender, GestureStateChangeEventArgs e)
    {
        if (e.State == Gesture.GestureState.Ended)
        {
            target.SendMessage(message, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
