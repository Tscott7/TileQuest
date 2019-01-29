using UnityEngine;
using TMPro;

public class BlankProxEvent : MonoBehaviour {
    
    public float playerx;
    public float playerz;
    public bool trigger = false;
    public bool onTile = true;
    public float tileposx;
    public float tileposz;
    public GameObject player = null;
    public GameObject health = null;
    public GameObject attack = null;
    public GameObject defense = null;
    public GameObject score = null;
    public GameObject horse = null;
    public GameObject ship = null;
    public GameObject dragon = null;
    public GameObject days = null;
    public GameObject messages = null;
    public GameObject scroller = null;
    public GameObject traviaPanel = null;
    public GameObject sresaPanel = null;
    public GameObject ezzrynPanel = null;
    public GameObject elevasPanel = null;
    public GameObject asteronPanel = null;
    public GameObject endelinPanel = null;
    public GameObject davekPanel = null;
    public GameObject nymerisSuccessPanel = null;
    public GameObject nymerisFailPanel = null;
    public GameObject winPanel = null;
    public GameObject losePanel = null;
    public string type;
    public Material newtex;
    public DayDecrease other;
    public bool activated = false;
    private int roll = 0;

    void Start()
    {
        tileposx = gameObject.transform.position.x;
        tileposz = gameObject.transform.position.z;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (health == null)
        {
            health = GameObject.Find("Game/GameCanvas/BottomPanel/CurrentHealth");
        }
        if (attack == null)
        {
            attack = GameObject.Find("Game/GameCanvas/BottomPanel/AttackPower");
        }
        if (defense == null)
        {
            defense = GameObject.Find("Game/GameCanvas/BottomPanel/DefensePower");
        }
        if (score == null)
        {
            score = GameObject.Find("Game/GameCanvas/BottomPanel/ScoreNum");
        }
        if (horse == null)
        {
            horse = GameObject.Find("Game/GameCanvas/BottomPanel/Horse");
        }
        if (ship == null)
        {
            ship = GameObject.Find("Game/GameCanvas/BottomPanel/Ship");
        }
        if (dragon == null)
        {
            dragon = GameObject.Find("Game/GameCanvas/BottomPanel/Dragon");
        }
        if (messages == null)
        {
            messages = GameObject.Find("Game/GameCanvas");
        }
        if (scroller == null)
        {
            scroller = GameObject.Find("Game/GameCanvas/MessageBackPanel/MessagePanel");
        }
        if (traviaPanel == null)
        {
            traviaPanel = GameObject.Find("Game/GameCanvas/TraviaPanel");
        }
        if (sresaPanel == null)
        {
            sresaPanel = GameObject.Find("Game/GameCanvas/SresaPanel");
        }
        if (ezzrynPanel == null)
        {
            ezzrynPanel = GameObject.Find("Game/GameCanvas/EzzrynPanel");
        }
        if (elevasPanel == null)
        {
            elevasPanel = GameObject.Find("Game/GameCanvas/ElevasPanel");
        }
        if (asteronPanel == null)
        {
            asteronPanel = GameObject.Find("Game/GameCanvas/AsteronPanel");
        }
        if (endelinPanel == null)
        {
            endelinPanel = GameObject.Find("Game/GameCanvas/EndelinPanel");
        }
        if (davekPanel == null)
        {
            davekPanel = GameObject.Find("Game/GameCanvas/DavekPanel");
        }
        if (nymerisSuccessPanel == null)
        {
            nymerisSuccessPanel = GameObject.Find("Game/GameCanvas/NymerisSuccessPanel");
        }
        if (nymerisFailPanel == null)
        {
            nymerisFailPanel = GameObject.Find("Game/GameCanvas/NymerisFailPanel");
        }
        if (winPanel == null)
        {
            winPanel = GameObject.Find("Game/GameCanvas/WinPanel");
        }
        if (losePanel == null)
        {
            losePanel = GameObject.Find("Game/GameCanvas/LosePanel");
        }
        if (days == null)
        {
            days = GameObject.Find("Game/GameCanvas/DayPanel/Days");
        }
        playerx = player.transform.position.x;
        playerz = player.transform.position.z;
        type = gameObject.transform.parent.name;
    }

