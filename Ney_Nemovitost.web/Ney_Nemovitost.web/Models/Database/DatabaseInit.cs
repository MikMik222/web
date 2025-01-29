using Ney_Nemovitost.web.Models.Entities;
using Ney_Nemovitost.web.Models.Identity;
using System;

namespace Ney_Nemovitost.web.Models.Database
{
    internal class DatabaseInit
    {
        public List<Role> CreateRoles()

        {
            List<Role> roles = new List<Role>();
            Role role1 = new Role()
            {
                Id = 1,
                Name = "Vlastnik_Registrovany",
                NormalizedName = "VLASTNIK_REGISTROVANY",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };
            roles.Add(role1);
            return roles;
        }

        internal List<DispoziceNemovitosti> CreateDispozitionOptions()
        {
            List<DispoziceNemovitosti> dispoziceNemovitostis = new List<DispoziceNemovitosti>();

            DispoziceNemovitosti dispozice1 = new DispoziceNemovitosti()
            {
                ID = 1,
                Dispozice = "Garsoniéra"
            };
            DispoziceNemovitosti dispozice2 = new DispoziceNemovitosti()
            {
                ID = 2,
                Dispozice = "1+kk"
            };
            DispoziceNemovitosti dispozice3 = new DispoziceNemovitosti()
            {
                ID = 3,
                Dispozice = "1+1"
            };
            DispoziceNemovitosti dispozice4 = new DispoziceNemovitosti()
            {
                ID = 4,
                Dispozice = "2+kk"
            };
            DispoziceNemovitosti dispozice5 = new DispoziceNemovitosti()
            {
                ID = 5,
                Dispozice = "2+1"
            };
            DispoziceNemovitosti dispozice6 = new DispoziceNemovitosti()
            {
                ID = 6,
                Dispozice = "3+kk"
            };
            DispoziceNemovitosti dispozice7 = new DispoziceNemovitosti()
            {
                ID = 7,
                Dispozice = "3+1"
            };
            DispoziceNemovitosti dispozice8 = new DispoziceNemovitosti()
            {
                ID = 8,
                Dispozice = "4+kk"
            };
            DispoziceNemovitosti dispozice9 = new DispoziceNemovitosti()
            {
                ID = 9,
                Dispozice = "4+1"
            };
            DispoziceNemovitosti dispozice10 = new DispoziceNemovitosti()
            {
                ID = 10,
                Dispozice = "5+kk"
            };
            DispoziceNemovitosti dispozice11 = new DispoziceNemovitosti()
            {
                ID = 11,
                Dispozice = "5+1"
            };
            DispoziceNemovitosti dispozice12 = new DispoziceNemovitosti()
            {
                ID = 12,
                Dispozice = "6+kk"
            };
            DispoziceNemovitosti dispozice13 = new DispoziceNemovitosti()
            {
                ID = 13,
                Dispozice = "6+1"
            };
            DispoziceNemovitosti dispozice14 = new DispoziceNemovitosti()
            {
                ID = 14,
                Dispozice = "7+kk"
            };
            DispoziceNemovitosti dispozice15 = new DispoziceNemovitosti()
            {
                ID = 15,
                Dispozice = "7+1"
            };
            DispoziceNemovitosti dispozice16 = new DispoziceNemovitosti()
            {
                ID = 16,
                Dispozice = "Ostatní"
            };
            dispoziceNemovitostis.Add(dispozice1);
            dispoziceNemovitostis.Add(dispozice2);
            dispoziceNemovitostis.Add(dispozice3);
            dispoziceNemovitostis.Add(dispozice4);
            dispoziceNemovitostis.Add(dispozice5);
            dispoziceNemovitostis.Add(dispozice6);
            dispoziceNemovitostis.Add(dispozice7);
            dispoziceNemovitostis.Add(dispozice8);
            dispoziceNemovitostis.Add(dispozice9);
            dispoziceNemovitostis.Add(dispozice10);
            dispoziceNemovitostis.Add(dispozice11);
            dispoziceNemovitostis.Add(dispozice12);
            dispoziceNemovitostis.Add(dispozice13);
            dispoziceNemovitostis.Add(dispozice14);
            dispoziceNemovitostis.Add(dispozice15);
            dispoziceNemovitostis.Add(dispozice16);
            return dispoziceNemovitostis;
        }

        internal List<TypyDodatku> CreateDodatky()
        {
            List<TypyDodatku> typyDodatkus = new List<TypyDodatku>();
            TypyDodatku dodatek1 = new TypyDodatku()
            {
                Id = 1,
                TypDodatku = "Článek 2 - změna maximálního počtu osob"
            };
            TypyDodatku dodatek2 = new TypyDodatku()
            {
                Id = 2,
                TypDodatku = "Článek 3 - doba nájmu"
            };
            TypyDodatku dodatek3 = new TypyDodatku()
            {
                Id = 3,
                TypDodatku = "Článek 4 - cena nájmu a služeb"
            };
            typyDodatkus.Add(dodatek1);
            typyDodatkus.Add(dodatek2);
            typyDodatkus.Add(dodatek3);
            return typyDodatkus;
        }

        internal List<EnerNarocnostNemovitosti> CreateEnergetickaOptions()
        {
            List<EnerNarocnostNemovitosti> enerNarocnostNemovitostis = new List<EnerNarocnostNemovitosti>();

            EnerNarocnostNemovitosti enerNarocnost1 = new EnerNarocnostNemovitosti()
            {
                ID = 1,
                EnerNárocnost = "A"
            };
            EnerNarocnostNemovitosti enerNarocnost2 = new EnerNarocnostNemovitosti()
            {
                ID = 2,
                EnerNárocnost = "B"
            };
            EnerNarocnostNemovitosti enerNarocnost3 = new EnerNarocnostNemovitosti()
            {
                ID = 3,
                EnerNárocnost = "C"
            };
            EnerNarocnostNemovitosti enerNarocnost4 = new EnerNarocnostNemovitosti()
            {
                ID = 4,
                EnerNárocnost = "D"
            };
            EnerNarocnostNemovitosti enerNarocnost5 = new EnerNarocnostNemovitosti()
            {
                ID = 5,
                EnerNárocnost = "E"
            };
            EnerNarocnostNemovitosti enerNarocnost6 = new EnerNarocnostNemovitosti()
            {
                ID = 6,
                EnerNárocnost = "F"
            };
            EnerNarocnostNemovitosti enerNarocnost7 = new EnerNarocnostNemovitosti()
            {
                ID = 7,
                EnerNárocnost = "G"
            };
            enerNarocnostNemovitostis.Add(enerNarocnost1);
            enerNarocnostNemovitostis.Add(enerNarocnost2);
            enerNarocnostNemovitostis.Add(enerNarocnost3);
            enerNarocnostNemovitostis.Add(enerNarocnost4);
            enerNarocnostNemovitostis.Add(enerNarocnost5);
            enerNarocnostNemovitostis.Add(enerNarocnost6);
            enerNarocnostNemovitostis.Add(enerNarocnost7);
            return enerNarocnostNemovitostis;
        }

