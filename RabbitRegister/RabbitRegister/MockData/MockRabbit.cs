﻿using RabbitRegister.Model;
using static System.Net.Mime.MediaTypeNames;

namespace RabbitRegister.MockData
{
    public class MockRabbit
    {
        private static List<Rabbit> _rabbits = new List<Rabbit>()
        {
            new Rabbit(
                001,
                5095,
                5095,
                "Kaliba",
                "Angora",
                "Grå",
                Sex.Hun,
                new DateTime(2019, 02, 27),
                562,
                92,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Meget god avlskanin og god mor. Mange gode egenskaber såsom tæt pels, og rolige tendenser ved klip.",
                null,
                "/Images/Rabbits/Kaliba.jpg"),

            new Rabbit(
                002,
                5095,
                5095,
                "Sov",
                "Angora",
                "Sort",
                Sex.Hun,
                new DateTime(2020, 06, 12),
                500,
                74,
                DeadOrAlive.Død,
                IsForSale.Nej,
                "Meget sky kanin. Havde ikke gode egenskaber for at blive tam, men tilgengæld gode pels kvaliteter",
                "Fødselskomplikationer - mulighvis for langt imellem parring",
                null),

            new Rabbit(
                003,
                5095,
                5095,
                "Smørklat smør",
                "Fransk Angora",
                "Gul",
                Sex.Hun,
                new DateTime(2020, 03, 12),
                530,
                75,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Hun filtrer meget i nakken og på maven, ellers hurtigvoksende pels",
                null,
                "/Images/Rabbits/Smoerklatsmoer.jpg"),

            new Rabbit(
                004,
                5095,
                5053,
                "Fiktiv",
                "Fransk Angora",
                "Hvid",
                Sex.Hun,
                new DateTime(2019, 09, 21),
                511,
                66,
                DeadOrAlive.Død,
                IsForSale.Nej,
                null,
                null,
                "/Images/Rabbits/Fiktiv.jpg"),

            new Rabbit(
                120,
                4640,
                5095,
                "Mulan",
                "Angora",
                "Blå",
                Sex.Hun,
                new DateTime(2021, 05, 11),
                614,
                87,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                "/Images/Rabbits/Mulan.jpg"),

            new Rabbit(
                105,
                4640,
                5095,
                "Ingolf",
                "Engelsk Angora",
                "Blå Chinchilla",
                Sex.Han,
                new DateTime(2021, 04, 05),
                510,
                89,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Han er ret lille i forhold til hvad standarden siger. Meget imødekommende",
                null,
                "/Images/Rabbits/Ingolf.jpg"),

             new Rabbit(
                067,
                4982,
                5053,
                "Frida",
                "Satin Angora",
                "Ræve Rød",
                Sex.Hun,
                new DateTime(2022, 06, 22),
                520,
                62,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Hun er til låns.. Hun er bliver meget let stresset og sky",
                null,
                "/Images/Rabbits/Frida.jpg"),

            new Rabbit(
                001,
                5053,
                5053,
                "Niko",
                "Satin Angora",
                "Vildt Rød",
                Sex.Han,
                new DateTime(2022, 10, 18),
                532,
                72,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Ikke prangende, men den bedste Satin Angora der findes for nu",
                null,
                null),

            new Rabbit(
                0123,
                5053,
                5095,
                "Gul-unge",
                "Satin Angora",
                "Gul",
                Sex.Han,
                new DateTime(2023, 06, 30),
                780,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                "/Images/Rabbits/Gul-unge.jpg"),

            new Rabbit(
                0223,
                5053,
                5095,
                "Gastly",
                "Satin Angora",
                "Sort",
                Sex.Hun,
                new DateTime(2023, 06, 30),
                790,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                "/Images/Rabbits/Gastly.jpg"),

            new Rabbit(
                0423,
                5053,
                5095,
                "Chinchou",
                "Satin Angora",
                "Blå",
                Sex.Hun,
                new DateTime(2023, 06, 30),
                665,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                "/Images/Rabbits/Chinchou.jpg"),

            new Rabbit(
                206,
                4977,
                5053,
                "Dario",
                "Satin-Angora",
                "Beige",
                Sex.Han,
                new DateTime(2022, 02, 02),
                null,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                "Avlshan. Pt far til 3 kuld",
                null,
                null),

            new Rabbit(
                315,
                4977,
                5053,
                "Miranda",
                "Satin-Angora",
                "Sort",
                Sex.Hun,
                new DateTime(2023, 12, 01),
                null,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                null),

            new Rabbit(
                323,
                5053,
                5053,
                "Dario",
                "Satin-Angora",
                "Beige",
                Sex.Han,
                new DateTime(2023, 12, 08),
                null,
                null,
                DeadOrAlive.Levende,
                IsForSale.Nej,
                null,
                null,
                null),
        };



        public static List<Rabbit> GetMockRabbits()
        { return _rabbits; }

    }
}
