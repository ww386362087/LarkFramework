using UnityEngine;
using System.Collections;

public class Test_1DBlendTree : MonoBehaviour {

    private Animator ani;
    private float vertical;
    private float horizontal;
    private float runspeed = 1;
    private bool stand = true;
    private bool jump;
    private bool fly;
    private bool grounded;
    private bool fowardPressed;
    private int dragoInt;

    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        fowardPressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow); //If foward is pressed

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(RunspeedChanged(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(RunspeedChanged(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(RunspeedChanged(3));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fly = !fly;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isJumping() && grounded)
            {
                jump = true;
            }
        }
        else
        {
            jump = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            dragoInt = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("Fire");
        }

        if ((horizontal != 0) || (vertical != 0))
            stand = false;
        else stand = true;

        if (jump) stand = false;

        Falling();

        //print("-----------:"+vertical + "|" + horizontal);

        ani.SetFloat("Speed", vertical* runspeed);
        ani.SetFloat("Direction", horizontal, 0.25f, Time.deltaTime);
        ani.SetBool("Stand", stand);
        ani.SetBool("Jump", jump);
        ani.SetBool("Fly", fly);
        ani.SetBool("Grounded", grounded);
        ani.SetBool("FowardPressed", fowardPressed);
        ani.SetInteger("DragoInt", dragoInt);

        //print(ani.GetFloat("Speed") + "|" + ani.GetFloat("Direction"));
    }

    void Falling()
    {
        RaycastHit hitGrounded;

        if (Physics.Raycast(transform.position, -transform.up, out hitGrounded, .1f))
        {
            if (isJumping(0.5f, true))
            {
                grounded = false;
            }
            else
            {
                grounded = true;
            }
        }
        else
        {
            grounded = false;
        }
    }

    bool isJumping(float normalizedtime, bool half)
    {
        if (half)  //if is jumping the first half
        {

            if (ani.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime < normalizedtime)
                    return true;
            }

            if (ani.GetNextAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (ani.GetNextAnimatorStateInfo(0).normalizedTime < normalizedtime)
                    return true;
            }
        }
        else //if is jumping the second half
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedtime)
                    return true;
            }

            if (ani.GetNextAnimatorStateInfo(0).IsTag("Jump"))
            {
                if (ani.GetNextAnimatorStateInfo(0).normalizedTime > normalizedtime)
                    return true;
            }
        }


        return false;

    }
    bool isJumping()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
        {
            return true;
        }
        if (ani.GetNextAnimatorStateInfo(0).IsTag("Jump"))
        {
            return true;
        }
        return false;
    }

    IEnumerator RunspeedChanged(float tagSpeed)
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            runspeed = Mathf.MoveTowards(runspeed, tagSpeed, Time.deltaTime);
            yield return null;
        }
    }
}
