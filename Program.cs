using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class User : IComparable
    {
        public override string ToString()
        {
            return base.ToString() +" " + FirstName+ " " + LastName +" "+ Email;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            if (obj is User otherId)
                return Id.CompareTo(otherId.Id);
            
            throw new NotImplementedException();
        }

        public void Equals(){}
        public void GetHashCode(){}
        

        private static int _userId = 1;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private double _balance;

        public int Id;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == null)
                {
                    throw new Exception(message: "he first letter has to be uppercase");
                }
                else
                {
                    _firstName = value;
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == null)
                {
                    throw new Exception(message: "he first letter has to be uppercase");
                }
                else
                {
                    _lastName = value;
                }
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                foreach (var VARIABLE in value)
                {
                    if (char.IsLower(VARIABLE) || char.IsDigit(VARIABLE) || VARIABLE == '_')
                    {
                        _userName = value;
                    }
                    else
                    {
                        throw new Exception(message: "he first letter has to be uppercase");
                    }
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                string[] b = value.Split('@');

                if (b.Length != 2)
                {
                    throw new Exception(message: "he first letter has to be uppercase");
                }


                foreach (var VARIABLE in b[0])
                {
                    if (!char.IsLetter(VARIABLE) || !char.IsDigit(VARIABLE) || VARIABLE is not ('.' or '-' or '_'))
                    {
                         throw new Exception(message: "he first letter has to be uppercase");
                    }
                }

                if (b[1][0] is not ('-' or '.') && b[1].Last() is not ('-' or '.') && b[1].Contains('.'))
                {
                    throw new Exception(message: "he first letter has to be uppercase");
                }
                
                foreach (var VARIABLE in b[1])
                {
                    if (!char.IsLetter(VARIABLE) || !char.IsDigit(VARIABLE) || VARIABLE is not ('.' or '-'))
                    {
                        throw new Exception(message: "he first letter has to be uppercase");
                    }
                }

                _email = value;
            }
        }

        public double Balance
        {
            get => _balance;
            set
            {
                if (_balance <= 50)
                {
                    Console.WriteLine("balance to low");
                }
                else
                {
                    _balance = value;
                }
            }
        }
        
        public User(string firstName, string lastName, string userName, string email, double balance)
        {
            Id = _userId++;
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _email = email;
            _balance = balance;
        }
    }
}
