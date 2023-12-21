using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public CharacterController mCharacterController;

    private float hInput;
    private float vInput;
    private float speed;

    public Vector2 direction;

    public float force;
    public GameObject pointPre;
    public GameObject[] points;


    [SerializeField]
    public float mWalkSpeed = 10f;
    public int noOfPoints;
    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
        points = new GameObject[noOfPoints];

        FillArray();

    }

    // Update is called once per frame
    void Update()
    {

        HandleInputs();
        Move();
        Follow();
        for(int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = Pointpos(i * 0.1f);
        }

    }

    private void HandleInputs()
    {
        // We shall handle our inputs here.
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");



        speed = mWalkSpeed;

    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");



        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        mCharacterController.Move(move * Time.deltaTime * mWalkSpeed);
    }
    private void Follow()
    {
        Vector2 mosePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//find the mosepos on the screen

        Vector2 playerPos = transform.position;

        direction = mosePos - playerPos;

        Facing();
    }

    private void Facing()
    {
        transform.right = direction;
    }
    private void FillArray()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = Instantiate(pointPre, transform.position, Quaternion.identity);
        }
    }

    Vector2 Pointpos(float t)
    {
        Vector2 currentpos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t*t);
        return currentpos;
    }
}
       

    
