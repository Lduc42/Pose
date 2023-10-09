using UnityEngine;

public class Dragger : MonoBehaviour {

    public Vector3 _dragOffset;
    private Camera _cam;


    [SerializeField] private float _speed = 10;

    void Awake() {
        _cam = Camera.main;
    }

    private void Update()
    {
        // Kiểm tra nếu người dùng nhấp chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            
            //Debug.Log("nhap chuot");
        }
    }

    void OnMouseDown() {
        _dragOffset = transform.position - GetMousePos();
        _dragOffset.z = 0;
    }

    void OnMouseDrag() {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime) ;
    }

    private void OnMouseUp()
    {
        //if (Vector3.Distance(this.transform.position, GetMousePos())< 2) Debug.Log("nhap chuot");
    }

    public Vector3 GetMousePos() {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}