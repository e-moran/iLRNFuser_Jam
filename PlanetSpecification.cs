using System;
using System.Linq;
using System.Text;
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
    private const int NumberOfTextOptions = 2; // The number of options available for each string type
    private int[] _values;
    private string _stringRepresentation;

    private string[,,] _promptText =
    {
        { // Ozone
            { // Low
                "Low Ozone",
                "Also Low Ozone"
            },
            { // Medium
                "Medium Ozone",
                "Also Medium Ozone"
            },
            { // High
                "High Ozone",
                "Also High Ozone"
            }
        },
        { // Water
            { // Low
                "Low Water",
                "Also Low Water"
            },
            { // Medium
                "Medium Water",
                "Also Medium Water"
            },
            { // High
                "High Water",
                "Also High Water"
            }
        },
        { // Size
            { // Low
                "Low Size",
                "Also Low Size"
            },
            { // Medium
                "Medium Size",
                "Also Medium Size"
            },
            { // High
                "High Size",
                "Also High Size"
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
    public Boolean ValidateEntry(int[] enteredValues)
    {
        return enteredValues.SequenceEqual(_values); // This method checks equality of the two arrays
    }

    public override string ToString()
    {
        if (_stringRepresentation != null) // If a string representation was already generated, return that
        {
            return _stringRepresentation;
        }
        
        StringBuilder sb = new StringBuilder("Hey I'm looking for a planet with: ");
        for (int i = 0; i < NumberOfValues; i++)
        {
            sb.Append(_promptText[i, _values[i], Random.Range(0, NumberOfTextOptions)]).Append(", ");
        }
        
        _stringRepresentation = sb.ToString(0, sb.Length - 2); // Using a substring to ensure to remove the trailing ", "

        return _stringRepresentation;
    }
}
