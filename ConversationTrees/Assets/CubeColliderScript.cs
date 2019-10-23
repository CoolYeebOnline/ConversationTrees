using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeColliderScript : MonoBehaviour
{
    private bool PlayerInRange = false;

    private Text PlayerText;

    ConversationClass currentNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerInRange) return;

        PlayerText.text = currentNode.Message;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentNode = currentNode.response1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentNode = currentNode.response2;
        }

        if (currentNode == null)
        {
            PlayerText.text = "";
            PlayerInRange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.tag == "Player")
        {
            PlayerInRange = true;
            PlayerText = GameObject.FindWithTag("PlayerText").GetComponent<Text>();
            currentNode = ConversationTree;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            PlayerInRange = false;
            PlayerText.text = string.Empty;
            PlayerText = null;
            
        }
    }
    private ConversationClass ConversationTree = new ConversationClass()
    {
        Message = "Hello, how are you today? \n [1 - Great, let's talk again], [2 - Okay, Goodbye",
        response1 = new ConversationClass()
        {
            Message = "I'm fine thanks \n [1 - Great, let's talk again], [2 - Ok, Goodbye]",
            response1 = new ConversationClass()
            {
                Message = "Great, we certainly will!",
                response1 = null,
                response2 = null
            },
            response2 = null
        },
        response2 = new ConversationClass()
        {
            Message = "Ok, Goodbye!",
            response1 = null,
            response2 = null
        }
    };
}
