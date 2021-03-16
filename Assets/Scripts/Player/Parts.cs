using static UnityEngine.Debug;
using System.Collections;

/*
 * Class to manage the assembly/disassembly
 */
public class Parts {

    /*
     * Body parts that can be removed
     */
    public enum Part {
        Arm,
        Leg,
        Head,
        Torso,
        None
    }

    // Player's current state
    private Dictionary<Part, int> partsLeft;

    public Parts() {
        // Add initial parts
        partsLeft = new Dictionary<Part, int>();
        partsLeft.Add(Parts.Arm, 2);
        partsLeft.Add(Parts.Leg, 2);
        partsLeft.Add(Parts.Head, 1);
        partsLeft.Add(Parts.Torso, 1);
    }

    public int GetPartsRemaining(Part part) {
        int remaining = 0;
        partsLeft.TryGetValue(part, out remaining);
        return remaining;
    }

    public void UsePartToFix(Part part) {
        int remaining = GetPartsRemaining(part);
        if (remaining > 0) {
            partsLeft[part] = remaining-1;
        } else {
            Debug.LogError("Not enough of the part missing! Use GetPartsRemaining() before UsePartToFix()");
        }
    }
}