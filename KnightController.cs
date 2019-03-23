using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    string path;
    string jsonString;
    float speed = 4;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;

    Vector3 movDir = Vector3.zero;
    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void converter()
    {
        path = Application.dataPath + "/output.json";
        jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);
        print(jsonString);

    }


    // Update is called once per frame
    void Update()
    {
        Movemement();
        GetInput();
    }
    void Movemement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("attacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("attacking") == false)
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("condition", 1);
                    movDir = new Vector3(0, 0, 1);
                    movDir = movDir * speed;
                    movDir = transform.TransformDirection(movDir);
                }
                }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false);
                anim.SetInteger("condition", 0);
                movDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        movDir.y -= gravity * Time.deltaTime;
        controller.Move(movDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(anim.GetBool("running")==true)
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                }
                if(anim.GetBool("running")==false)
                {
                    Attacking();
                }   
            }
        }
    }

    void Attacking()
    {
        StartCoroutine(attackRoutine());
    }
    IEnumerator attackRoutine()
    {
        anim.SetBool("attacking", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
    }
}
