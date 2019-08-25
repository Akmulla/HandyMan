using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject[] stck;
    private int tos;
    public GameObject obj;
    public int size;

    public void Awake() 
    {
        stck = new GameObject[size];
        tos = size;
        for (int i = 0 ; i < size ; i++)
        {
            stck[i] = ((GameObject)Instantiate(obj, Vector2.zero, Quaternion.identity));
            stck[i].GetComponent<PoolRef>().pool = this;
            stck[i].SetActive(false);
        }
    }

    public GameObject Activate(Vector3 pos, Quaternion rot)
    {
        GameObject obj = Pop();
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        obj.SetActive(true);
        return (obj);
    }

    public void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
        Push(obj);
    }

    public void Push(GameObject obj)
    {
        if (tos >= stck.Length)
        {
            Debug.Log("Stack is already full");
            return;
        }
        stck[tos] = obj;
        tos++;
    }

    public GameObject Pop()
    {
        if (tos <= 0)
        {
            Debug.Log("Stack is empty");
            return null;
        }
        tos--;
        return stck[tos];
    }
}
