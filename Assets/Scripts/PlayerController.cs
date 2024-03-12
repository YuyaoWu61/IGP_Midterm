using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletTracker;
    public GameObject gunPoint;
    public bool canShoot = true;
    public float shootTime = .2f;

    private float mouseSensitivity = 3.5f;

    public Camera m_cam;
    Transform cameraTrans;
    float cameraPitch = 0;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameManager = GameObject.FindWithTag("GM");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity);

        //Constraint the camera pitch inbetween -90 to 90
        cameraPitch -= mouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        cameraTrans.localEulerAngles = Vector3.right * cameraPitch;


        if(gameManager.GetComponent<GameManager>().bulletNum <= 2){
            if (Input.GetMouseButtonUp(0) && canShoot)
            {
                SpawnBullets();
                canShoot = false;
                StartCoroutine(SetBoolAfterDelay(shootTime));
            }
        }
        

        if(Input.GetMouseButtonUp(1) && canShoot && gameManager.GetComponent<GameManager>().killTotal >= 3){
            gameManager.GetComponent<GameManager>().killTotal -= 3;
            GameObject btrack = Instantiate(bulletTracker, gunPoint.transform.position, Quaternion.identity);
            canShoot = false;
            StartCoroutine(SetBoolAfterDelay(shootTime));
        }
    }

    public void SpawnBullets(){
        GameObject b = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        // m_cam.

    }

    IEnumerator SetBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
        
    }
}
