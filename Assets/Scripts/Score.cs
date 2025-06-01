using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Updates the Score readout display once every 1-second
// create a Legact TextMesh object for HUD
// attach as child to Main Camera (whcih is a child of Player
// position (-4, 2.5, 5)
// rotation (0, 0, 0)
// scale (0.2, 0.2, 0.2)
// receive shadows = off
// font size = 20
// if the lag is too much as 1-second, shorten to 0.5 or 0.25 second

public class Score : MonoBehaviour
{
    public int maxDiamonds;
    public int currentDiamonds;
    public int maxEnemies;
    public int currentEnemies;

    // local
    TextMesh scoreText;
    string HUDtext;

    // Awake is called when object created
    private void Awake()
    {
        // initialize scoring
        maxDiamonds = 0;
        currentDiamonds = 0;
        maxEnemies = 0;
        currentEnemies = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        // find & set the TextMesh object
        scoreText = GetComponent<TextMesh>();
        scoreText.text = HUDtext;

        // initialize HUDtext
        HUDtext = "";

        // update score display regularly
        InvokeRepeating("ScoreUpdate", 0.1f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnDestroy()
    {
        CancelInvoke();
    }

    // Update is called once per second
    void ScoreUpdate()
    {
        // set HUD to current score
        HUDtext = string.Format("Diamonds: {0:0}/{1:0}\nEnemies: {2:0}/{3:0}", currentDiamonds, maxDiamonds, currentEnemies, maxEnemies);

        // check if all coins collected to add WINNER
        if (currentDiamonds >= maxDiamonds)
        {
            HUDtext += "\nWINNER";
        }

        // set TextMesh to display HUDtext string
        scoreText.text = HUDtext;
    }

}
