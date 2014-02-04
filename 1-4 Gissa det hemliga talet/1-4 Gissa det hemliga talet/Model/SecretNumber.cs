using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace _1_4_Gissa_det_hemliga_talet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreveiousGuess };

    public class SecretNumber
    {
        private int _number;
        private List<int> _preveiousGuesses;
        const int MaxNumberOfGuesses = 7;
       

        public bool CanMakeGuess {

            get
            {
                if (_preveiousGuesses.Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;

                    return false;
                }
                return true;
            }
        }
        public int Count
        {
            get { return _preveiousGuesses.Count; }
        }
        
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }          
            }
        }



        public Outcome Outcome
        {
            get
            {
                return Outcome;
            }
            set
            {
                Outcome = value;
            }
        }
        
        //Undvika privacy leak. Därför kör vi AsReadOnly så det inte ska gå att manipulera
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _preveiousGuesses.AsReadOnly();
            }
        }



        public void Initialize()
        {
            Random random = new Random();
            _number = random.Next(1, 101);

            _preveiousGuesses.Clear();
            Outcome = Outcome.Indefinite;
            
        }
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Count > MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            else if (guess == Number)
            {
                return Outcome.Correct;
            }
            else if (guess > Number)
            {
                return Outcome.High;
            }
            else if (guess < Number)
            {
                return Outcome.Low;
            }
            else
            {
                return Outcome.Correct;
            }
        }
        public SecretNumber()
        {
            _preveiousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
}