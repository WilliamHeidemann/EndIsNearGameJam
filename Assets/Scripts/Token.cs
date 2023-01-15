using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Token : MonoBehaviour, IInteractable
{
    public static ICollection<Token> Tokens = new List<Token>();
    public string Message;
    public int Order;
    public void Read()
    {
        print(Message);
    }

    public void Interact()
    {
        Tokens.Add(this);
        Destroy(gameObject);
    }
}