using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharacterSwap : MonoBehaviour
{
    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    int wc;
   // public CinemachineVirtualCamera cam;
   // public Camera cam1;
    public ParticleSystem m_ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wc = whichCharacter;
            if (whichCharacter == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            wc = whichCharacter;
            if (whichCharacter == possibleCharacters.Count - 1)
            {
                whichCharacter = 0;
            }
            else
            {
                whichCharacter += 1;
            }
            if (Vector3.Distance(possibleCharacters[whichCharacter].position, character.position) > 5)
            {
                Debug.Log("Too far");
                whichCharacter = wc;
                return;
            }
            Swap();
        }
    }

    public void Swap()
    {
        Debug.Log("Close enough");
        character = possibleCharacters[whichCharacter];
        character.GetComponent<PlayerController>().enabled = true;
        m_ParticleSystem.transform.position = character.position;
        m_ParticleSystem.Play();
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerController>().enabled = false;
            }
        }

       // cam.LookAt = character;
       // cam.Follow = character;
       // cam1.transform.position = character.position;
       // cam1.transform.rotation = character.rotation;
    }
}