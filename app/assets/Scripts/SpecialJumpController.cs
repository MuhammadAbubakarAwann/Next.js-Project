using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialJumpController : MonoBehaviour
{
    private PlayerMovement tempPlayer;
    public float specialJumpPower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        tempPlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("specialHurdle"))
        {
            tempPlayer.EnablePlayerSpecialJump(specialJumpPower);
        }
    }

    // call a coroutine before disabling the special jump effect
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("specialHurdle"))
        {
            StartCoroutine(DisablingAfterTime());
        }
    }

    IEnumerator DisablingAfterTime()
    {
        yield return new WaitForSeconds(0.7f);

        tempPlayer.DisablePlayerSpecialJump(specialJumpPower);
    }
}
