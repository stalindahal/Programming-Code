using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class Program
    {
        class ReservationDetail
        {
            public string customerName { get; set; }
            public int nights { get; set; }
            public string available_room { get; set; }    // Change1: Changing variable names
            public double totalPrice { get; set; }

        }
        // calulation of room services
        //Pujan Budathoki
        static double Price(int night, string isRoomService)
        {
            double price = 0;
                try{
            if((night > 0 )&& (night <= 3))
                price = 100*night; 
            else if((night > 3 )&& (night <= 10))
                price = 80.5*night; 
            else if((night > 10 )&& (night <= 20))
                price = 75.3*night;
            //roomservice should be checked to lower yes
            if(isRoomService.ToLower()=="yes")
                return price+price*0.1;
            else
                return price;

        }
        catch (Exception ex)
            {
                Console.WriteLine($"Error calculating price: {ex.Message}");
                return 0; // Return 0 in case of error
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.WriteLine("Our Hotel, Your Destination");   //Change 2: Adding one more messages
            Console.Write("\nEnter no. of Customer: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 0)
    {
        Console.WriteLine("Please enter a valid number of customers.");
        Console.Write("\nEnter no. of Customer again: ");
        neww = Convert.ToInt32(Console.ReadLine());
        n=neww;
      
    }
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            List<ReservationDetail> reservations = new List<ReservationDetail>();

            int nights;
                do
                {
                    Console.Write("Enter the number of nights (1 to 20): ");
                    nights = Convert.ToInt32(Console.ReadLine());
                } while (nights <= 0 || nights > 20);

                reservationDetails[i].Nights = nights;

                Console.Write("Enter yes/no to indicate wheather you want ta room service: ");
                rd[i].roomService=Console.ReadLine();

                rd[i].totalPrice = Price(rd[i].nights, rd[i].roomService);
                Console.WriteLine($"The total price from {rd[i].customerName} is ${rd[i].totalPrice}");
                Console.WriteLine("\n--------------------------------------------------------------------");

            }
    
            var (minPrice,minindex) = rd.Select(x=>x.totalPrice).Select((m,i) => (m,i)).Min();
            var (maxPrice,maxindex) = rd.Select(x => x.totalPrice).Select((m, i) => (m, i)).Max();

            ReservationDetail maxrd = rd[maxindex];
            ReservationDetail minrd =rd[minindex];

            Console.WriteLine("\n\t\t\t\tSummary of reservation");
            Console.WriteLine("--------------------------------------------------------------------\n");
            Console.WriteLine("Name\t\tNumber of nights\t\tRoom service\t\tCharge");
            Console.WriteLine($"{minrd.customerName}\t\t\t{minrd.nights}\t\t\t{minrd.roomService}\t\t\t{minrd.totalPrice}");
            Console.WriteLine($"{maxrd.customerName}\t\t{maxrd.nights}\t\t\t{maxrd.roomService}\t\t\t{maxrd.totalPrice}");
            Console.WriteLine("\n--------------------------------------------------------------------\n");
            Console.WriteLine($"The customer spending most is {maxrd.customerName} ${maxrd.totalPrice}");
            Console.WriteLine($"The customer spending least is {minrd.customerName} ${minrd.totalPrice}");
            Console.WriteLine($"Press any ket to continue....");
            Console.ReadLine();

        }
    }
}
