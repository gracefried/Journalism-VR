using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoTriggers : MonoBehaviour {

    public bool Cop;
    public bool protestA;
    public bool protestB;
    public bool injuredP;
    public bool politician;

    public bool canPass;
    public bool bottleActive;
    public bool bottleGiven;

    public bool scandal;
    public bool millpockets;
    public bool violence;
    public bool benefits;
    public bool taxes;

    bool check;
    public string headline;

    //public 


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        Cop = true; protestA = false; protestB = false; injuredP = false; politician = false;

        canPass = false; bottleActive = false; bottleGiven = false;

        scandal = false; millpockets = false; violence = false; benefits = false; taxes = false;
        check = false;
        headline = "";
	}
	
	// Update is called once per frame
	void Update () {
		//if(SceneManager.GetActiveScene().name == "HeadlineScene" && check == false) { getHeadlines(); }
	}

    public List<string> getHeadlines()
    {
        List<string> posHeadLine = new List<string>();
        if(Cop == true)
        {
            posHeadLine.Add("The Silence of Free Speech: Officers and Media Suppression");
            posHeadLine.Add("Violent Protest Leads to Police Intervention");
        }

        if (protestA == true)
        {
            posHeadLine.Add("Local Community Stands Against Amendment 41");
            posHeadLine.Add("Amendment 41: Your Money vs Their Comfort");
            posHeadLine.Add("We're All Running Out of Dough, 41 Has Got to Go!!");
        }

        if (protestB == true)
        {
            posHeadLine.Add("Local Community Stands With Amendment 41");
            posHeadLine.Add("Amendment 41: How Our Community Will Benefit");
            posHeadLine.Add("Love Us, Hate Us, but 41 Will Save Us!");
        }

        if (injuredP == true)
        {
            posHeadLine.Add("Local Protest Devolves into Violence");
        }

        if (politician == true)
        {
            posHeadLine.Add("Councilwoman Rallies Support for Amendment 41");
        }

        if (scandal == true)
        {
            posHeadLine.Add("Is the Councilwoman using the Amendment to Distract Us from her Scandal?");
        }

        if (millpockets == true)
        {
            posHeadLine.Add("Who's really benefitting from Amendment 41?");
        }

        posHeadLine.Add("Local Protest: Happens!");
        posHeadLine.Add("Conflict Over Amendment 41");

        check = true;
        return posHeadLine;
    }

    public List<string> getComments()
    {
        List<string> comments = new List<string>();

        if(headline == "The Silence of Free Speech: Officers and Media Suppression")
        {
            comments.Add("What does this have to do with the protest?");
            comments.Add("Be careful who you target, it can cause their supporters to retaliate");
            comments.Add("Don't disrespect our officers! They keep us safe!");
            comments.Add("Any officer is twice the person as some coward like you!");
            comments.Add("Fake News!");
        }

        else if (headline == "Is the Councilwoman using the Amendment to Distract Us from her Scandal?")
        {
            comments.Add("What does this have to do with the protest?");
            comments.Add("Be careful who you target, it can cause their supporters to retaliate");
            comments.Add("Don't disrespect our councilwoman! They keep us safe!");
            comments.Add("This is slander, you'll be hearing from my lawyer!");
            comments.Add("Fake News!");
        }

        else if (headline == "Violent Protest Leads to Police Intervention" || headline == "Local Protest Devolves into Violence")
        {
            comments.Add("The protest wasn't even violent! It was one guy!");
            comments.Add("Wish I coulda seen something crazy like that...");
            comments.Add("This doesn't say much about the protest...");
            comments.Add("Try to stick to the topic of your project");
            comments.Add("What was the protest even about?");
            comments.Add("I was there, some guy was knocked out...");
            comments.Add("Thank goodness the cops were there...");
            comments.Add("At least everyone made it back safe!");   
        }

        else if (headline == "Local Community Stands Against Amendment 41" || headline == "Amendment 41: Your Money vs Their Comfort" || 
            headline == "We're All Running Out of Dough, 41 Has Got to Go!!")
        {
            comments.Add("Yeah, down with 41!");
            comments.Add("This source is kind of biased, try not to focus too much on one side");
            comments.Add("Talk with as many people on both sides!");
            if (protestB == false) { comments.Add("Yeah, you didn't even hear my side of the story!"); }
            if (politician == false) { comments.Add("If you spoke with the councilwoman you might've changed your mind!"); }
            comments.Add("Think of the benefits, though!");
            comments.Add("I hate 41!");
        }

        else if (headline == "Local Community Stands With Amendment 41" || headline == "Amendment 41: How Our Community Will Benefit" ||
            headline == "Love Us, Hate Us, but 41 Will Save Us!" || headline == "Councilwoman Rallies Support for Amendment 41")
        {
            comments.Add("Yes! Vote 41!");
            if (politician == true) { comments.Add("The Councilwoman is such a great woman!"); }
            comments.Add("This source is kind of biased, try not to focus too much on one side");
            comments.Add("Talk with as many people on both sides!");
            if (protestA == false) { comments.Add("Yeah, you didn't even hear my side of the story!"); }
            if (politician == false) { comments.Add("You totally should've interviewed the councilwoman for this piece!"); }
            comments.Add("Think of our taxes, though!");
            comments.Add("I love Amendment 41!");
        }
        else
        {
            comments.Add("Were you even at this protest?");
            comments.Add("Try actually talking to people");
            comments.Add("The stuff they'll put in headlines these days...");
        }

        return comments;
    }
}
