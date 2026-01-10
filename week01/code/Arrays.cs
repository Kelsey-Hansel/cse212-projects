public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Kelsey's code process: 
        // variable to store results
        // variable to store each multiple one at a time, starts with "number"
        // for loop that iterates "length" times
        // in each iteration, multiple variable is added to the results variable as a multiple of "number"
        // add "number" to multiple variable to get next multiple

        var results = new double[length];
        double multiple = number;
        for (int i = 0; i < length; i++)
        {
            results[i] = multiple;
            multiple += number;
        }

        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Kelsey's code process:
        // Use GetRange() to get the list values that will be rotated stored in a varaible
        // Use InsertRange() to put the rotated values to their final rotated position at the start of the list
        // Use RemoveRange() to remove the dupicated rotated values from the end of the list

        var rotateRange = data.GetRange(data.Count - amount, amount);
        data.InsertRange(0, rotateRange);
        data.RemoveRange(data.Count - amount, amount);
    }
}
