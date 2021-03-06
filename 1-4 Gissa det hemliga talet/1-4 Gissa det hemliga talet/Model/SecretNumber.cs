﻿using System;
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
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;

                    return true;
                }
                return false;
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
            get;
           private set;
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
            _preveiousGuesses.Clear();
            Outcome = Outcome.Indefinite;

            Random random = new Random();
            _number = random.Next(1, 101);
        }
        public Outcome MakeGuess(int guess)
        {
            if (PreviousGuesses.Contains(guess))
            {
                return Outcome.PreveiousGuess;
            }
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Count +1 >= MaxNumberOfGuesses)
            {
                
                return Outcome.NoMoreGuesses;
            }
            else if (guess > Number)
            {
                _preveiousGuesses.Add(guess);
                return Outcome.High;
            }
            else if (guess < Number)
            {
                _preveiousGuesses.Add(guess);
                return Outcome.Low;
            }
            else
            {
                _preveiousGuesses.Add(guess);
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