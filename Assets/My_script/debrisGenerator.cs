using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class debrisGenerator : MonoBehaviour
{
    [Tooltip("Nombre maximal de Cubes (simultan��ment) dans le jeu")]
    public int maxCubeInPlayGround = 200;
    private int counter = 0;
    public GameObject source;

    [Tooltip("Nombre minimal de frame entre deux spawns de Junk")]
    public int minFrame = 3;
    [Tooltip("Nombre maximal de frame entre deux spawns de Cube")]
    public int maxFrame = 10;

    private int frameRate = 0;

    private Rigidbody myJunk;

    public Rigidbody junk1;
    public Rigidbody junk2;
    public Rigidbody junk3;
    public Rigidbody junk4;
    public Rigidbody junk5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("createJunk");
    }

    IEnumerator createJunk()
    {
        if (counter < maxCubeInPlayGround)
        {
            switch (Random.Range(1, 6))
            {
                case 1:
                    myJunk = junk1;
                    break;
                case 2:
                    myJunk = junk2;
                    break;
                case 3:
                    myJunk = junk3;
                    break;
                case 4:
                    myJunk = junk4;
                    break;
                case 5:
                    myJunk = junk5;
                    break;
                default:
                    break;
            }
            // Instanciation du dechet spacial
            Quaternion rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            Rigidbody junk = Instantiate(myJunk, source.transform.position, rotation) as Rigidbody;

            counter++;
            // Choix aleatoire du temps d'attente avant la prochaine coroutine
            frameRate = Random.Range(minFrame, maxFrame);
        }
        // Attente
        yield return new WaitForSeconds(frameRate / 10.0f);
        // Demarrage de la coroutine suivante
        StartCoroutine("createJunk");
    }

    public void JunkDestroyed()
    {
        counter--;
    }
}