﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ZodiacBack.Models
{
    public class ZodiacResponse
    {
        private DateTime BirthdayDate { get; }

        public string WestSign => CalculateWestSign();

        public string EastSign => CalculateEastSign();

        public bool IsBirthday => CheckIfBirthday();

        public int Age => CalculateAge();

        public IEnumerable<string> SpecialMessages => GetSpecialMessages();

        public IEnumerable<string> ErrorMessages => GetErrorMessages();

        public ZodiacResponse(string birthday)
        {
            BirthdayDate = DateTime.Parse(birthday);
        }

        private int CalculateAge()
        {
            var now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            var dob = int.Parse(BirthdayDate.ToString("yyyyMMdd"));
            return (now - dob) / 10000;
        }

        private bool CheckIfBirthday()
        {
            DateTime now = DateTime.Now;
            return BirthdayDate.Day == now.Day && BirthdayDate.Month == now.Month;
        }

        private IEnumerable<string> GetErrorMessages()
        {
            var list = new List<string>();
            if (Age > 135)
            {
                list.Add("Людина не може жити більше 135 років");
            }else if (Age <= 0)
            {
                list.Add("Вам не може бути 0 або меньше років");
            }

            return list;
        }

        private IEnumerable<string> GetSpecialMessages()
        {
            if (ErrorMessages.Any()) return null;
            
            var messages = new List<string>();
            if (IsBirthday)
            {
                messages.Add("Друже, з днем народження!");
            }

            return messages;
        }

        private string CalculateEastSign()
        {
            if (ErrorMessages.Any()) return null;
            
            var year = BirthdayDate.Year;
            var remainder = year % 12;

            var sign = remainder switch
            {
                0 => "Мавпа",
                1 => "Півень",
                2 => "Собака",
                3 => "Свиня",
                4 => "Щур",
                5 => "Бик",
                6 => "Тигр",
                7 => "Кролик",
                8 => "Дракон",
                9 => "Змія",
                10 => "Кінь",
                11 => "Вівця(Коза)",
                _ => ""
            };

            return sign;
        }

        private string CalculateWestSign()
        {
            if (ErrorMessages.Any()) return null;
            
            var day = BirthdayDate.Day;
            var month = BirthdayDate.Month;

            var astroSign = month switch
            {
                1 when day < 20 => "Козеріг",
                1 => "Водолій",
                2 when day < 19 => "Водолій",
                2 => "Риби",
                3 when day < 21 => "Риби",
                3 => "Овен",
                4 when day < 20 => "Овен",
                4 => "Телець",
                5 when day < 21 => "Телець",
                5 => "Близнюки",
                6 when day < 21 => "Близнюки",
                6 => "Рак",
                7 when day < 23 => "Рак",
                7 => "Лев",
                8 when day < 23 => "Лев",
                8 => "Діва",
                9 when day < 23 => "Діва",
                9 => "Терези",
                10 when day < 23 => "Терези",
                10 => "Скорпіон",
                11 when day < 22 => "Скорпіон",
                11 => "Стрілець",
                12 when day < 22 => "Стрілець",
                12 => "Козеріг",
                _ => ""
            };

            return astroSign;
        }
    }
}