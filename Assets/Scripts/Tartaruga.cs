using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tartaruga : MonoBehaviour
{
    Rigidbody2D rbTartaruga;
    [SerializeField] float speed = 2f;


    private void Awake() {
        rbTartaruga = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        rbTartaruga.velocity = new Vector2(speed, rbTartaruga.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
