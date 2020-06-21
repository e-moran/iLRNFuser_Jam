using System;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetSpecification
{
    /*
     * Planet Specification Values:
     * 0 = Ozone
     * 1 = Water
     * 2 = Size
     *
     * Each value shall store an int representing its required option, the int shall correspond with the horizontal
     * placement of the selector that its referring to from left to right. I'm choosing to use an array to store all
     * values all they'll all be written to and read at roughly the same time as each other so storing them in the same
     * data block will reduce the chance of a cache miss.
     */
    private const int NumberOfValues = 3;
    private const int NumberOfOptions = 3; // Stores the number of options for each value with 0 = left-most option
    private const int NumberOfTextOptions = 5; // The number of options available for each string type
    private const int NumberOfIntroductions = 13;
    private int[] _values;
    private string _stringRepresentation;

    public string[] _intros =
    {
        "Hail, friend! I am in need of a planet to use as a military outpost. Here are the details of our order.",
        "What do we need it for? None of your business. Let's get this over with.",
        "Um, hi. I'm looking for a pl-planet for hosting our 'Tombs and Terrors' campaign.",
        "Hello there! Wouldn't happen to be sellin' some planets would ye? Here's what we need.",
        "Hi, I’m supposed to pick up a planet for my sister? She gave me a note that says this.",
        "I’m looking for a planet… shaken, not stirred. Oh and some other stuff.",
        "Quick, We need a planet! We’re running out of helium to keep our current one floating!",
        "Planet. Now.",
        "Hi I know we were here last week but we kinda ruined that one it is super embarrassing I know but anyway here is our new request.",
        "I need a new planet for a photo for the gram, I can’t pay you but you’ll get TONNES of exposure.",
        "Do I get a discount if my planet’s destruction WASN’T global warming?",
        "Hey, I need to fake a planet landing, can you help me out?",
        "Yo, I’m getting an interplanetary snooker goin’ and I need a few more planets. You in?"
    };

    private string[,,] _promptText =
    {
        { // Ozone
            { // Low
                "Most planets in our system are so cold we can't grow any crops.",
                "Most of our plant species need lots of UV to thrive.",
                "We need extra desertification for covert operations.",
                "We encourage a hostile environment so we don't have to deal with different species on our planet.",
                "The government secretly wants this planet to fail, so try to make this planet more hostile."
            },
            { // Medium
                "Thankfully, we've never had any issues with our environment.",
                "Our people are very respectful of nature, if that changes anything.",
                "We're putting the planet in a temperature sweetspot, as per your guidelines.",
                "We have completely renewable energy, can we get 10% off the price for that?",
                "A terratron once told me they were jealous of our ecosystems. That's the power of recycling!"
            },
            { // High
               "The only free space is close to the sun so we're gonna need some extra protection from that.",
                "We sun burn super duper easily! Please help us with that.",
                "We use CFCs in all our inventions. That won't be an issue will it?",
                "We have a big burping culture. It's how we greet eachother. We teach all our animals to do it too!",
                "We don't believe in recycling. It's a distraction to innovation."
            }
        },
        { // Water
            { // Low
                "Our people can't swim so don't go putting oceans or any of that fancy stuff on our planet.",
                "FYI, our creatures thrive off vinegar instead of water. Don't go adding extra costs to our bill.",
                "Keep it dry. We don't want people getting any resources that we don't ship in ourselves.",
                "We hate the rain. Please don't let it rain.",
                "We need to be able to see the sky, so keep the cloud cover low."
            },
            { // Medium
               "I always hated our last planet’s beach but hey, at least we had a beach and it wasn’t overflowing.",
                "I’m happy our last planet had the perfect moisture for gardening, I’d like to keep it that way.",
                "I don’t think we need too much water, just a normal amount.",
                "I’m happy our last planet had the perfect moisture for gardening, I’d like to keep it that way.",
                "I don’t think we need too much water, just a normal amount."
            },
            { // High
              "We love swimming! If you could - like - flood the place? Yeah, that would be cool.",
                "We need lots of rain for our special wildlife. Can you sort that out for us?",
                "We have super dry skin. I would help to get soothing wet weather.",
                "If there’s anything I love, it’s a karst landscape. Help me out here.",
                "We live with dolphins so constant flooding, no matter what altitude, would be a plus."

            }
        },
        { // Size
            { // Low
               "We’re pretty lazy so if you could bump the gravity down a notch so we could bounce everywhere, that would be great",
                "I would love to be able to jump up a mountain instead of having to climb it. What an effort.",
                "Rocket fuel is so expensive in our system. Any way you could help us get more bang for our buck?",
                "We’re a close knit population. Try not to put a lot of distance between us!",
                "Wouldn’t it be great if I could throw a ball and it would go all the way around the planet and come back to me? Too bad our last planet was too big for that."
            },
            { // Medium
               "I’ve been on planets where I float when I walk. Not into it! I’ll keep to my regular footing.",
                "Low gravity makes me feel nauseous. I’d like if I could just sit in my chair, you know?",
                "Can’t we just have an average sized planet? Why is everyone big into these small moon planets?",
                "Low gravity makes me feel nauseous. I’d like if I could just sit in my chair, you know?",
                "I’ve been on planets where I float when I walk. Not into it! I’ll keep to my regular footing."
            },
            { // High
                "I want my feet firmly planted on the ground. And I mean FIRMLY!",
                "I would appreciate it if my grandmother was so far away that it takes weeks to travel to me - by plane!",
                "We’ve a massive population, you’ll need to accommodate that!",
                "We’re materialistic people. Make sure to give us plenty of resources to work with.",
                "Make sure we’re the biggest planet in the ENTIRE SYSTEM!"
            }
        }
    };

    public PlanetSpecification()
    {
        _values = new int[NumberOfOptions];

        // We'll just use a for loop to set the default values since they all range from 0-2
        for (int i = 0; i < NumberOfValues; i++)
        {
            _values[i] = Random.Range(0, NumberOfOptions);
        }
    }

    // Checks an array submitted by the game to see if the player has successfully completed the round
    public int ScoreForEntry(int[] enteredValues)
    {
        var mapping = new [] {-1, 0, 0, 1};
        int numMatching = 0;
        
        for (int i = 0; i < NumberOfValues; i++)
        {
            if (enteredValues[i] == _values[i])
            {
                numMatching++;
            }
        }

        return mapping[numMatching];
    }

    public override string ToString()
    {
        if (_stringRepresentation != null) // If a string representation was already generated, return that
        {
            return _stringRepresentation;
        }
        
        StringBuilder sb = new StringBuilder(_intros[Random.Range(0, NumberOfIntroductions)], 512);
        for (int i = 0; i < NumberOfValues; i++)
        {
            sb.Append(" ").Append(_promptText[i, _values[i], Random.Range(0, NumberOfTextOptions)]);
        }
        
        _stringRepresentation = sb.ToString(0, sb.Length); // Using a substring to ensure to remove the trailing ", "
        return _stringRepresentation;
    }
}
