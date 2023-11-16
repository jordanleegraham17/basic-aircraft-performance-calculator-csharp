using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* About this project:
 * This is a mini project to replicate a simple aircraft performance calculator.
 * The goal of this mini project is to make use of different conditional statements and data types I have learned so far.
 * Implementing these different tools as much as possible through different logical functions to complete the task.
 * Plan:
 * The plan for this project is to initially take in various inputs from the user and read the information back,
 * such as a selection of aircraft type, weight (passengers + baggage + fuel), fuel on board etc.
*/

namespace _06_BasicFunctions
{
    class B_AircraftPerformanceCalculator
    {
        //global variables
        bool validInput = true;
        string aircraftType;

        static void Main(String[] args)
        {
            //variables
            string welcomeMessage = "Welcome, please follow the prompts to enter your flight data.";
            
            //program begins
            Console.WriteLine(welcomeMessage);

            //prompt user for their aircraft type
            AircraftSelection();

        }//end main

        //_____ OTHER METHODS ______
        static void AircraftSelection()
        {
            //variables
            int userAircraftSelection;
            bool validInput = true;

            //set the users choice of aircraft based on input
            while (validInput)
            {
                //prompt user for their selection
                Console.WriteLine("\nPlease select an aircraft type from the following list");
                Console.WriteLine("1. Cessna 152\t2. Cessna 172");

                //validate the users input choice as an integer value and not different characters
                if (int.TryParse(Console.ReadLine(), out userAircraftSelection))
                {
                    switch (userAircraftSelection)
                    {
                        case 1:
                            string aircraftType = "Cessna 152";
                            Console.WriteLine($"You have selected : {aircraftType}");
                            PassengerWeightCalculation(aircraftType);
                            break;
                        case 2:
                            aircraftType = "Cessna 172";
                            Console.WriteLine($"You have selected : {aircraftType}");
                            PassengerWeightCalculation(aircraftType);
                            break;
                        default:
                            Console.WriteLine("You did not choose a valid aircraft type, please try again.");
                            AircraftSelection();
                            break;
                    }//end switch statement
                }//end if validate user selection
                else
                {
                    Console.WriteLine("Please enter a valid integer to a corresponding aircraft in the list.");
                }//end else
            }//end while loop
        }//end AircraftSelection() method

        static void PassengerWeightCalculation(string aircraftType)
        {
            //variables
            bool validInput = true;
            int passengerWeight;
            int numberOfPassengers;
            int coPilotOnboardSelection;
            int totalPassengerWeight = 0;
            int pilotWeight;

            //console output so we know this method has been reached - will remove after testing
            Console.WriteLine($"\nBeginning Weight Calculations for type {aircraftType}...");

            //calculating passenger weight depending on aircraft type
            if (aircraftType == "Cessna 172")
            {
                //while loop to continue prompting user
                while (validInput)
                {
                    //ask the user to enter the number of passengers onboard
                    Console.WriteLine("\nPlease enter the number of passengers on board: ");
                    if (int.TryParse(Console.ReadLine(), out numberOfPassengers))
                    {
                        //dont let the user select more than 3 passengers
                        if (numberOfPassengers <= 3)
                        {
                            //ask for each passengers weight
                            for (int i = 1; i <= numberOfPassengers; i++)
                            {
                                Console.WriteLine($"\nPlease enter the weight of passenger {i} in Kilograms (KG)");
                                passengerWeight = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Passenger {i} weight: {passengerWeight}KG");

                                //adding up each passenger weight for a total
                                totalPassengerWeight += passengerWeight;
                            }//end for loop

                            //adding pilot weight to this calculation
                            Console.WriteLine("\nFinally, Please enter the Pilot weight in Kilograms (KG)");
                            pilotWeight = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Pilot weight: {pilotWeight}KG");

                            //final output of passenger weight for C172 aircraft and directing to next method
                            totalPassengerWeight = totalPassengerWeight + pilotWeight;
                            Console.WriteLine($"\nThe total weight of passengers onboard is: {totalPassengerWeight}KG"); //giving total passenger weight
                            LuggageWeightCalculation();

                        }//end if
                        else
                        {
                            //output if the user enters an invalid option
                            Console.WriteLine("A C172 Aircraft can only hold maximum 3 passengers. Please use a larger aircraft.");
                            validInput = false;
                        }//end else                      
                    }//end if
                    else
                    {
                        Console.WriteLine("Please use a numerical value to indicate the number of passengers, eg: 3");
                    }//end else
                }//end while
            }//end if
            else
            {
                //handle when the aircraft selection is for a cessna 152 (cannot hold passengers)
                while(validInput)
                {
                    //checking if the user has a co-pilot onboard
                    Console.WriteLine("\nDo you have a co-pilot on board?");
                    Console.WriteLine("1. Yes\t2.No");
                    if (int.TryParse(Console.ReadLine(), out coPilotOnboardSelection))
                    {
                        bool coPilotOnboard = coPilotOnboardSelection == 1 ? true : false;
                        Console.WriteLine($"Co-Pilot onboard: {coPilotOnboard}");

                        //calculate the weight if there is a co-pilot
                        if (coPilotOnboard == true)
                        {
                            Console.WriteLine("Please enter the co-pilots weight in Kilograms (KG): ");
                            int coPilotWeight = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Co-Pilot Weight = {coPilotWeight}KG");
                            
                            //ask for the pilots weight
                            Console.WriteLine("Please enter the pilots weight in Kilograms (KG): ");
                            pilotWeight = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Pilot Weight = {pilotWeight}KG");

                            //calculate total passenger weight
                            totalPassengerWeight = coPilotWeight + pilotWeight;
                            Console.WriteLine($"The total passenger weight is: {totalPassengerWeight}KG");

                            //go to luggage weight calculation
                            LuggageWeightCalculation();
                        }//end if
                        else
                        {
                            //ask for only the pilots weight
                            Console.WriteLine("Please enter the pilot weight only : ");
                            pilotWeight = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Pilot Weight = {pilotWeight}KG");

                            //calculate total passenger weight
                            totalPassengerWeight = pilotWeight;
                            Console.WriteLine($"The total passenger weight is: {totalPassengerWeight}KG");
                            
                            //go to luggage weight calculation
                            LuggageWeightCalculation();
                        }//end else
                    }//end if
                    else
                    {
                        //handling if the user doesnt select an available value
                        Console.WriteLine("Please enter a valid integer to the corresponding selection in the list.");
                    }//end else
                }//end while
            }//end else
        }//end PassengerWeightCalculation method

        private static void LuggageWeightCalculation()
        {
            Console.WriteLine("\nNow calculating  luggage weight");
            Console.ReadKey();//keeping the command line alive
        }//end LuggageWeightCalculation method

    }//end class
}//end namespace
