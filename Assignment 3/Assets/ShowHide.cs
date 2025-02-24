using UnityEngine;

public class ShowHideObject : MonoBehaviour
{
    public GameObject targetObject;

    // Show the object
    public void ShowObject()
    {
        targetObject.SetActive(true);
    }

    // Hide the object
    public void HideObject()
    {
        targetObject.SetActive(false);
    }
}
