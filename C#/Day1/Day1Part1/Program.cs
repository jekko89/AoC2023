//VSCode adds this automatically inone of the Debug files, but I'm adding this for usability in case this is shared
using System.IO;
using System.Reflection.PortableExecutable;


//Read Input File
String line;
int sum = 0;
var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
try
{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader(path);
    //Read the first line of text
    line = sr.ReadLine();
    //Continue to read until you reach end of file
    while (line != null)
    {
        //Process Input Data
        //On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
        bool firstFound = false;
        string firstDigit = "";
        string lastDigit = "";
        foreach(char c in line)
        {
            //check if first digit found and set both first and last digit
            if(Char.IsDigit(c) && firstFound == false)
            {
                lastDigit = firstDigit = Char.ToString(c);
                firstFound = true;
            }
            //set and replace last digit found
            else if (Char.IsDigit(c))
            {
                lastDigit = Char.ToString(c);
            }
        }

        //output final 2 digit number for the read line
        Console.WriteLine(firstDigit + lastDigit);

        //add to total sum for final answer
        sum += Int32.Parse(firstDigit+lastDigit);

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
    Console.WriteLine(sum);
    Console.WriteLine("\nTerminating Program.");
}