    void Update()
    {
        playerx = Mathf.Round(player.transform.position.x);
        playerz = Mathf.Round(player.transform.position.z);
        if (activated && !onTile && trigger && tileposx == playerx && tileposz == playerz)
        {
            // Off tile going on
            onTile = true;
            other.countdown();
        }
        else if (activated && onTile && trigger && tileposx != playerx || tileposz != playerz)
        {
            // On tile going off
            onTile = false;
        }
        else if (!trigger && !activated && tileposx == playerx && tileposz == playerz)
        {
            activated = true;
            onTile = true;
            trigger = true;
            gameObject.GetComponent<MeshRenderer>().material = newtex;
            if (type == "HumanBlank")
            {
                HumanBlankEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 5).ToString();
            }
            else if (type == "MidlandBlank")
            {
                MidlandBlankEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 10).ToString();
            }
            else if (type == "ElvenBlank")
            {
                ElvenBlankEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
            }
            else if (type == "HumanRoad")
            {
                HumanRoadEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 5).ToString();
            }
            else if (type == "SeaRoad")
            {
                SeaRoadEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 10).ToString();
            }
            else if (type == "ElvenRoad")
            {
                ElvenRoadEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
            }
            else if (type == "NorthernIslesBlank")
            {
                NorthernIslesBlankEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
            }
            else if (type == "HumanVillage")
            {
                HumanVillageEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 5).ToString();
            }
            else if (type == "SeaVillage")
            {
                HumanVillageEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 10).ToString();
            }
            else if (type == "ElvenVillage")
            {
                HumanVillageEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
            }
            else if (type == "Water")
            {
                WaterEvent();
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 10).ToString();
            }
            else if (type == "City")
            {
                Time.timeScale = 0;
                if (gameObject.name != "Rhanos")
                {
                    CityEvent();
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
                }
                else
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add("-Green tiles = Land");
                    messages.GetComponent<DisplayText>().chatEvents.Add("-Gray tiles = Road");
                    messages.GetComponent<DisplayText>().chatEvents.Add("-Brown tiles = Village");
                    messages.GetComponent<DisplayText>().chatEvents.Add("-Gold tiles = City");
                    messages.GetComponent<DisplayText>().chatEvents.Add("-Blue tiles = Water");
                }
            }
            else if (type == "End")
            {
                if (int.Parse(attack.GetComponent<TextMeshProUGUI>().text) >= 100 && int.Parse(defense.GetComponent<TextMeshProUGUI>().text) >= 100)
                {
                    winPanel.SetActive(true);
                    score.GetComponent<TextMeshProUGUI>().text = int.Parse(score.GetComponent<TextMeshProUGUI>().text) + (int.Parse(days.GetComponent<TextMeshProUGUI>().text) * 25).ToString();
                }
                else
                {
                    losePanel.SetActive(true);
                }
            }
            Canvas.ForceUpdateCanvases();
            scroller.GetComponent<UnityEngine.UI.ScrollRect>().verticalNormalizedPosition = 0f;
            Canvas.ForceUpdateCanvases();
            if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 0)
            {
                health.GetComponent<TextMeshProUGUI>().text = "0";
                losePanel.SetActive(true);
            }
        }
        
    }
    
    void HumanBlankEvent()
    {
        Debug.Log("HumanBlankEvent");
        roll = Random.Range(1, 17);
        if (roll == 1) // !Pack of Wolves
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You are attacked by a pack of wolves. {0}", BasicEvent(20)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
        }
        else if (roll == 2) // Camp of Deserters
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-You stumble upon a small camp of deserters.");
            roll = Random.Range(1, 3);
            if (roll == 1) //// !Attack Seeking Revenge
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You tried to convince them to join you, but they attack, seeking revenge on your father, their former King. {0}", BasicEvent(40)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 40).ToString();
            }
            else // Join
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They agree to join you! {0}", AddStats(Random.Range(1, 4), Random.Range(1, 3))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
        }
        else if (roll == 3) // Storm
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-A thunderous storm rolls in, upturning your encampment and ravaging you and your men. (-20 Health, -1 Day)");
            health.GetComponent<TextMeshProUGUI>().text = (int.Parse(health.GetComponent<TextMeshProUGUI>().text) - 20).ToString();
            other.countdown();
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
        }
        else if (roll == 4) // Castle Ruins
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-You stumble upon castle ruins from the Ryet Empire hundreds of years ago. They ruled the world before the lands were split by dragons, so the legends say.");
            roll = Random.Range(1, 3);
            if (roll == 1) //// Armory
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You explore the ruins and find an armory stocked with old arms and armor. {0}", AddStats(Random.Range(1, 3), Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
            else //// !Bandits
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-When you enter, you find a group of bandits waiting in ambush. {0}", BasicEvent(30)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
            }
        }
        else if (roll == 5) // !Camp Raid at Night
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Your camp gets raided in the middle of the night. {0}", BasicEvent(50)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
        }
        else if (roll == 6) // Blocked Mountain Pass
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-The mountain trail has eroded away, forcing you to backtrack. (-1 Day)");
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
            other.countdown();
        }
        else if (roll == 7) // Old Woman
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-An old woman approaches you in the woods and offers to patch up your wounds. (Health Restored!)");
            if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
            {
                health.GetComponent<TextMeshProUGUI>().text = "100";
            }
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
        }
        else if (roll == 8 || roll == 9 || roll == 10) // Easy Terrain, Extra Training
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The terrain breaks up, allowing you to set up camp early. With the additional time, you train, refining your sword skills. {0}", AddStats(Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The terrain breaks up, allowing you to set up camp early. With the additional time, you train, refining your defensive skills. {0}", AddStats(0, Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
        }
        else if (roll == 11) // Dwarves
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-In the mountains, dwarves approach you. A few offer their aid and others donate weapons and shields. {0}", AddStats(Random.Range(1, 6), Random.Range(1, 6))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void NorthernIslesBlankEvent()
    {
        Debug.Log("NorthernIslesBlankEvent");
        roll = Random.Range(1, 8);
        if (roll == 1) // Wyvern
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-On the mountains overhead, a jet black wyvern roosts and watches your progress closely. The path forward gets close to it and upon your approach it attacks. {0}", BasicEvent(100)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 100).ToString();
        }
        else if (roll == 2) // Floor Crumbles
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The precarious climb along the mountainside is treacherous. Rocks crumble, ice slips, and some of your men fall to their doom. (-20 Health)"));
            health.GetComponent<TextMeshProUGUI>().text = (int.Parse(health.GetComponent<TextMeshProUGUI>().text) - 20).ToString();
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
        }
        else if (roll == 3) // Abandoned Dragon Cave
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-When scaling a craggy mountain, you come across a cave. Stalactites of ice drip frigid water onto your head. It appears to have been the home of a dragon at one time. You find a treasure trove of armor, weapons, and gold. {0}", AddStats(Random.Range(1, 7), Random.Range(1, 7))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 40).ToString();
        }
        other.countdown();
    }

    void MidlandBlankEvent()
    {
        Debug.Log("SeaBlankEvent");
        roll = Random.Range(1, 8);
        if (roll == 1) // Looters
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A days-old battlefield lies before you. Looters are peeling the armor, weapons, and personal effects off of the dessicating corpses. They attack you without a second thought, desperate to claim more spoils. {0}", BasicEvent(75)));
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You defeat them, and a few brave members of your party risk claiming better weapons and armors off the fallen. {0}", AddStats(Random.Range(1, 4), Random.Range(1, 6))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 75).ToString();
        }
        else if (roll == 2) // Jungle Delay
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A tropical storm and the dense jungle foliage slows down your progress. Perhaps you should've stayed on the road. (-2 Days)"));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            other.countdown();
            other.countdown();
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void ElvenBlankEvent()
    {
        Debug.Log("ElvenBlankEvent");
        roll = Random.Range(1, 16);
        if (roll == 1) // Nymphs
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The forest calls to you, every piece of flora coaxing you closer. When you and your company are nearly catatonic, the trees move toward you, surrounding on all sides. You realize they're not trees, but people with half their skin made of bark, swirling up their limbs. Nymphs, someone says. {0}"));
            roll = Random.Range(1, 3);
            if (roll == 1) //// They attack
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They move quickly and attack you with their pointed wooden staffs. {0}", BasicEvent(70)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 70).ToString();
            }
            else //// Capture
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They knock you unconscious and take you back to their town. You explain to their leader your mission and she agrees to help. She outfits your people with some new weapons, mainly bows and arrows. {0}", AddStats(Random.Range(1, 9), Random.Range(1, 3))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 35).ToString();
            }
        }
        else if (roll == 2) // Officials
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Elven officials spot your group and attack the humans, thinking you and them are invaders and capturers of the elves with you. {0}", BasicEvent(60)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 60).ToString();
        }
        else if (roll == 3) // Ritual Site
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Moving through dense forest, you stumble upon an old elven ritual site. Searching around, you find a legendary sword. Some in your group tell you that it is known as Deremos and is imbued with magic. {0}", AddStats(13)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
        }
        else if (roll == 4) // Menders
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You come across two elves who have made camp on the plains. They invite you to make camp with them and tell you they have some magical mending abilities. (Health Resored Beyond Full!)"));
            if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
            {
                health.GetComponent<TextMeshProUGUI>().text = "120";
            }
        }
        else if (roll == 5) // Patrol
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A patrol from a nearby town spots you and hails you over. You bring a few elves from your group over to help explain the situation. They let you pass, but not before slipping you the key to the nearest town's armory. {0}", AddStats(Random.Range(1, 4), Random.Range(1, 8))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
        }
        else if (roll == 6) // Dark Scouts
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You spot scouts from the gathering dark army. You fight them before they can get away and report on what you're doing. {0}", BasicEvent(80)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 80).ToString();
        }
        else if (roll == 7) // Lost
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You get lost in a forest of bloodwood trees. You don't find your way out until some local loggers find your camp a few nights later. (-3 Days)"));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            other.countdown();
            other.countdown();
            other.countdown();
        }
        else if (roll == 8 || roll == 9 || roll == 10) // Easy Terrain, Extra Training
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The terrain breaks up, allowing you to set up camp early. With the additional time, you train, refining your sword skills. {0}", AddStats(Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The terrain breaks up, allowing you to set up camp early. With the additional time, you train, refining your defensive skills. {0}", AddStats(0, Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
            }
        }
        else if (roll == 11)
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A large force of dark creatures sets upon your group. They must have found out about your plans to fight them somehow. They're incredibly quick and have weapons made of some kind of dark magic. {0}", BasicEvent(95)));
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-After defeating them, you claim some of their weapons and armor for yourself. {0}", AddStats(Random.Range(1, 13), Random.Range(1, 13))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 95).ToString();
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void HumanRoadEvent()
    {
        Debug.Log("HumanRoadEvent");
        roll = Random.Range(1, 13);
        if (roll == 1) // Caravan
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You encounter a traveling caravan of traders and barter for better supplies. {0}", AddStats(Random.Range(1, 3), Random.Range(1, 3))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
        }
        else if (roll == 2) // Family 
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You pass a family traveling south to visit their kin. They offer you and your company a spot at their fire where they exchange some items with you. {0}", AddStats(Random.Range(1, 3), Random.Range(1, 5))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 35).ToString();
        }
        else if (roll == 3 || roll == 4) // River
        {
            roll = Random.Range(1, 3);
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You come across a river bridge, blocked by a group of mercenaries."));
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They refuse to let you pass, claiming that their lord opposes your father's taxes. When you insist, they attack, thinking they will easily best you. {0}", BasicEvent(70)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 70).ToString();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They sympathize with your efforts and they join you, against the wishes of their lord. {0}", AddStats(Random.Range(1, 7), Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
            }
        }
        else if (roll == 5) // Religious Zealots
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You come across a gathering of zealots of the old religion who claim to have heard of the tainted beings gathering and believe them to be the armies of God. They attack in the name of their holy God Ehruthios! {0}", BasicEvent(50)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 4);
            if (roll == 1)
            {
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add("-You saved a day by traveling on the road!");
            }
            return;
        }
        else
        {
            if (Random.Range(1, 3) == 1)
            {
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add("-You saved a day by traveling on the road!");
            }
        }
    }

    void SeaRoadEvent()
    {
        Debug.Log("SeaRoadEvent");
        roll = Random.Range(1, 8);
        if (roll == 1) // Ambush
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Walking along the road, you come across piles of bodies left over from an old battle you assume. When you get close, the bodies jump up and attack. Bandits come out of the trees around you and you're forced to fight. {0}", BasicEvent(75)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 75).ToString();
        }
        else if (roll == 2)
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You pass an unusual group of elves and humans. They claim to be former soldiers who were thought to be dead or missing after a battle. They decided to take the opportunity and form a group of mercenaries outside of the war. You explain what is happening and they agree to join! {0}", AddStats(Random.Range(1, 8), Random.Range(1, 6))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 35).ToString();
        }
        if (Random.Range(1, 3) == 1)
        {
            other.countdown();
        }
        else
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-You saved a day by traveling on the road!");
        }
    }

    void ElvenRoadEvent()
    {
        Debug.Log("ElvenRoadEvent");
        roll = Random.Range(1, 14);
        if (roll == 1) // Wolf-Like Creatures
        {
            roll = Random.Range(1, 3);
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You move off the road to make camp for the night. The trees grow thick with licken and moss. The air takes on an aura and you find a young wolf-like creature lying beside a steaming pond."));
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-As you approach, you see blood pooled under its silvery fur. You spend the next day cleaning its wounds and helping it to reawaken. When it does, it leads you to a small cave, littered with bones, weapons, and armor. (-1 Day) {0}", AddStats(Random.Range(1, 5), Random.Range(1, 8))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 35).ToString();
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Before you can approach, a dozen others emerge from the trees and attack you. {0}", BasicEvent(70)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 70).ToString();
            }
        }
        else if (roll == 2) // Mythical Creature Trader
        {
            roll = Random.Range(1, 3);
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You pass an elf selling mythical creatures on the side of the road. He has everything from baby wyverns to arachnids the size of a shepherd's dog. He claims they have been magically trained so that they'll follow the command of anyone who knows their real names."));
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Your party refuses to buy from him, citing the cruel treatment of them and horrifying condition of the cages they've been forced into. Out of spite and anger, he opens some cages when your not looking and they attack {0}", BasicEvent(80)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 80).ToString();
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Considering the advantages of having the creatures' might on your side in the coming battle, you purchase a few arachnids and two adolescent wyverns to attack from the skies. He teaches you their names and sets you on your way. {0}", AddStats(Random.Range(1, 8), Random.Range(1, 4))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
            }
        }
        else if (roll == 3) // Apothecary
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A traveling apothecary stops you along the road. He convinces you to buy magic-imbued potions that he says will harden your skin and make it tougher to pierce. {0}", AddStats(0, Random.Range(1, 10))));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 30).ToString();
        }
        else if (roll == 4) // Hooded Figures
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Hooded figures stalk you on the road. You notice shadow whirling around them like a wispy black cloud."));
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You strike before they do, recognizing them as creatures from that dark army gathering. {0}", BasicEvent(50)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You hesitate and they move up quickly, sensing it. They strike as you finally recognize them as creatures from the gathering dark army. {0}", BasicEvent(85)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 85).ToString();
            }
        }
        else if (roll == 5) // Royals
        {
            roll = Random.Range(1, 3);
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You pass an elf selling mythical creatures on the side of the road. He has everything from baby wyverns to arachnids the size of a shepherd's dog. He claims they have been magically trained so that they'll follow the command of anyone who knows their real names."));
            if (roll == 1)
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Your party refuses to buy from him, citing the cruel treatment of them and horrifying condition of the cages they've been forced into. Out of spite and anger, he opens some cages when your not looking and they attack {0}", BasicEvent(80)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 80).ToString();
                other.countdown();
            }
            else
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A procession of royals pass by, going south. You try to beg for support, but he claims that he already sent his men south and is moving away from the unavoidable war. He is sympathetic though and gives you gold to hire a few mercenaries from a nearby outpost. You thank him and end up hiring some new swords {0}", AddStats(Random.Range(1, 8), Random.Range(1, 8))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 35).ToString();
            }
        }
        else if (roll == 6) // Bandits
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You come upon a bridge that passes over a roaring river. Bandits are waiting on it, collecting a toll on anyone trying to flee the war. Unable to let this injustice continue, you engage. {0}", BasicEvent(75)));
            score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 75).ToString();
        }
        if (Random.Range(1, 3) == 1)
        {
            other.countdown();
        }
        else
        {
            messages.GetComponent<DisplayText>().chatEvents.Add("-You saved a day by traveling on the road!");
        }
    }

    void HumanVillageEvent()
    {
        Debug.Log("HumanVillageEvent");
        if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
        {
            health.GetComponent<TextMeshProUGUI>().text = "100";
        }
        messages.GetComponent<DisplayText>().chatEvents.Add("-Health restored by local villagers.");
        score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 10).ToString();
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void SeaVillageEvent()
    {
        Debug.Log("SeaVillageEvent");
        if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
        {
            health.GetComponent<TextMeshProUGUI>().text = "100";
        }
        messages.GetComponent<DisplayText>().chatEvents.Add("-Health restored by local villagers.");
        score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void ElvenVillageEvent()
    {
        Debug.Log("ElvenVillageEvent");
        if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
        {
            health.GetComponent<TextMeshProUGUI>().text = "100";
        }
        messages.GetComponent<DisplayText>().chatEvents.Add("-Health restored by local villagers.");
        score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    void WaterEvent()
    {
        Debug.Log("WaterEvent");
        roll = Random.Range(1, 12);
        if (ship.activeSelf)
        {
            if (roll == 1) // Trade Ship
            {
                roll = Random.Range(1, 3);
                if (roll == 1)
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A trade ship passes by and hails you. They offer trades which improve your weapons. {0}", AddStats(Random.Range(1, 7))));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
                }
                else
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-A trade ship passes by and hails you. They offer trades which improve your armor. {0}", AddStats(0, Random.Range(1, 7))));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
                }
            }
            else if (roll == 2) // Pirates
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Two ships of pirates converge on you. {0}", BasicEvent(50)));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
            }
            else if (roll == 3) // Slaver Ship
            {
                messages.GetComponent<DisplayText>().chatEvents.Add("-You spot slaver ships on the horizon.");
                roll = Random.Range(1, 3);
                if (roll == 1) //// Spots You
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They spot you and attack {0}", BasicEvent(70)));
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-After handling them, you loot their ships and free the slaves. Some agree to join you! {0}", AddStats(Random.Range(1, 6), Random.Range(1, 6))));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 70).ToString();
                }
                else //// Get Away
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You manage to get away before they spot you. (-1 Day)"));
                    other.countdown();
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
                }
            }
            else if (roll == 4 || roll == 6) // Nymphs
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You see the heads of beautiful women rise among the waves."));
                roll = Random.Range(1, 4);
                if (roll == 1) //// Lure
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-They call your name and lure you to the side of the ship with their melodic voices. One of your crewmates pull you back, but others in your crew aren't so lucky. {0}", BasicEvent(60)));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 60).ToString();
                }
                else if (roll == 2) //// Fight
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-Your crew resists their calls, but the nymphs are adamant about getting you. They strike your ships from below with their iconic clubs, causing havoc. {0}", BasicEvent(50)));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 50).ToString();
                }
                else //// Ambassador Meeting
                {
                    messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The nymphs approach and call for an audience. You meet their ambassador, Nisue, who pledges supplies to aid your cause {0}", AddStats(Random.Range(1, 6), Random.Range(1, 7))));
                    score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
                }
            }
            else if (roll == 5) // Shipwreck
            {
                messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-You encounter a shipwreck and find supplies in the wreckage. {0}", AddStats(Random.Range(1, 6), Random.Range(1, 6))));
                score.GetComponent<TextMeshProUGUI>().text = (int.Parse(score.GetComponent<TextMeshProUGUI>().text) + 25).ToString();
            }
        }
        else
        {
            messages.GetComponent<DisplayText>().chatEvents.Add(string.Format("-The waves are tremendous and knock you back. You aren't going to make it far without a ship. Perhaps you could find one back on land. (-30 Health)"));
            health.GetComponent<TextMeshProUGUI>().text = (int.Parse(health.GetComponent<TextMeshProUGUI>().text) - 30).ToString();
            other.countdown();
            return;
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (ship.activeSelf)
        {
            roll = Random.Range(1, 4);
            if (roll == 1)
            {
                other.countdown();
            }
        }
    }

    void CityEvent()
    {
        Debug.Log("CityEvent");
        if (playerx == 66 && playerz == 33)
        {
            // Travia
            traviaPanel.SetActive(true);
            if (int.Parse(health.GetComponent<TextMeshProUGUI>().text) <= 100)
            {
                health.GetComponent<TextMeshProUGUI>().text = "100";
            }
            ship.SetActive(true);
        }
        else if (playerx == 21 && playerz == 96)
        {
            // Sresa
            sresaPanel.SetActive(true);
            attack.GetComponent<TextMeshProUGUI>().text = (int.Parse(attack.GetComponent<TextMeshProUGUI>().text) + 20).ToString();
        }
        else if (playerx == 90 && playerz == 42)
        {
            // Ezzryn
            ezzrynPanel.SetActive(true);
            string trash = AddStats(10, 10);
        }
        else if (playerx == 105 && playerz == 48)
        {
            // Elevas
            elevasPanel.SetActive(true);
        }
        else if (playerx == 129 && playerz == 45)
        {
            // Asteron
            asteronPanel.SetActive(true);
            horse.SetActive(true);
        }
        else if (playerx == 159 && playerz == 75)
        {
            // Endelin
            endelinPanel.SetActive(true);
            health.GetComponent<TextMeshProUGUI>().text = "250";
        }
        else if (playerx == 135 && playerz == 111)
        {
            // Davek
            davekPanel.SetActive(true);
            attack.GetComponent<TextMeshProUGUI>().text = (int.Parse(attack.GetComponent<TextMeshProUGUI>().text) + 5).ToString();
            attack.GetComponent<TextMeshProUGUI>().text = (int.Parse(attack.GetComponent<TextMeshProUGUI>().text) + 15).ToString();
        }
        else if (playerx == 90 && playerz == 111)
        {
            // Nymeris
            if ((int.Parse(attack.GetComponent<TextMeshProUGUI>().text) >= 75) && (int.Parse(defense.GetComponent<TextMeshProUGUI>().text) >= 75)) {
                nymerisSuccessPanel.SetActive(true);
                dragon.SetActive(true);
                AddStats(25, 25);
            }
            else
            {
                nymerisFailPanel.SetActive(true);
            }
        }
        if (dragon.activeSelf)
        {
            roll = Random.Range(1, 5);
            if (roll == 1)
            {
                other.countdown();
                return;
            }
        }
        else if (horse.activeSelf)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
            {
                other.countdown();
            }
        }
        else
        {
            other.countdown();
        }
    }

    string BasicEvent(int maxDamage)
    {
        int attackVal = int.Parse(attack.GetComponent<TextMeshProUGUI>().text);
        int defenseVal = int.Parse(defense.GetComponent<TextMeshProUGUI>().text);
        maxDamage -= Random.Range(0, defenseVal);
        maxDamage -= Random.Range(0, attackVal);
        if (maxDamage <= 10)
        {
            maxDamage = Random.Range(0, 10);
        }
        health.GetComponent<TextMeshProUGUI>().text = (int.Parse(health.GetComponent<TextMeshProUGUI>().text) - maxDamage).ToString();
        return string.Format("(-{0} Health)", maxDamage);
    }

    string AddStats(int attackAdd=0, int defenseAdd=0)
    {
        attack.GetComponent<TextMeshProUGUI>().text = (int.Parse(attack.GetComponent<TextMeshProUGUI>().text) + attackAdd).ToString();
        defense.GetComponent<TextMeshProUGUI>().text = (int.Parse(defense.GetComponent<TextMeshProUGUI>().text) + defenseAdd).ToString();
        return string.Format("(+{0} Attack, +{1} Defense)", attackAdd.ToString(), defenseAdd.ToString());
    }
}