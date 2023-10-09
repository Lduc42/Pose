using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject[] CharacterStates;
    public List<Dragger> dragger;

    public int currentIndex = 0;
    public float internalCheck;

    // Start is called before the first frame update
    void Start()
    {
        GetDraggerComponent();
        ActiveObject(currentIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu người dùng nhấp chuột trái
        if (Input.GetMouseButtonUp(0))
        {
            if (Vector3.Distance(dragger[currentIndex].transform.position, dragger[currentIndex].GetMousePos()) < internalCheck)
            {
                Debug.Log("nhap chuot");
            }
            //Debug.Log("nhap chuot");
        }
    }

    private void OnMouseUp()
    {
        if (Vector3.Distance(dragger[currentIndex].transform.position, dragger[currentIndex].GetMousePos()) < internalCheck)
        {
            Debug.Log("nhap chuot");
        }
    }

    private void GetDraggerComponent()
    {
        foreach(var character_states in CharacterStates)
        {
            dragger.Add(character_states.GetComponent<Dragger>());
        }
    }

    protected void SwitchObject()
    {
        DeactiveObject(currentIndex);
        currentIndex++;

        if(currentIndex >= CharacterStates.Length)
        {
            currentIndex = 0;
        }

        ActiveObject(currentIndex);
    }

    protected void ActiveObject(int index)
    {
        CharacterStates[index].gameObject.SetActive(true);
    }

    protected void DeactiveObject(int index)
    {
        CharacterStates[index].gameObject.SetActive(false);
    }
}
