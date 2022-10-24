using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuskyPlayer : Human
{
    InputMananger inputMananger;

    [SerializeField] public bool isGrap = false;
    [SerializeField] private Item item = null;
    // Start is called before the first frame update
    void Start()
    {
        InitCollider();
        InitRigidbody();
    }
    private void Awake()
    {
        //Player Controlled by InputManager
        inputMananger = gameObject.AddComponent<InputMananger>();
    }



    // Update is called once per frame
    void Update()
    {

        if (inputMananger.Vertical == 0f && inputMananger.Horizontal == 0)
        {
            isMove = false;
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            isMove = true;
            _rigidbody.velocity = new Vector3(inputMananger.Horizontal * walkSpeed, 0, inputMananger.Vertical * walkSpeed);
        }
        if (Input.GetKey(KeyCode.LeftControl)) // Pick Up Item
        {
            isGrap = true;
        }
        else // Get Key Up for Drop Item
        {
            isGrap = false;
            if (transform.GetComponentInChildren<Item>() != null)
            {
                item = GetComponentInChildren<Item>();
                item.gameObject.transform.SetParent(null);

            }
        }
    }
    void DropItem(Transform pos) // My Grap Item(Child Item) SetParent Off
    {
        pos.gameObject.transform.SetParent(null);
    }
    private void OnCollisionStay(Collision collision) // Check Item Collision
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            if (isGrap)
            {
                collision.gameObject.transform.SetParent(this.transform);
                collision.transform.position += Vector3.zero;
            }

        }
    }
}
