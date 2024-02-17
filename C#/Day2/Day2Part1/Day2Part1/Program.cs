// See https://aka.ms/new-console-template for more information

/* Problem Statement:
The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?
Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
*/

//Read Input File
string line;
var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

//declare global variables
int redLimit = 12;
int greenLimit = 13;
int blueLimit = 14;
int sum = 0; //for tracking final answer

try
{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader(path);

    //Read the first line of text
    line = sr.ReadLine();

    //Continue to read until you reach end of file
    while (line != null)
    {
        //parse line - Game# - cubes pulled delimited by ';'
        //Example: "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"

        //split string between delimiters ';' and ':'
        string[] inputs = line.Split(';', ':');
        
        //determine game number
        int gameNumber = Int32.Parse(inputs[0].Remove(0,5));

        //set bool if the game is possible for the line
        bool possible = true;

        //remove first element in array now that we have the value
        inputs = inputs.Skip(1).ToArray();

        //check each game within the line
        foreach(var x in inputs)
        {
            //declare variables for the line
            int redCurrent = 0;
            int greenCurrent = 0;
            int blueCurrent = 0;

            string[] game = x.Split(';');
            foreach(var y in game)
            {
                string[] sets = y.Split(',');
                foreach(var z in sets)
                {
                    string[] pulls = z.Trim().Split(' ');
                    int numberPulled = Int32.Parse(pulls[0]);
                    string color = pulls[1];

                    //add to total pulled
                    switch(color)
                    {
                        case "red":
                            redCurrent += numberPulled;
                            break;
                        case "green":
                            greenCurrent += numberPulled;
                            break;
                        case "blue":
                            blueCurrent += numberPulled;
                            break;
                    }
                }
                //check if game is possible for each set and set flag if not
                if(redCurrent > redLimit || greenCurrent > greenLimit || blueCurrent > blueLimit) { possible = false;}

                //reset current for next game set
                redCurrent = greenCurrent = blueCurrent = 0;
            }
        }
        //after all games are checked, check bool for possible and add game number to sum
        if(possible) {sum += gameNumber;}

        //Read the next line
        line = sr.ReadLine();
    }
    //close the file
    sr.Close();
}
catch(Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine($"Total is: {sum}");
    Console.WriteLine("\nTerminating Program.");
}