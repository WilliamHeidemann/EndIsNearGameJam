using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class Altar : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Token> tokens;
    public void Interact()
    {
        tokens.AddRange(Token.Tokens);
        Token.Tokens = new List<Token>();
        
        foreach (var token in tokens.OrderBy(token => token.Order))
        {
            token.Read();
        }
    }
}
