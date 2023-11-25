using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{

    public GameObject coin;
    public List<GameObject> tracks;
    public int trackNumber = 0;
    public int coins = 0;
    public TMP_Text coinText;
    public GameObject fade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Finish"))
        {
            GameObject coinInst = Instantiate(coin, transform);
            coinInst.GetComponent<AudioSource>().Play();
            Destroy(coinInst, 0.5f);
            coins++;
            if (coins == 5)
            {
                trackNumber = 1;
                StartCoroutine(TransicionCambio());
            }
            else if (coins >= 10)
            {
                if (coins == 10)
                {
                    trackNumber = 2;
                    StartCoroutine(TransicionCambio());
                } else
                {
                    ChangeTrack();
                }

            }
            coinText.text = coins.ToString();
        }
    }

    private IEnumerator TransicionCambio()
    {
        fade.GetComponent<Animator>().enabled = true;
        fade.GetComponent<Animator>().Play("FadesAnim");
        yield return new WaitForSeconds(1f);
        ChangeTrack();
    }

    private void ChangeTrack()
    {
        switch (trackNumber)
        {
            case 1:
                tracks[0].SetActive(false);
                tracks[1].SetActive(true);
                tracks[2].SetActive(false);
                GetComponent<Animator>().Play("Track2RaceAnim");
                break;
            case 2:
                tracks[0].SetActive(false);
                tracks[1].SetActive(false);
                tracks[2].SetActive(true);
                if (Random.Range(0, 2) == 0)
                {
                    GetComponent<Animator>().Play("Track3RaceAnim1");
                } else
                {
                    GetComponent<Animator>().Play("Track3RaceAnim2");
                }

                break;
            default:
                tracks[0].SetActive(true);
                tracks[1].SetActive(false);
                tracks[2].SetActive(false);
                GetComponent<Animator>().Play("Track1RaceAnim");
                break;
        }
    }
}
