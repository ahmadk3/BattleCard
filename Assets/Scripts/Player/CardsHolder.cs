using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardsHolder : MonoBehaviour {

    public GameObject[] cards = new GameObject[5];

    public Rect LifeBar;
    //	public Text timeTextFireball;
    private Transform t;
    private Rigidbody rb;
    public Slider ManaBar;
    private float[] nextfire = new float[5];
    public GameObject[] cardsUI = new GameObject[3];
    private Random rnd = new Random();
    public GameObject[] availableCards = new GameObject[5];

    private int manaRegenCooldown = 10;
    private float nextManaRegen = 0.0f;

    // Use this for initialization
    void Start() {

        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        for (int i = 0; i < 5; i++)
        {
            nextfire[i] = 0.0f;
        }
        for (int i = 0; i < 5; i++)
        {
            availableCards[i] = cards[i];
        }
        updateCardsUI();
    }

    void useCard(int index)
    {
        int rnd = Random.Range(0, 5);
        print(rnd);
        updateCardsUI();
        if (cards[index] != null && Time.time > nextfire[index])
        {
            GameObject card = (GameObject)Instantiate(cards[index], t.position, t.rotation);
            nextfire[index] = Time.time + card.GetComponent<Card>().cooldown;
            ManaBar.value -= card.GetComponent<Card>().cost;
            card.SetActive(true);
            cards[index] = availableCards[rnd];
        }
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKey("j"))
        {
            useCard(0);
        }

        else if (Input.GetKey("k"))
        {
            useCard(1);
        }
        else if (Input.GetKey("l"))
        {
            useCard(2);
        }

        if(Time.time >= nextManaRegen && ManaBar.value < 1)
        {
            ManaBar.value = Mathf.Min(1, ManaBar.value + 0.02f);
        }

    }

    void updateCardsUI()
    {
        for (int i = 0; i < 3; i++)
        {
            Text manaCost = cardsUI[i].transform.Find("ManaCost").gameObject.GetComponent<Text>();
            Text cooldown = cardsUI[i].transform.Find("Cooldown").gameObject.GetComponent<Text>();
            Image sprite = cardsUI[i].transform.Find("CardSprite").gameObject.GetComponent<Image>();

            Card card = cards[i].GetComponent<Card>();
            Sprite cardSprite = cards[i].GetComponent<SpriteRenderer>().sprite;
            manaCost.text = card.cost.ToString();
            cooldown.text = card.cooldown.ToString();
            sprite.sprite = cardSprite;
        }
    }
}