        internal List<KostrukceNemovitosti> CreateKonstrukceOptions()
        {
            List<KostrukceNemovitosti> kostrukceNemovitostis = new List<KostrukceNemovitosti>();
            KostrukceNemovitosti kostrukceNemovitosti1 = new KostrukceNemovitosti()
            {
                ID = 1,
                Konstrukce = "Dřevostavba"
            };
            KostrukceNemovitosti kostrukceNemovitosti2 = new KostrukceNemovitosti()
            {
                ID = 2,
                Konstrukce = "Cihla"
            };
            KostrukceNemovitosti kostrukceNemovitosti3 = new KostrukceNemovitosti()
            {
                ID = 3,
                Konstrukce = "Panel"
            };
            KostrukceNemovitosti kostrukceNemovitosti4 = new KostrukceNemovitosti()
            {
                ID = 4,
                Konstrukce = "Nizkoenergetický"
            };
            KostrukceNemovitosti kostrukceNemovitosti5 = new KostrukceNemovitosti()
            {
                ID = 5,
                Konstrukce = "Ostatní"
            };
            kostrukceNemovitostis.Add(kostrukceNemovitosti1);
            kostrukceNemovitostis.Add(kostrukceNemovitosti2);
            kostrukceNemovitostis.Add(kostrukceNemovitosti3);
            kostrukceNemovitostis.Add(kostrukceNemovitosti4);
            kostrukceNemovitostis.Add(kostrukceNemovitosti5);
            return kostrukceNemovitostis;
        }

        internal List< MoznostiSluzeb> CreateMoznostiSluzeb()
        {
            List<MoznostiSluzeb> moznostiSluzebs = new List<MoznostiSluzeb>();
            MoznostiSluzeb m1 = new MoznostiSluzeb()
            {
                ID= 1,
                NazevSluzby = "Cena nájmu"
            };
            MoznostiSluzeb m2 = new MoznostiSluzeb()
            {
                ID = 2,
                NazevSluzby = "Cena vody"
            };
            MoznostiSluzeb m3 = new MoznostiSluzeb()
            {
                ID = 3,
                NazevSluzby = "Cena plynu"
            };
            MoznostiSluzeb m4 = new MoznostiSluzeb()
            {
                ID = 4,
                NazevSluzby = "Cena elektřiny"
            };
            MoznostiSluzeb m5 = new MoznostiSluzeb()
            {
                ID = 5,
                NazevSluzby = "Cena internetu"
            };
            MoznostiSluzeb m6 = new MoznostiSluzeb()
            {
                ID = 6,
                NazevSluzby = "Cena úklidu"
            };
            MoznostiSluzeb m7 = new MoznostiSluzeb()
            {
                ID = 7,
                NazevSluzby = "Cena odpadu"
            };
            MoznostiSluzeb m8 = new MoznostiSluzeb()
            {
                ID = 8,
                NazevSluzby = "Cena společné elektřiny"
            };
            moznostiSluzebs.Add(m1);
            moznostiSluzebs.Add(m2);
            moznostiSluzebs.Add(m3);
            moznostiSluzebs.Add(m4);
            moznostiSluzebs.Add(m5);
            moznostiSluzebs.Add(m6);
            moznostiSluzebs.Add(m7);
            moznostiSluzebs.Add(m8);

            return moznostiSluzebs;
        }

        internal List<OptionNemovitost> CreateNemovitostOptions()
        {
            List<OptionNemovitost> optionNemovitost = new List<OptionNemovitost>();

            OptionNemovitost optionNemovitost1 = new OptionNemovitost()
            {
                ID = 1,
                Volba = "Byt",
                VolbaJinyPad = "Bytu"
            };

            OptionNemovitost optionNemovitost2 = new OptionNemovitost()
            {
                ID = 2,
                Volba = "Dům",
                VolbaJinyPad = "Domu"

            };
            OptionNemovitost optionNemovitost3 = new OptionNemovitost()
            {
                ID = 3,
                Volba = "Pozemek",
                VolbaJinyPad = "Pozemku"
            };
            OptionNemovitost optionNemovitost4 = new OptionNemovitost()
            {
                ID = 4,
                Volba = "Garáž",
                VolbaJinyPad = "Garáži"
            };
            OptionNemovitost optionNemovitost5 = new OptionNemovitost()
            {
                ID = 5,
                Volba = "Kancelář",
                VolbaJinyPad = "Kanceláře"
            };
            OptionNemovitost optionNemovitost6 = new OptionNemovitost()
            {
                ID = 6,
                Volba = "Nebytový prostor",
                VolbaJinyPad = "Nebytového prostoru"
            };
            OptionNemovitost optionNemovitost7 = new OptionNemovitost()
            {
                ID = 7,
                Volba = "Chaty a chalupy",
                VolbaJinyPad = "chaty a chalupy"
            };
            optionNemovitost.Add(optionNemovitost1);
            optionNemovitost.Add(optionNemovitost2);
            optionNemovitost.Add(optionNemovitost3);
            optionNemovitost.Add(optionNemovitost4);
            optionNemovitost.Add(optionNemovitost5);
            optionNemovitost.Add(optionNemovitost6);
            optionNemovitost.Add(optionNemovitost7);
            return optionNemovitost;
        }

