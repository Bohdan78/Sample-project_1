using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Vector3 startPosition, currentPosition;

    public GameObject container;

    public Transform platform;
    public float distance;

    private Vector3 mousePos;
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private float border = 20.5f, diffDistance, dirrection;

    public Transform testABS;

    public static CameraController Instance { set; get; }

    private enum ZoomStatus : int { ZOOM, BACK};
    private ZoomStatus zoom = ZoomStatus.BACK;
    private bool allowZoom;

    [SerializeField]
    private float zoomOriginPos, zoomOriginEuler;


    private enum MoveCamera : int { ALLOW, BLOCK};
    private MoveCamera cameraMove = MoveCamera.ALLOW;

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        diffDistance = 1;
        dirrection = 1;

        zoomOriginPos = transform.position.y;
        zoomOriginEuler = transform.rotation.eulerAngles.x;
    }

    public void SetDiffDistance()
    {
        if (dirrection == 1)
        {
            dirrection = -1;
           // diffDistance = 7f;
        }
        else if (dirrection != 1)
        { 
            diffDistance = 1;
            dirrection = 1;
        }
    }

    public void SwitchZoomStatus()
    {
        if (zoom == ZoomStatus.BACK)
            zoom = ZoomStatus.ZOOM;
        else if (zoom == ZoomStatus.ZOOM)
            zoom = ZoomStatus.BACK;
        allowZoom = true;
    }

    public void SwitchMoveStatus()
    {
        if (cameraMove == MoveCamera.ALLOW)
            cameraMove = MoveCamera.BLOCK;
        else if (cameraMove == MoveCamera.BLOCK)
            cameraMove = MoveCamera.ALLOW;
    }

    public void AllowMoveCamera()
    {
        cameraMove = MoveCamera.ALLOW;
    }
	
    public void BlockMoveCamera()
    {
        cameraMove = MoveCamera.BLOCK;
    }
	
	void LateUpdate ()
    {
       // distance = Vector3.Distance(transform.position, platform.position);

        if (Input.GetMouseButtonDown(0))
        {

            mousePos = Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //print("POINT" + hit.point);
                startPosition = hit.point;
            }
            else
            {
                mousePos.z = Camera.main.transform.position.y;
                startPosition = Camera.main.ScreenToWorldPoint(mousePos);
            }


        }

        else if (Input.GetMouseButton(0) && cameraMove == MoveCamera.ALLOW)
        {
            mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            currentPosition = Camera.main.ScreenToWorldPoint(mousePos);

            if (Vector3.Distance(startPosition, currentPosition) > diffDistance)
            {
                float x = Mathf.Clamp(startPosition.x - currentPosition.x + Camera.main.transform.position.x, -border, border);
                float z = Mathf.Clamp(startPosition.z - currentPosition.z + Camera.main.transform.position.z, -border, border);
                Vector3 desiredPosition = new Vector3(x * dirrection, Camera.main.transform.position.y, z * dirrection);
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.25f);
                
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            startPosition = Vector3.zero;
            currentPosition = Vector3.zero;
            mousePos = Vector3.zero;
        }

        if(allowZoom)
        {
            if (zoom == ZoomStatus.BACK)
                Zoom(zoomOriginPos, zoomOriginEuler);
            else if(zoom == ZoomStatus.ZOOM)
                Zoom(zoomOriginPos /2, zoomOriginEuler / 2);
        }

    }

    public void Zoom(float pY, float eX)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, pY, transform.position.z), Time.deltaTime * 6);
        transform.eulerAngles= Vector3.MoveTowards(transform.eulerAngles, new Vector3(eX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), Time.deltaTime * 18);
        if (transform.position.y == pY && transform.eulerAngles.y == eX)
            allowZoom = false;
    }

      

//#if UNITY_EDITOR || UNITY_STANDALONE

//#else

//#endif
    

    
}
