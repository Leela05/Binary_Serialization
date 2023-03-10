using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Provides functionality for formatting serialized objects.
//IFormatter
using System.Runtime.Serialization;

//Serializes and deserializes an object, or an entire graph of connected objects in binary format.  
using System.Runtime.Serialization.Formatters.Binary; // BinaryFormatter

using System.IO;

namespace Binary_Serialization
{
    [Serializable]
    class EmployeeDetails
    {
        public int Employee_Id { get; set; }
        public string Emplpoyee_name { get; set; }
        public string Goc { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
// step 1 -  create the instance of the EmployeeDetails class
            
            EmployeeDetails employee1 = new EmployeeDetails() // object 1
            {
                Employee_Id = 99021710,
                Emplpoyee_name = "Leela",
                Goc = "System c Healthcare"
            };


// step 2 - convert .net object to binary format

// IFormatter - Provides functionality for formatting serialized objects.

// Stream - used to read and write to files

            IFormatter formatter = new BinaryFormatter();

// Employee.txt -  creates the file in local 

            Stream stream = new FileStream(@"C:\\Users\\lees\\source\\repos\\Task\\Code\\Binary_Serialization\\Employee.txt",FileMode.Create,FileAccess.Write);

// step 3 - Serialization -  Serialize() method serialize the data to the file
            
            formatter.Serialize(stream, employee1);
            stream.Close();

 // step 4 - Deserialization (convert binary to .net object)

 //

            stream = new FileStream(@"C:\\Users\\lees\\source\\repos\\Task\\Code\\Binary_Serialization\\Employee.txt",FileMode.Open,FileAccess.Read);

            EmployeeDetails deserilize = (EmployeeDetails)formatter.Deserialize(stream);

            Console.WriteLine("After Deserialize Object:" + deserilize.Employee_Id);
            Console.WriteLine("After Deserialize Object:" + deserilize.Emplpoyee_name);
            Console.WriteLine("After Deserialize Object:" + deserilize.Goc);


            Console.ReadLine(); 
        }
    }
}