        internal List<Predvolby> CreatePredvolby()
        {
            List<Predvolby> predvolbies = new List<Predvolby>();
            Predvolby p1 = new Predvolby() { ID = 1, NameCountry = "Afghanistan", predvolba = 93 };
            Predvolby p2 = new Predvolby() { ID = 2, NameCountry = "Aland Islands", predvolba = 358 };
            Predvolby p3 = new Predvolby() { ID = 3, NameCountry = "Albania", predvolba = 355 };
            Predvolby p4 = new Predvolby() { ID = 4, NameCountry = "Algeria", predvolba = 213 };
            Predvolby p5 = new Predvolby() { ID = 5, NameCountry = "American Samoa", predvolba = 1 };
            Predvolby p6 = new Predvolby() { ID = 6, NameCountry = "Andorra", predvolba = 376 };
            Predvolby p7 = new Predvolby() { ID = 7, NameCountry = "Angola", predvolba = 244 };
            Predvolby p8 = new Predvolby() { ID = 8, NameCountry = "Anguilla", predvolba = 1 };
            Predvolby p9 = new Predvolby() { ID = 9, NameCountry = "Antigua and Barbuda", predvolba = 1 };
            Predvolby p10 = new Predvolby() { ID = 10, NameCountry = "Argentina", predvolba = 54 };
            Predvolby p11 = new Predvolby() { ID = 11, NameCountry = "Armenia", predvolba = 374 };
            Predvolby p12 = new Predvolby() { ID = 12, NameCountry = "Aruba", predvolba = 297 };
            Predvolby p13 = new Predvolby() { ID = 13, NameCountry = "Australia", predvolba = 61 };
            Predvolby p14 = new Predvolby() { ID = 14, NameCountry = "Austria", predvolba = 43 };
            Predvolby p15 = new Predvolby() { ID = 15, NameCountry = "Azerbaijan", predvolba = 994 };
            Predvolby p16 = new Predvolby() { ID = 16, NameCountry = "Bahamas", predvolba = 1 };
            Predvolby p17 = new Predvolby() { ID = 17, NameCountry = "Bahrain", predvolba = 973 };
            Predvolby p18 = new Predvolby() { ID = 18, NameCountry = "Bangladesh", predvolba = 880 };
            Predvolby p19 = new Predvolby() { ID = 19, NameCountry = "Barbados", predvolba = 1 };
            Predvolby p20 = new Predvolby() { ID = 20, NameCountry = "Belarus", predvolba = 375 };
            Predvolby p21 = new Predvolby() { ID = 21, NameCountry = "Belgium", predvolba = 32 };
            Predvolby p22 = new Predvolby() { ID = 22, NameCountry = "Belize", predvolba = 501 };
            Predvolby p23 = new Predvolby() { ID = 23, NameCountry = "Benin", predvolba = 229 };
            Predvolby p24 = new Predvolby() { ID = 24, NameCountry = "Bermuda", predvolba = 1 };
            Predvolby p25 = new Predvolby() { ID = 25, NameCountry = "Bhutan", predvolba = 975 };
            Predvolby p26 = new Predvolby() { ID = 26, NameCountry = "Bolivia", predvolba = 591 };
            Predvolby p27 = new Predvolby() { ID = 27, NameCountry = "Bonaire, Sint Eustatius and Saba", predvolba = 599 };
            Predvolby p28 = new Predvolby() { ID = 28, NameCountry = "Bosnia and Herzegovina", predvolba = 387 };
            Predvolby p29 = new Predvolby() { ID = 29, NameCountry = "Botswana", predvolba = 267 };
            Predvolby p30 = new Predvolby() { ID = 30, NameCountry = "Brazil", predvolba = 55 };
            Predvolby p31 = new Predvolby() { ID = 31, NameCountry = "British Indian Ocean Territory", predvolba = 246 };
            Predvolby p32 = new Predvolby() { ID = 32, NameCountry = "British Virgin Islands", predvolba = 1 };
            Predvolby p33 = new Predvolby() { ID = 33, NameCountry = "Brunei", predvolba = 673 };
            Predvolby p34 = new Predvolby() { ID = 34, NameCountry = "Bulgaria", predvolba = 359 };
            Predvolby p35 = new Predvolby() { ID = 35, NameCountry = "Burkina Faso", predvolba = 226 };
            Predvolby p36 = new Predvolby() { ID = 36, NameCountry = "Burundi", predvolba = 257 };
            Predvolby p37 = new Predvolby() { ID = 37, NameCountry = "Cabo Verde", predvolba = 238 };
            Predvolby p38 = new Predvolby() { ID = 38, NameCountry = "Cambodia", predvolba = 855 };
            Predvolby p39 = new Predvolby() { ID = 39, NameCountry = "Cameroon", predvolba = 237 };
            Predvolby p40 = new Predvolby() { ID = 40, NameCountry = "Canada", predvolba = 1 };
            Predvolby p41 = new Predvolby() { ID = 41, NameCountry = "Caribbean", predvolba = 0 };
            Predvolby p42 = new Predvolby() { ID = 42, NameCountry = "Cayman Islands", predvolba = 1 };
            Predvolby p43 = new Predvolby() { ID = 43, NameCountry = "Central African Republic", predvolba = 236 };
            Predvolby p44 = new Predvolby() { ID = 44, NameCountry = "Chad", predvolba = 235 };
            Predvolby p45 = new Predvolby() { ID = 45, NameCountry = "Chile", predvolba = 56 };
            Predvolby p46 = new Predvolby() { ID = 46, NameCountry = "China", predvolba = 86 };
            Predvolby p47 = new Predvolby() { ID = 47, NameCountry = "Christmas Island", predvolba = 61 };
            Predvolby p48 = new Predvolby() { ID = 48, NameCountry = "Cocos (Keeling) Islands", predvolba = 61 };
            Predvolby p49 = new Predvolby() { ID = 49, NameCountry = "Colombia", predvolba = 57 };
            Predvolby p50 = new Predvolby() { ID = 50, NameCountry = "Comoros", predvolba = 269 };
            Predvolby p51 = new Predvolby() { ID = 51, NameCountry = "Congo", predvolba = 242 };
            Predvolby p52 = new Predvolby() { ID = 52, NameCountry = "Congo (DRC)", predvolba = 243 };
            Predvolby p53 = new Predvolby() { ID = 53, NameCountry = "Cook Islands", predvolba = 682 };
            Predvolby p54 = new Predvolby() { ID = 54, NameCountry = "Costa Rica", predvolba = 506 };
            Predvolby p55 = new Predvolby() { ID = 55, NameCountry = "CĂ´te dâ€™Ivoire", predvolba = 225 };
            Predvolby p56 = new Predvolby() { ID = 56, NameCountry = "Croatia", predvolba = 385 };
            Predvolby p57 = new Predvolby() { ID = 57, NameCountry = "Cuba", predvolba = 53 };
            Predvolby p58 = new Predvolby() { ID = 58, NameCountry = "CuraĂ§ao", predvolba = 599 };
            Predvolby p59 = new Predvolby() { ID = 59, NameCountry = "Cyprus", predvolba = 357 };
            Predvolby p60 = new Predvolby() { ID = 60, NameCountry = "Czechia", predvolba = 420 };
            Predvolby p61 = new Predvolby() { ID = 61, NameCountry = "Denmark", predvolba = 45 };
            Predvolby p62 = new Predvolby() { ID = 62, NameCountry = "Djibouti", predvolba = 253 };
            Predvolby p63 = new Predvolby() { ID = 63, NameCountry = "Dominica", predvolba = 1 };
            Predvolby p64 = new Predvolby() { ID = 64, NameCountry = "Dominican Republic", predvolba = 1 };
            Predvolby p65 = new Predvolby() { ID = 65, NameCountry = "Ecuador", predvolba = 593 };
            Predvolby p66 = new Predvolby() { ID = 66, NameCountry = "Egypt", predvolba = 20 };
            Predvolby p67 = new Predvolby() { ID = 67, NameCountry = "El Salvador", predvolba = 503 };
            Predvolby p68 = new Predvolby() { ID = 68, NameCountry = "Equatorial Guinea", predvolba = 240 };
            Predvolby p69 = new Predvolby() { ID = 69, NameCountry = "Eritrea", predvolba = 291 };
            Predvolby p70 = new Predvolby() { ID = 70, NameCountry = "Estonia", predvolba = 372 };
            Predvolby p71 = new Predvolby() { ID = 71, NameCountry = "Ethiopia", predvolba = 251 };
            Predvolby p72 = new Predvolby() { ID = 72, NameCountry = "Europe", predvolba = 0 };
            Predvolby p73 = new Predvolby() { ID = 73, NameCountry = "Falkland Islands", predvolba = 500 };
            Predvolby p74 = new Predvolby() { ID = 74, NameCountry = "Faroe Islands", predvolba = 298 };
            Predvolby p75 = new Predvolby() { ID = 75, NameCountry = "Fiji", predvolba = 679 };
            Predvolby p76 = new Predvolby() { ID = 76, NameCountry = "Finland", predvolba = 358 };
            Predvolby p77 = new Predvolby() { ID = 77, NameCountry = "France", predvolba = 33 };
            Predvolby p78 = new Predvolby() { ID = 78, NameCountry = "French Guiana", predvolba = 594 };
            Predvolby p79 = new Predvolby() { ID = 79, NameCountry = "French Polynesia", predvolba = 689 };
            Predvolby p80 = new Predvolby() { ID = 80, NameCountry = "Gabon", predvolba = 241 };
            Predvolby p81 = new Predvolby() { ID = 81, NameCountry = "Gambia", predvolba = 220 };
            Predvolby p82 = new Predvolby() { ID = 82, NameCountry = "Georgia", predvolba = 995 };
            Predvolby p83 = new Predvolby() { ID = 83, NameCountry = "Germany", predvolba = 49 };
            Predvolby p84 = new Predvolby() { ID = 84, NameCountry = "Ghana", predvolba = 233 };
            Predvolby p85 = new Predvolby() { ID = 85, NameCountry = "Gibraltar", predvolba = 350 };
            Predvolby p86 = new Predvolby() { ID = 86, NameCountry = "Greece", predvolba = 30 };
            Predvolby p87 = new Predvolby() { ID = 87, NameCountry = "Greenland", predvolba = 299 };
            Predvolby p88 = new Predvolby() { ID = 88, NameCountry = "Grenada", predvolba = 1 };
            Predvolby p89 = new Predvolby() { ID = 89, NameCountry = "Guadeloupe", predvolba = 590 };
            Predvolby p90 = new Predvolby() { ID = 90, NameCountry = "Guam", predvolba = 1 };
            Predvolby p91 = new Predvolby() { ID = 91, NameCountry = "Guatemala", predvolba = 502 };
            Predvolby p92 = new Predvolby() { ID = 92, NameCountry = "Guernsey", predvolba = 44 };
            Predvolby p93 = new Predvolby() { ID = 93, NameCountry = "Guinea", predvolba = 224 };
            Predvolby p94 = new Predvolby() { ID = 94, NameCountry = "Guinea-Bissau", predvolba = 245 };
            Predvolby p95 = new Predvolby() { ID = 95, NameCountry = "Guyana", predvolba = 592 };
            Predvolby p96 = new Predvolby() { ID = 96, NameCountry = "Haiti", predvolba = 509 };
            Predvolby p97 = new Predvolby() { ID = 97, NameCountry = "Honduras", predvolba = 504 };
            Predvolby p98 = new Predvolby() { ID = 98, NameCountry = "Hong Kong SAR", predvolba = 852 };
            Predvolby p99 = new Predvolby() { ID = 99, NameCountry = "Hungary", predvolba = 36 };
            Predvolby p100 = new Predvolby() { ID = 100, NameCountry = "Iceland", predvolba = 354 };
            Predvolby p101 = new Predvolby() { ID = 101, NameCountry = "India", predvolba = 91 };
            Predvolby p102 = new Predvolby() { ID = 102, NameCountry = "Indonesia", predvolba = 62 };
            Predvolby p103 = new Predvolby() { ID = 103, NameCountry = "Iran", predvolba = 98 };
            Predvolby p104 = new Predvolby() { ID = 104, NameCountry = "Iraq", predvolba = 964 };
            Predvolby p105 = new Predvolby() { ID = 105, NameCountry = "Ireland", predvolba = 353 };
            Predvolby p106 = new Predvolby() { ID = 106, NameCountry = "Isle of Man", predvolba = 44 };
            Predvolby p107 = new Predvolby() { ID = 107, NameCountry = "Israel", predvolba = 972 };
            Predvolby p108 = new Predvolby() { ID = 108, NameCountry = "Italy", predvolba = 39 };
            Predvolby p109 = new Predvolby() { ID = 109, NameCountry = "Jamaica", predvolba = 1 };
            Predvolby p110 = new Predvolby() { ID = 110, NameCountry = "Japan", predvolba = 81 };
            Predvolby p111 = new Predvolby() { ID = 111, NameCountry = "Jersey", predvolba = 44 };
            Predvolby p112 = new Predvolby() { ID = 112, NameCountry = "Jordan", predvolba = 962 };
            Predvolby p113 = new Predvolby() { ID = 113, NameCountry = "Kazakhstan", predvolba = 7 };
            Predvolby p114 = new Predvolby() { ID = 114, NameCountry = "Kenya", predvolba = 254 };
            Predvolby p115 = new Predvolby() { ID = 115, NameCountry = "Kiribati", predvolba = 686 };
            Predvolby p116 = new Predvolby() { ID = 116, NameCountry = "Korea", predvolba = 82 };
            Predvolby p117 = new Predvolby() { ID = 117, NameCountry = "Kosovo", predvolba = 383 };
            Predvolby p118 = new Predvolby() { ID = 118, NameCountry = "Kuwait", predvolba = 965 };
            Predvolby p119 = new Predvolby() { ID = 119, NameCountry = "Kyrgyzstan", predvolba = 996 };
            Predvolby p120 = new Predvolby() { ID = 120, NameCountry = "Laos", predvolba = 856 };
            Predvolby p121 = new Predvolby() { ID = 121, NameCountry = "Latin America", predvolba = 0 };
            Predvolby p122 = new Predvolby() { ID = 122, NameCountry = "Latvia", predvolba = 371 };
            Predvolby p123 = new Predvolby() { ID = 123, NameCountry = "Lebanon", predvolba = 961 };
            Predvolby p124 = new Predvolby() { ID = 124, NameCountry = "Lesotho", predvolba = 266 };
            Predvolby p125 = new Predvolby() { ID = 125, NameCountry = "Liberia", predvolba = 231 };
            Predvolby p126 = new Predvolby() { ID = 126, NameCountry = "Libya", predvolba = 218 };
            Predvolby p127 = new Predvolby() { ID = 127, NameCountry = "Liechtenstein", predvolba = 423 };
            Predvolby p128 = new Predvolby() { ID = 128, NameCountry = "Lithuania", predvolba = 370 };
            Predvolby p129 = new Predvolby() { ID = 129, NameCountry = "Luxembourg", predvolba = 352 };
            Predvolby p130 = new Predvolby() { ID = 130, NameCountry = "Macao SAR", predvolba = 853 };
            Predvolby p131 = new Predvolby() { ID = 131, NameCountry = "Macedonia, FYRO", predvolba = 389 };
            Predvolby p132 = new Predvolby() { ID = 132, NameCountry = "Madagascar", predvolba = 261 };
            Predvolby p133 = new Predvolby() { ID = 133, NameCountry = "Malawi", predvolba = 265 };
            Predvolby p134 = new Predvolby() { ID = 134, NameCountry = "Malaysia", predvolba = 60 };
            Predvolby p135 = new Predvolby() { ID = 135, NameCountry = "Maldives", predvolba = 960 };
            Predvolby p136 = new Predvolby() { ID = 136, NameCountry = "Mali", predvolba = 223 };
            Predvolby p137 = new Predvolby() { ID = 137, NameCountry = "Malta", predvolba = 356 };
            Predvolby p138 = new Predvolby() { ID = 138, NameCountry = "Marshall Islands", predvolba = 692 };
            Predvolby p139 = new Predvolby() { ID = 139, NameCountry = "Martinique", predvolba = 596 };
            Predvolby p140 = new Predvolby() { ID = 140, NameCountry = "Mauritania", predvolba = 222 };
            Predvolby p141 = new Predvolby() { ID = 141, NameCountry = "Mauritius", predvolba = 230 };
            Predvolby p142 = new Predvolby() { ID = 142, NameCountry = "Mayotte", predvolba = 262 };
            Predvolby p143 = new Predvolby() { ID = 143, NameCountry = "Mexico", predvolba = 52 };
            Predvolby p144 = new Predvolby() { ID = 144, NameCountry = "Micronesia", predvolba = 691 };
            Predvolby p145 = new Predvolby() { ID = 145, NameCountry = "Moldova", predvolba = 373 };
            Predvolby p146 = new Predvolby() { ID = 146, NameCountry = "Monaco", predvolba = 377 };
            Predvolby p147 = new Predvolby() { ID = 147, NameCountry = "Mongolia", predvolba = 976 };
            Predvolby p148 = new Predvolby() { ID = 148, NameCountry = "Montenegro", predvolba = 382 };
            Predvolby p149 = new Predvolby() { ID = 149, NameCountry = "Montserrat", predvolba = 1 };
            Predvolby p150 = new Predvolby() { ID = 150, NameCountry = "Morocco", predvolba = 212 };
            Predvolby p151 = new Predvolby() { ID = 151, NameCountry = "Mozambique", predvolba = 258 };
            Predvolby p152 = new Predvolby() { ID = 152, NameCountry = "Myanmar", predvolba = 95 };
            Predvolby p153 = new Predvolby() { ID = 153, NameCountry = "Namibia", predvolba = 264 };
            Predvolby p154 = new Predvolby() { ID = 154, NameCountry = "Nauru", predvolba = 674 };
            Predvolby p155 = new Predvolby() { ID = 155, NameCountry = "Nepal", predvolba = 977 };
            Predvolby p156 = new Predvolby() { ID = 156, NameCountry = "Netherlands", predvolba = 31 };
            Predvolby p157 = new Predvolby() { ID = 157, NameCountry = "New Caledonia", predvolba = 687 };
            Predvolby p158 = new Predvolby() { ID = 158, NameCountry = "New Zealand", predvolba = 64 };
            Predvolby p159 = new Predvolby() { ID = 159, NameCountry = "Nicaragua", predvolba = 505 };
            Predvolby p160 = new Predvolby() { ID = 160, NameCountry = "Niger", predvolba = 227 };
            Predvolby p161 = new Predvolby() { ID = 161, NameCountry = "Nigeria", predvolba = 234 };
            Predvolby p162 = new Predvolby() { ID = 162, NameCountry = "Niue", predvolba = 683 };
            Predvolby p163 = new Predvolby() { ID = 163, NameCountry = "Norfolk Island", predvolba = 672 };
            Predvolby p164 = new Predvolby() { ID = 164, NameCountry = "North Korea", predvolba = 850 };
            Predvolby p165 = new Predvolby() { ID = 165, NameCountry = "Northern Mariana Islands", predvolba = 1 };
            Predvolby p166 = new Predvolby() { ID = 166, NameCountry = "Norway", predvolba = 47 };
            Predvolby p167 = new Predvolby() { ID = 167, NameCountry = "Oman", predvolba = 968 };
            Predvolby p168 = new Predvolby() { ID = 168, NameCountry = "Pakistan", predvolba = 92 };
            Predvolby p169 = new Predvolby() { ID = 169, NameCountry = "Palau", predvolba = 680 };
            Predvolby p170 = new Predvolby() { ID = 170, NameCountry = "Palestinian Authority", predvolba = 970 };
            Predvolby p171 = new Predvolby() { ID = 171, NameCountry = "Panama", predvolba = 507 };
            Predvolby p172 = new Predvolby() { ID = 172, NameCountry = "Papua New Guinea", predvolba = 675 };
            Predvolby p173 = new Predvolby() { ID = 173, NameCountry = "Paraguay", predvolba = 595 };
            Predvolby p174 = new Predvolby() { ID = 174, NameCountry = "Peru", predvolba = 51 };
            Predvolby p175 = new Predvolby() { ID = 175, NameCountry = "Philippines", predvolba = 63 };
            Predvolby p176 = new Predvolby() { ID = 176, NameCountry = "Pitcairn Islands", predvolba = 0 };
            Predvolby p177 = new Predvolby() { ID = 177, NameCountry = "Poland", predvolba = 48 };
            Predvolby p178 = new Predvolby() { ID = 178, NameCountry = "Portugal", predvolba = 351 };
            Predvolby p179 = new Predvolby() { ID = 179, NameCountry = "Puerto Rico", predvolba = 1 };
            Predvolby p180 = new Predvolby() { ID = 180, NameCountry = "Qatar", predvolba = 974 };
            Predvolby p181 = new Predvolby() { ID = 181, NameCountry = "RĂ©union", predvolba = 262 };
            Predvolby p182 = new Predvolby() { ID = 182, NameCountry = "Romania", predvolba = 40 };
            Predvolby p183 = new Predvolby() { ID = 183, NameCountry = "Russia", predvolba = 7 };
            Predvolby p184 = new Predvolby() { ID = 184, NameCountry = "Rwanda", predvolba = 250 };
            Predvolby p185 = new Predvolby() { ID = 185, NameCountry = "Saint BarthĂ©lemy", predvolba = 590 };
            Predvolby p186 = new Predvolby() { ID = 186, NameCountry = "Saint Kitts and Nevis", predvolba = 1 };
            Predvolby p187 = new Predvolby() { ID = 187, NameCountry = "Saint Lucia", predvolba = 1 };
            Predvolby p188 = new Predvolby() { ID = 188, NameCountry = "Saint Martin", predvolba = 590 };
            Predvolby p189 = new Predvolby() { ID = 189, NameCountry = "Saint Pierre and Miquelon", predvolba = 508 };
            Predvolby p190 = new Predvolby() { ID = 190, NameCountry = "Saint Vincent and the Grenadines", predvolba = 1 };
            Predvolby p191 = new Predvolby() { ID = 191, NameCountry = "Samoa", predvolba = 685 };
            Predvolby p192 = new Predvolby() { ID = 192, NameCountry = "San Marino", predvolba = 378 };
            Predvolby p193 = new Predvolby() { ID = 193, NameCountry = "SĂŁo TomĂ© and PrĂ­ncipe", predvolba = 239 };
            Predvolby p194 = new Predvolby() { ID = 194, NameCountry = "Saudi Arabia", predvolba = 966 };
            Predvolby p195 = new Predvolby() { ID = 195, NameCountry = "Senegal", predvolba = 221 };
            Predvolby p196 = new Predvolby() { ID = 196, NameCountry = "Serbia", predvolba = 381 };
            Predvolby p197 = new Predvolby() { ID = 197, NameCountry = "Seychelles", predvolba = 248 };
            Predvolby p198 = new Predvolby() { ID = 198, NameCountry = "Sierra Leone", predvolba = 232 };
            Predvolby p199 = new Predvolby() { ID = 199, NameCountry = "Singapore", predvolba = 65 };
            Predvolby p200 = new Predvolby() { ID = 200, NameCountry = "Sint Maarten", predvolba = 1 };
            Predvolby p201 = new Predvolby() { ID = 201, NameCountry = "Slovakia", predvolba = 421 };
            Predvolby p202 = new Predvolby() { ID = 202, NameCountry = "Slovenia", predvolba = 386 };
            Predvolby p203 = new Predvolby() { ID = 203, NameCountry = "Solomon Islands", predvolba = 677 };
            Predvolby p204 = new Predvolby() { ID = 204, NameCountry = "Somalia", predvolba = 252 };
            Predvolby p205 = new Predvolby() { ID = 205, NameCountry = "South Africa", predvolba = 27 };
            Predvolby p206 = new Predvolby() { ID = 206, NameCountry = "South Sudan", predvolba = 211 };
            Predvolby p207 = new Predvolby() { ID = 207, NameCountry = "Spain", predvolba = 34 };
            Predvolby p208 = new Predvolby() { ID = 208, NameCountry = "Sri Lanka", predvolba = 94 };
            Predvolby p209 = new Predvolby() { ID = 209, NameCountry = "St Helena, Ascension, Tristan da Cunha", predvolba = 290 };
            Predvolby p210 = new Predvolby() { ID = 210, NameCountry = "Sudan", predvolba = 249 };
            Predvolby p211 = new Predvolby() { ID = 211, NameCountry = "Suriname", predvolba = 597 };
            Predvolby p212 = new Predvolby() { ID = 212, NameCountry = "Svalbard and Jan Mayen", predvolba = 47 };
            Predvolby p213 = new Predvolby() { ID = 213, NameCountry = "Swaziland", predvolba = 268 };
            Predvolby p214 = new Predvolby() { ID = 214, NameCountry = "Sweden", predvolba = 46 };
            Predvolby p215 = new Predvolby() { ID = 215, NameCountry = "Switzerland", predvolba = 41 };
            Predvolby p216 = new Predvolby() { ID = 216, NameCountry = "Syria", predvolba = 963 };
            Predvolby p217 = new Predvolby() { ID = 217, NameCountry = "Taiwan", predvolba = 886 };
            Predvolby p218 = new Predvolby() { ID = 218, NameCountry = "Tajikistan", predvolba = 992 };
            Predvolby p219 = new Predvolby() { ID = 219, NameCountry = "Tanzania", predvolba = 255 };
            Predvolby p220 = new Predvolby() { ID = 220, NameCountry = "Thailand", predvolba = 66 };
            Predvolby p221 = new Predvolby() { ID = 221, NameCountry = "Timor-Leste", predvolba = 670 };
            Predvolby p222 = new Predvolby() { ID = 222, NameCountry = "Togo", predvolba = 228 };
            Predvolby p223 = new Predvolby() { ID = 223, NameCountry = "Tokelau", predvolba = 690 };
            Predvolby p224 = new Predvolby() { ID = 224, NameCountry = "Tonga", predvolba = 676 };
            Predvolby p225 = new Predvolby() { ID = 225, NameCountry = "Trinidad and Tobago", predvolba = 1 };
            Predvolby p226 = new Predvolby() { ID = 226, NameCountry = "Tunisia", predvolba = 216 };
            Predvolby p227 = new Predvolby() { ID = 227, NameCountry = "Turkey", predvolba = 90 };
            Predvolby p228 = new Predvolby() { ID = 228, NameCountry = "Turkmenistan", predvolba = 993 };
            Predvolby p229 = new Predvolby() { ID = 229, NameCountry = "Turks and Caicos Islands", predvolba = 1 };
            Predvolby p230 = new Predvolby() { ID = 230, NameCountry = "Tuvalu", predvolba = 688 };
            Predvolby p231 = new Predvolby() { ID = 231, NameCountry = "U.S. Outlying Islands", predvolba = 0 };
            Predvolby p232 = new Predvolby() { ID = 232, NameCountry = "U.S. Virgin Islands", predvolba = 1 };
            Predvolby p233 = new Predvolby() { ID = 233, NameCountry = "Uganda", predvolba = 256 };
            Predvolby p234 = new Predvolby() { ID = 234, NameCountry = "Ukraine", predvolba = 380 };
            Predvolby p235 = new Predvolby() { ID = 235, NameCountry = "United Arab Emirates", predvolba = 971 };
            Predvolby p236 = new Predvolby() { ID = 236, NameCountry = "United Kingdom", predvolba = 44 };
            Predvolby p237 = new Predvolby() { ID = 237, NameCountry = "United States", predvolba = 1 };
            Predvolby p238 = new Predvolby() { ID = 238, NameCountry = "Uruguay", predvolba = 598 };
            Predvolby p239 = new Predvolby() { ID = 239, NameCountry = "Uzbekistan", predvolba = 998 };
            Predvolby p240 = new Predvolby() { ID = 240, NameCountry = "Vanuatu", predvolba = 678 };
            Predvolby p241 = new Predvolby() { ID = 241, NameCountry = "Vatican City", predvolba = 39 };
            Predvolby p242 = new Predvolby() { ID = 242, NameCountry = "Venezuela", predvolba = 58 };
            Predvolby p243 = new Predvolby() { ID = 243, NameCountry = "Vietnam", predvolba = 84 };
            Predvolby p244 = new Predvolby() { ID = 244, NameCountry = "Wallis and Futuna", predvolba = 681 };
            Predvolby p245 = new Predvolby() { ID = 245, NameCountry = "World", predvolba = 0 };
            Predvolby p246 = new Predvolby() { ID = 246, NameCountry = "Yemen", predvolba = 967 };
            Predvolby p247 = new Predvolby() { ID = 247, NameCountry = "Zambia", predvolba = 260 };
            Predvolby p248 = new Predvolby() { ID = 248, NameCountry = "Zimbabwe", predvolba = 263 };

            predvolbies.Add(p1);
            predvolbies.Add(p2);
            predvolbies.Add(p3);
            predvolbies.Add(p4);
            predvolbies.Add(p5);
            predvolbies.Add(p6);
            predvolbies.Add(p7);
            predvolbies.Add(p8);
            predvolbies.Add(p9);
            predvolbies.Add(p10);
            predvolbies.Add(p11);
            predvolbies.Add(p12);
            predvolbies.Add(p13);
            predvolbies.Add(p14);
            predvolbies.Add(p15);
            predvolbies.Add(p16);
            predvolbies.Add(p17);
            predvolbies.Add(p18);
            predvolbies.Add(p19);
            predvolbies.Add(p20);
            predvolbies.Add(p21);
            predvolbies.Add(p22);
            predvolbies.Add(p23);
            predvolbies.Add(p24);
            predvolbies.Add(p25);
            predvolbies.Add(p26);
            predvolbies.Add(p27);
            predvolbies.Add(p28);
            predvolbies.Add(p29);
            predvolbies.Add(p30);
            predvolbies.Add(p31);
            predvolbies.Add(p32);
            predvolbies.Add(p33);
            predvolbies.Add(p34);
            predvolbies.Add(p35);
            predvolbies.Add(p36);
            predvolbies.Add(p37);
            predvolbies.Add(p38);
            predvolbies.Add(p39);
            predvolbies.Add(p40);
            predvolbies.Add(p41);
            predvolbies.Add(p42);
            predvolbies.Add(p43);
            predvolbies.Add(p44);
            predvolbies.Add(p45);
            predvolbies.Add(p46);
            predvolbies.Add(p47);
            predvolbies.Add(p48);
            predvolbies.Add(p49);
            predvolbies.Add(p50);
            predvolbies.Add(p51);
            predvolbies.Add(p52);
            predvolbies.Add(p53);
            predvolbies.Add(p54);
            predvolbies.Add(p55);
            predvolbies.Add(p56);
            predvolbies.Add(p57);
            predvolbies.Add(p58);
            predvolbies.Add(p59);
            predvolbies.Add(p60);
            predvolbies.Add(p61);
            predvolbies.Add(p62);
            predvolbies.Add(p63);
            predvolbies.Add(p64);
            predvolbies.Add(p65);
            predvolbies.Add(p66);
            predvolbies.Add(p67);
            predvolbies.Add(p68);
            predvolbies.Add(p69);
            predvolbies.Add(p70);
            predvolbies.Add(p71);
            predvolbies.Add(p72);
            predvolbies.Add(p73);
            predvolbies.Add(p74);
            predvolbies.Add(p75);
            predvolbies.Add(p76);
            predvolbies.Add(p77);
            predvolbies.Add(p78);
            predvolbies.Add(p79);
            predvolbies.Add(p80);
            predvolbies.Add(p81);
            predvolbies.Add(p82);
            predvolbies.Add(p83);
            predvolbies.Add(p84);
            predvolbies.Add(p85);
            predvolbies.Add(p86);
            predvolbies.Add(p87);
            predvolbies.Add(p88);
            predvolbies.Add(p89);
            predvolbies.Add(p90);
            predvolbies.Add(p91);
            predvolbies.Add(p92);
            predvolbies.Add(p93);
            predvolbies.Add(p94);
            predvolbies.Add(p95);
            predvolbies.Add(p96);
            predvolbies.Add(p97);
            predvolbies.Add(p98);
            predvolbies.Add(p99);
            predvolbies.Add(p100);
            predvolbies.Add(p101);
            predvolbies.Add(p102);
            predvolbies.Add(p103);
            predvolbies.Add(p104);
            predvolbies.Add(p105);
            predvolbies.Add(p106);
            predvolbies.Add(p107);
            predvolbies.Add(p108);
            predvolbies.Add(p109);
            predvolbies.Add(p110);
            predvolbies.Add(p111);
            predvolbies.Add(p112);
            predvolbies.Add(p113);
            predvolbies.Add(p114);
            predvolbies.Add(p115);
            predvolbies.Add(p116);
            predvolbies.Add(p117);
            predvolbies.Add(p118);
            predvolbies.Add(p119);
            predvolbies.Add(p120);
            predvolbies.Add(p121);
            predvolbies.Add(p122);
            predvolbies.Add(p123);
            predvolbies.Add(p124);
            predvolbies.Add(p125);
            predvolbies.Add(p126);
            predvolbies.Add(p127);
            predvolbies.Add(p128);
            predvolbies.Add(p129);
            predvolbies.Add(p130);
            predvolbies.Add(p131);
            predvolbies.Add(p132);
            predvolbies.Add(p133);
            predvolbies.Add(p134);
            predvolbies.Add(p135);
            predvolbies.Add(p136);
            predvolbies.Add(p137);
            predvolbies.Add(p138);
            predvolbies.Add(p139);
            predvolbies.Add(p140);
            predvolbies.Add(p141);
            predvolbies.Add(p142);
            predvolbies.Add(p143);
            predvolbies.Add(p144);
            predvolbies.Add(p145);
            predvolbies.Add(p146);
            predvolbies.Add(p147);
            predvolbies.Add(p148);
            predvolbies.Add(p149);
            predvolbies.Add(p150);
            predvolbies.Add(p151);
            predvolbies.Add(p152);
            predvolbies.Add(p153);
            predvolbies.Add(p154);
            predvolbies.Add(p155);
            predvolbies.Add(p156);
            predvolbies.Add(p157);
            predvolbies.Add(p158);
            predvolbies.Add(p159);
            predvolbies.Add(p160);
            predvolbies.Add(p161);
            predvolbies.Add(p162);
            predvolbies.Add(p163);
            predvolbies.Add(p164);
            predvolbies.Add(p165);
            predvolbies.Add(p166);
            predvolbies.Add(p167);
            predvolbies.Add(p168);
            predvolbies.Add(p169);
            predvolbies.Add(p170);
            predvolbies.Add(p171);
            predvolbies.Add(p172);
            predvolbies.Add(p173);
            predvolbies.Add(p174);
            predvolbies.Add(p175);
            predvolbies.Add(p176);
            predvolbies.Add(p177);
            predvolbies.Add(p178);
            predvolbies.Add(p179);
            predvolbies.Add(p180);
            predvolbies.Add(p181);
            predvolbies.Add(p182);
            predvolbies.Add(p183);
            predvolbies.Add(p184);
            predvolbies.Add(p185);
            predvolbies.Add(p186);
            predvolbies.Add(p187);
            predvolbies.Add(p188);
            predvolbies.Add(p189);
            predvolbies.Add(p190);
            predvolbies.Add(p191);
            predvolbies.Add(p192);
            predvolbies.Add(p193);
            predvolbies.Add(p194);
            predvolbies.Add(p195);
            predvolbies.Add(p196);
            predvolbies.Add(p197);
            predvolbies.Add(p198);
            predvolbies.Add(p199);
            predvolbies.Add(p200);
            predvolbies.Add(p201);
            predvolbies.Add(p202);
            predvolbies.Add(p203);
            predvolbies.Add(p204);
            predvolbies.Add(p205);
            predvolbies.Add(p206);
            predvolbies.Add(p207);
            predvolbies.Add(p208);
            predvolbies.Add(p209);
            predvolbies.Add(p210);
            predvolbies.Add(p211);
            predvolbies.Add(p212);
            predvolbies.Add(p213);
            predvolbies.Add(p214);
            predvolbies.Add(p215);
            predvolbies.Add(p216);
            predvolbies.Add(p217);
            predvolbies.Add(p218);
            predvolbies.Add(p219);
            predvolbies.Add(p220);
            predvolbies.Add(p221);
            predvolbies.Add(p222);
            predvolbies.Add(p223);
            predvolbies.Add(p224);
            predvolbies.Add(p225);
            predvolbies.Add(p226);
            predvolbies.Add(p227);
            predvolbies.Add(p228);
            predvolbies.Add(p229);
            predvolbies.Add(p230);
            predvolbies.Add(p231);
            predvolbies.Add(p232);
            predvolbies.Add(p233);
            predvolbies.Add(p234);
            predvolbies.Add(p235);
            predvolbies.Add(p236);
            predvolbies.Add(p237);
            predvolbies.Add(p238);
            predvolbies.Add(p239);
            predvolbies.Add(p240);
            predvolbies.Add(p241);
            predvolbies.Add(p242);
            predvolbies.Add(p243);
            predvolbies.Add(p244);
            predvolbies.Add(p245);
            predvolbies.Add(p246);
            predvolbies.Add(p247);
            predvolbies.Add(p248);
            return predvolbies;
        }


    }
}
