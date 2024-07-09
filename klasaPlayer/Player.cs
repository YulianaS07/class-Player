using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasaPlayer
{
    public class Player
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value.Trim().ToLower();
                if (value == null)
                    throw new ArgumentException("Wrong name!");
                char[] _name = name.ToCharArray();
                if (name.Length < 3 || !char.IsLetter(name[0]))
                    throw new ArgumentException("Wrong name!");
                if (name.Contains(" "))
                {
                    string[] name1 = name.Split(" ");
                    string name2 = "";
                    for (int i = 0; i < name1.Length; i++)
                    {
                        string ch = name1[i].ToLower();
                        name2 += ch;
                    }
                    name = name2;
                    _name = name.ToCharArray();
                }
                
                foreach (char c in _name)
                {
                    if (!char.IsLetterOrDigit(c))
                        throw new ArgumentException("Wrong name!");
                }
            }
        }

        private string password;
        private string Password 
        {
            get => password;
            set
            {
                if (value == null)
                    throw new ArgumentException("Wrong password!");
                password = value.Trim();
                if (password.Length < 8 || password.Length > 16 || !password.Any(char.IsLetterOrDigit)
                    || !password.Any(char.IsPunctuation) || !password.Any(char.IsUpper))
                    throw new ArgumentException("Wrong password!");
            }
        }
        private int bestScore;
        public int BestScore { get => bestScore; }
        private int lastScore;
        public int LastScore { get => lastScore; }
        private double summary = 0;
        private double score = 0;
        private double avgScore;
        public double AvgScore { get => avgScore; }

        public Player(string name, string password, int BestScore = 0, int LastScore = 0, double AvgScore = 0) 
        {
            Name = name;
            Password = password;
        }

        public void AddScore(int currentScore)
        {
            if (currentScore < 0 || currentScore > 100)
            {
                Console.WriteLine("Wrong value!");
                return;
            }
            lastScore = currentScore;
            if (currentScore > bestScore)
                bestScore = currentScore;
            summary += currentScore;
            score++;
            avgScore = summary / score;
        }

        public bool TryAddScore(int currentScore)
        {
            if (currentScore < 0 || currentScore > 100)
                return false;
            lastScore = currentScore;
            if (currentScore > bestScore)
                bestScore = currentScore;
            summary += currentScore;
            score++;
            avgScore = Math.Round((summary / score), 1);
            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == password && newPassword != null 
                && !(newPassword.Length < 8) && !(newPassword.Length > 16) 
                && newPassword.Any(char.IsDigit) && newPassword.Any(char.IsLetter)
                    && newPassword.Any(char.IsPunctuation) && newPassword.Any(char.IsUpper))
            {
                newPassword = Password;
                return true;
            }
            else
                return false;
        }

        public bool VerifyPassword(string password)
        {
            if (password == this.password)
                return true;
            else
                return false;
        }

        public override string ToString()
            => $"Name: {Name}, Score: last={LastScore}, best={BestScore}, avg={AvgScore}";

    }
}
//Konstruktor tworzy obiekt gracza, inicjując podanymi jako argumenty: nazwą gracza oraz hasłem. Jeśli nazwa gracza nie spełnia warunków poprawności, proces tworzenia obiektu jest przerywany i zgłaszany jest wyjątek ArgumentException z komunikatem "Wrong name!". Jeśli nazwa gracza jest poprawna, zaś hasło nie spełnia warunków poprawności, proces tworzenia obiektu jest przerywany i zgłaszany jest wyjątek ArgumentException z komunikatem "Wrong password!". Wartości BestScore, LastScore oraz AvgScore wynoszą 0.

//void AddScore(int currentScore) -dodanie wyniku aktualnie zakończonej rozgrywki, wymusza modyfikację BestScore, LastScore oraz AvgScore. Parametr jest liczbą od 0 do 100. W przypadku podania wartości spoza zakresu, zgłasza wyjątek ArgumentOutOfRangeException z komunikatem "Wrong value!".

//bool TryAddScore(int currentScore) -jak AddScore, ale nie zgłasza żadnych wyjątków. Jeśli wynik został zarejestrowany, zgłasza true, w przeciwnym przypadku false.

//bool ChangePassword(string oldPassword, string newPassword) -zmiana hasła, wymaga podania poprawnego podania starego hasła (oldPassword) oraz nowego newPassword - zwraca wtedy true. W przeciwnym przypadku zwraca false bez zgłaszania wyjątków i zmiany hasła.

//bool VerifyPassword(string password) -zwraca true jeśli zapamiętane hasło jest takie samo jak podane jako argument, w przeciwnym przypadku false.

//tekstowa reprezentacja obiektu w formie: "Name: {Name}, Score: last={LastScore}, best={BestScore}, avg={AvgScore}".Średni wynik podawany jest z 1 miejscem po przecinku