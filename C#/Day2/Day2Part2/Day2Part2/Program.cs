// See https://aka.ms/new-console-template for more information

/* Problem Statement Part 2:
As you continue your walk, the Elf poses a second question:
in each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?
*/

//Read Input File
string line;
var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");

//for tracking final answer
int sum = 0; 

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
        
        //set bool if the game is possible for the line
        bool possible = true;

        //remove first element in array now that we have the value
        inputs = inputs.Skip(1).ToArray();

        //variables to track the minimum number of balls for the game
        int redMinimum = 0;
        int greenMinimum = 0;
        int blueMinimum = 0;

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

                //part2 - set minimum number of each color needed for the game to work
                if(redCurrent > redMinimum) { redMinimum = redCurrent; }
                if(greenCurrent > greenMinimum) { greenMinimum = greenCurrent; }
                if(blueCurrent > blueMinimum) { blueMinimum = blueCurrent; }

                //reset current for next game set
                redCurrent = greenCurrent = blueCurrent = 0;
            }
        }
        //after all games are checked, check bool for possible and add game number to sum
        if(possible) {sum += redMinimum * greenMinimum * blueMinimum;}

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