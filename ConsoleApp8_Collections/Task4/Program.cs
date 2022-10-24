using System;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Task4
{
    internal static class Program
    {
        public static void Main()
        {
            string path = "notebook";
            
            CreateFile(path, InputData());
        }

        private static string InputData()
        {
            Console.WriteLine("Enter the data");
            
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine() ?? "";
            XElement myPerson = new XElement("Person");
            XAttribute name = new XAttribute("name", fullName);
            myPerson.Add(name);

            #region Address
            
            XElement myAddress = new XElement("Address");
            
            Console.Write("Enter street: ");
            string street = Console.ReadLine();
            XElement myStreet = new XElement("Street"); 
            myStreet.Add(street);
            
            Console.Write("Enter house number: ");
            string houseNum = Console.ReadLine();   
            XElement myHouseNumber = new XElement("HouseNumber");
            myHouseNumber.Add(houseNum);

            Console.Write("Enter apartment number: ");
            string apartNum = Console.ReadLine();     
            XElement myFlatNumber = new XElement("FlatNumber");
            myFlatNumber.Add(apartNum);
            myAddress.Add(myStreet, myHouseNumber, myFlatNumber);

            #endregion

            #region Phones
            
            XElement myPhones = new XElement("Phones");
            
            Console.Write("Enter mobile phone: ");
            string mobileNum = Console.ReadLine();  
            XElement myMobilePhone = new XElement("MobilePhone");
            myMobilePhone.Add(mobileNum);
            
            Console.Write("Enter home phone number: ");
            string homeNum = Console.ReadLine();
            XElement myFlatPhone = new XElement("FlatPhone");
            myFlatPhone.Add(homeNum);
            myPhones.Add(myFlatPhone, myMobilePhone);

            #endregion
            
            myPerson.Add(myAddress, myPhones);

            string tempXml = myPerson.ToString();

            return tempXml;
        }

        private static void CreateFile(string path, string tempXml)
        {
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            byte[] bytes = Encoding.UTF8.GetBytes(tempXml);
            
            fStream.Write(bytes, 0, tempXml.Length);
            
            fStream.Close();
        }
    }
}