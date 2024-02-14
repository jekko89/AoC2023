//VSCode adds this automatically inone of the Debug files, but I'm adding this for usability in case this is shared
using System.Globalization;
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
        //Your calculation isn't quite right.
        //It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".
        //It can be both digits (1,2,3) or words (one, two three)
        bool firstFound = false;
        string firstDigit = "";
        string lastDigit = "";
        string[] digits = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        int index = 0;

        foreach(char c in line)
        {
            //check if first digit found and set both first and last digit
            if(firstFound == false)
            {
                if(Char.IsDigit(c))
                {
                    lastDigit = firstDigit = Char.ToString(c);
                    firstFound = true;
                }
                else if(Char.IsLetter(c))
                {
                    foreach(string d in digits)
                    {
                        if(line.Contains(d) && line.IndexOf(d) == index)
                        {
                            string returnDigit = "0";
                            switch(d)
                            {
                                case "one":
                                    returnDigit = "1";
                                    break;
                                case "two":
                                    returnDigit = "2";
                                    break;
                                case "three":
                                    returnDigit = "3";
                                    break;
                                case "four":
                                    returnDigit = "4";
                                    break;
                                case "five":
                                    returnDigit = "5";
                                    break;
                                case "six":
                                    returnDigit = "6";
                                    break;
                                case "seven":
                                    returnDigit = "7";
                                    break;
                                case "eight":
                                    returnDigit = "8";
                                    break;
                                case "nine":
                                    returnDigit = "9";
                                    break;
                            }
                            lastDigit = firstDigit = returnDigit;
                            firstFound = true;
                        }
                    }
                }
            }
            else
            {
                if(Char.IsDigit(c))
                {
                    lastDigit = Char.ToString(c);
                }
                else if(Char.IsLetter(c))
                {
                    foreach(string d in digits)
                    {
                        if(line.Contains(d) && line.LastIndexOf(d) == index)
                        {
                            string returnDigit = "0";
                            switch(d)
                            {
                                case "one":
                                    returnDigit = "1";
                                    break;
                                case "two":
                                    returnDigit = "2";
                                    break;
                                case "three":
                                    returnDigit = "3";
                                    break;
                                case "four":
                                    returnDigit = "4";
                                    break;
                                case "five":
                                    returnDigit = "5";
                                    break;
                                case "six":
                                    returnDigit = "6";
                                    break;
                                case "seven":
                                    returnDigit = "7";
                                    break;
                                case "eight":
                                    returnDigit = "8";
                                    break;
                                case "nine":
                                    returnDigit = "9";
                                    break;
                            }
                            lastDigit = returnDigit;
                        }
                    }
                }
            }
            index++;
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